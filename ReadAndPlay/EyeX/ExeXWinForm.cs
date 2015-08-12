﻿using System;
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
        //public bool se_grabaron_datos { get; set; }//para avisar a EyeXWinForm si se cancelo la tarea (cuando se pregunta Are you ready?)
        //private bool saveEyeTrackerData = false;
        
        private readonly EyeTrackingEngine eyeTrackingEngine;
        private MouseController CursorControl = new MouseController();
        private EyeTracking.distanceDev2User distanciaDev2USer;
        private delegate void Action();

        public bool closeApp { get; set; }




        
        
        
        
        public EyeXWinForm(EyeTrackingEngine eyeTrackingEngine)
        {
            InitializeComponent();

            closeApp = true;
            //this.institution_engine = institution_engine;

            this.eyeTrackingEngine = eyeTrackingEngine;
            eyeTrackingEngine.GazePoint += this.GazePoint;
            eyeTrackingEngine.OnGetCalibrationCompletedEvent += this.OnGetCalibrationCompleted;

            eyeTrackingEngine.Initialize();

            Program.datosCompartidos.LogEyeTrackerData = new LogEyeTracker.LogEyeTracker();
            Program.datosCompartidos.logTestData = new LogTest();

            distanciaDev2USer = new EyeTracking.distanceDev2User();
        }
        
        


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
            if (eyeTrackingEngine.State == EyeTrackingState.Tracking)       
            {
                Program.datosCompartidos.getNewTime();

                eyeTrackingEngine.GazePoint -= this.GazePoint;
                eyeTrackingEngine.OnGetCalibrationCompletedEvent -= this.OnGetCalibrationCompleted;

                closeApp = false;
                this.Hide();

                //if (Program.datosCompartidos.testSelected == testType.reading)
                //{
                //    Game1 _Game1 = new Game1(this);
                //    _Game1.FormClosed += test_Closed;
                //    _Game1.Left = 0;//_TobiiForm.monitorBounds.X;
                //    _Game1.StartPosition = FormStartPosition.Manual;
                //    _Game1.Show();
                //}
                //else if (Program.datosCompartidos.testSelected == testType.persuit)
                //{
                //    StimuloPersuitHorizontal.StimuloPersuit persuit = new StimuloPersuitHorizontal.StimuloPersuit(this);
                //    persuit.Show();
                //    persuit.FormClosed += test_Closed;
                //}

            }
            else
                MessageBox.Show("Eye tracker not connected", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        	
        //protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        //{
        //    base.OnClosing(e);
        //    eyeTrackingEngine.Dispose();
        //}

        //public void toogleSaveEyeTrackerDataValue()
        //{
        //    saveEyeTrackerData = !saveEyeTrackerData;
        //}

        
        
        
        
        //resume
        //private void buttonResumen_Click(object sender, EventArgs e)
        //{

        //    string selectedPath = selectionOfFolder();
        //    testType testType = checkTipoTest(selectedPath);

        //    if (testType == testType.reading)
        //    {
        //        openWindowReviewReading(false, true, selectedPath);
        //    }
        //    else if (testType == testType.persuit)
        //        openWindowReviewPersuit(false, selectedPath);
        //    else
        //        MessageBox.Show("Error. Test type not identified.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        //private string selectionOfFolder()
        //{
        //    FolderBrowserDialog fbd = new FolderBrowserDialog();
        //    fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";
        //    DialogResult result = fbd.ShowDialog();
        //    string selectedPath = fbd.SelectedPath;
        //    return selectedPath;
        //}

        //private string openTestDatajsonAndGetField(string path)
        //{
        //    TestData1 testData;
        //    string file = @"\testData.json";

        //    if (File.Exists(path + file))
        //    {
        //        string json = File.ReadAllText(path + file);
        //        testData = JsonConvert.DeserializeObject<TestData1>(json);
        //        return testData.image2read;
        //    }
        //    else
        //    {
        //        MessageBox.Show("El archivo " + file + " no existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

        //private testType checkTipoTest(string selectedPath)
        //{
        //    string image2read = openTestDatajsonAndGetField(selectedPath);

        //    if (string.IsNullOrEmpty(image2read))
        //        return testType.persuit;
        //    else
        //        return testType.reading;//aca se puede ir mas y buscar la forma de saber si es silent o outloud
        //}

        //private void openWindowReviewPersuit(bool showLastTest, string selectedPath)
        //{
        //    ReviewPersuit.ReviewPersuit reviewPersuit = new ReviewPersuit.ReviewPersuit(showLastTest, true, selectedPath);
        //    //reviewPersuit.ReviewClosed += reviewPersuit_ReviewClosed;
        //    if(reviewPersuit.everythingOk)
        //        reviewPersuit.Show();
        //    else
        //        reviewPersuit.Dispose();
        //}
        
        //private void openWindowReviewReading(bool showLastTest, bool newTestAvailable, string selectedPath)
        //{
        //    Resumen.Resumen resumenGame1 = new Resumen.Resumen(showLastTest, newTestAvailable, selectedPath);
        //    //resumenGame1.ReviewClosed += resumenGame1_ReviewClosed;
        //    if (resumenGame1.everythingOk)
        //        resumenGame1.Show();
        //    else
        //        resumenGame1.Dispose();
        //}







        //void reviewPersuit_ReviewClosed(bool newTest)
        //{
        //    if (!newTest)
        //        this.Close();
        //}         

        //private void resumenGame1_ReviewClosed(bool newTest)
        //{
        //    if (!newTest)
        //        this.Close();
        //}        




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

        //private void buttonViewCalibration_Click(object sender, EventArgs e)
        //{
        //    var resultForm = new CalibrationResultForm();
        //    resultForm.SetPlotData(Program.datosCompartidos.calibrationDataEyeX);
        //    resultForm.ShowDialog();
        //}


        //varios
        //private void test_Closed(object sender, FormClosedEventArgs e)
        //{
        //    //Show the resume window
        //    if (se_grabaron_datos)
        //    {
        //        //datos del test
        //         Program.datosCompartidos.logTestData.saveData2File();

        //         //datos del tracker
        //         Program.datosCompartidos.LogEyeTrackerData.saveData2File();


        //        //subir los datos a la nube
        //        aws_class_data aws_data = new aws_class_data();
        //        aws_data.AwsS3FolderName = Program.datosCompartidos.institutionName;
        //        aws_data.FileToUpload = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\" +
        //                                    Program.datosCompartidos.startTimeTest +
        //                                    @"-us" + Program.datosCompartidos.activeUser;

        //        aws_class_engine.BackupTest(aws_data);

        //        Program.datosCompartidos.number_of_screening_done++;

        //        if (Program.datosCompartidos.testSelected == testType.reading)
        //            openWindowReviewReading(true, true, null);

        //        else if (Program.datosCompartidos.testSelected == testType.persuit)
        //            openWindowReviewPersuit(true, null);

        //    }
        //}


    }
}
