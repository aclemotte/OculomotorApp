using System;
using System.Drawing;
using System.Windows.Forms;
using LookAndPlayForm.BackupClass;
using LookAndPlayForm.InstitutionID;
using LookAndPlayForm.Varios;
using Tobii.Gaze.Core;
using WobbrockLib.Devices;


namespace LookAndPlayForm
{


    public partial class EyeXWinForm : Form
    {
        public readonly EyeTrackingEngine eyeTrackingEngine;
        
        private bool testStarted = false;
        private MouseController CursorControl = new MouseController();
        private EyeTracking.distanceDev2User distanciaDev2USer;
        private institution_class_engine institution_engine;
        private delegate void Action();


        public EyeXWinForm(EyeTrackingEngine eyeTrackingEngine, institution_class_engine institution_engine)
        {
            InitializeComponent();

            this.institution_engine = institution_engine;

            this.eyeTrackingEngine = eyeTrackingEngine;
            eyeTrackingEngine.GazePoint += this.GazePoint;
            eyeTrackingEngine.OnGetCalibrationCompletedEvent += this.OnGetCalibrationCompleted;

            eyeTrackingEngine.Initialize();

            //this.datosCompartidos = LookAndPlayForm.Program.datosCompartidos;
            Program.datosCompartidos.LogData = new LogEyeTracker();

            distanciaDev2USer = new EyeTracking.distanceDev2User();
        }
        public bool se_grabaron_datos;

        



        //form
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
                    distance2Controls(distanciaDev2USer.distance(gazePointEventArgs.GazeDataReceived));
                    Invalidate();
                }));

            if (testStarted)
            {
                //Creo que ni gazeWeighted ni cursorFiltered se usan
                PointD gazeWeighted = eyetrackingFunctions.WeighGaze(gazePointEventArgs.GazeDataReceived);// creo que no se usa
                PointD cursorFiltered = CursorControl.filterData(gazeWeighted, false);// creo que no se usa
                
                Program.datosCompartidos.LogData.AddGazeDataItem2List(gazePointEventArgs.GazeDataReceived, gazeWeighted, cursorFiltered);                
            }
        }

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

        
        private void buttonNewTest_Click(object sender, EventArgs e)
        {
            if (eyeTrackingEngine.State == EyeTrackingState.Tracking)//if (_TobiiForm.tobii_connected)            
            {
                Program.datosCompartidos.getNewTime();

                if (Program.datosCompartidos.testSelected == SelectTest.FormSelectionTest.testType.reading)
                {
                    Game1 _Game1 = new Game1(this);
                    _Game1.FormClosed += Game1_Closed;
                    _Game1.Left = 0;//_TobiiForm.monitorBounds.X;
                    _Game1.StartPosition = FormStartPosition.Manual;
                    _Game1.Show();
                }
                else if (Program.datosCompartidos.testSelected == SelectTest.FormSelectionTest.testType.persuit)
                {
                    StimuloPersuitHorizontal.StimuloPersuit persuit = new StimuloPersuitHorizontal.StimuloPersuit();
                    persuit.Show();
                }

            }
            else
                MessageBox.Show("Eye tracker not connected");
        }
        	
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            eyeTrackingEngine.Dispose();
        }

        public void toogleTestStatus()
        {
            testStarted = !testStarted;
        }

        
        
        
        
        //resume
        private void buttonResumen_Click(object sender, EventArgs e)
        {
            openWindowResumen(false, true);
        }

        private void openWindowResumen(bool showLastTest, bool newTestAvailable)
        {
            Resumen.Resumen resumenGame1 = new Resumen.Resumen(showLastTest, newTestAvailable);
            resumenGame1.ReviewClosed += resumenGame1_ReviewClosed;
            if (resumenGame1.everythingOk)
                resumenGame1.Show();
            else
                resumenGame1.Dispose();
        }









        //game
        private void resumenGame1_ReviewClosed(bool newTest)
        {
            if (!newTest)
                this.Close();
        }


        private void Game1_Closed(object sender, FormClosedEventArgs e)
        {
            //Show the resume window
            if (se_grabaron_datos)
            {
                openWindowResumen(true, true);

                //subir los datos a la nube
                aws_class_data aws_data = new aws_class_data();
                aws_data.AwsS3FolderName = institution_engine.institutionsList[0].institution_name;
                aws_data.FileToUpload = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\" +
                                            Program.datosCompartidos.startTimeTest +
                                            @"-us" + Program.datosCompartidos.activeUser;

                aws_class_engine.BackupTest(aws_data);

                Program.datosCompartidos.number_of_screening_done++;
            }
        }
        




        //calibration
        private void buttonCalibrate_Click(object sender, EventArgs e)
        {
            //buttonCalibrate.Enabled = false;
            CalibrationWinForm calibrationForm = new CalibrationWinForm(eyeTrackingEngine);
            calibrationForm.ShowDialog();
        }
        
        private void OnGetCalibrationCompleted(object sender, CalibrationReadyEventArgs e)
        {
            toolStripStatusLabelCalibration.Text = 
                "Calibration value. Left: " + 
                Program.datosCompartidos.meanCalibrationErrorLeftPx.ToString() +
                ". Right: " +
                Program.datosCompartidos.meanCalibrationErrorRightPx.ToString();
        }

        private void buttonViewCalibration_Click(object sender, EventArgs e)
        {
            var resultForm = new CalibrationResultForm();
            resultForm.SetPlotData(Program.datosCompartidos.calibrationDataEyeX);
            resultForm.ShowDialog();
        }

    }
}
