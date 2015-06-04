using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LookAndPlayForm.FixDetector;
using Newtonsoft.Json;
//using WobbrockLib.Controls;

namespace LookAndPlayForm.Resumen
{

    public partial class Resumen : Form
    {
        fixationData fixData;
        eyetrackerDataEyeX eyetrackerDataL;
        TestData testData;

        
        bool testDataFound;
        bool eyetrackerDataFound;
        bool fixDataFound;
        bool imageFound;
        
        int gazeDotRadius = 2;
        int fixDotRadius = 7;

        int numberOfFix;
        int numberOfFixL;
        int numberOfFixR;

        Size stimulusSize;
        Point stimulusLocation;

        public bool everythingOk { get; set; }



        public Resumen(bool showLastTest)
        {
            string selectedPath; 

            InitializeComponent();

            if (!showLastTest)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";
                DialogResult result = fbd.ShowDialog();
                selectedPath = fbd.SelectedPath;
            }
            else
            {
                selectedPath =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\" +
                                LookAndPlayForm.Program.datosCompartidos.startTime +
                                @"-us" + Program.datosCompartidos.activeUser + @"\";
            }

            Console.WriteLine("selectedPath: " + selectedPath);

            toolStripStatusLabelFileName.Text = selectedPath;

            processFixData(selectedPath);//procesa los datos de los ojos y genera un archivo fixData.json
            fixDataFound = loadFixationDataFromJson(selectedPath);//carga el archivo fixData.json
            eyetrackerDataFound = loadEyetrackerDataFromJson(selectedPath);
            testDataFound = loadTestDataFromJson(selectedPath);
            getStimulusFeactures(eyetrackerDataFound);
            imageFound = class4Graphic.loadImage2Control(testDataFound, testData, pictureBoxStimulus);

            everythingOk = fixDataFound & eyetrackerDataFound & testDataFound & imageFound;

            if (everythingOk)
                processMetrics();

        }

        private void processFixData(string path)
        {
            FixDetector.FixDetector detectorFijaciones = new FixDetector.FixDetector(path);
        }

