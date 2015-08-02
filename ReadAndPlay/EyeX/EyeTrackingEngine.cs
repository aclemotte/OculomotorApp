using System;
using System.Collections.Generic;
using System.Threading;
using Tobii.Gaze.Core;

namespace LookAndPlayForm
{

    public enum EyeTrackingState
    {
        NotInitialized,
        EyeTrackerNotFound,
        Connecting,
        StartingTracking,
        ConnectionFailed,
        Error,
        Tracking,
        //
        Calibration,
        ComputingCalibration,
        CalibrationFailed,
        
    }

    /// <summary>
    /// The eyetracking engine provides gaze data from the currently setup eyetracker.
    /// It reads and validates the current eye tracker configuration,
    /// connects to and prepares the eye tracker for eyetracking and then
    /// provides gaze data until the eye tracker is disconnected or eyetracking engine is disposed. 
    /// </summary>
    public sealed class EyeTrackingEngine : IDisposable
    {
        public EventHandler<EyeTrackingStateChangedEventArgs> StateChanged;
        public EventHandler<GazePointEventArgs> GazePoint;
        public event EventHandler onAddCalibrationPointCompletedEvent;
        public event EventHandler onStartCalibrationCompletedEvent;
        public event EventHandler onComputeandSetCalibrationCompletedEvent;
        public event EventHandler<CalibrationReadyEventArgs> OnGetCalibrationCompletedEvent;


        private static readonly Dictionary<EyeTrackingState, string> ErrorMessages = new Dictionary<EyeTrackingState, string>
        {
            { EyeTrackingState.EyeTrackerNotFound, "No eye tracker could be found." },
            { EyeTrackingState.ConnectionFailed, "The connection to the eye tracker failed." },
            { EyeTrackingState.Error, "The eye tracker reported an error." },
        };

        private EyeTrackingState _state = EyeTrackingState.NotInitialized;
        private Uri _eyeTrackerUrl;
        private IEyeTracker _eyeTracker;
        private Thread _thread;

        private eyesDetector detectorDeOjos;
        
        /// <summary>
        /// Create eye tracking engine 
        /// Throws EyeTrackerException if not successful
        /// </summary>
        public EyeTrackingEngine()
        {
            detectorDeOjos = new eyesDetector();            
        }

        public EyeTrackingState State
        {
            get
            {
                return _state;
            }

            private set
            {
                if (_state != value)
                {
                    _state = value;
                    RaiseStateChanged();
                }
            }
        }

        /// <summary>
        /// Stop eye tracking and dispose eye tracking engine and Tobii EyeTracking
        /// </summary>
        public void Dispose()
        {
            Reset();
        }

        /// <summary>
        /// Initialize the eye tracker engine.
        /// State changes are notified to the client with the StateChanged event handler. 
        /// </summary>
        public void Initialize()
        {
            if (State != EyeTrackingState.NotInitialized)
            {
                throw new InvalidOperationException("EyeTrackingEngine can not be initialized when not in state NotInitialized");
            }

            InitializeEyeTrackerAndRunEventLoop();
        }

        /// <summary>
        ///  Retry to Initialize eye tracker engine. Should be called when user has manually
        /// changed the configuration or performed a calibration with the Tobii EyeTracking Control Panel.
        /// </summary>
        public void Retry()
        {
            Reset();
            Initialize();
        }

        public void requestStartCalibration()
        {
            _eyeTracker.StartCalibrationAsync(OnStartCalibrationCompleted);
        }

        public void AddCalibrationPoint(Point2D CalibrationDotPosition)
        {
            _eyeTracker.AddCalibrationPointAsync(CalibrationDotPosition, OnAddCalibrationPointCompleted);
        }

        public void ComputeAndSetCalibration()
        {
            State = EyeTrackingState.ComputingCalibration;
            _eyeTracker.ComputeAndSetCalibrationAsync(OnComputeAndSetCalibrationCompleted);
        }






        private bool CanRetry
        {
            get
            {
                return State == EyeTrackingState.EyeTrackerNotFound ||
                    State == EyeTrackingState.ConnectionFailed ||
                    State == EyeTrackingState.Error;
            }
        }

        private string ErrorMessage
        {
            get { return ErrorMessages.ContainsKey(State) ? ErrorMessages[State] : string.Empty; }
        }

