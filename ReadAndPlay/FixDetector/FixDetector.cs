using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FixDet;
using Newtonsoft.Json;

namespace LookAndPlayForm.FixDetector
{


    class FixDetector
    {

        FixDetectorClass fixationDetector;
        fixationData fixData;

        eyetrackerDataEyeX eyetrackerDatajson;
        TestData testDatajson;

        string path;
        string eyetrackerData = string.Empty;
        string testData = string.Empty; 

        enum processingEyeOptions
        {
            leftAndRight, leftOnly, rightOnly
        }

        processingEyeOptions processingEye;
        
        
        public FixDetector(string path)
        {

            this.path = path;
            fixData = new fixationData();

            fixationDetector = new FixDetectorClass();
            fixationDetector.FixationStart += fixationDetector_FixationStart;
            fixationDetector.FixationEnd += fixationDetector_FixationEnd;
            //fixationDetector.FixationUpdate += fixationDetector_FixationUpdate;


            //fixationDetector.Analyzer = EFDAnalyzer.fdaFixationSize;
            //fixationDetector.FixationRadius = 60;
            //fixationDetector.NoiseFilter = 1;
            //fixationDetector.Filter = EFDFilter.fdfAveraging;
            //fixationDetector.MinFixDuration = 100;
            //fixationDetector.FilterBufferSize = 20;
            //fixationDetector.UpdateInterval = 100;


            //Analyzer
            fixationDetector.Analyzer = EFDAnalyzer.fdaFixationSize;
            //fixationDetector.Analyzer = EFDAnalyzer.fdaDispersion;
            //fixationDetector.Analyzer = EFDAnalyzer.fdaSpeed;

            //Filter 
            fixationDetector.Filter = EFDFilter.fdfNone;
            //fixationDetector.Filter = EFDFilter.fdfAveraging;
            //fixationDetector.Filter = EFDFilter.fdfWeightedAvg;

            fixationDetector.MinFixDuration = 30;//0-300
            //fixationDetector.FilterBufferSize = 10;//2-1000
            //fixationDetector.FilterWeight = 0.5f; //se usa con el filtro EFDFilter.fdfWeightedAvg
            fixationDetector.UpdateInterval = 1000;//100-1000

            //EFDAnalyzer.fdaFixationSize
            fixationDetector.FixationRadius = 40;
            fixationDetector.NoiseFilter = 0;

            //EFDAnalyzer.fdaSpeed
            fixationDetector.SpeedThreshold = 100;//100-1000
            fixationDetector.AccelerationThreshold = 2000;//1000-10000
            fixationDetector.SpeedBufferSize = 10;//3-10
            
            //EFDAnalyzer.fdaDispersion
            fixationDetector.MaxDispersion = 20;//15-100
            fixationDetector.WindowSize = 5;//2-50

            if (file2String())
            {
                string2Json();
                processData();
                saveData2File();

                fixData.clearAllList();
            }
        }

        
        
        
        
        
        void saveData2File()
        {
            File.WriteAllText(path + @"\fixData.json", JsonConvert.SerializeObject(fixData));
        }
        
        bool file2String()
        {
            Console.WriteLine("FixDetector. Path: " + path);

            try
            {
                eyetrackerData = File.ReadAllText(path + @"\eyetrackerData.json");
                testData = File.ReadAllText(path + @"\testData.json");
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException)
                {
                    Console.WriteLine("FixDetector. No se encontro el archivo eyetrackerData.json o testData.json");
                    return false;
                }
            }

            Console.WriteLine("FixDetector. Files 2 string: done");
            return true;
        }

