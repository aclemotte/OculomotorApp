﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LookAndPlayForm.Comments;
using LookAndPlayForm.FixDetector;
using LookAndPlayForm.LogEyeTracker;
using LookAndPlayForm.Review;
using Newtonsoft.Json;
using LookAndPlayForm.Utility;
using LookAndPlayForm.DataBase;
//using WobbrockLib.Controls;

namespace LookAndPlayForm.Resumen
{

    public partial class Resumen : Form
    {
        public bool toHome { get; set; }

        public bool everythingOk { get; set; }

        public bool closeApp { get; set; }

        string date;
        string dateloc;
        string user_id; 
        
        fixationData fixData;
        eyetrackerDataEyeX eyetrackerDataL;
        TestData1 _testData;
        Size stimulusSize;
        Point stimulusLocation;
        bool fixDataFound;
        bool imageFound;        
        int gazeDotRadius = 2;
        int fixDotRadius = 7;
        int numberOfFixL;
        int numberOfFixR;

        public Resumen(bool showLastTest, bool newTestAvailable, string fixDataJson, string eyetrackerDataJson, OutputTestData2 testData)
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); 

            closeApp = true;

            if (showLastTest)
            {
                fixDataJson = DataBaseWorker.LoadLastReadingData(out date, out user_id, out eyetrackerDataJson, out testData);
            }

            this.dateloc = testData.date_loc;
            this.user_id = testData.user_id;
            date = testData.date;

            buttonNewTest.Enabled = newTestAvailable;
            
            //Console.WriteLine("selectedPath: " + selectedPath);            

            _testData = DataConverter.TestData2ToTestData1(testData);

            if (string.IsNullOrWhiteSpace(fixDataJson))
                fixDataJson = processFixData(eyetrackerDataJson, _testData, testData.date, user_id);//procesa los datos de los ojos y genera un archivo fixData.json 
            toolStripStatusLabelFileName.Text = string.Format("{0}-us{1}", dateloc, user_id);            
            fixDataFound = loadFixationDataFromJson(fixDataJson); //carga el archivo fixData.json             
            eyetrackerDataL = ReviewClass.loadEyetrackerDataFromJson(eyetrackerDataJson);            
            getStimulusFeactures(ReviewClass.eyetrackerDataFound(eyetrackerDataL));
            imageFound = class4Graphic.loadImage2Control(ReviewClass.testDataFound(_testData), _testData, pictureBoxStimulus);

            everythingOk = fixDataFound & ReviewClass.eyetrackerDataFound(eyetrackerDataL) & ReviewClass.testDataFound(_testData) & imageFound;