        private void InitializeEyeTrackerAndRunEventLoop()
        {
            if (State != EyeTrackingState.NotInitialized)
            {
                throw new InvalidOperationException("Can not initialize eye tracker and run event loop when not in state NotInitialized");
            }

            try
            {
                _eyeTrackerUrl = new EyeTrackerCoreLibrary().GetConnectedEyeTracker();
                if (_eyeTrackerUrl == null)
                {
                    State = EyeTrackingState.EyeTrackerNotFound;
                    return;
                }
            }
            catch (EyeTrackerException ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                State = EyeTrackingState.Error;
                return;
            }

            try
            {
                _eyeTracker = new EyeTracker(_eyeTrackerUrl);
                _eyeTracker.EyeTrackerError += OnEyeTrackerError;
                _eyeTracker.GazeData += OnGazeData;

                CreateAndRunEventLoopThread();

                _eyeTracker.ConnectAsync(OnConnectFinished);

                State = EyeTrackingState.Connecting;
            }
            catch (EyeTrackerException ex)
            {
                State = EyeTrackingState.ConnectionFailed;
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        private void CreateAndRunEventLoopThread()
        {
            if (_thread != null)
            {
                throw new InvalidOperationException("_thread parameter is already set");
            }

            _thread = new Thread(() =>
            {
                try
                {
                    _eyeTracker.RunEventLoop();
                }
                catch (EyeTrackerException ex)
                {
                    State = EyeTrackingState.Error;
                    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                }
            });

            _thread.Start();
        }

        private void Reset()
        {
            if (_eyeTracker != null)
            {
                _eyeTracker.BreakEventLoop();
                if (_thread != null)
                {
                    _thread.Join();
                }

                _eyeTracker.EyeTrackerError -= OnEyeTrackerError;
                _eyeTracker.GazeData -= OnGazeData;
                _eyeTracker.Dispose();
                _eyeTracker = null;
            }

            if (_thread != null)
            {
                _thread.Abort();
                _thread = null;
            }

            State = EyeTrackingState.NotInitialized;
        }

        private void RaiseStateChanged()
        {
            var handler = StateChanged;

            if (handler != null)
            {
                handler(this, new EyeTrackingStateChangedEventArgs(State, ErrorMessage, CanRetry));
            }
        }

        private void RaiseGazePoint(GazeData GazeData)
        {
            var handler = GazePoint;
            if (handler != null)
            {
                handler(this, new GazePointEventArgs(GazeData));
            }
        }

        
        //Cuando tal cosa ...
        
        private void OnConnectFinished(ErrorCode errorCode)
        {
            if (errorCode != ErrorCode.Success)
            {
                State = EyeTrackingState.ConnectionFailed;
                return;
            }

            _eyeTracker.GetDeviceInfoAsync(OnDeviceInfoCompleted);
            _eyeTracker.GetCalibrationAsync(OnGetCalibrationCompleted);
            _eyeTracker.StartTrackingAsync(OnStartTrackingFinished);
        }

        private void OnDeviceInfoCompleted(DeviceInfo deviceInfo, Tobii.Gaze.Core.ErrorCode errorCode)
        {
            Program.datosCompartidos.EyeTrackerInfo = deviceInfo.Model;
        }

        private void OnGetCalibrationCompleted(Calibration calibration, Tobii.Gaze.Core.ErrorCode errorCode)
        {
            Program.datosCompartidos.calibrationDataEyeX = calibration;

            CalibrationError errorCalibracion = new CalibrationError(Program.datosCompartidos.calibrationDataEyeX.GetCalibrationPointDataItems());
            Program.datosCompartidos.meanCalibrationErrorLeftPx = errorCalibracion.meanCalibrationErrorLeftPx;
            Program.datosCompartidos.meanCalibrationErrorRightPx = errorCalibracion.meanCalibrationErrorRightPx;

            Console.WriteLine("EyetrackingEngine.OnGetCalibrationCompleted. errorCode: " + errorCode.ToString() + 
                "error: " +
                errorCalibracion.meanCalibrationErrorLeftPx.ToString() + ", " +
                errorCalibracion.meanCalibrationErrorRightPx.ToString());

            if (OnGetCalibrationCompletedEvent != null)
                OnGetCalibrationCompletedEvent(this, new CalibrationReadyEventArgs(errorCalibracion.CalibrationPointDataL));                       
        }

        private void OnStartCalibrationCompleted(ErrorCode errorCode)
        {
            Console.WriteLine("EyeTRackingEngine.OnStartCalibrationCompleted. errorCode: " + errorCode.ToString());

            if (errorCode != ErrorCode.Success)
            {
                //HandleError(Tobii.Gaze.Core.ErrorMessage.GetErrorMessage(errorCode));
                State = EyeTrackingState.CalibrationFailed;
                return;
            }
            else
            {
                State = EyeTrackingState.Calibration;
                if (onStartCalibrationCompletedEvent != null) onStartCalibrationCompletedEvent(this, EventArgs.Empty);
            }
        }

        private void OnAddCalibrationPointCompleted(ErrorCode errorCode)
        {
            Console.WriteLine("EyeTrackingEngine.OnAddCalibrationPointCompleted. errorCode: " + errorCode.ToString());

            if (errorCode != ErrorCode.Success)
            {
                return;
            }

            if (onAddCalibrationPointCompletedEvent != null) onAddCalibrationPointCompletedEvent(this, EventArgs.Empty);
        }

        private void OnComputeAndSetCalibrationCompleted(ErrorCode errorCode)
        {
            Console.WriteLine("EyeTrackingEngine.OnComputeAndSetCalibrationCompleted. errorCode: " + errorCode.ToString());

            if (errorCode != ErrorCode.Success)
            {
                if (errorCode == ErrorCode.FirmwareOperationFailed)
                {
                }

                //return;
            }

            if (onComputeandSetCalibrationCompletedEvent != null) 
                onComputeandSetCalibrationCompletedEvent(this, EventArgs.Empty);
            
            _eyeTracker.StopCalibrationAsync(OnStopCalibrationCompleted);
        }

        private void OnStopCalibrationCompleted(ErrorCode errorCode)
        {
            Console.WriteLine("EyeTrackingEngine.OnStopCalibrationCompleted. errorCode: " + errorCode.ToString());

            _eyeTracker.GetCalibrationAsync(OnGetCalibrationCompleted);

            if (errorCode != ErrorCode.Success)
            {
                return;
            }

            State = EyeTrackingState.Tracking;
        }

        private void OnStartTrackingFinished(ErrorCode errorCode)
        {
            if (errorCode != ErrorCode.Success)
            {
                State = EyeTrackingState.Error;
            }
            else
            {
                State = EyeTrackingState.Tracking;
            }
        }

        private void OnEyeTrackerError(object sender, EyeTrackerErrorEventArgs eyeTrackerErrorEventArgs)
        {
            Console.WriteLine("EyeTrackingEngine.OnEyeTrackerError. errorCode: " + eyeTrackerErrorEventArgs.ErrorCode.ToString());

            if (eyeTrackerErrorEventArgs.ErrorCode != ErrorCode.Success)
            {
                State = EyeTrackingState.ConnectionFailed;
            }
        }

        private void OnGazeData(object sender, GazeDataEventArgs gazeDataEventArgs)
        {
            var gazeData = gazeDataEventArgs.GazeData;

            detectorDeOjos.dataReceived(gazeData.TrackingStatus);

            RaiseGazePoint(gazeData);
        }


    }

    public class CalibrationReadyEventArgs: EventArgs
    {
        public CalibrationReadyEventArgs(List<myCalibrationPointData> CalibrationPointDataLTemp)
        {
            CalibrationPointDataL = CalibrationPointDataLTemp;
        }

        public List<myCalibrationPointData> CalibrationPointDataL;
    }

    public class GazePointEventArgs : EventArgs
    {
        public GazePointEventArgs(GazeData GazedataTemp)
        {
            GazeDataReceived = GazedataTemp;
        }

        public GazeData GazeDataReceived;
    }

    public class EyeTrackingStateChangedEventArgs : EventArgs
    {
        public EyeTrackingStateChangedEventArgs(EyeTrackingState eyeTrackingState, string errorMessage, bool canRetry)
        {
            EyeTrackingState = eyeTrackingState;
            ErrorMessage = errorMessage;
            CanRetry = canRetry;
        }

        /// <summary>
        /// Gets the EyeTrackingState.
        /// </summary>
        public EyeTrackingState EyeTrackingState { get; private set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Indicates if it's possible to retry the operation.
        /// </summary>
        public bool CanRetry { get; private set; }
    }
}
