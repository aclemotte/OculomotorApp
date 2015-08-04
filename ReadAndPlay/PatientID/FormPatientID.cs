﻿using System;
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
    public partial class FormPatientID : Form
    {
        /*
            busca la carpeta root, retorno en bool, sino existe lo crea
            busca y lee users.cvs, retorno en bool, sino existe lo crea
            
            espera boton ok
                
            al darle al boton ok pregunta por id usuario

            si id usuario es nuevo (mayor a id last_session)
            {
                pregunta por el resto de la info
                - name
                - institution
            }
            
            Se inicia la prueba

            Al final de la prueba actualiza users.cvs con updateCsV();
            Al final de la prueba se genera una carpeta:
            user-date
        */

        string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";
        bool datosMigrados2NewClass = false;
        string institution_name;


        public bool newUser { get; set; }                
        
        public patient_class_datav2 patientDataSelected { get; set; }

        public List<patient_class_datav2> patientsList { get; set; }



        public FormPatientID(string institution_name)
        {
            InitializeComponent();

            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            bool rootFolder = rootFolderExist();
            bool userFile = usersFileExist(rootFolder);
            this.institution_name = institution_name;

            patients2Form();                 
        }

        public void updateCsv()
        {
            if (patientsList != null)
            {

                //caso que se haya introducido un nuevo usuario, 
                //se almacena en la lista el nuevo usuario y 
                //se guarda la lista en un archivo csv
                if (numericUpDownUserID.Value > Convert.ToDecimal(patientsList.Last().user_id))
                {
                    patientsList.Add(patientDataSelected);

                    if (datosMigrados2NewClass)
                        BackUpOldUserFile();

                    reWriteCsv();
                }
                else 
                {                
                    //caso que no se haya introducido un nuevo usuario, se almacena la lista xq se ha migrado
                    if (datosMigrados2NewClass)
                    {
                        //usersList.Add(userDataSelected);
                        BackUpOldUserFile();

                        reWriteCsv();
                    }
                }
                
            }
            else
            {
                patientsList = new List<patient_class_datav2>();
                patientsList.Add(patientDataSelected);

                using (var sw = new StreamWriter(rootPath + @"users.csv"))
                {
                    var writer = new CsvWriter(sw);
                    //Write the entire contents of the CSV file into another
                    writer.WriteRecords(patientsList);
                }
            }

        }

        private void reWriteCsv()
        {
            using (var sw = new StreamWriter(rootPath + @"users.csv"))
            {
                var writer = new CsvWriter(sw);
                //Write the entire contents of the CSV file into another
                writer.WriteRecords(patientsList);
            }
        }

        private void BackUpOldUserFile()
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
            if (File.Exists(rootPath + @"users.csv"))
            {
                using (var sr1 = new StreamReader(rootPath + @"users.csv"))
                {
                    var reader1 = new CsvReader(sr1);
                    try
                    {
                        datosMigrados2NewClass = false;
                        patientsList = reader1.GetRecords<patient_class_datav2>().ToList();
                        return true;
                    }
                    catch (Exception e1)
                    {
                        ErrorLog.ErrorLog.toErrorFile(e1.GetBaseException().ToString());

                        datosMigrados2NewClass = true;
                        //MessageBox.Show(e1.Message);                        
                        try
                        {
                            //migracion local de datos a clase nueva
                            
                            using (var sr2 = new StreamReader(rootPath + @"users.csv"))
                            {
                                var reader2 = new CsvReader(sr2);
                                try
                                {
                                    patientsList = new List<patient_class_datav2>();//lista vacia
                                    List<patient_class_datav1> usersListOldClass = reader2.GetRecords<patient_class_datav1>().ToList();//lista de la clase vieja
                                    //Convertidor de Lista de clase nueva
                                    for (int indiceLista = 0; indiceLista < usersListOldClass.Count; indiceLista++)
                                    {
                                        patient_class_datav2 one_users_classv2 = new patient_class_datav2();
                                        one_users_classv2.user_id = usersListOldClass[indiceLista].user_id;
                                        one_users_classv2.user_name = usersListOldClass[indiceLista].user_name;
                                        one_users_classv2.user_institution = usersListOldClass[indiceLista].user_institution;
                                        patientsList.Add(one_users_classv2);
                                    }

                                    return true;
                                }
                                catch (Exception e3)
                                {
                                    //MessageBox.Show(e3.Message);
                                    ErrorLog.ErrorLog.toErrorFile(e3.GetBaseException().ToString());
                                    return false;
                                }
                            }
                        }
                        catch(Exception e2)
                        {
                            //MessageBox.Show(e2.Message);
                            ErrorLog.ErrorLog.toErrorFile(e2.GetBaseException().ToString());
                            return false;
                        }
                    }
                }
                
            }
            else
            {
                Console.WriteLine("usersFile no existe");
                return false;
            }
        }

        private bool patients2Form()
        {
            if (patientsList != null)
            {
                numericUpDownUserID.Maximum = Convert.ToDecimal(patientsList.Last().user_id) + 1;
                numericUpDownUserID.Value = Convert.ToDecimal(patientsList.Last().user_id);

                if(numericUpDownUserID.Value == 1)
                {
                    textBoxUserName.Text = patientsList[0].user_name;
                    //textBoxUserInstitution.Text = patientsList[0].user_institution;
                    textBoxUserName.ReadOnly = true;
                    //textBoxUserInstitution.ReadOnly = true;
                }
            }
            else
            {
                numericUpDownUserID.Maximum = 1;
                numericUpDownUserID.Value = 1;
                //textBoxUserName.Text = "Name";
                //textBoxUserInstitution.Text = "Institution";
            }

            return true;
        }



        private void numericUpDownUserID_ValueChanged(object sender, EventArgs e)
        {
            //1. para cuando se llega al numero de un nuevo usuario se rellena con texto generico
            //2. para cuando se llega al numero de un usuario conocido se rellena con texto del usuario

            //1.
            if (numericUpDownUserID.Value > Convert.ToDecimal(patientsList.Last().user_id))
            {
                textBoxUserName.Text = "";// String.Empty;
                //textBoxUserInstitution.Text = "";// String.Empty;
                textBoxAge.Text = "";
                comboBoxCountry.Text = "";
                textBoxEmail.Text = "";

                textBoxUserName.ReadOnly = false;
                //textBoxUserInstitution.ReadOnly = false;
                textBoxAge.ReadOnly = false;                
                textBoxEmail.ReadOnly = false;

                //uncheck all checkboxes
                setDiagnosedConditionsControl(null);

                newUser = true;
            }
            //2.
            else
            {
                int userIndex = Convert.ToInt32(numericUpDownUserID.Value) - 1;

                textBoxUserName.Text = patientsList[userIndex].user_name;
                //textBoxUserInstitution.Text = patientsList[userIndex].user_institution;
                textBoxAge.Text = patientsList[userIndex].user_age;
                comboBoxCountry.Text = patientsList[userIndex].user_country;
                textBoxEmail.Text = patientsList[userIndex].user_email;
                setGenderControl(patientsList[userIndex].user_gender);
                setDiagnosedConditionsControl(patientsList[userIndex].user_diagnosedConditions);

                textBoxUserName.ReadOnly = true;
                //textBoxUserInstitution.ReadOnly = true;
                textBoxAge.ReadOnly = true;
                textBoxEmail.ReadOnly = true;

                newUser = false;
            }
        }

        /// <summary>
        /// enum userGender -> radiobutton male y female
        /// </summary>
        /// <param name="user_gender"></param>
        private void setGenderControl(userGender user_gender)
        {
            if (user_gender == userGender.female)
                radioButtonFemale.Checked = true;
            else
                radioButtonMale.Checked = true;
        }
        
        /// <summary>
        /// radiobutton male y female -> enum userGender 
        /// </summary>
        /// <returns></returns>
        private userGender getGenderFromControl()
        {
            if (radioButtonFemale.Checked)
                return userGender.female;
            else
                return userGender.male;
        }
        
        /// <summary>
        /// class diagnosedConditionsClass -> checkboxes
        /// </summary>
        /// <param name="dCondition"></param>
        private void setDiagnosedConditionsControl(diagnosedConditionsClass dCondition)
        {
            if (dCondition == null)
            {
                checkBoxStrabismusExotropia.Checked = false;
                checkBoxStrabismusEsotropia.Checked = false;
                checkBoxAstigmatism.Checked = false;
                checkBoxNystagmus.Checked = false;
                checkBoxAmblyopia.Checked = false;
                checkBoxHypermetropia.Checked = false;
                checkBoxMyopia.Checked = false;
                checkBoxCranialNervePalsy.Checked = false;
                checkBoxADHD.Checked = false;
                checkBoxDislexia.Checked = false;
                checkBoxOther.Checked = false;
            }
            else
            {
                checkBoxStrabismusExotropia.Checked = dCondition.strabismusExotropia;
                checkBoxStrabismusEsotropia.Checked = dCondition.strabismusEsotropia;
                checkBoxAstigmatism.Checked = dCondition.astigmatism;
                checkBoxNystagmus.Checked = dCondition.nystagmus;
                checkBoxAmblyopia.Checked = dCondition.amblyopia;
                checkBoxHypermetropia.Checked = dCondition.hypermetropia;
                checkBoxMyopia.Checked = dCondition.myopia;
                checkBoxCranialNervePalsy.Checked = dCondition.cranialNervePalsy;
                checkBoxADHD.Checked = dCondition.ADHD;
                checkBoxDislexia.Checked = dCondition.dislexia;
                checkBoxOther.Checked = dCondition.other;
            }           
        }

        /// <summary>
        /// checkboxes -> class diagnosedConditionsClass
        /// </summary>
        /// <returns></returns>
        private diagnosedConditionsClass getDiagnosedConditionFromControl()
        {
            diagnosedConditionsClass dCondition = new diagnosedConditionsClass();

            dCondition.strabismusExotropia = checkBoxStrabismusExotropia.Checked;
            dCondition.strabismusEsotropia = checkBoxStrabismusEsotropia.Checked;
            dCondition.astigmatism = checkBoxAstigmatism.Checked;
            dCondition.nystagmus = checkBoxNystagmus.Checked;
            dCondition.amblyopia = checkBoxAmblyopia.Checked;
            dCondition.hypermetropia = checkBoxHypermetropia.Checked;
            dCondition.myopia = checkBoxMyopia.Checked;
            dCondition.cranialNervePalsy = checkBoxCranialNervePalsy.Checked;
            dCondition.ADHD = checkBoxADHD.Checked;
            dCondition.dislexia = checkBoxDislexia.Checked;
            dCondition.other = checkBoxOther.Checked;

            return dCondition;
        }

        
        
        
        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (camposCorrectamenteCompletados())
            {
                patientDataSelected = new patient_class_datav2();
                patientDataSelected.user_id = numericUpDownUserID.Value.ToString();
                patientDataSelected.user_name = textBoxUserName.Text;
                patientDataSelected.user_institution = institution_name;// textBoxUserInstitution.Text;
                patientDataSelected.user_age = textBoxAge.Text;
                patientDataSelected.user_country = comboBoxCountry.Text;
                patientDataSelected.user_email = textBoxEmail.Text;
                patientDataSelected.user_gender = getGenderFromControl();
                patientDataSelected.user_diagnosedConditions = getDiagnosedConditionFromControl();
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private bool camposCorrectamenteCompletados()
        {
            //if (comboBoxSampleText.SelectedItem == null)
            //{
            //    MessageBox.Show("Please select a sample text", "Empty field");
            //    return false;
            //}
            //else if ...
            if (newUser && textBoxUserName.Text == "")
            {
                MessageBox.Show("Name field is required", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (newUser && textBoxEmail.Text == "")
            {
                MessageBox.Show("Email field is required", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (newUser && textBoxAge.Text == "")
            {
                MessageBox.Show("Age field is required, Empty field", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return true;
        }


        //private void radioButtonText1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButtonText1.Checked)
        //        Program.datosCompartidos.image2read = "TextoIn4.png";
        //    else
        //        Program.datosCompartidos.image2read = "TextoIn5.png";
        //}

        //private void radioButtonText2_CheckedChanged(object sender, EventArgs e)
        //{
        //}

        //private void buttonResume_Click(object sender, EventArgs e)
        //{
        //    Resumen.Resumen resumenGame1 = new Resumen.Resumen(false, false);

        //    if (resumenGame1.everythingOk)
        //        resumenGame1.Show();
        //    else
        //        resumenGame1.Dispose();
        //}

        //private void comboBoxSampleText_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if(comboBoxSampleText.SelectedIndex != -1)
        //    {
        //        Program.datosCompartidos.image2read = comboBoxSampleText.SelectedItem.ToString();
        //    }
        //}

    }
}