            if (everythingOk)
                processMetrics();
        }

        private string processFixData(string eyetrackerData, TestData1 testData, string date, string user_id)
        {
            FixDetector.FixDetector detectorFijaciones = new FixDetector.FixDetector(eyetrackerData, testData, date, user_id);
            return detectorFijaciones.FixDataJson;
        }

        //Load json
        #region load json files

        private bool loadFixationDataFromJson(string json)
        {
            try
            {
                fixData = JsonConvert.DeserializeObject<fixationData>(json);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /*
        private bool loadFixationDataFromJson(string path)
        {
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string file = @"\fixData.json";

            if (File.Exists(path + file))
            {
                string json = File.ReadAllText(path + file);
                fixData = JsonConvert.DeserializeObject<fixationData>(json);
                return true;
            }
            else
            {
                MessageBox.Show("El archivo " + file + " no existe");
                return false;
            }
        } */       

        #endregion

        //metrics
        #region metrics

        private void processMetrics()
        {
            getNumberOfFix();
            getMeanAndStdDurationFix();
            getWordsPerMinute();
            getNumberOfWords();
            getReadingTime();
            getSOR();
            getFix100W();
            getRegression();
            getCalibError();
        }

        private void getRegression()
        {

            if (numberOfFixL != 0)
            {
                //mean
                int regressionL = eyeRegression(fixData.fixationDataPointLeft);
                textBoxRegressionL.Text = regressionL.ToString();
            }

            if (numberOfFixR != 0)
            {
                //mean
                int regressionR = eyeRegression(fixData.fixationDataPointRight);
                textBoxRegressionR.Text = regressionR.ToString();
            }
        }
        private int eyeRegression(List<fixationDataPoint> listaFixDataPoints)
        {
            int numberOfRegression  = 0;
            bool firstFix = true;
            Point previousFix = new Point();

            for(int indexFix = 0; indexFix<listaFixDataPoints.Count;indexFix++)
            {
                if (listaFixDataPoints[indexFix].fixationState == stateFixationData.end)
                {
                    if (firstFix)
                    {
                        firstFix = false;
                        previousFix = new Point(listaFixDataPoints[indexFix].fixationData.X, listaFixDataPoints[indexFix].fixationData.Y);
                    }
                    else
                    {
                        Point currentFix = new Point(listaFixDataPoints[indexFix].fixationData.X, listaFixDataPoints[indexFix].fixationData.Y);
                        
                        if (RegressionDetector.RegressionDetector.esUnaRegresion(currentFix, previousFix))
                            numberOfRegression++;

                        previousFix = currentFix;
                    }
                }
            }

            return numberOfRegression;
        }
             
        private void getSOR()
        {
            int numberOfWord = Varios.ImageDictionary.Image2ReadDictionary[_testData.image2read].numeroPalabras;

            if (numberOfFixL != 0)
            {
                double sorL = ((double)numberOfWord / (double)numberOfFixL);
                textBoxSORL.Text = sorL.ToString("0.00");
            }
            if(numberOfFixR !=0)
            {
                double sorR = ((double)numberOfWord / (double)numberOfFixR);
                textBoxSORR.Text = sorR.ToString("0.00");
            }            
        }

        private void getCalibError()
        {
            textBoxCalibErrorL.Text = _testData.calibration_error_left_px.ToString();
            textBoxCalibErrorR.Text = _testData.calibration_error_right_px.ToString();

            if (_testData.calibration_error_left_px > settings.maxCalibracionError)
            {
                textBoxCalibErrorL.BackColor = Color.Red;
            }

            if (_testData.calibration_error_right_px > settings.maxCalibracionError)
            {
                textBoxCalibErrorR.BackColor = Color.Red;
            }
        }

        private void getWordsPerMinute()
        {
            int lastItem = eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL.Count;
            int wordPerMin = 0;

            if(lastItem > 0)
            {
                double tiempo = (double)(
                                    eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[lastItem - 1].Timestamp -
                                    eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[0].Timestamp
                                        ) /
                                (double)(1000000 * 60);//microsegundos a minutos

                //aca puede que se pueda calcular hasta la ultima fijacion en vez de la ultima mirada
                if (tiempo != 0)
                {
                    wordPerMin = (int)((double)Varios.ImageDictionary.Image2ReadDictionary[_testData.image2read].numeroPalabras / tiempo);
                    textBoxWordsMin.Text = wordPerMin.ToString();
                }
                else
                    textBoxWordsMin.Text = "-";
                    
                
            }
        }

        private void getReadingTime()
        {
            int lastItem = eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL.Count;
            
            if (lastItem > 0)
            {
                int tiempo = (int)((double)(
                                        eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[lastItem - 1].Timestamp -
                                        eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[0].Timestamp
                                            ) /
                                    (double)(1000000));//microsegundos a segundos

                textBoxReadingTime.Text = tiempo.ToString("0");
            }
        }

        private void getNumberOfWords()
        {
            int numberOfWords = 0;
            numberOfWords = Varios.ImageDictionary.Image2ReadDictionary[_testData.image2read].numeroPalabras;
            textBoxNumberOfWords.Text = numberOfWords.ToString();
        }
        
        private void getFix100W()
        {
            int numberOfWord = Varios.ImageDictionary.Image2ReadDictionary[_testData.image2read].numeroPalabras;
            
            if(numberOfFixL != 0)
            {
                double fix100WordsL = ((double)numberOfFixL / (double)numberOfWord * 100 );
                textBoxFixs100WL.Text = fix100WordsL.ToString("0");
            }

            if (numberOfFixR != 0)
            {
                double fix100WordsR = ((double)numberOfFixR / (double)numberOfWord * 100);
                textBoxFixs100WR.Text = fix100WordsR.ToString("0");
            }
        }



        private void getMeanAndStdDurationFix()
        {
            
            if(numberOfFixL!=0)
            {
                //mean
                double meanFixDurationL = eyeMeanDurationFix(fixData.fixationDataPointLeft);
                textBoxMeanFixL.Text = (meanFixDurationL/1000).ToString("0.00");
                //std
                double stdFixDurationL = eyeStdDurationFix(fixData.fixationDataPointLeft, meanFixDurationL);
                textBoxStdFixL.Text = (stdFixDurationL / 1000).ToString("0.00");
            }

            if (numberOfFixR != 0)
            {
                //mean
                double meanFixDurationR = eyeMeanDurationFix(fixData.fixationDataPointRight);
                textBoxMeanFixR.Text = (meanFixDurationR / 1000).ToString("0.00");
                //std
                double stdFixDurationR = eyeStdDurationFix(fixData.fixationDataPointRight, meanFixDurationR);
                textBoxStdFixR.Text = (stdFixDurationR / 1000).ToString("0.00");
            }

        }
        private double eyeStdDurationFix(List<fixationDataPoint> listaFixDataPoints, double mean)
        {
            double stdFixDuration = 0;

            foreach (fixationDataPoint fixPoint in listaFixDataPoints)
            {
                stdFixDuration += (fixPoint.fixationData.Duration - mean) * (fixPoint.fixationData.Duration - mean);
            }

            if (listaFixDataPoints.Count == 0)
                stdFixDuration = double.NaN;
            else
                stdFixDuration = Math.Sqrt(Convert.ToDouble(stdFixDuration / listaFixDataPoints.Count));
            
            return stdFixDuration;
        }
        private double eyeMeanDurationFix(List<fixationDataPoint> listaFixDataPoints)
        {
            int sumFixDuration = 0;
            double meanFixDuration;

            foreach (fixationDataPoint fixPoint in listaFixDataPoints)
            {
                if (fixPoint.fixationState == stateFixationData.end)
                {
                    sumFixDuration += fixPoint.fixationData.Duration;
                }
            }

            //problema si es dividido por cero
            if (listaFixDataPoints.Count == 0)
                meanFixDuration = double.NaN;
            else
                meanFixDuration = (double)sumFixDuration / (double)listaFixDataPoints.Count;


            return meanFixDuration;

        }
        


        private void getNumberOfFix()
        {
            //textBoxNumFix.Text = eyeNumberOfFix(fixData.fixationDataPointLandR).ToString();
            //textBoxNumFixL.Text = eyeNumberOfFix(fixData.fixationDataPointLeft).ToString();
            //textBoxNumFixR.Text = eyeNumberOfFix(fixData.fixationDataPointRight).ToString();

            //numberOfFix = eyeNumberOfFix(fixData.fixationDataPointLandR);
            numberOfFixL = eyeNumberOfFix(fixData.fixationDataPointLeft);
            numberOfFixR = eyeNumberOfFix(fixData.fixationDataPointRight);


            //textBoxNumFix.Text = numberOfFix.ToString();
            textBoxNumFixL.Text = numberOfFixL.ToString();
            textBoxNumFixR.Text = numberOfFixR.ToString();
        }
        private int eyeNumberOfFix(List<fixationDataPoint> listaFixDataPoints)
        {
            int numberOfFix = 0;
            foreach (fixationDataPoint fixPoint in listaFixDataPoints)
            {
                if (fixPoint.fixationState == stateFixationData.end)
                {
                    numberOfFix += 1;
                }
            }

            return numberOfFix;
        }

        #endregion






        //data 2 graphic controls

        private void plotGazeData2Control()
        {
            List<Point> gazeDataDoubleList;

            if (checkBoxGaze.Checked)
            {               
                if (checkBoxL.Checked)
                {
                    gazeDataDoubleList = class4Graphic.getGazeData2List(eyetrackerDataL, _testData, Eye.left);
                    class4Graphic.plotGazeDataList(gazeDataDoubleList, EyeOption.Left, settings.leftEyeColor, gazeDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                }

                if (checkBoxR.Checked)
                {
                    gazeDataDoubleList = class4Graphic.getGazeData2List(eyetrackerDataL, _testData, Eye.right);
                    class4Graphic.plotGazeDataList(gazeDataDoubleList, EyeOption.Right, settings.rightEyeColor, gazeDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
               }
            }
        }
       
 
        private void plotFixData2Control()
        {

            List<Point> fixDataList = new List<Point>();

            if (checkBoxFixations.Checked)
            {
                if (checkBoxL.Checked)
                {

                    fixDataList = class4Graphic.fixData2List(fixData, Eye.left);
                    class4Graphic.plotFixDataList(fixDataList, EyeOption.Left,settings.leftEyeColor, fixDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                    class4Graphic.plotLinesBetweenFixs(fixDataList, settings.leftEyeColor, this, pictureBoxStimulus, stimulusSize, stimulusLocation);                    
                }

                if (checkBoxR.Checked)
                {
                    fixDataList = class4Graphic.fixData2List(fixData, Eye.right);
                    class4Graphic.plotFixDataList(fixDataList, EyeOption.Right, settings.rightEyeColor, fixDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                    class4Graphic.plotLinesBetweenFixs(fixDataList, settings.rightEyeColor, this, pictureBoxStimulus, stimulusSize, stimulusLocation);                                       
                }
            }
        }
        

        //Varios


        private void getStimulusFeactures(bool eyetrackerDataFound)
        {
            if (eyetrackerDataFound)
            {
                int stimulusX = eyetrackerDataL.targetTraceL[settings.indiceTrial].targetPositionSize.position.X;
                int stimulusY = eyetrackerDataL.targetTraceL[settings.indiceTrial].targetPositionSize.position.Y;
                int stimulusW = eyetrackerDataL.targetTraceL[settings.indiceTrial].targetPositionSize.size.X;
                int stimulusH = eyetrackerDataL.targetTraceL[settings.indiceTrial].targetPositionSize.size.Y;

                stimulusSize = new Size(stimulusW, stimulusH);
                stimulusLocation = new Point(stimulusX, stimulusY);
            }
        }

        private void buttonPlot_Click(object sender, EventArgs e)
        {
            if (everythingOk)            
            {
                plotGazeData2Control();
                plotFixData2Control();
            }
        }

        private void buttonPlotExtern_Click(object sender, EventArgs e)
        {
            SampleTextFullScreen sampleTextFullScreen = new SampleTextFullScreen(_testData, stimulusSize, stimulusLocation, fixData, eyetrackerDataL, checkBoxGaze, checkBoxFixations, checkBoxL, checkBoxR);
            sampleTextFullScreen.ShowDialog();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            toHome = true;
            closeApp = false;
            this.Close();
        }             

        private void buttonComments_Click(object sender, EventArgs e)
        {
            CommentsForm commentsF = new CommentsForm(date, user_id);
            commentsF.Show();
        }

        private void buttonNewTest_Click(object sender, EventArgs e)
        {
            toHome = false;
            closeApp = false;
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            LookAndPlayForm.SaveForm.SaveForm.toPng(this);
            MessageBox.Show("The review was saved in your desktop");
        }
    }
}
