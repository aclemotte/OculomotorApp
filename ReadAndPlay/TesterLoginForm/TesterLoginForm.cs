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

        /* Casos:
         * 1. Sin el archivo testers. 
         *      Deshabilitar: boton Ok, comboBox y avisar que no hay ningun tester al inicio (solo es posible meter un nuevo usuario)
         * 2. Sin el archivo testers, darle a new tester y darle a cancel
         *      Volver a la ventana de login y listo
         * 3. Boton ok sin tester seleccionado
         *      Avisar
         * 4. Nuevo usuario. 
         *      Actualizar archivo de testers
         *      Pasar automaticamente de ventana
         * El ID del primer usuario es 1
         * La lista del ComboBox comienza con 0
         */


        private string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";
        private bool userFile;


        public bool newUser { get; set; }
        public TesterLoginEngineData testerDataSelected { get; set; }
        public List<TesterLoginEngineData> testersList { get; set; }
        public bool closeApp { get; set; }








        public TesterLoginForm()
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();            
            closeApp = true;

            bool rootFolder = rootFolderExist();//busca el directorio. sino existe lo crea
            userFile = testersFileExist(rootFolder);//buscar el archivo. sino existe NO lo crea. 
            
            if (userFile)
                testersFileData2Form();
            else
            {
                comboBoxTesters.Enabled = false;
                buttonOk.Enabled = false;
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

        private bool testersFileData2Form()
        {
            if(testersList != null)
            {
                int indexTester = 0;
                for (indexTester = 0; indexTester < testersList.Count; indexTester++ )
                {
                    comboBoxTesters.Items.Add(testersList[indexTester].tester_name);
                }
            }
            return true;
        }




        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (comboBoxTesters.SelectedItem != null)
            {
                testerDataSelected = new TesterLoginEngineData();
                testerDataSelected.tester_id = (comboBoxTesters.Items.IndexOf(comboBoxTesters.SelectedItem.ToString())+1).ToString();
                testerDataSelected.tester_name = comboBoxTesters.SelectedItem.ToString();
                closeApp = false;
            }
            else
            {
                MessageBox.Show("To continue, select a registered tester or register a new tester with the New tester button.", "Tester not found.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }
        
        private void buttonNewTester_Click(object sender, EventArgs e)
        {
            int newUserID;

            if (testersList != null)
            {
                newUserID = Convert.ToInt32(testersList.Last().tester_id) + 1;
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
                testerNewForm.Dispose();
                testerNewForm = null;
                testersList = new List<TesterLoginEngineData>();
                testersList.Add(testerDataSelected);
                updateTestersFile();
                pasarDeForm();
            }
            else
            {
                testerNewForm.Dispose();
                testerNewForm = null;
            }

        }

        private void updateTestersFile()
        {
            using (var sw = new StreamWriter(rootPath + @"testers.csv"))
            {
                var writer = new CsvWriter(sw);
                //Write the entire contents of the CSV file into another
                writer.WriteRecords(testersList);
            }
        }

        private void pasarDeForm()
        {
            closeApp = false;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TesterLoginForm_Shown(object sender, EventArgs e)
        {
            if (!userFile)
            {
                MessageBox.Show("To continue, register a new tester with the New tester button.", "Empty list of testers.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
