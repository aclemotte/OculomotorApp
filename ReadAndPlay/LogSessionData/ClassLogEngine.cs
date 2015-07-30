using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookAndPlayForm.LogData
{
    class ClassLogEngine
    {

        public static void Log(ClassLogData data)
        {
            string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";

            using (StreamWriter writer = File.AppendText(rootPath + @"log.txt"))
            {
                writer.WriteLine(
                    data.Date + "," + 
                    data.Time_start + "," + 
                    data.Time_end + "," + 
                    data.Tester + "," + 
                    data.Patient + "," +
                    data.number_of_screening_done + "," + 
                    data.AssemblyVersion);
            }
        }
    }
}
