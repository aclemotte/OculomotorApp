﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsvHelper;
using LookAndPlayForm.DataBase;
using LookAndPlayForm.Utility;

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


        private string rootPath = CData.DataFolder + @"\";
        //private bool userFile;


        public bool newUser { get; set; }
        public TesterLoginEngineData testerDataSelected { get; set; }
        public List<TesterLoginEngineData> testersList { get; set; }
        public bool closeApp { get; set; }

        public TesterLoginForm()
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();            
            closeApp = true;

            LoadTesters();
        }

        private void LoadTesters()
        {
            testersList = DataBaseWorker.LoadTesters();
            if (testersList == null || testersList.Count < 1)
            {
                comboBoxTesters.Enabled = false;
                buttonOk.Enabled = false;
            }
            else
                testersFileData2Form();
        }

        private bool testersFileData2Form()
        {
            if (testersList != null)
            {
                int indexTester = 0;
                for (indexTester = 0; indexTester < testersList.Count; indexTester++)
                {
                    comboBoxTesters.Items.Add(testersList[indexTester].tester_name);
                }
                comboBoxTesters.SelectedIndex = 0;
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
            try
            {
                int newUserID;
                if (testersList != null && testersList.Count > 0)
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
                    //if (!userFile)
                    if (testersList == null || testersList.Count < 1)
                        testersList = new List<TesterLoginEngineData>();
                    testersList.Add(testerDataSelected);
                    AddTester(testerDataSelected);
                    
                    pasarDeForm();
                }
                else
                {
                    testerNewForm.Dispose();
                    testerNewForm = null;
                }
            }
            catch(Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        private void AddTester(TesterLoginEngineData newtester)
        {
            DataBaseWorker.AddTester(newtester);

            updateTestersFile();
        }

        private void updateTestersFile()
        {
            using (var sw = new StreamWriter(CData.TempDataFolder + @"\testers.csv"))
            {
                var writer = new CsvWriter(sw);
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
            if (testersList == null || testersList.Count < 1)
            {
                MessageBox.Show("To continue, register a new tester with the New tester button.", "Empty list of testers.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void comboBoxTesters_SelectedValueChanged(object sender, EventArgs e)
        {
            textBoxTesterID.Text = (comboBoxTesters.Items.IndexOf(comboBoxTesters.SelectedItem.ToString()) + 1).ToString();
        }
    }
}
