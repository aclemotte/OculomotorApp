using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tobii.Gaze.Core;

namespace LookAndPlayForm
{
    //el que instancio esta clase es EyeTrackingEngine
    public class sharedData
    {
        public int meanCalibrationErrorLeftPx { get; set; }
        public int meanCalibrationErrorRightPx { get; set; }
        //public double averageErrorDegreeLeft { get; set; }
        //public double averageErrorDegreeRight { get; set; }
        public string EyeTrackerInfo { get; set; }
        public Tobii.Gaze.Core.Calibration calibrationDataEyeX { get; set; }
        //public TETCSharpClient.Data.CalibrationResult calibrationDataEyeTribe { get; set; }
        public LogEyeTracker LogData { get; set; }
        public bool eyeNotFound { get; set; }
        public  System.Drawing.Rectangle monitorBounds { get; set; }
        //public SaveFileDialog pathFile;

        public sharedData()
        {
            eyeNotFound = true;
            getDisplaySelected();
        }

        private void getDisplaySelected()
        {
            ////si se selecciona el monitor externo
            //if (radioButtonDisplay2.Checked)
            //    monitorBounds = Screen.AllScreens[1].Bounds;

            ////si se selecciona el monitor propio
            //if (radioButtonDisplay1.Checked)
                monitorBounds = Screen.AllScreens[0].Bounds;

        }

        public string startTime = Varios.functions.getCurrentTime();
        public string activeUser {get; set;}
        public bool updateCsv = false;

        public string image2read = "TextoIn2.png";
    }
}
