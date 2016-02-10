using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using LookAndPlayForm.Utility;
using LookAndPlayForm.DataBase;
using System.Globalization;

namespace LookAndPlayForm
{
    /// <summary>
    /// 
    /// </summary>
    public class LogTest
    {
        /// Properties
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public OutputTestData2 testData { get; set; }

        #endregion

        /// Init
        #region Init

        /// <summary>
        /// 
        /// </summary>
        public LogTest()
        {
            testData = new OutputTestData2();
        }

        #endregion

        /// Functions
        #region Functions

        /// <summary>
        /// 
        /// </summary>
        public void saveData2File()
        {

            testData.screen_Height = Screen.PrimaryScreen.Bounds.Height;
            testData.screen_Width = Screen.PrimaryScreen.Bounds.Width;
            testData.date = Program.datosCompartidos.startTimeTest;
            testData.date_loc = DataConverter.LocalDateFromUTC(Program.datosCompartidos.startTimeTest);
            testData.eyetracker = Program.datosCompartidos.EyeTrackerInfo;
            testData.user_id = Program.datosCompartidos.activeUser;
            testData.tester_id = Program.datosCompartidos.activeTester;
            testData.windows_username = Environment.UserName;
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

            DataBaseWorker.SaveTestData(testData, Program.datosCompartidos.activeUser, "");
        }

        #endregion
    }
}
