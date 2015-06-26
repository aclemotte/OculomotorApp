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
    public partial class FormUserID : Form
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

        
        
        
        
        
        public users_class userDataSelected { get; set; }

        public List<users_class> usersList { get; set; }
        


        public FormUserID()
        {
            InitializeComponent();

            labelVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            bool rootFolder = rootFolderExist();
            bool userFile = usersFileExist(rootFolder);

            lastSession2Form();                 
        }

        public void updateCsv()
        {
            if (usersList != null)
            {
                if (numericUpDownUserID.Value > Convert.ToDecimal(usersList.Last().user_id))
                {
                    usersList.Add(userDataSelected);

                    using (var sw = new StreamWriter(rootPath + @"users.csv"))
                    {
                        var writer = new CsvWriter(sw);
                        //Write the entire contents of the CSV file into another
                        writer.WriteRecords(usersList);
                    }
                }
            }
            else
            {
                usersList = new List<users_class>();
                usersList.Add(userDataSelected);

                using (var sw = new StreamWriter(rootPath + @"users.csv"))
                {
                    var writer = new CsvWriter(sw);
                    //Write the entire contents of the CSV file into another
                    writer.WriteRecords(usersList);
                }
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
                using (var sr = new StreamReader(rootPath + @"users.csv"))
                {
                    var reader = new CsvReader(sr);
                    try
                    {
                        usersList = reader.GetRecords<users_class>().ToList();
                        return true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return false;
                    }
                }
                
            }
            else
            {
                Console.WriteLine("usersFile no existe");
                return false;
            }
        }

        private bool lastSession2Form()
        {
            if (usersList != null)
            {
                numericUpDownUserID.Maximum = Convert.ToDecimal(usersList.Last().user_id) + 1;
                numericUpDownUserID.Value = Convert.ToDecimal(usersList.Last().user_id);

                if(numericUpDownUserID.Value == 1)
                {
                    textBoxUserName.Text = usersList[0].user_name;
                    textBoxUserInstitution.Text = usersList[0].user_institution;
                    textBoxUserName.ReadOnly = true;
                    textBoxUserInstitution.ReadOnly = true;
                }
            }
            else
            {
                numericUpDownUserID.Maximum = 1;
                numericUpDownUserID.Value = 1;
                textBoxUserName.Text = "Name";
                textBoxUserInstitution.Text = "Institution";
            }

            return true;
        }

        private void numericUpDownUserID_ValueChanged(object sender, EventArgs e)
        {
            //1. para cuando se llega al numero de un nuevo usuario se rellena con texto generico
            //2. para cuando se llega al numero de un usuario conocido se rellena con texto del usuario

            //1.
            if (numericUpDownUserID.Value > Convert.ToDecimal(usersList.Last().user_id))
            {
                textBoxUserName.Text = "Name";// String.Empty;
                textBoxUserInstitution.Text = "Institution";// String.Empty;
                textBoxUserName.ReadOnly = false;
                textBoxUserInstitution.ReadOnly = false;
            }
            //2.
            else
            {
                int userIndex = Convert.ToInt32(numericUpDownUserID.Value) - 1;

                textBoxUserName.Text = usersList[userIndex].user_name;
                textBoxUserInstitution.Text = usersList[userIndex].user_institution;
                textBoxAge.Text = usersList[userIndex].user_age;
                comboBoxCountry.Text = usersList[userIndex].user_country;
                textBoxEmail.Text = usersList[userIndex].user_email;
                setGenderControl(usersList[userIndex].user_gender);
                setDiagnosedConditionsControl(usersList[userIndex].user_diagnosedConditions);

                textBoxUserName.ReadOnly = true;
                textBoxUserInstitution.ReadOnly = true;
                textBoxAge.ReadOnly = true;
                textBoxEmail.ReadOnly = true;
            }
        }

        private void setGenderControl(userGender user_gender)
        {
            if (user_gender == userGender.female)
                radioButtonFemale.Checked = true;
            else
                radioButtonMale.Checked = true;
        }


        
        private userGender getGenderFromControl()
        {
            if (radioButtonFemale.Checked)
                return userGender.female;
            else
                return userGender.male;
        }
        
        private void setDiagnosedConditionsControl(diagnosedConditionsClass dCondition)
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
            if (comboBoxSampleText.SelectedItem != null)
            {
                userDataSelected = new users_class();
                userDataSelected.user_id = numericUpDownUserID.Value.ToString();
                userDataSelected.user_name = textBoxUserName.Text;
                userDataSelected.user_institution = textBoxUserInstitution.Text;
                userDataSelected.user_age = textBoxAge.Text;
                userDataSelected.user_country = comboBoxCountry.Text;
                userDataSelected.user_email = textBoxEmail.Text;
                userDataSelected.user_gender = getGenderFromControl();
                userDataSelected.user_diagnosedConditions = getDiagnosedConditionFromControl();
            }
            else
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Please select a sample text");
            }
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

        private void buttonResume_Click(object sender, EventArgs e)
        {
            Resumen.Resumen resumenGame1 = new Resumen.Resumen(false);

            if (resumenGame1.everythingOk)
                resumenGame1.Show();
            else
                resumenGame1.Dispose();
        }

        private void comboBoxSampleText_SelectedValueChanged(object sender, EventArgs e)
        {
            if(comboBoxSampleText.SelectedIndex != -1)
            {
                Program.datosCompartidos.image2read = comboBoxSampleText.SelectedItem.ToString();
            }
        }

    }
}
