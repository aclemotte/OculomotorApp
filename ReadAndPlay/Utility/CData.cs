using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LookAndPlayForm.Utility
{
    /// <summary>
    /// This class contains specific [constant] data and fields
    /// </summary>
    public class CData
    {
        public static string DataFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData"; // Data Folder path
        public static string DataBaseName = "MrPatchData.sqlite"; // DataBase name
        public static string DataBasePath = DataFolder + @"\" + DataBaseName; // full path to DB
        public static string PDFName = "Images.pdf";
        public static string PNGName = "Images.png";
        public static string ImagesFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    }
}
