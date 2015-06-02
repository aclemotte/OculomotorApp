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
        int indiceTrial = 0;
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
 
            processFixData(selectedPath);
            fixDataFound = loadFixationDataFromJson(selectedPath);
            eyetrackerDataFound = loadEyetrackerDataFromJson(selectedPath);
            getStimulusFeactures();
            testDataFound = loadTestDataFromJson(selectedPath);
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
        private bool loadTestDataFromJson(string  path)
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





        //metrics
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
            int lastItem = eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL.Count;
            int wordPerMin = 0;
            double tiempo = (double)(
                                eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL[lastItem - 1].Timestamp -
                                eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL[0].Timestamp
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

        



        


        //data 2 graphic controls

        private void plotGazeData()
        {
            List<PointD> gaze2Plot = new List<PointD>();

            if (checkBoxGaze.Checked)
            {               
                if (checkBoxL.Checked)
                {
                    for (var indiceSample = 0; indiceSample < eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL.Count; indiceSample++)
                    {
                        double gazeX = (int)(eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.X * (double)testData.screen_Width);
                        double gazeY = (int)(eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.Y * (double)testData.screen_Height);

                        if (
                            !double.IsNaN(eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.X)
                            && !double.IsNaN(eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.Y)
                            )
                        {
                            plotGaze(gazeX, gazeY, Color.Red);
                        }
                    }
                }

                if (checkBoxR.Checked)
                {
                    for (var indiceSample = 0; indiceSample < eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL.Count; indiceSample++)
                    {
                        double gazeX = (int)(eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.X * (double)testData.screen_Width);
                        double gazeY = (int)(eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.Y * (double)testData.screen_Height);

                        if (
                            !double.IsNaN(eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.X)
                            && !double.IsNaN(eyetrackerDataL.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.Y)
                            )
                        {
                            plotGaze(gazeX, gazeY, Color.Blue);
                        }
                    }
                }
            }
        }
        
        private void plotGaze(double gazeX, double gazeY, Color gazeColor)
        {

            //stimulusSize.Height  stimulusH
            //stimulusSize.Width  stimulusW
            //stimulusLocation.X  stimulusX
            //stimulusLocation.Y  stimulusY

            //int stimulusX = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.position.X;
            //int stimulusY = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.position.Y;
            //int stimulusW = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.size.X;
            //int stimulusH = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.size.Y;

            //posicion relativa a la esquina superior izquierda del pictureBoxStimulus
            int dotX = (int)((gazeX - (double)stimulusLocation.X) * (double)pictureBoxStimulus.Size.Width / (double)stimulusSize.Width);
            int dotY = (int)((gazeY - (double)stimulusLocation.Y) * (double)pictureBoxStimulus.Size.Height / (double)stimulusSize.Height);

            bool dotOverPictureBox = isDotOverPictureBox((int)gazeX, (int)gazeY, stimulusLocation.X, stimulusLocation.Y, stimulusSize.Width, stimulusSize.Height);

            if (dotOverPictureBox)
            {
                SolidBrush brush = new SolidBrush(gazeColor);
                Graphics g = Graphics.FromHwnd(pictureBoxStimulus.Handle);
                Point dPoint = new Point(dotX - gazeDotRadius, dotY - gazeDotRadius);
                Rectangle rect = new Rectangle(dPoint, new Size(2*gazeDotRadius, 2*gazeDotRadius));
                g.FillEllipse(brush, rect);
                g.Dispose();
            }
            else
            {
                SolidBrush brush = new SolidBrush(Color.Black);
                Graphics g = this.CreateGraphics();
                Point dpoint = new Point(dotX + pictureBoxStimulus.Location.X - gazeDotRadius, dotY + pictureBoxStimulus.Location.Y - gazeDotRadius);
                Rectangle rect = new Rectangle(dpoint, new Size(2*gazeDotRadius, 2*gazeDotRadius));
                g.FillEllipse(brush, rect);
                g.Dispose();
            }
        }



        private void plotFixData2Control()
        {
            if (checkBoxFixations.Checked)
            {
                if (checkBoxL.Checked)
                {

                    bool firstFix = true;
                    int previousFixX = 0;
                    int previousFixY = 0;

                    for (var indiceSample = 0; indiceSample < fixData.fixationDataPointLeft.Count; indiceSample++)
                    {
                        if (fixData.fixationDataPointLeft[indiceSample].fixationState == stateFixationData.end)
                        {
                            int currentFixX = fixData.fixationDataPointLeft[indiceSample].fixationData.X;
                            int currentFixY = fixData.fixationDataPointLeft[indiceSample].fixationData.Y;
                            
                            plotFix(currentFixX, currentFixY, Color.Red);
                            
                            if (firstFix)
                            {
                                previousFixX = currentFixX;
                                previousFixY = currentFixY;
                                firstFix = false;
                            }
                            else
                            {
                                plotLine(currentFixX, currentFixY, previousFixX, previousFixY, Color.Red);
                                previousFixX = currentFixX;
                                previousFixY = currentFixY;
                            }
                        }
                    }
                }

                if (checkBoxR.Checked)
                {
                    
                    bool firstFix = true;
                    int previousFixX = 0;
                    int previousFixY = 0;

                    for (var indiceSample = 0; indiceSample < fixData.fixationDataPointRight.Count; indiceSample++)
                    {
                        if (fixData.fixationDataPointRight[indiceSample].fixationState == stateFixationData.end)
                        {
                            int currentFixX = fixData.fixationDataPointRight[indiceSample].fixationData.X;
                            int currentFixY = fixData.fixationDataPointRight[indiceSample].fixationData.Y;
                            
                            plotFix(currentFixX, currentFixY, Color.Blue);
                            
                            if(firstFix)
                            {
                                previousFixX = currentFixX;
                                previousFixY = currentFixY;
                                firstFix = false; 
                            }
                            else
                            {
                                plotLine(currentFixX, currentFixY, previousFixX, previousFixY, Color.Blue);
                                previousFixX = currentFixX;
                                previousFixY = currentFixY;
                            }
                        }
                    }

                    
                }
            }
        }        
        
        private void plotLine(int currentFixX, int currentFixY, int previousFixX, int previousFixY, Color lineColor)
        {

            //stimulusSize.Height  stimulusH
            //stimulusSize.Width  stimulusW
            //stimulusLocation.X  stimulusX
            //stimulusLocation.Y  stimulusY

            //int stimulusX = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.position.X;
            //int stimulusY = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.position.Y;
            //int stimulusW = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.size.X;
            //int stimulusH = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.size.Y;

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

        private void plotFix(int fixX, int fixY, Color fixColor)
        {

            //stimulusSize.Height  stimulusH
            //stimulusSize.Width  stimulusW
            //stimulusLocation.X  stimulusX
            //stimulusLocation.Y  stimulusY

            //int stimulusX = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.position.X;
            //int stimulusY = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.position.Y;
            //int stimulusW = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.size.X;
            //int stimulusH = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.size.Y;

            //posicion relativa a la esquina superior izquierda del pictureBoxStimulus
            int dotX = (int)((double)(fixX - stimulusLocation.X) * (double)pictureBoxStimulus.Size.Width / (double)stimulusSize.Width);
            int dotY = (int)((double)(fixY - stimulusLocation.Y) * (double)pictureBoxStimulus.Size.Height / (double)stimulusSize.Height);

            bool dotOverPictureBox = isDotOverPictureBox(fixX, fixY, stimulusLocation.X, stimulusLocation.Y, stimulusSize.Width, stimulusSize.Height);

            SolidBrush brush;
            Graphics newGraphics;
            Rectangle rect;
            Point dPoint;

            if (dotOverPictureBox)
            {
                brush = new SolidBrush(fixColor);
                newGraphics = Graphics.FromHwnd(pictureBoxStimulus.Handle);
                dPoint = new Point(dotX - fixDotRadius, dotY - fixDotRadius);
                rect = new Rectangle(dPoint, new Size(2 * fixDotRadius, 2 * fixDotRadius));
                //g.FillEllipse(brush, rect);
                //g.Dispose();
            }
            else
            {
                brush = new SolidBrush(Color.Black);
                newGraphics = this.CreateGraphics();
                dPoint = new Point(dotX + pictureBoxStimulus.Location.X - fixDotRadius, dotY + pictureBoxStimulus.Location.Y - fixDotRadius);
                rect = new Rectangle(dPoint, new Size(2 * fixDotRadius, 2 * fixDotRadius));
                //g.FillEllipse(brush, rect);
                //g.Dispose();
            }

            newGraphics.FillEllipse(brush, rect);
            newGraphics.Dispose();
        }


        private bool isDotOverPictureBox(int gazeX, int gazeY, int stimulusX, int stimulusY, int stimulusW, int stimulusH)
        {
            if (
                gazeX > stimulusX &&
                gazeX < (stimulusX + stimulusW) &&
                gazeY > stimulusY &&
                gazeY < (stimulusY + stimulusH)
              )
                return true;
            else
                return false;
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
            int stimulusX = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.position.X;
            int stimulusY = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.position.Y;
            int stimulusW = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.size.X;
            int stimulusH = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.size.Y;

            stimulusSize = new Size(stimulusW, stimulusH);
            stimulusLocation = new Point(stimulusX, stimulusY);
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

                plotGazeData();
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
