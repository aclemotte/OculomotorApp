using System;
using System.Drawing;
using System.Windows.Forms;
using Tobii.Gaze.Core;
using WobbrockLib.Devices;


namespace LookAndPlayForm
{


    public partial class EyeXWinForm : Form
    {
        public readonly EyeTrackingEngine eyeTrackingEngine;
        private delegate void UpdateStateDelegate(EyeTrackingStateChangedEventArgs eyeTrackingStateChangedEventArgs);
        private bool ETcontrolCursor = false;
        private bool ETcontrolCursorInGame = false;        
        private bool GameStarted = false;
        private MouseController CursorControl = new MouseController();
        private Game1 _Game1;
        public sharedData datosCompartidos;
        private LowLevelKeyboardHook _llkhk;
        private Dwell clickDwell;

        public EyeXWinForm(EyeTrackingEngine eyeTrackingEngine)
        {
            InitializeComponent();

            this.eyeTrackingEngine = eyeTrackingEngine;
            eyeTrackingEngine.StateChanged += this.StateChanged;
            eyeTrackingEngine.GazePoint += this.GazePoint;
            eyeTrackingEngine.OnGetCalibrationCompletedEvent += this.OnGetCalibrationCompleted;

            eyeTrackingEngine.Initialize();

            this.datosCompartidos = LookAndPlayForm.Program.datosCompartidos;
            datosCompartidos.LogData = new LogEyeTracker();

            _llkhk = new LowLevelKeyboardHook("Low-level Keyboard Hook");
            _llkhk.OnKeyPress += new EventHandler<KeyPressEventArgs>(OnKeyboardHookPress);

            clickDwell = new Dwell(LookAndPlayForm.Program.datosCompartidos);

        }

        private delegate void Action();

        private void GazePoint(object sender, GazePointEventArgs gazePointEventArgs)
        {
            BeginInvoke(new Action(() =>
                {
                    var handle = Handle;
                    if (handle == null)
                    {
                        // window not created yet. never mind.
                        return;
                    }

                    _trackStatus.OnGazeData(gazePointEventArgs.GazeDataReceived);
                    _trackStatusControlMirada.OnGazeData(gazePointEventArgs.GazeDataReceived);
                    progressBar4Distance.Value = eyetrackingFunctions.distanceBetweenDev2User(gazePointEventArgs.GazeDataReceived);
                    Invalidate();
                }));

            if (GameStarted || ETcontrolCursor)
            {
                PointD cursorFiltered = new PointD();
                PointD gazeWeighted;
                gazeWeighted = eyetrackingFunctions.WeighGaze(gazePointEventArgs.GazeDataReceived);

                if (ETcontrolCursorInGame || ETcontrolCursor)
                    cursorFiltered = CursorControl.filterData(gazeWeighted, true);
                else
                    cursorFiltered = CursorControl.filterData(gazeWeighted, false);

                if (GameStarted)
                    this.datosCompartidos.LogData.AddGazeDataItem2List(gazePointEventArgs.GazeDataReceived, gazeWeighted, cursorFiltered);                
            }
        }

        private void StateChanged(object sender, EyeTrackingStateChangedEventArgs eyeTrackingStateChangedEventArgs)
        {
            // Forward state change to UI thread
            if (InvokeRequired)
            {
                var updateStateDelegate = new UpdateStateDelegate(UpdateState);
                Invoke(updateStateDelegate, new object[] { eyeTrackingStateChangedEventArgs });
            }
            else
            {
                UpdateState(eyeTrackingStateChangedEventArgs);
            }
        }

        private void UpdateState(EyeTrackingStateChangedEventArgs eyeTrackingStateChangedEventArgs)
        {
            if (!string.IsNullOrEmpty(eyeTrackingStateChangedEventArgs.ErrorMessage))
            {
                //ErrorMessagePanel.Visible = true;
                //ErrorMessage.Text = eyeTrackingStateChangedEventArgs.ErrorMessage;
                //Retry.Enabled = eyeTrackingStateChangedEventArgs.CanRetry;
                return;
            }

            //ErrorMessagePanel.Visible = false;

        }

        private void RetryClick(object sender, EventArgs e)
        {
            eyeTrackingEngine.Retry();
        }

        private void SuppressErrorMessageClick(object sender, EventArgs e)
        {
            //ErrorMessagePanel.Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                toogleGameStatus(true);                
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void toogleGameStatus(bool ETcontrolCursor)
        {
            GameStarted = !GameStarted;
            this.ETcontrolCursorInGame = ETcontrolCursor;
        }

        public void toogleGameStatus()
        {
            GameStarted = !GameStarted;            
        }

        //public void toogleControlCursor()
        //{
        //    ETcontrolCursor = !ETcontrolCursor;
        //}

        private void buttonGame1_Click(object sender, EventArgs e)
        {
            if (eyeTrackingEngine.State == EyeTrackingState.Tracking)//if (_TobiiForm.tobii_connected)            
            {
            }
            else
                MessageBox.Show("Tobii no conectado");


            _Game1 = new Game1(this);
            _Game1.Left = 0;//_TobiiForm.monitorBounds.X;
            _Game1.StartPosition = FormStartPosition.Manual;
            _Game1.Show();
        }
        	
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            eyeTrackingEngine.Dispose();
        }

        private void buttonViewCalibration_Click(object sender, EventArgs e)
        {
            var resultForm = new CalibrationResultForm();
            resultForm.SetPlotData(datosCompartidos.calibrationDataEyeX);
            resultForm.ShowDialog();
        }

        private void buttonResumen_Click(object sender, EventArgs e)
        {
            Resumen.Resumen resumenGame1 = new Resumen.Resumen();

            if (resumenGame1.everythingOk)
                resumenGame1.Show();
            else
                resumenGame1.Dispose();
        }

        private void buttonCalibrate_Click(object sender, EventArgs e)
        {
            CalibrationWinForm calibrationForm = new CalibrationWinForm(this, eyeTrackingEngine);
            this.AddOwnedForm(calibrationForm);
            calibrationForm.Show();
        }

        private void EyeXWinForm_Load(object sender, EventArgs e)
        {
            _llkhk.Install(); // keyboard
        }

        private void EyeXWinForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _llkhk.Uninstall();
        }

        private void toogleETcontrolCursor()
        {
            ETcontrolCursor = !ETcontrolCursor;
            
            if(ETcontrolCursor)
                clickDwell.startDwelling();

            if(!ETcontrolCursor)
                clickDwell.stopDwelling();
        }

        private void OnKeyboardHookPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'q':
                case 'Q':
                    toogleETcontrolCursor();
                    break;

            }
        }

        private void OnGetCalibrationCompleted(object sender, CalibrationReadyEventArgs e)
        {
            //textBoxCalibrationErrorLeft.BeginInvoke((Action)(() =>
            //{
            //    textBoxCalibrationErrorLeft.Text = LookAndPlayForm.Program.datosCompartidos.meanCalibrationErrorLeftPx.ToString();
            //}));

            //textBoxCalibrationErrorRight.BeginInvoke((Action)(() =>
            //{
            //    textBoxCalibrationErrorRight.Text = LookAndPlayForm.Program.datosCompartidos.meanCalibrationErrorRightPx.ToString();
            //}));

        }
    }
}
