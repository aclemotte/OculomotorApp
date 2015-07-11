using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace LookAndPlayForm.InstitutionID
{
    public class institution_class_engine
    {
        private string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";

        public List<intitution_class_data> institutionsList { get; set; }





        public institution_class_engine()
        {
            bool rootFolder = rootFolderExist();
            bool userFile = institutionsFileExist(rootFolder);
        }

        public void updateCsv(System.Windows.Forms.NumericUpDown numericUpDownInstitutionID, intitution_class_data institutionDataSelected)
        {
            if (institutionsList != null)
            {

                //caso que se haya introducido un nuevo usuario, se almacena en la lista y luego se guarda la lista
                if (numericUpDownInstitutionID.Value > Convert.ToDecimal(institutionsList.Last().institution_id))
                {
                    institutionsList.Add(institutionDataSelected);

                    using (var sw = new StreamWriter(rootPath + @"institutions.csv"))
                    {
                        var writer = new CsvWriter(sw);
                        //Write the entire contents of the CSV file into another
                        writer.WriteRecords(institutionsList);
                    }
                }
            }
            else
            {
                institutionsList = new List<intitution_class_data>();
                institutionsList.Add(institutionDataSelected);

                using (var sw = new StreamWriter(rootPath + @"institutions.csv"))
                {
                    var writer = new CsvWriter(sw);
                    //Write the entire contents of the CSV file into another
                    writer.WriteRecords(institutionsList);
                }
            }
        }




        private bool institutionsFileExist(bool rootFolder)
        {
            if (File.Exists(rootPath + @"institutions.csv"))
            {
                using (var sr1 = new StreamReader(rootPath + @"institutions.csv"))
                {
                    var reader1 = new CsvReader(sr1);
                    try
                    {
                        institutionsList = reader1.GetRecords<intitution_class_data>().ToList();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        File.WriteAllText("lastError.txt", string.Format("Last Error @{0}: {1}", DateTime.Now, ex.GetBaseException()));
                        return false;
                    }
                }

            }
            else
            {
                Console.WriteLine("institutions.csv no existe");
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
