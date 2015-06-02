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
        public bool fixDataFound;
        bool imageFound;
        
        int gazeDotRadius = 2;
        int fixDotRadius = 7;

        int numberOfFix;
        int numberOfFixL;
        int numberOfFixR;

        Size stimulusSize;
        Point stimulusLocation;

        public bool everythingOk;



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
            getStimulusFeactures();
            imageFound = loadImage2Control(testDataFound);

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

            textBoxFixs100WL.Text = fix100WordsL.ToString();
            textBoxFixs100WR.Text = fix100WordsR.ToString();
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
                    plotGazeDataList(gazeDataDoubleList, Color.Red);
                }

                if (checkBoxR.Checked)
                {
                    gazeDataDoubleList = class4Graphic.getGazeData2List(eyetrackerDataL, testData, eye.right);
                    plotGazeDataList(gazeDataDoubleList, Color.Blue);
               }
            }
        }
       
        private void plotGazeDataList(List<Point> gazeDataDoubleList, Color gazeColor)
        {

            for (var indiceSample = 0; indiceSample < gazeDataDoubleList.Count; indiceSample++)
            {
                plotDot(gazeDataDoubleList[indiceSample].X, gazeDataDoubleList[indiceSample].Y, gazeColor, gazeDotRadius);
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
                    plotFixDataList(fixDataList, Color.Red);
                    plotLinesBetweenFixs(fixDataList, Color.Red);                    
                }

                if (checkBoxR.Checked)
                {
                    fixDataList = class4Graphic.fixData2List(fixData, eye.right);
                    plotFixDataList(fixDataList, Color.Blue);
                    plotLinesBetweenFixs(fixDataList, Color.Blue);                                       
                }
            }
        }

        private void plotFixDataList(List<Point> fixDataList, Color fixColor)
        {
            for (var indiceSample = 0; indiceSample < fixDataList.Count; indiceSample++)
            {
                plotDot(fixDataList[indiceSample].X, fixDataList[indiceSample].Y, fixColor, fixDotRadius);
            }
        }





        private void plotLinesBetweenFixs(List<Point> fixDataList, Color fixColor)
        {
            bool firstFix = true;
            int previousFixX = 0;
            int previousFixY = 0;

            for (var indiceSample = 0; indiceSample < fixDataList.Count; indiceSample++)
            {
                if (firstFix)
                {
                    previousFixX = fixDataList[indiceSample].X;
                    previousFixY = fixDataList[indiceSample].Y;
                    firstFix = false;
                }
                else
                {
                    plotLine(fixDataList[indiceSample].X, fixDataList[indiceSample].Y, previousFixX, previousFixY, fixColor);
                    previousFixX = fixDataList[indiceSample].X;
                    previousFixY = fixDataList[indiceSample].Y;
                }
            }
        }

        private void plotLine(int currentFixX, int currentFixY, int previousFixX, int previousFixY, Color lineColor)
        {
            //posicion relativa a la esquina superior izquierda del pictureBoxStimulus
            int currentFixXrelative = (int)((double)(currentFixX - stimulusLocation.X) * (double)pictureBoxStimulus.Size.Width / (double)stimulusSize.Width);
            int currentFixYrelative = (int)((double)(currentFixY - stimulusLocation.Y) * (double)pictureBoxStimulus.Size.Height / (double)stimulusSize.Height);
            int previousFixXrelative = (int)((double)(previousFixX - stimulusLocation.X) * (double)pictureBoxStimulus.Size.Width / (double)stimulusSize.Width);
            int previousFixYrelative = (int)((double)(previousFixY - stimulusLocation.Y) * (double)pictureBoxStimulus.Size.Height / (double)stimulusSize.Height);

            //bool currentDotOverPictureBox = isDotOverPictureBox(currentFixX, currentFixY, stimulusLocation.X, stimulusLocation.Y, stimulusSize.Width, stimulusSize.Height);
            //bool previousDotOverPictureBox = isDotOverPictureBox(previousFixX, previousFixY, stimulusLocation.X, stimulusLocation.Y, stimulusSize.Width, stimulusSize.Height);

            // se grafican las dos lineas, total al final si no corresponde no se dibuja
            //if (currentDotOverPictureBox)
            {
                Pen myPen = new Pen(lineColor);
                Graphics g = Graphics.FromHwnd(pictureBoxStimulus.Handle);

                g.DrawLine(myPen, previousFixXrelative, previousFixYrelative, currentFixXrelative, currentFixYrelative);

                myPen.Dispose();
                g.Dispose();

            }
            //else
            {
                Pen myPen = new Pen(Color.Black);
                Graphics g = this.CreateGraphics();

                g.DrawLine(myPen,
                    previousFixXrelative + pictureBoxStimulus.Location.X,
                    previousFixYrelative + pictureBoxStimulus.Location.Y,
                    currentFixXrelative + pictureBoxStimulus.Location.X,
                    currentFixYrelative + pictureBoxStimulus.Location.Y
                            );

                myPen.Dispose();
                g.Dispose();

            }

        }


        //Varios
        private bool loadImage2Control(bool testDataFound)
        {
            /*
             * leer testdata.imagen
             * en funcion de lo que se lee se carga en el picture box            
             */

            if(testDataFound)
            {   
                
                //if (Varios.ImageDictionary.Image2ReadDictionary.ContainsKey(settings.image2read))
                if (Varios.ImageDictionary.Image2ReadDictionary.ContainsKey(testData.image2read))
                {
                    //pictureBoxStimulus.Image = Varios.ImageDictionary.Image2ReadDictionary[settings.image2read].imagen;
                    //Console.WriteLine("testData.imagen2read:" + settings.image2read + " encontrada");
                    pictureBoxStimulus.Image = Varios.ImageDictionary.Image2ReadDictionary[testData.image2read].imagen;
                    Console.WriteLine("testData.imagen2read:" + testData.image2read + " encontrada");
                    return true;
                }
                else
                {
                    Console.WriteLine("testData.imagen2read:" + testData.image2read + " NO encontrada");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("testDataFound: false");
                return false;
            }
        }

        private void getStimulusFeactures()
        {            
            int stimulusX = eyetrackerDataL.targetTraceL[settings.indiceTrial].targetPositionSize.position.X;
            int stimulusY = eyetrackerDataL.targetTraceL[settings.indiceTrial].targetPositionSize.position.Y;
            int stimulusW = eyetrackerDataL.targetTraceL[settings.indiceTrial].targetPositionSize.size.X;
            int stimulusH = eyetrackerDataL.targetTraceL[settings.indiceTrial].targetPositionSize.size.Y;

            stimulusSize = new Size(stimulusW, stimulusH);
            stimulusLocation = new Point(stimulusX, stimulusY);
        }

        private void plotDot(int dotX, int dotY, Color dotColor, int dotRadius)
        {
            //posicion relativa a la esquina superior izquierda del pictureBoxStimulus
            int dotXrelative = (int)((double)(dotX - stimulusLocation.X) * (double)pictureBoxStimulus.Size.Width / (double)stimulusSize.Width);
            int dotYrelative = (int)((double)(dotY - stimulusLocation.Y) * (double)pictureBoxStimulus.Size.Height / (double)stimulusSize.Height);

            bool dotOverPictureBox = isDotOverPictureBox(dotX, dotY, stimulusLocation.X, stimulusLocation.Y, stimulusSize.Width, stimulusSize.Height);

            SolidBrush brush;
            Graphics newGraphics;
            Rectangle rect;
            Point dPoint;

            if (dotOverPictureBox)
            {
                brush = new SolidBrush(dotColor);
                newGraphics = Graphics.FromHwnd(pictureBoxStimulus.Handle);
                dPoint = new Point(dotXrelative - dotRadius, dotYrelative - dotRadius);
                rect = new Rectangle(dPoint, new Size(2 * dotRadius, 2 * dotRadius));
                //g.FillEllipse(brush, rect);
                //g.Dispose();
            }
            else
            {
                brush = new SolidBrush(Color.Black);
                newGraphics = this.CreateGraphics();
                dPoint = new Point(dotXrelative + pictureBoxStimulus.Location.X - dotRadius, dotYrelative + pictureBoxStimulus.Location.Y - dotRadius);
                rect = new Rectangle(dPoint, new Size(2 * dotRadius, 2 * dotRadius));
                //g.FillEllipse(brush, rect);
                //g.Dispose();
            }

            newGraphics.FillEllipse(brush, rect);
            newGraphics.Dispose();
        }

        private bool isDotOverPictureBox(int dotX, int dotY, int stimulusX, int stimulusY, int stimulusW, int stimulusH)
        {
            if (
                dotX > stimulusX &&
                dotX < (stimulusX + stimulusW) &&
                dotY > stimulusY &&
                dotY < (stimulusY + stimulusH)
              )
                return true;
            else
                return false;
        }


        //Botones
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
            Graph1 newGraph1 = new Graph1(testData, stimulusSize, stimulusLocation, fixData);
            newGraph1.Show();
        }
    }
}
