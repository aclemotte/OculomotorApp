using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using LookAndPlayForm.LogEyeTracker;
using Newtonsoft.Json;

namespace LookAndPlayForm.Review
{
    public static class ReviewClass
    {
        public class GazePositionAndTimeClass
        {
            public Point gazePosition;
            public double timeSegundos;

            public GazePositionAndTimeClass(Point gazePosition, double timeSegundos)
            {
                this.gazePosition = gazePosition;
                this.timeSegundos = timeSegundos;
            }
        }

        public static List<GazePositionAndTimeClass> getGazePositionAndTimeList(eyetrackerDataEyeX eyetrackerDataL, TestData testData, eye fromEye)
        {
            List<GazePositionAndTimeClass> gazePositionAndTime = new List<GazePositionAndTimeClass>();

            if (fromEye == eye.left)
            {
                for (var indiceSample = 0; indiceSample < eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL.Count; indiceSample++)
                {
                    int gazeX = (int)(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.X * (double)testData.screen_Width);
                    int gazeY = (int)(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.Y * (double)testData.screen_Height);
                    double timeSegundos = (double)eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Timestamp/(double)1000000.0;
                    if (
                        !double.IsNaN(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.X)
                        && !double.IsNaN(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.Y)
                        )
                    {
                        gazePositionAndTime.Add(new GazePositionAndTimeClass(new Point(gazeX, gazeY), timeSegundos));
                    }
                }
            }

            if (fromEye == eye.right)
            {
                for (var indiceSample = 0; indiceSample < eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL.Count; indiceSample++)
                {
                    int gazeX = (int)(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.X * (double)testData.screen_Width);
                    int gazeY = (int)(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.Y * (double)testData.screen_Height);
                    double timeSegundos = (double)eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Timestamp / (double)1000000.0;

                    if (
                        !double.IsNaN(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.X)
                        && !double.IsNaN(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.Y)
                        )
                    {
                        gazePositionAndTime.Add(new GazePositionAndTimeClass(new Point(gazeX, gazeY), timeSegundos));
                    }
                }
            }

            return gazePositionAndTime;
        }

        public static eyetrackerDataEyeX loadEyetrackerDataFromJson(string path)
        {
            eyetrackerDataEyeX eyetrackerDataL;
            eyetrackerDataL.targetTraceL = null;
            string file = @"\eyetrackerData.json";

            if (File.Exists(path + file))
            {
                string json = File.ReadAllText(path + file);
                eyetrackerDataL = JsonConvert.DeserializeObject<eyetrackerDataEyeX>(json);
            }
            return eyetrackerDataL;
        }

        public static TestData loadTestDataFromJson(string path)
        {
            TestData testData = null;
            string file = @"\testData.json";

            if (File.Exists(path + file))
            {
                string json = File.ReadAllText(path + file);
                testData = JsonConvert.DeserializeObject<TestData>(json);
            }
            return testData;
        }

        public static bool testDataFound(TestData testData)
        {
            if (testData == null)
                return false;
            else
                return true;
        }

        public static bool eyetrackerDataFound(eyetrackerDataEyeX eyetrackerDataL)
        {
            if (eyetrackerDataL.targetTraceL == null)
                return false;
            else
                return true;
        }
    }
}
