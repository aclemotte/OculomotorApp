using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsvHelper;

namespace LookAndPlayForm.TesterID
{
    public class TesterLoginEngine
    {
        private string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";
        
        public List<TesterLoginEngineData> testersList { get; set; }
        




        public TesterLoginEngine()
        {
            bool rootFolder = rootFolderExist();
            bool userFile = testersFileExist(rootFolder);
        }

        public void updateCsv(NumericUpDown numericUpDownTesterID, TesterLoginEngineData testerDataSelected)
        {
            if (testersList != null)
            {

                //caso que se haya introducido un nuevo usuario, se almacena en la lista y luego se guarda la lista
                if (numericUpDownTesterID.Value > Convert.ToDecimal(testersList.Last().tester_id))
                {
                    testersList.Add(testerDataSelected);

                    using (var sw = new StreamWriter(rootPath + @"testers.csv"))
                    {
                        var writer = new CsvWriter(sw);
                        //Write the entire contents of the CSV file into another
                        writer.WriteRecords(testersList);
                    }
                }
            }
            else
            {
                testersList = new List<TesterLoginEngineData>();
                testersList.Add(testerDataSelected);

                using (var sw = new StreamWriter(rootPath + @"testers.csv"))
                {
                    var writer = new CsvWriter(sw);
                    //Write the entire contents of the CSV file into another
                    writer.WriteRecords(testersList);
                }
            }

        }




        private bool testersFileExist(bool rootFolder)
        {
            if (File.Exists(rootPath + @"testers.csv"))
            {
                using (var sr1 = new StreamReader(rootPath + @"testers.csv"))
                {
                    var reader1 = new CsvReader(sr1);
                    try
                    {
                        testersList = reader1.GetRecords<TesterLoginEngineData>().ToList();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        //File.WriteAllText("lastError.txt", string.Format("Last Error @{0}: {1}", DateTime.Now, ex.GetBaseException()));
                        ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                        return false;
                    }
                }

            }
            else
            {
                Console.WriteLine("testers.csv no existe");
                return false;
            }
        }

        private bool rootFolderExist()
        {
            if (Directory.Exists(rootPath))
            {
                return true;
            }
            else
            {
                Console.WriteLine(rootPath + " folder no existe");
                Directory.CreateDirectory(rootPath);
                return false;
            }
        }
    }
}
