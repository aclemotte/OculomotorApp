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

        public static List<GazePositionAndTimeClass> getGazePositionAndTimeList(eyetrackerDataEyeX eyetrackerDataL, TestData1 testData, eye fromEye)
        {
            List<GazePositionAndTimeClass> gazePositionAndTime = new List<GazePositionAndTimeClass>();
            double timeSegundosInicial = 0;
            double timeSegundos = 0;

            if (fromEye == eye.left)
            {
                for (var indiceSample = 0; indiceSample < eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL.Count; indiceSample++)
                {
                    int gazeX = (int)(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.X * (double)testData.screen_Width);
                    int gazeY = (int)(eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.Y * (double)testData.screen_Height);

                    if (indiceSample == 0)
                    {
                        timeSegundos = 0;
                        timeSegundosInicial = (double)eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Timestamp / (double)1000000.0;
                    }
                    else
                    {
                        timeSegundos = ((double)eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Timestamp / (double)1000000.0) - timeSegundosInicial;
                    }

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

                    if (indiceSample == 0)
                    {
                        timeSegundos = 0;
                        timeSegundosInicial = (double)eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Timestamp / (double)1000000.0;
                    }
                    else
                    {
                        timeSegundos = ((double)eyetrackerDataL.targetTraceL[settings.indiceTrial].gazeDataItemL[indiceSample].Timestamp / (double)1000000.0) - timeSegundosInicial;
                    }

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

        public static TestData1 loadTestDataFromJson(string path)
        {
            TestData1 testData = null;
            string file = @"\testData.json";

            if (File.Exists(path + file))
            {
                string json = File.ReadAllText(path + file);
                testData = JsonConvert.DeserializeObject<TestData1>(json);
            }
            return testData;
        }

        public static bool testDataFound(TestData1 testData)
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

        public static TestPersuit.StimuloPersuitSetup loadPersuitDataFromJson(string path)
        {
            TestPersuit.StimuloPersuitSetup stimuloPersuitSetup = null;
            string file = @"\persuitData.json";

            if (File.Exists(path + file))
            {
                string json = File.ReadAllText(path + file);
                stimuloPersuitSetup = JsonConvert.DeserializeObject<TestPersuit.StimuloPersuitSetup>(json);
            }
            return stimuloPersuitSetup;
        }

        public static bool persuitDataFound(TestPersuit.StimuloPersuitSetup stimuloPersuitSetup)
        {
            if (stimuloPersuitSetup == null)
                return false;
            else
                return true;
        }
    }
}
