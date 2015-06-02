using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LookAndPlayForm.FixDetector;

namespace LookAndPlayForm.Resumen
{
    public partial class Graph1 : Form
    {

        TestData testData;
        fixationData fixData;
        Size stimulusSize;
        Point stimulusLocation;
        int fixDotRadius = 7;

        public Graph1(TestData testData, Size stimulusSize, Point stimulusLocation, fixationData fixData)
        {
            InitializeComponent();

            this.testData = testData;
            this.fixData = fixData;
            this.stimulusSize = stimulusSize;
            this.stimulusLocation = stimulusLocation;

            loadImage2Control();


            pictureBoxStimulus.Size = stimulusSize;
            pictureBoxStimulus.Location = stimulusLocation;

        }

        private bool loadImage2Control()
        {
            /*
             * leer testdata.imagen
             * en funcion de lo que se lee se carga en el picture box            
             */

            //if (testDataFound)
            //{

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
            //}
            //else
            //{
            //    Console.WriteLine("testDataFound: false");
            //    return false;
            //}
        }

        private void plotFixData2Control()
        {

            bool firstFix;
            int previousFixX;
            int previousFixY;

            firstFix = true;
            previousFixX = 0;
            previousFixY = 0;

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
                

                
            firstFix = true;
            previousFixX = 0;
            previousFixY = 0;

            for (var indiceSample = 0; indiceSample < fixData.fixationDataPointRight.Count; indiceSample++)
            {
                if (fixData.fixationDataPointRight[indiceSample].fixationState == stateFixationData.end)
                {
                    int currentFixX = fixData.fixationDataPointRight[indiceSample].fixationData.X;
                    int currentFixY = fixData.fixationDataPointRight[indiceSample].fixationData.Y;

                    plotFix(currentFixX, currentFixY, Color.Blue);

                    if (firstFix)
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

        //Boton salir
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPlot_Click(object sender, EventArgs e)
        {
            plotFixData2Control();
        }
    }
}