        void string2Json()
        {
            try
            {
                eyetrackerDatajson = JsonConvert.DeserializeObject<eyetrackerDataEyeX>(eyetrackerData);
                testDatajson = JsonConvert.DeserializeObject<TestData>(testData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("FixDetector. Problemas con JsonDeserialize: " + ex.ToString());
                return;
            }

            Console.WriteLine("FixDetector. String 2 json: done");
        }

        void processData()
        {
            var indiceTrial = 0;

            //gazeWeigthedL
            processingEye = processingEyeOptions.leftAndRight;
            fixationDetector.init();

            for (var indiceSample = 0; indiceSample < eyetrackerDatajson.targetTraceL[indiceTrial].gazeWeigthedL.Count; indiceSample++)
            {
                if (
                    validGazeData(
                        eyetrackerDatajson.targetTraceL[indiceTrial].gazeWeigthedL[indiceSample].X,
                        eyetrackerDatajson.targetTraceL[indiceTrial].gazeWeigthedL[indiceSample].Y
                                 )
                    )
                {
                    fixationDetector.addPoint(
                       convertirTimeStampMicro2Milli(eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Timestamp),
                       (int)(eyetrackerDatajson.targetTraceL[indiceTrial].gazeWeigthedL[indiceSample].X * (double)testDatajson.screen_Width),
                       (int)(eyetrackerDatajson.targetTraceL[indiceTrial].gazeWeigthedL[indiceSample].Y * (double)testDatajson.screen_Height)
                        );
                }
            }

            fixationDetector.finalize();
            Console.WriteLine("FixDetector. Process data gazeWeigthedL: done");

            
            
            //Left
            processingEye = processingEyeOptions.leftOnly;
            fixationDetector.init();

            for (var indiceSample = 0; indiceSample < eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL.Count; indiceSample++)
            {
                if (
                    validGazeData(
                        eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.X,
                        eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.Y
                                 )
                    )
                {
                    fixationDetector.addPoint(
                       convertirTimeStampMicro2Milli(eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Timestamp),
                       (int)(eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.X * (double)testDatajson.screen_Width),
                       (int)(eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Left.GazePointOnDisplayNormalized.Y * (double)testDatajson.screen_Height)
                        );
                }
            }

            fixationDetector.finalize();
            Console.WriteLine("FixDetector. Process data Left: done");
            
            
            
            //Right
            processingEye = processingEyeOptions.rightOnly;
            fixationDetector.init();

            for (var indiceSample = 0; indiceSample < eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL.Count; indiceSample++)
            {
                if (
                    validGazeData(
                        eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.X,
                        eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.Y
                                 )
                    )
                {
                    fixationDetector.addPoint(
                       convertirTimeStampMicro2Milli(eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Timestamp),
                       (int)(eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.X * (double)testDatajson.screen_Width),
                       (int)(eyetrackerDatajson.targetTraceL[indiceTrial].gazeDataItemL[indiceSample].Right.GazePointOnDisplayNormalized.Y * (double)testDatajson.screen_Height)
                        );
                }
            }

            fixationDetector.finalize();
            Console.WriteLine("FixDetector. Process data Right: done");
        }
        
        int convertirTimeStampMicro2Milli(long timeStampMicro)
        {
            int timeStampMili = (int)(timeStampMicro / (long)1000);
            return timeStampMili;
        }

        bool validGazeData(double gazeX, double gazeY)
        {
            if (!double.IsNaN(gazeX) && !double.IsNaN(gazeY) && Math.Abs(gazeX) > 0.001 && Math.Abs(gazeY) > 0.001)
                return true;
            else
                return false;
        }
        
        
        
        
        //Eventos fix detector spakov
        void fixationDetector_FixationEnd(int aTime, int aDuration, int aX, int aY)
        {
            fixationDataPoint fix = new fixationDataPoint();
            fix.fixationData = fixationDetector.LastFixation;
            fix.fixationState = stateFixationData.end;
            
            switch (processingEye)
            {
                case processingEyeOptions.leftAndRight:
                    fixData.fixationDataPointLandR.Add(fix);
                    break;
                case processingEyeOptions.leftOnly:
                    fixData.fixationDataPointLeft.Add(fix);
                    break;
                case processingEyeOptions.rightOnly:
                    fixData.fixationDataPointRight.Add(fix);
                    break;
            }
        }

        void fixationDetector_FixationStart(int aTime, int aDuration, int aX, int aY)
        {
            fixationDataPoint fix = new fixationDataPoint();
            fix.fixationData = fixationDetector.LastFixation;
            fix.fixationState = stateFixationData.start;

            switch(processingEye)
            {
                case processingEyeOptions.leftAndRight:
                    fixData.fixationDataPointLandR.Add(fix);
                    break;
                case processingEyeOptions.leftOnly:
                    fixData.fixationDataPointLeft.Add(fix);
                    break;
                case processingEyeOptions.rightOnly:
                    fixData.fixationDataPointRight.Add(fix);
                    break;
            }
            
        }
    }
}