        //Load json
        #region load json files

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
        }
        
        private bool loadEyetrackerDataFromJson(string path)
        {
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string file = @"\eyetrackerData.json";

            if (File.Exists(path + file))
            {
                string json = File.ReadAllText(path + file);
                eyetrackerDataL = JsonConvert.DeserializeObject<eyetrackerDataEyeX>(json);
                return true;
            }
            else
            {
                MessageBox.Show("El archivo " + file + " no existe");
                return false;
            }
        }

        private bool loadTestDataFromJson(string path)
        {
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string file = @"\testData.json";

            if (File.Exists(path + file))
            {
                string json = File.ReadAllText(path + file);
                testData = JsonConvert.DeserializeObject<TestData>(json);
                return true;
            }
            else
            {
                MessageBox.Show("El archivo " + file + " no existe");
                return false;
            }
        }

        #endregion

        //metrics
        #region metrics

        private void processMetrics()
        {
            getNumberOfFix();
            getMeanAndStdDurationFix();
            getWordsPerMinute();
            getSOR();
            getFix100W();
            getCalibError();
        }

             
        private void getSOR()
        {
            int numberOfWord = Varios.ImageDictionary.Image2ReadDictionary[testData.image2read].numeroPalabras;
            double sor = ((double)numberOfWord / (double)numberOfFix);
            double sorL = ((double)numberOfWord / (double)numberOfFixL);
            double sorR = ((double)numberOfWord / (double)numberOfFixR);

            //textBoxSOR.Text = sor.ToString("0.00");
            textBoxSORL.Text = sorL.ToString("0.00");
            textBoxSORR.Text = sorR.ToString("0.00");
        }

        private void getCalibError()
        {
            textBoxCalibErrorL.Text = testData.calibration_error_left_px.ToString();
            textBoxCalibErrorR.Text = testData.calibration_error_right_px.ToString();

            if (testData.calibration_error_left_px > settings.maxCalibracionError)
            {
                textBoxCalibErrorL.BackColor = Color.Red;
            }

            if (testData.calibration_error_right_px > settings.maxCalibracionError)
            {
                textBoxCalibErrorR.BackColor = Color.Red;
            }
        }

        private void getWordsPerMinute()
        {
            int lastItem = eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL.Count;
            int wordPerMin = 0;
            double tiempo = (double)(
                                eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[lastItem - 1].Timestamp -
                                eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[0].Timestamp
                                    ) /
                            (double)(1000000 * 60);//microsegundos a minutos

            //aca puede que se pueda calcular hasta la ultima fijacion en vez de la ultima mirada
            wordPerMin = (int)((double)Varios.ImageDictionary.Image2ReadDictionary[testData.image2read].numeroPalabras / tiempo);
            textBoxWordsMin.Text = wordPerMin.ToString();

        }
        
        private void getFix100W()
        {
            int numberOfWord = Varios.ImageDictionary.Image2ReadDictionary[testData.image2read].numeroPalabras;
            double fix100WordsL = ((double)numberOfFixL / (double)numberOfWord * 100 );
            double fix100WordsR = ((double)numberOfFixR / (double)numberOfWord * 100 );

            textBoxFixs100WL.Text = fix100WordsL.ToString("0");
            textBoxFixs100WR.Text = fix100WordsR.ToString("0");
        }



        private void getMeanAndStdDurationFix()
        {
            //mean
            double meanFixDuration = eyeMeanDurationFix(fixData.fixationDataPointLandR);
            double meanFixDurationL = eyeMeanDurationFix(fixData.fixationDataPointLeft);
            double meanFixDurationR = eyeMeanDurationFix(fixData.fixationDataPointRight);

            //textBoxMeanFix.Text = ((int)meanFixDuration).ToString();
            textBoxMeanFixL.Text = (meanFixDurationL/1000).ToString("0.00");
            textBoxMeanFixR.Text = (meanFixDurationR/1000).ToString("0.00");

            //std
            double stdFixDuration = eyeStdDurationFix(fixData.fixationDataPointLandR, meanFixDuration);
            double stdFixDurationL = eyeStdDurationFix(fixData.fixationDataPointLeft, meanFixDurationL);
            double stdFixDurationR = eyeStdDurationFix(fixData.fixationDataPointRight, meanFixDurationR);

            
            //textBoxStdFix.Text = ((int)stdFixDuration).ToString();
            textBoxStdFixL.Text = (stdFixDurationL/1000).ToString("0.00");
            textBoxStdFixR.Text = (stdFixDurationR/1000).ToString("0.00");
        }
        private double eyeStdDurationFix(List<fixationDataPoint> listaFixDataPoints, double mean)
        {
            double stdFixDuration = 0;

            foreach (fixationDataPoint fixPoint in listaFixDataPoints)
            {
                stdFixDuration += (fixPoint.fixationData.Duration - mean) * (fixPoint.fixationData.Duration - mean);
            }

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
            meanFixDuration = (double)sumFixDuration / (double)listaFixDataPoints.Count;
            return meanFixDuration;

        }
        


        private void getNumberOfFix()
        {
            //textBoxNumFix.Text = eyeNumberOfFix(fixData.fixationDataPointLandR).ToString();
            //textBoxNumFixL.Text = eyeNumberOfFix(fixData.fixationDataPointLeft).ToString();
            //textBoxNumFixR.Text = eyeNumberOfFix(fixData.fixationDataPointRight).ToString();

            numberOfFix = eyeNumberOfFix(fixData.fixationDataPointLandR);
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
                    gazeDataDoubleList = class4Graphic.getGazeData2List(eyetrackerDataL, testData, eye.left);
                    class4Graphic.plotGazeDataList(gazeDataDoubleList, Color.Red, gazeDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                }

                if (checkBoxR.Checked)
                {
                    gazeDataDoubleList = class4Graphic.getGazeData2List(eyetrackerDataL, testData, eye.right);
                    class4Graphic.plotGazeDataList(gazeDataDoubleList, Color.Blue, gazeDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
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

                    fixDataList = class4Graphic.fixData2List(fixData, eye.left);
                    class4Graphic.plotFixDataList(fixDataList, Color.Red, fixDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                    class4Graphic.plotLinesBetweenFixs(fixDataList, Color.Red, this, pictureBoxStimulus, stimulusSize, stimulusLocation);                    
                }

                if (checkBoxR.Checked)
                {
                    fixDataList = class4Graphic.fixData2List(fixData, eye.right);
                    class4Graphic.plotFixDataList(fixDataList, Color.Blue,fixDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                    class4Graphic.plotLinesBetweenFixs(fixDataList, Color.Blue, this, pictureBoxStimulus, stimulusSize, stimulusLocation);                                       
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
                //this.Invalidate();
                //this.Update();
                //pictureBoxStimulus.Invalidate();
                //pictureBoxStimulus.Update();

                plotGazeData2Control();
                plotFixData2Control();
            }
        }

        private void buttonPlotExtern_Click(object sender, EventArgs e)
        {
            Graph1 newGraph1 = new Graph1(testData, stimulusSize, stimulusLocation, fixData, eyetrackerDataL, checkBoxGaze, checkBoxFixations, checkBoxL, checkBoxR);
            newGraph1.Show();
        }
    }
}
