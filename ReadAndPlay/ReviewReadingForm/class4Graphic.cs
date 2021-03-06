﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LookAndPlayForm.FixDetector;
using LookAndPlayForm.LogEyeTracker;

namespace LookAndPlayForm.Resumen
{

    public static class class4Graphic
    {
        
        public static List<Point> getGazeData2List(eyetrackerDataEyeX eyetrackerDataL, TestData1 testData, Eye fromEye)
        {

            List<Point> gazeDataDoubleList = new List<Point>();

            if (fromEye == Eye.left)
            {
                for (var indiceSample = 0; indiceSample < eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL.Count; indiceSample++)
                {
                    int gazeX = (int)(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.X * (double)testData.screen_Width);
                    int gazeY = (int)(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.Y * (double)testData.screen_Height);

                    if (
                        !double.IsNaN(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.X)
                        && !double.IsNaN(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.Y)
                        )
                    {
                        gazeDataDoubleList.Add(new Point(gazeX, gazeY));
                    }
                }
            }

            if (fromEye == Eye.right)
            {
                for (var indiceSample = 0; indiceSample < eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL.Count; indiceSample++)
                {
                    int gazeX = (int)(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.X * (double)testData.screen_Width);
                    int gazeY = (int)(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.Y * (double)testData.screen_Height);

                    if (
                        !double.IsNaN(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.X)
                        && !double.IsNaN(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.Y)
                        )
                    {
                        gazeDataDoubleList.Add(new Point(gazeX, gazeY)); //plotGaze(gazeX, gazeY, Color.Blue);
                    }
                }
            }



            return gazeDataDoubleList;
        }

        public static void plotGazeDataList(List<Point> gazeDataDoubleList, EyeOption eyeSelected, Color gazeColor, int gazeDotRadius, Form formulario, PictureBox pictureBoxStimulus, Size stimulusSize, Point stimulusLocation)
        {

            for (var indiceSample = 0; indiceSample < gazeDataDoubleList.Count; indiceSample++)
            {
                plotDot(gazeDataDoubleList[indiceSample].X, gazeDataDoubleList[indiceSample].Y, eyeSelected, gazeColor, gazeDotRadius, formulario, pictureBoxStimulus, stimulusSize, stimulusLocation);
            }
        }



        public static List<Point> fixData2List(fixationData fixData, Eye fromEye)
        {
            List<Point> fixDataList = new List<Point>();

            if (fromEye == Eye.left)
            {
                for (var indiceSample = 0; indiceSample < fixData.fixationDataPointLeft.Count; indiceSample++)
                {
                    if (fixData.fixationDataPointLeft[indiceSample].fixationState == stateFixationData.end)
                    {
                        int currentFixX = fixData.fixationDataPointLeft[indiceSample].fixationData.X;
                        int currentFixY = fixData.fixationDataPointLeft[indiceSample].fixationData.Y;

                        fixDataList.Add(new Point(currentFixX, currentFixY));
                    }
                }
            }

            if (fromEye == Eye.right)
            {
                for (var indiceSample = 0; indiceSample < fixData.fixationDataPointRight.Count; indiceSample++)
                {
                    if (fixData.fixationDataPointRight[indiceSample].fixationState == stateFixationData.end)
                    {
                        int currentFixX = fixData.fixationDataPointRight[indiceSample].fixationData.X;
                        int currentFixY = fixData.fixationDataPointRight[indiceSample].fixationData.Y;

                        fixDataList.Add(new Point(currentFixX, currentFixY));
                    }
                }
            }

            return fixDataList;
        }

        public static void plotFixDataList(List<Point> fixDataList, EyeOption eyeSelected, Color fixColor, int fixDotRadius, Form formulario, PictureBox pictureBoxStimulus, Size stimulusSize, Point stimulusLocation)
        {
            for (var indiceSample = 0; indiceSample < fixDataList.Count; indiceSample++)
            {
                plotDot(fixDataList[indiceSample].X, fixDataList[indiceSample].Y, eyeSelected, fixColor, fixDotRadius, formulario, pictureBoxStimulus, stimulusSize, stimulusLocation);
            }
        }



