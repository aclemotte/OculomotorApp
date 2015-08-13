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
    public partial class FormPatientID : Form
    {
        public patient_class_datav3 patientDataSelected { get; set; }
        public bool newUser { get; set; }
        



        
        public FormPatientID(decimal patientID)
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            newUser = false;
            numericUpDownUserID.Value = patientID;
        }

        


        
        
        
        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (camposCorrectamenteCompletados())
            {
                patientDataSelected = new patient_class_datav3();
                patientDataSelected.user_id = numericUpDownUserID.Value.ToString();
                patientDataSelected.user_name = textBoxUserName.Text;
                patientDataSelected.user_institution = Program.datosCompartidos.institutionName;
                patientDataSelected.user_age = textBoxAge.Text;
                patientDataSelected.user_country = comboBoxCountry.Text;
                patientDataSelected.user_email = textBoxEmail.Text;
                patientDataSelected.user_gender = getGenderFromControl();
                patientDataSelected.user_diagnosedConditions = getDiagnosedConditionFromControl();
                newUser = true;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private bool camposCorrectamenteCompletados()
        {
            if (textBoxUserName.Text == "")
            {
                MessageBox.Show("Name field is required", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Email field is required", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (textBoxAge.Text == "")
            {
                MessageBox.Show("Age field is required, Empty field", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return true;
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
        /// checkboxes -> class diagnosedConditionsClass
        /// </summary>
        /// <returns></returns>
        private diagnosedConditionsClassv2 getDiagnosedConditionFromControl()
        {
            diagnosedConditionsClassv2 dCondition = new diagnosedConditionsClassv2();

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
            dCondition.convergenceInsufficiency = checkBoxConvergenceInsufficiency.Checked;
            return dCondition;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            newUser = false;
            this.Close();
        }

    }
}
