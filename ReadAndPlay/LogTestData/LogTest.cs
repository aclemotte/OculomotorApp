using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace LookAndPlayForm
{
    public class LogTest
    {
        public TestData2 testData { get; set; }

        public LogTest()
        {
            testData = new TestData2();
        }

        public void saveData2File()
        {

            testData.screen_Height = Screen.PrimaryScreen.Bounds.Height;
            testData.screen_Width = Screen.PrimaryScreen.Bounds.Width;
            testData.date = String.Format("{0:u}", DateTime.Now);//yyyy'-'MM'-'dd HH':'mm':'ss'Z'
            testData.eyetracker = Program.datosCompartidos.EyeTrackerInfo;
            //testData.pointer_type = "eyetracker"; // settings.pointercontroltypeSelected.ToString();
            //testData.blink_time_min = 0;
            //testData.blink_time_max = 0;
            //testData.dwell_area = settings.DwellArea;
            //testData.dwell_time = settings.DwellTime;
            //testData.dewll_time_latency = settings.DwellLatency;
            testData.calibration_error_left_px = Program.datosCompartidos.meanCalibrationErrorLeftPx;
            testData.calibration_error_right_px = Program.datosCompartidos.meanCalibrationErrorRightPx;
            testData.filter_type = settings.filtertypeSelected.ToString();
            testData.typeTestDone = Program.datosCompartidos.testSelected;
            testData.readingTestTypeDone = Program.datosCompartidos.readingTestTypeSelected;
            testData.image2read = Program.datosCompartidos.image2read;
            testData.assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\" +
                            LookAndPlayForm.Program.datosCompartidos.startTimeTest + 
                            @"-us" + Program.datosCompartidos.activeUser + @"\";

            bool exists = System.IO.Directory.Exists(path);

            if (!exists)
                System.IO.Directory.CreateDirectory(path);

            File.WriteAllText(path + @"testData.json", JsonConvert.SerializeObject(testData));
        }
    }
}
