using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using LookAndPlayForm.FixDetector;

namespace LookAndPlayForm.Resumen
{

    public static class class4Graphic
    {
        
        public static List<Point> getGazeData2List(eyetrackerDataEyeX eyetrackerDataL, TestData testData, eye fromEye)
        {

            List<Point> gazeDataDoubleList = new List<Point>();

            if (fromEye == eye.left)
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

            if (fromEye == eye.right)
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


        public static List<Point> fixData2List(fixationData fixData, eye fromEye)
        {
            List<Point> fixDataList = new List<Point>();

            if (fromEye == eye.left)
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

            if (fromEye == eye.right)
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

    }
}
