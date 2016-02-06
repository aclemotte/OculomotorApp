using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using LookAndPlayForm.Utility;
using LookAndPlayForm.DataBase;

namespace LookAndPlayForm.InstitutionID
{
    public class institution_class_engine
    {
        private string rootPath = CData.DataFolder + @"\";

        public List<institution_class_data> institutionsList { get; set; }

        public institution_class_engine()
        {
            //bool rootFolder = rootFolderExist();
            //bool userFile = institutionsFileExist(rootFolder);
            load();
        }

        private void load()
        {
            institutionsList = DataBaseWorker.LoadInstitutions();
        }

        public void updateDataBase(System.Windows.Forms.NumericUpDown numericUpDownInstitutionID, institution_class_data institutionDataSelected)
        {
            try
            {
                if (institutionsList != null && institutionsList.Count > 0)
                {
                    if (numericUpDownInstitutionID.Value > Convert.ToDecimal(institutionsList.Last().institution_id))
                    {
                        DataBaseWorker.AddInstitution(institutionDataSelected);
                    }
                }
                else
                {
                    institutionsList = new List<institution_class_data>();
                    institutionsList.Add(institutionDataSelected);
                    DataBaseWorker.AddInstitution(institutionDataSelected);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        /*
        public void updateCsv(System.Windows.Forms.NumericUpDown numericUpDownInstitutionID, institution_class_data institutionDataSelected)
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
            else//caso de que no haya ninguna institucion aun
            {
                institutionsList = new List<institution_class_data>();
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
                        institutionsList = reader1.GetRecords<institution_class_data>().ToList();
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
        }*/

    }
}
