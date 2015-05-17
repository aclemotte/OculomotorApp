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
        public LogEyeTracker LogData { get; set; }
        public bool eyeNotFound { get; set; }
        public  System.Drawing.Rectangle monitorBounds { get; set; }
        public string activeUser { get; set; }
        public bool updateCsv { get; set; }
        public string image2read { get; set; }
        public string startTime { get; set; }

        public sharedData()
        {
            eyeNotFound = true;
            updateCsv = false;
            getDisplaySelected();
            image2read = "TextoIn2.png";
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
        
        /// <summary>
        /// Cada vez que se inicia un nuevo test antes de comenzar el test se llama a este metodo para que genere un nuevo valor para startTime
        /// </summary>
        public void getNewTime()
        {
            startTime = Varios.functions.getCurrentTime();
        }
    }
}
