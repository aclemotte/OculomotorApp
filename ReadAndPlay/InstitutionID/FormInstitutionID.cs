using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.InstitutionID
{
    public partial class FormInstitutionID : Form
    {

        public intitution_class_data institutionDataSelected { get; set; }

        private institution_class_engine institution_engine;






        public FormInstitutionID(institution_class_engine institution_engine)
        {
            InitializeComponent();

            this.institution_engine = institution_engine;

            //institutions2Form();
        }

        public void updateCsv()
        {
            //institution_engine.updateCsv(numericUpDownInstitutionID, institutionDataSelected);
            institution_engine.updateCsv(new NumericUpDown(), institutionDataSelected);
        }

        

        //caso de que existan ya instituciones almacenadas. Se cargan los datos almacenados en sesiones previas
        private bool institutions2Form()
        {
            if (institution_engine.institutionsList != null)
            {
                //numericUpDownInstitutionID.Maximum = Convert.ToDecimal(institution_engine.institutionsList.Last().institution_id) + 1;//cambiar
                //numericUpDownInstitutionID.Value = Convert.ToDecimal(institution_engine.institutionsList.Last().institution_id);

                //if (numericUpDownInstitutionID.Value == 1)
                //{
                //    textBoxInstitutionName.Text = institution_engine.institutionsList[0].institution_name;
                //    textBoxInstitutionName.ReadOnly = true;
                //}
            }
            else
            {
                //numericUpDownInstitutionID.Maximum = 1;
                //numericUpDownInstitutionID.Value = 1;
                //textBoxInstitutionName.Text = "Name";
            }

            return true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (camposCorrectamenteCompletados())
            {
                DialogResult dialogResult = MessageBox.Show("This information cannot be changed later. Please confirm the data", "", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    institutionDataSelected = new intitution_class_data();
                    institutionDataSelected.institution_id = "1"; //numericUpDownInstitutionID.Value.ToString();
                    institutionDataSelected.institution_name = textBoxInstitutionName.Text;
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.DialogResult = DialogResult.None;
                }

                //institutionDataSelected = new intitution_class_data();
                //institutionDataSelected.institution_id = numericUpDownInstitutionID.Value.ToString();
                //institutionDataSelected.institution_name = textBoxInstitutionName.Text;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private bool camposCorrectamenteCompletados()
        {
            if (string.IsNullOrEmpty(textBoxInstitutionName.Text))
            {
                MessageBox.Show("Please complete all the fields");
                return false;
            }
            else
                return true;
        }

        private void numericUpDownInstitutionID_ValueChanged(object sender, EventArgs e)
        {

        }


        
    }
}
