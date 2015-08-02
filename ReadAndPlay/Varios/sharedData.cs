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
        public string EyeTrackerInfo { get; set; }
        public Tobii.Gaze.Core.Calibration calibrationDataEyeX { get; set; }
        public LogEyeTracker LogEyeTrackerData { get; set; }
        public LogTest logTestData { get; set; }
        public bool eyeNotFound { get; set; }
        public string activeUser { get; set; }
        public string image2read { get; set; }
        public string startTimeTest { get; set; }//ojo que se pueden correr varios test sin cerrar la app
        public int number_of_screening_done { get; set; }

        public SelectTest.FormSelectionTest.testType testSelected { get; set; }

        public sharedData()
        {
            eyeNotFound = true;
            image2read = "";
            startTimeTest = Varios.functions.getCurrentTime();
            number_of_screening_done = 0;
        }
        
        /// <summary>
        /// Cada vez que se inicia un nuevo test antes de comenzar el test se llama a este metodo para que genere un nuevo valor para startTime
        /// </summary>
        public void getNewTime()
        {
            startTimeTest = Varios.functions.getCurrentTime();
        }
    }
}
