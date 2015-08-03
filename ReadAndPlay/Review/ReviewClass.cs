using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LookAndPlayForm.LogEyeTracker;
using Newtonsoft.Json;

namespace LookAndPlayForm.Review
{
    public static class ReviewClass
    {
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
    }
}
