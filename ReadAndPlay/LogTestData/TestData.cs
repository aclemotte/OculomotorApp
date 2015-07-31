using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LookAndPlayForm
{
    public class TestData
    {
        public int screen_Height;
        public int screen_Width;
        public string date;
        public string eyetracker;
        public string pointer_type;
        public int blink_time_min;
        public int blink_time_max;
        public int dwell_area;
        public int dwell_time;
        public int dewll_time_latency;
        public int calibration_error_left_px;
        public int calibration_error_right_px;
        public string filter_type;
        public string image2read;
    }

    public class TestData2
    {
        public int testdataVersion;
        public int screen_Height;
        public int screen_Width;
        public string date;
        public string eyetracker;
        public int calibration_error_left_px;
        public int calibration_error_right_px;
        public string filter_type;
        public string testDone;
        public string image2read;
        public string assemblyVersion;
    }
}
