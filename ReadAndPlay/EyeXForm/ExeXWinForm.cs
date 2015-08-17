using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LookAndPlayForm.BackupClass;
using LookAndPlayForm.InstitutionID;
using LookAndPlayForm.Varios;
using Newtonsoft.Json;
using Tobii.Gaze.Core;
using WobbrockLib.Devices;


namespace LookAndPlayForm
{


    public partial class EyeXWinForm : Form
    {        
        private readonly EyeTrackingEngine eyeTrackingEngine;
        private MouseController CursorControl = new MouseController();
        private EyeTracking.distanceDev2User distanciaDev2USer;
        private delegate void Action();

        public bool closeApp { get; set; }




        
        
        
        
        public EyeXWinForm(EyeTrackingEngine eyeTrackingEngine)
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); 

            closeApp = true;

            this.eyeTrackingEngine = eyeTrackingEngine;
            eyeTrackingEngine.GazePoint += this.GazePoint;
            eyeTrackingEngine.OnGetCalibrationCompletedEvent += this.OnGetCalibrationCompleted;

            eyeTrackingEngine.Initialize();

            Program.datosCompartidos.LogEyeTrackerData = new LogEyeTracker.LogEyeTracker();
            Program.datosCompartidos.logTestData = new LogTest();

            distanciaDev2USer = new EyeTracking.distanceDev2User();
        }
        
        

        //eventos del engine
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
                    distance2Controls(distanciaDev2USer.distance(gazePointEventArgs.GazeDataReceived));
                    Invalidate();
                }));

            //if (saveEyeTrackerData)
            //{
            //    //Creo que ni gazeWeighted ni cursorFiltered se usan
            //    PointD gazeWeighted = eyetrackingFunctions.WeighGaze(gazePointEventArgs.GazeDataReceived);// creo que no se usa
            //    PointD cursorFiltered = CursorControl.filterData(gazeWeighted, false);// creo que no se usa los datos filtrados
                
            //    Program.datosCompartidos.LogEyeTrackerData.AddGazeDataItem2List(gazePointEventArgs.GazeDataReceived, gazeWeighted, cursorFiltered);                
            //}
        }

        private void OnGetCalibrationCompleted(object sender, CalibrationReadyEventArgs e)
        {
            toolStripStatusLabelCalibration.Text =
                "Last calibration value. Left: " +
                Program.datosCompartidos.meanCalibrationErrorLeftPx.ToString() +
                ". Right: " +
                Program.datosCompartidos.meanCalibrationErrorRightPx.ToString();
        }




        //botones
        private void buttonNewTest_Click(object sender, EventArgs e)
        {
            if (eyeTrackingEngine.State == EyeTrackingState.Tracking)
            {
                if(!eyeTrackerCalibrated())
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to continue? The data will not be accurate if the eye-tracker is not calibrated", "The eye-tracker probably is not calibrated", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                        return;
                }

                if (!goodCalibration())
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to continue? The data will not be accurate if the calibration is less than 50 for both eyes", "Poor calibration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                        return;
                }

                Program.datosCompartidos.getNewTime();
                unHookEvents();

                closeApp = false;
                this.Hide();
                
            }
            else
                messageEyetrackerNotConnected();
        }

        private bool goodCalibration()
        {
            if (Program.datosCompartidos.meanCalibrationErrorLeftPx < 50 && Program.datosCompartidos.meanCalibrationErrorRightPx < 50)
                return true;
            else
                return false;
        }

        private bool eyeTrackerCalibrated()
        {
            //si no esta calibrado aparece como -2147483648: son 8 cuartetos de 1's: 32 bits de 1's
            if (Program.datosCompartidos.meanCalibrationErrorLeftPx > 0 && Program.datosCompartidos.meanCalibrationErrorRightPx > 0)
            {
                return true;
            }
            else
                return false;
        }


        private void buttonCalibrate_Click(object sender, EventArgs e)
        {
            if (Program.eyeTrackingEngine.State == EyeTrackingState.Tracking)
            {
                CalibrationWinForm calibrationForm = new CalibrationWinForm(eyeTrackingEngine);
                calibrationForm.ShowDialog();
                calibrationForm.Dispose();
                calibrationForm = null;
            }
            else
                messageEyetrackerNotConnected();
        }
        





        //varios
        private void distance2Controls(double distance)
        {
            if (double.IsNaN(distance))
            {
                //contador de nan ++ 
            }
            else if (distance > 10 && distance < 90)
            {
                progressBar4Distance.Value = Convert.ToInt32(distance);
                labelDistance.Text = "Distance OK";
                labelDistance.ForeColor = System.Drawing.Color.Black;
            }
            else if (distance < 10)
            {
                labelDistance.Text = "You're close to eyetracker";
                labelDistance.ForeColor = System.Drawing.Color.Red;
            }
            else if (distance > 90)
            {
                labelDistance.Text = "You're far from eye-tracker";
                labelDistance.ForeColor = System.Drawing.Color.Red;
            }


        }        
        
        private void messageEyetrackerNotConnected()
        {
            MessageBox.Show("Eye tracker not connected. Please connect the tracker and re-star the App.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void unHookEvents()
        {
            eyeTrackingEngine.GazePoint -= this.GazePoint;
            eyeTrackingEngine.OnGetCalibrationCompletedEvent -= this.OnGetCalibrationCompleted;
        }        
        
        
        
        
        
        
        
        private void EyeXWinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            unHookEvents();
        }        
    }
}
