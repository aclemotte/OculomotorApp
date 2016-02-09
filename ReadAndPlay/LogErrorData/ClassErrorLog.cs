using LookAndPlayForm.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LookAndPlayForm.ErrorLog
{
    public static class ErrorLog
    {
        public static void toErrorFile(string errorMsg)
        {
            /*si no existe el archivo
                crear el archivo de registro
         
             agregar el mensage de error con la fecha
             */

            string rootPath = CData.DataFolder + @"\";

            using (StreamWriter writer = File.AppendText(rootPath + @"error.txt"))
            {
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ": " + errorMsg);
            }
        }
    }
}