        public static void plotDot(int dotX, int dotY, EyeOption eyeSelected, Color dotColor, int dotRadius, Form formulario, PictureBox pictureBoxStimulus, Size stimulusSize, Point stimulusLocation)
        {
            //posicion relativa a la esquina superior izquierda del pictureBoxStimulus
            int dotXrelative = (int)((double)(dotX - stimulusLocation.X) * (double)pictureBoxStimulus.Size.Width / (double)stimulusSize.Width);
            int dotYrelative = (int)((double)(dotY - stimulusLocation.Y) * (double)pictureBoxStimulus.Size.Height / (double)stimulusSize.Height);

            //bool dotOverPictureBox = isDotOverPictureBox(new Point(dotX, dotY), stimulusSize, stimulusLocation);

            //SolidBrush brush;
            //Graphics newGraphics;
            //Rectangle rect;
            //Point dPoint;

            //se grafican tanto sobre el picturebox como sobre el form que total si no se puede no grafica
            //if (dotOverPictureBox)
            {
                SolidBrush brush;
                Graphics newGraphics;
                Rectangle rect;
                Point dPoint;

                brush = new SolidBrush(dotColor);
                newGraphics = Graphics.FromHwnd(pictureBoxStimulus.Handle);
                dPoint = new Point(dotXrelative - dotRadius, dotYrelative - dotRadius);
                rect = new Rectangle(dPoint, new Size(2 * dotRadius, 2 * dotRadius));
                if(eyeSelected == EyeOption.Left)
                    newGraphics.FillRectangle(brush, rect);
                else
                    newGraphics.FillEllipse(brush, rect);

                newGraphics.Dispose();
            }
            //else
            {
                SolidBrush brush;
                Graphics newGraphics;
                Rectangle rect;
                Point dPoint;

                //brush = new SolidBrush(Color.Black);
                brush = new SolidBrush(dotColor);
                newGraphics = formulario.CreateGraphics();
                dPoint = new Point(dotXrelative + pictureBoxStimulus.Location.X - dotRadius, dotYrelative + pictureBoxStimulus.Location.Y - dotRadius);
                rect = new Rectangle(dPoint, new Size(2 * dotRadius, 2 * dotRadius));
                if (eyeSelected == EyeOption.Left) 
                    newGraphics.FillRectangle(brush, rect);
                else
                    newGraphics.FillEllipse(brush, rect);

                newGraphics.Dispose();
            }

            //newGraphics.FillEllipse(brush, rect);
            //newGraphics.Dispose();
        }

        private static bool isDotOverPictureBox(Point dot, Size stimulusSize, Point stimulusLocation)
        {
            if (
                dot.X > stimulusLocation.X &&
                dot.X < (stimulusLocation.X + stimulusSize.Width) &&
                dot.Y > stimulusLocation.Y &&
                dot.Y < (stimulusLocation.Y + stimulusSize.Height)
              )
                return true;
            else
                return false;
        }


        public static void plotLinesBetweenFixs(List<Point> fixDataList, Color lineColor, Form formulario, PictureBox pictureBoxStimulus, Size stimulusSize, Point stimulusLocation)
        {
            Color tempLineColor;
            bool firstFix = true;
            Point previousFix = new Point();

            for (int indexFix = 0; indexFix < fixDataList.Count; indexFix++)
            {
                if (firstFix)
                {
                    previousFix = new Point(fixDataList[indexFix].X, fixDataList[indexFix].Y);
                    firstFix = false;
                }
                else
                {
                    Point currentFix = new Point(fixDataList[indexFix].X, fixDataList[indexFix].Y);

                    if (RegressionDetector.RegressionDetector.esUnaRegresion(currentFix, previousFix))
                        tempLineColor = Color.Red;
                    else
                        tempLineColor = lineColor;

                    plotLine(currentFix.X, currentFix.Y, previousFix.X, previousFix.Y, tempLineColor, formulario, pictureBoxStimulus, stimulusSize, stimulusLocation);
                    previousFix = currentFix;
                }
            }
        }

        public static void plotLine(int currentFixX, int currentFixY, int previousFixX, int previousFixY, Color lineColor, Form formulario, PictureBox pictureBoxStimulus, Size stimulusSize, Point stimulusLocation)
        {
            //posicion relativa a la esquina superior izquierda del pictureBoxStimulus
            int currentFixXrelative = (int)((double)(currentFixX - stimulusLocation.X) * (double)pictureBoxStimulus.Size.Width / (double)stimulusSize.Width);
            int currentFixYrelative = (int)((double)(currentFixY - stimulusLocation.Y) * (double)pictureBoxStimulus.Size.Height / (double)stimulusSize.Height);
            int previousFixXrelative = (int)((double)(previousFixX - stimulusLocation.X) * (double)pictureBoxStimulus.Size.Width / (double)stimulusSize.Width);
            int previousFixYrelative = (int)((double)(previousFixY - stimulusLocation.Y) * (double)pictureBoxStimulus.Size.Height / (double)stimulusSize.Height);

            //bool currentDotOverPictureBox = isDotOverPictureBox(currentFixX, currentFixY, stimulusLocation.X, stimulusLocation.Y, stimulusSize.Width, stimulusSize.Height);
            //bool previousDotOverPictureBox = isDotOverPictureBox(previousFixX, previousFixY, stimulusLocation.X, stimulusLocation.Y, stimulusSize.Width, stimulusSize.Height);

            //se grafican tanto sobre el picturebox como sobre el form que total si no se puede no grafica
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
                //Pen myPen = new Pen(Color.Black);
                Pen myPen = new Pen(lineColor);
                Graphics g = formulario.CreateGraphics();

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





        public static bool loadImage2Control(bool testDataFound, TestData1 testData, PictureBox pictureBoxStimulus)
        {
            /*
             * leer testdata.imagen
             * en funcion de lo que se lee se carga en el picture box            
             */

            if (testDataFound)
            {

                if (Varios.ImageDictionary.Image2ReadDictionary.ContainsKey(testData.image2read))
                {
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

    }
}
