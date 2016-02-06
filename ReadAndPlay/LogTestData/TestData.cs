using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LookAndPlayForm
{
    public class TestData1
    {
        public int screen_Height { get; set; }
        public int screen_Width { get; set; }
        public string date { get; set; }
        public string eyetracker { get; set; }
        public string pointer_type { get; set; }
        public int blink_time_min { get; set; }
        public int blink_time_max { get; set; }
        public int dwell_area { get; set; }
        public int dwell_time { get; set; }
        public int dewll_time_latency { get; set; }
        public int calibration_error_left_px { get; set; }
        public int calibration_error_right_px { get; set; }
        public string filter_type { get; set; }
        public string image2read { get; set; }
    }

    public class OutputTestData2
    {
        public int screen_Height { get; set; }
        public int screen_Width { get; set; }
        public string date { get; set; }

        public string date_loc { get; set; }
        public string user_id { get; set; }
        public string tester_id { get; set; }

        public string windows_username { get; set; }
        public string eyetracker { get; set; }
        public int calibration_error_left_px { get; set; }
        public int calibration_error_right_px { get; set; }
        public string filter_type { get; set; }
        public TestType typeTestDone { get; set; }
        public ReadingTestType readingTestTypeDone { get; set; }
        public string comments { get; set; }
        public string image2read { get; set; }
        public string assemblyVersion { get; set; }
    }
}
