﻿using System;
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

        public bool everythingOk;

        public Resumen()
        {
            InitializeComponent();


            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";
            DialogResult result = fbd.ShowDialog();

            Console.WriteLine("fbd.SelectedPath: " + fbd.SelectedPath);

            processFixData(fbd.SelectedPath);
            fixDataFound = loadFixationDataFromJson(fbd.SelectedPath);
            eyetrackerDataFound = loadEyetrackerDataFromJson(fbd.SelectedPath);
            testDataFound = loadTestDataFromJson(fbd.SelectedPath);
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
            getCalibError();
        }

        private void getCalibError()
        {
            textBoxCalibErrorL.Text = testData.calibration_error_left_px.ToString();
            textBoxCalibErrorR.Text = testData.calibration_error_right_px.ToString();
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




        private void getMeanAndStdDurationFix()
        {
            //mean
            double meanFixDuration = eyeMeanDurationFix(fixData.fixationDataPointLandR);
            double meanFixDurationL = eyeMeanDurationFix(fixData.fixationDataPointLeft);
            double meanFixDurationR = eyeMeanDurationFix(fixData.fixationDataPointRight);

            textBoxMeanFix.Text = ((int)meanFixDuration).ToString();
            textBoxMeanFixL.Text = ((int)meanFixDurationL).ToString();
            textBoxMeanFixR.Text = ((int)meanFixDurationR).ToString();

            //std
            double stdFixDuration = eyeStdDurationFix(fixData.fixationDataPointLandR, meanFixDuration);
            double stdFixDurationL = eyeStdDurationFix(fixData.fixationDataPointLeft, meanFixDurationL);
            double stdFixDurationR = eyeStdDurationFix(fixData.fixationDataPointRight, meanFixDurationR);

            
            textBoxStdFix.Text = ((int)stdFixDuration).ToString();
            textBoxStdFixL.Text = ((int)stdFixDurationL).ToString();
            textBoxStdFixR.Text = ((int)stdFixDurationR).ToString();
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

            meanFixDuration = (double)sumFixDuration / (double)listaFixDataPoints.Count;
            return meanFixDuration;

        }
        



        private void getNumberOfFix()
        {
            textBoxNumFix.Text = eyeNumberOfFix(fixData.fixationDataPointLandR).ToString();
            textBoxNumFixL.Text = eyeNumberOfFix(fixData.fixationDataPointLeft).ToString();
            textBoxNumFixR.Text = eyeNumberOfFix(fixData.fixationDataPointRight).ToString();            
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
                if (checkBoxL.Checked && checkBoxR.Checked)
                {
                    for (var indiceSample = 0; indiceSample < eyetrackerDataL.targetTraceL[indiceTrial].gazeFilteredL.Count; indiceSample++)
                    {
                        double gazeX = (int)(eyetrackerDataL.targetTraceL[indiceTrial].gazeWeigthedL[indiceSample].X * (double)testData.screen_Width);
                        double gazeY = (int)(eyetrackerDataL.targetTraceL[indiceTrial].gazeWeigthedL[indiceSample].Y * (double)testData.screen_Height);

                        if (
                            !double.IsNaN(eyetrackerDataL.targetTraceL[indiceTrial].gazeWeigthedL[indiceSample].X)
                            && !double.IsNaN(eyetrackerDataL.targetTraceL[indiceTrial].gazeWeigthedL[indiceSample].Y)
                            )
                        {
                            plotGaze(gazeX, gazeY, Color.LimeGreen);
                        }
                    }
                }

                if (checkBoxL.Checked && !checkBoxR.Checked)
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

                if (!checkBoxL.Checked && checkBoxR.Checked)
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

            int stimulusX = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.position.X;
            int stimulusY = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.position.Y;
            int stimulusW = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.size.X;
            int stimulusH = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.size.Y;

            //posicion relativa a la esquina superior izquierda del pictureBoxStimulus
            int dotX = (int)((gazeX - (double)stimulusX) * (double)pictureBoxStimulus.Size.Width / (double)stimulusW);
            int dotY = (int)((gazeY - (double)stimulusY) * (double)pictureBoxStimulus.Size.Height / (double)stimulusH);

            bool dotOverPictureBox = isDotOverPictureBox((int)gazeX, (int)gazeY, stimulusX, stimulusY, stimulusW, stimulusH);

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
                if (checkBoxL.Checked && checkBoxR.Checked)
                {
                    for (var indiceSample = 0; indiceSample < fixData.fixationDataPointLandR.Count; indiceSample++)
                    {
                        if (fixData.fixationDataPointLandR[indiceSample].fixationState == stateFixationData.end)
                        {
                            int fixX = fixData.fixationDataPointLandR[indiceSample].fixationData.X;
                            int fixY = fixData.fixationDataPointLandR[indiceSample].fixationData.Y;
                            plotFix(fixX, fixY, Color.Green);
                        }
                    }
                }

                if (checkBoxL.Checked && !checkBoxR.Checked)
                {
                    for (var indiceSample = 0; indiceSample < fixData.fixationDataPointLeft.Count; indiceSample++)
                    {
                        if (fixData.fixationDataPointLeft[indiceSample].fixationState == stateFixationData.end)
                        {
                            int fixX = fixData.fixationDataPointLeft[indiceSample].fixationData.X;
                            int fixY = fixData.fixationDataPointLeft[indiceSample].fixationData.Y;
                            plotFix(fixX, fixY, Color.Red);
                        }
                    }
                }

                if (!checkBoxL.Checked && checkBoxR.Checked)
                {
                    for (var indiceSample = 0; indiceSample < fixData.fixationDataPointRight.Count; indiceSample++)
                    {
                        if (fixData.fixationDataPointRight[indiceSample].fixationState == stateFixationData.end)
                        {
                            int fixX = fixData.fixationDataPointRight[indiceSample].fixationData.X;
                            int fixY = fixData.fixationDataPointRight[indiceSample].fixationData.Y;
                            plotFix(fixX, fixY, Color.Blue);
                        }
                    }
                }
            }
        }

        private void plotFix(int fixX, int fixY, Color fixColor)
        {

            int stimulusX = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.position.X;
            int stimulusY = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.position.Y;
            int stimulusW = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.size.X;
            int stimulusH = eyetrackerDataL.targetTraceL[indiceTrial].targetPositionSize.size.Y;

            //posicion relativa a la esquina superior izquierda del pictureBoxStimulus
            int dotX = (int)((double)(fixX - stimulusX) * (double)pictureBoxStimulus.Size.Width / (double)stimulusW);
            int dotY = (int)((double)(fixY - stimulusY) * (double)pictureBoxStimulus.Size.Height / (double)stimulusH);

            bool dotOverPictureBox = isDotOverPictureBox(fixX, fixY, stimulusX, stimulusY, stimulusW, stimulusH);

            if (dotOverPictureBox)
            {
                SolidBrush brush = new SolidBrush(fixColor);
                Graphics g = Graphics.FromHwnd(pictureBoxStimulus.Handle);
                Point dPoint = new Point(dotX - fixDotRadius, dotY - fixDotRadius);
                Rectangle rect = new Rectangle(dPoint, new Size(2*fixDotRadius, 2*fixDotRadius));
                g.FillEllipse(brush, rect);
                g.Dispose();
            }
            else
            {
                SolidBrush brush = new SolidBrush(Color.Black);
                Graphics g = this.CreateGraphics();
                Point dpoint = new Point(dotX + pictureBoxStimulus.Location.X - fixDotRadius, dotY + pictureBoxStimulus.Location.Y - fixDotRadius);
                Rectangle rect = new Rectangle(dpoint, new Size(2*fixDotRadius, 2*fixDotRadius));
                g.FillEllipse(brush, rect);
                g.Dispose();
            }
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
    }
}
