using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LookAndPlayForm.Utility
{
    /// <summary>
    /// This class performs different conversions
    /// </summary>
    public class DataConverter
    {
        /// UnescapedString
        #region UnescapedString

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToUnescapedString(string input)
        {
            return input.Replace("'", "''").Replace("\"", "\"\"");
        }

        public static string FromUnescapedString(string input)
        {
            return input.Replace("''","'").Replace("\"\"", "\"");
        }

        #endregion

        #region DateTime

        /// <summary>
        /// 
        /// </summary>
        /// <param name="utc"></param>
        /// <returns></returns>
        public static string RemoveZ(string utc)
        {
            string res = utc.Substring(0, utc.LastIndexOf('Z')).Replace(" ", "T");
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="utc"></param>
        /// <returns></returns>
        public static string LocalDateFromUTC(string utc)
        {
            string res = string.Format("{0:s}", DateTime.Parse(utc).ToLocalTime());
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentTime()
        {
            return String.Format("{0:u}", DateTime.UtcNow);
        }

        #endregion

        /// TestData
        #region TestData

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data2"></param>
        /// <returns></returns>
        public static TestData1 TestData2ToTestData1(OutputTestData2 data2)
        {
            if (data2 == null)
                return null;

            TestData1 data1 = new TestData1();

            data1.calibration_error_left_px = data2.calibration_error_left_px;
            data1.calibration_error_right_px = data2.calibration_error_right_px;
            data1.date = data2.date;
            data1.eyetracker = data2.eyetracker;
            data1.filter_type = data2.filter_type;
            data1.image2read = data2.image2read;
            data1.screen_Height = data2.screen_Height;
            data1.screen_Width = data2.screen_Width;

            return data1;
        }

        #endregion
    }
}
