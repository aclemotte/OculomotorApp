using LookAndPlayForm.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tobii.Gaze.Core;

namespace LookAndPlayForm
{
    public class SharedData
    {
        public int meanCalibrationErrorLeftPx { get; set; }
        public int meanCalibrationErrorRightPx { get; set; }
        public string EyeTrackerInfo { get; set; }
        public Tobii.Gaze.Core.Calibration calibrationDataEyeX { get; set; }
        public LogEyeTracker.LogEyeTracker LogEyeTrackerData { get; set; }
        public LogTest logTestData { get; set; }
        public bool eyeNotFound { get; set; }
        public string activeUser { get; set; }
        public string activeTester { get; set; }
        public string image2read { get; set; }
        public string startTimeTest { get; set; }//ojo que se pueden correr varios test sin cerrar la app
        public TestType testSelected { get; set; }
        public ReadingTestType readingTestTypeSelected { get; set; }
        public string institutionName { get; set; }

        public bool no_se_cancelo_el_test { get; set; }


        public SharedData()
        {
            eyeNotFound = true;
            image2read = "";
            startTimeTest = DataConverter.GetCurrentTime();
        }

        /// <summary>
        /// Cada vez que se inicia un nuevo test antes de comenzar el test se llama a este metodo para que genere un nuevo valor para startTime
        /// </summary>
        public void getNewTime()
        {
            startTimeTest = DataConverter.GetCurrentTime();
        }
    }
}
