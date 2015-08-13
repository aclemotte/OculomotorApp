using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsvHelper;

namespace LookAndPlayForm.TesterID
{
    public partial class TesterLoginForm : Form
    {

        private string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";

        public bool newUser { get; set; }
        public TesterLoginEngineData testerDataSelected { get; set; }
        public List<TesterLoginEngineData> testersList { get; set; }
        public bool closeApp { get; set; }





        public TesterLoginForm()
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();            
            closeApp = true;

            bool rootFolder = rootFolderExist();
            bool userFile = testersFileExist(rootFolder);
            testers2Form();
        }

        public void updateCsv()
        {
            if (testersList != null)
            {

                //caso que se haya introducido un nuevo usuario, 
                //se almacena en la lista el nuevo usuario y 
                //se guarda la lista en un archivo csv
                if (numericUpDownTesterID.Value > Convert.ToDecimal(testersList.Last().tester_id))
                {
                    testersList.Add(testerDataSelected);

                    reWriteCsv();
                }
            }
            else
            {
                testersList = new List<TesterLoginEngineData>();
                testersList.Add(testerDataSelected);

                reWriteCsv();
            }
        }

        private void reWriteCsv()
        {
            using (var sw = new StreamWriter(rootPath + @"testers.csv"))
            {
                var writer = new CsvWriter(sw);
                //Write the entire contents of the CSV file into another
                writer.WriteRecords(testersList);
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

        private bool testers2Form()
        {
            if(testersList != null)
            {
                numericUpDownTesterID.Maximum = Convert.ToDecimal(testersList.Last().tester_id);
                numericUpDownTesterID.Value = Convert.ToDecimal(testersList.Last().tester_id);
            }
            //sino se queda en cero que es lo que esta por defecto
            return true;
        }




        private void numericUpDownTesterID_ValueChanged(object sender, EventArgs e)
        {
            if (testersList != null)
            {
                if (numericUpDownTesterID.Value <= Convert.ToDecimal(testersList.Last().tester_id))
                {
                    int userIndex = Convert.ToInt32(numericUpDownTesterID.Value) - 1;
                    textBoxTesterName.Text = testersList[userIndex].tester_name;
                    textBoxTesterName.ReadOnly = true;
                }
            }
        }
        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(numericUpDownTesterID.Value > 0)
            {
                testerDataSelected = new TesterLoginEngineData();
                testerDataSelected.tester_id = numericUpDownTesterID.Value.ToString();
                testerDataSelected.tester_name = textBoxTesterName.Text;
                closeApp = false;                
            }
            else
            {
                MessageBox.Show("To continue, enter a new tester.", "Empty list of testers.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }
        
        private void buttonNewTester_Click(object sender, EventArgs e)
        {
            decimal newUserID;

            if (testersList != null)
            {
                newUserID = Convert.ToDecimal(testersList.Last().tester_id) + 1;
            }
            else
            {
                newUserID = 1;
            }

            TesterNewForm.TesterNewForm testerNewForm = new TesterNewForm.TesterNewForm(newUserID);
            testerNewForm.ShowDialog();
            newUser = testerNewForm.newUser;

            if (newUser)
            {
                testerDataSelected = testerNewForm.testerDataSelected;
                newUser2Form();//cargar datos del nuevo usuario al form
            }

            testerNewForm.Dispose();
            testerNewForm = null;
        }

        private void newUser2Form()
        {
            numericUpDownTesterID.Maximum = Convert.ToDecimal(testerDataSelected.tester_id);
            numericUpDownTesterID.Value = Convert.ToDecimal(testerDataSelected.tester_id);
            textBoxTesterName.Text = testerDataSelected.tester_name;
        }
    }
}
