using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using LookAndPlayForm.DataBase;
using LookAndPlayForm.Utility;

namespace LookAndPlayForm
{
    public partial class PatientLoginForm : Form
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

        string rootPath = CData.DataFolder + @"\";

        public bool newUser { get; set; }                        
        public patient_class_datav3 patientDataSelected { get; set; }
        public List<patient_class_datav3> patientsList { get; set; }
        public bool closeApp { get; set; }

        public PatientLoginForm()
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            closeApp = true;

            LoadPatients();
        }

        private void LoadPatients()
        {
            patientsList = DataBaseWorker.LoadUsers();

            if (patientsList != null && patientsList.Count > 0)
                patientsFile2Form();
            else
            {
                comboBoxPatients.Enabled = false;
                buttonOk.Enabled = false;
            }
        }

        private void AddPatient(patient_class_datav3 patient)
        {
            DataBaseWorker.AddUser(patient);

            updatePatientFile();
        }

        private void updatePatientFile()
        {
            using (var sw = new StreamWriter(CData.TempDataFolder + @"\users.csv"))
            {
                var writer = new CsvWriter(sw);
                writer.WriteRecords(patientsList);
            }
        }

        /*
        private void UpdateDataBase()
        {
            DataBaseWorker.SaveUsers(patientsList);
        }*/

        private bool patientsFile2Form()
        {
            if (patientsList != null)
            {
                int indexPatient = 0;
                for(indexPatient = 0; indexPatient<patientsList.Count; indexPatient++)
                {
                    comboBoxPatients.Items.Add(patientsList[indexPatient].user_name);
                }
            }
            return true;
        } 

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (comboBoxPatients.SelectedItem != null)
            {
                patientDataSelected = new patient_class_datav3();
                patientDataSelected.user_id = (comboBoxPatients.Items.IndexOf(comboBoxPatients.SelectedItem.ToString()) + 1).ToString();
                patientDataSelected.user_name = comboBoxPatients.SelectedItem.ToString();
                patientDataSelected.user_institution = Program.datosCompartidos.institutionName;
                closeApp = false;
            }
            else
            {
                MessageBox.Show("To continue, select a registered patient or register a new patient with the New patient button.", "Patient not found.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        private void buttonNewPatient_Click(object sender, EventArgs e)
        {
            try
            {
                int newUserID;
                if (patientsList != null && patientsList.Count > 0)
                {
                    newUserID = Convert.ToInt32(patientsList.Last().user_id) + 1;
                }
                else
                {
                    newUserID = 1;
                }

                FormPatientID patientNewForm = new FormPatientID(newUserID);
                patientNewForm.ShowDialog();
                newUser = patientNewForm.newUser;

                if (newUser)
                {
                    patientDataSelected = patientNewForm.patientDataSelected;
                    patientNewForm.Dispose();
                    patientNewForm = null;
                    if (patientsList == null)
                        patientsList = new List<patient_class_datav3>();
                    patientsList.Add(patientDataSelected);
                    AddPatient(patientDataSelected);
                    pasarDeForm();
                }
                else
                {
                    patientNewForm.Dispose();
                    patientNewForm = null;
                }
            }
            catch(Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        private void pasarDeForm()
        {
            closeApp = false;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void PatientLoginForm_Shown(object sender, EventArgs e)
        {
            if (patientsList == null || patientsList.Count < 1)
            {
                MessageBox.Show("To continue, register a new patient with the New patient button.", "Empty list of patients.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void comboBoxPatients_SelectedValueChanged(object sender, EventArgs e)
        {
            textBoxPatientID.Text =  (comboBoxPatients.Items.IndexOf(comboBoxPatients.SelectedItem.ToString()) + 1).ToString();
        }
    }
}
