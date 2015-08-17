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

        string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";
        private bool userFile;


        public bool newUser { get; set; }                        
        public patient_class_datav3 patientDataSelected { get; set; }
        public List<patient_class_datav3> patientsList { get; set; }
        public bool closeApp { get; set; }




        public PatientLoginForm()
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            closeApp = true;


            bool rootFolder = rootFolderExist();
            userFile = usersFileExist(rootFolder);
            if(userFile)
                patientsFile2Form();                 
            else
            {
                comboBoxPatients.Enabled = false;
                buttonOk.Enabled = false;
            }
        }

        private void BackUpOldUser1File()
        {
            try
            {
                File.Copy(rootPath + @"users.csv", rootPath + @"users_classv1.csv");
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        private void BackUpOldUser2File()
        {
            try
            {
                File.Copy(rootPath + @"users.csv", rootPath + @"users_classv2.csv");
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
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
                Console.WriteLine("rootFolderExist no existe");
                Directory.CreateDirectory(rootPath);
                return false;
            }
        }

        private bool usersFileExist(bool rootFolderExist)
        {
            string fileName = rootPath + @"users.csv";

            if (File.Exists(fileName))
            {

                //leer patient_class_datav3
                using (var sr3 = new StreamReader(fileName))
                {
                    var reader3 = new CsvReader(sr3);
                    try
                    {
                        patientsList = reader3.GetRecords<patient_class_datav3>().ToList();
                        return true;
                    }
                    catch (Exception e3)
                    {
                        ErrorLog.ErrorLog.toErrorFile(e3.GetBaseException().ToString());
                        
                        //leer patient_class_datav2
                        using (var sr2 = new StreamReader(fileName))
                        {
                            var reader2 = new CsvReader(sr2);
                            try
                            {
                                patientClassv2ToClassv3(reader2);
                                BackUpOldUser2File();
                                return true;
                            }
                            catch (Exception e2)
                            {
                                ErrorLog.ErrorLog.toErrorFile(e2.GetBaseException().ToString());
                                
                                //leer patient_class_datav1
                                using (var sr1 = new StreamReader(fileName))
                                {
                                    var reader1 = new CsvReader(sr1);
                                    try
                                    {
                                        patientClassv1ToClassv3(reader1);
                                        BackUpOldUser1File();
                                        return true;
                                    }
                                    catch (Exception e1)
                                    {
                                        ErrorLog.ErrorLog.toErrorFile(e1.GetBaseException().ToString());
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                ErrorLog.ErrorLog.toErrorFile(fileName + " no existe (users file)");
                return false;
            }
        }


        private void patientClassv1ToClassv3(CsvReader reader)
        {
            patientsList = new List<patient_class_datav3>();//lista vacia
            List<patient_class_datav1> usersListOldClass = reader.GetRecords<patient_class_datav1>().ToList();//lista de la clase vieja

            //Convertidor de Lista de clase nueva
            for (int indiceLista = 0; indiceLista < usersListOldClass.Count; indiceLista++)
            {
                patient_class_datav3 one_users_NewClass = new patient_class_datav3();
                one_users_NewClass.user_id = usersListOldClass[indiceLista].user_id;
                one_users_NewClass.user_name = usersListOldClass[indiceLista].user_name;
                one_users_NewClass.user_institution = usersListOldClass[indiceLista].user_institution;
                patientsList.Add(one_users_NewClass);
            }
        }

        private void patientClassv2ToClassv3(CsvReader reader)
        {
            patientsList = new List<patient_class_datav3>();//lista vacia
            List<patient_class_datav2> usersListOldClass = reader.GetRecords<patient_class_datav2>().ToList();//lista de la clase vieja

            //Convertidor de Lista de clase nueva
            for (int indiceLista = 0; indiceLista < usersListOldClass.Count; indiceLista++)
            {
                patient_class_datav3 one_users_NewClass = new patient_class_datav3();
                one_users_NewClass.user_id = usersListOldClass[indiceLista].user_id;
                one_users_NewClass.user_name = usersListOldClass[indiceLista].user_name;
                one_users_NewClass.user_institution = usersListOldClass[indiceLista].user_institution;
                one_users_NewClass.user_age = usersListOldClass[indiceLista].user_age;//age
                one_users_NewClass.user_country = usersListOldClass[indiceLista].user_country;//country
                one_users_NewClass.user_email = usersListOldClass[indiceLista].user_email;//email
                one_users_NewClass.user_gender = usersListOldClass[indiceLista].user_gender;//gender
                one_users_NewClass.user_diagnosedConditions.strabismusExotropia = usersListOldClass[indiceLista].user_diagnosedConditions.strabismusExotropia;
                one_users_NewClass.user_diagnosedConditions.strabismusEsotropia = usersListOldClass[indiceLista].user_diagnosedConditions.strabismusEsotropia;
                one_users_NewClass.user_diagnosedConditions.astigmatism = usersListOldClass[indiceLista].user_diagnosedConditions.astigmatism;
                one_users_NewClass.user_diagnosedConditions.nystagmus = usersListOldClass[indiceLista].user_diagnosedConditions.nystagmus;
                one_users_NewClass.user_diagnosedConditions.amblyopia = usersListOldClass[indiceLista].user_diagnosedConditions.amblyopia;
                one_users_NewClass.user_diagnosedConditions.hypermetropia = usersListOldClass[indiceLista].user_diagnosedConditions.hypermetropia;
                one_users_NewClass.user_diagnosedConditions.myopia = usersListOldClass[indiceLista].user_diagnosedConditions.myopia;
                one_users_NewClass.user_diagnosedConditions.cranialNervePalsy = usersListOldClass[indiceLista].user_diagnosedConditions.cranialNervePalsy;
                one_users_NewClass.user_diagnosedConditions.ADHD = usersListOldClass[indiceLista].user_diagnosedConditions.ADHD;
                one_users_NewClass.user_diagnosedConditions.dislexia = usersListOldClass[indiceLista].user_diagnosedConditions.dislexia;
                one_users_NewClass.user_diagnosedConditions.other = usersListOldClass[indiceLista].user_diagnosedConditions.other;
                //one_users_NewClass.user_diagnosedConditions.convergenceInsufficiency = usersListOldClass[indiceLista].user_diagnosedConditions;//nuevo
                patientsList.Add(one_users_NewClass);
            }
        }

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
            int newUserID;

            if (patientsList != null)
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
                if (!userFile)
                    patientsList = new List<patient_class_datav3>();
                patientsList.Add(patientDataSelected);
                updatePatientFile();
                pasarDeForm();
            }
            else 
            {
                patientNewForm.Dispose();
                patientNewForm = null;
            }
        }

        private void updatePatientFile()
        {
            using (var sw = new StreamWriter(rootPath + @"users.csv"))
            {
                var writer = new CsvWriter(sw);
                //Write the entire contents of the CSV file into another
                writer.WriteRecords(patientsList);
            }
        }

        private void pasarDeForm()
        {
            closeApp = false;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void PatientLoginForm_Shown(object sender, EventArgs e)
        {
            if (!userFile)
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
