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

        public intitution_class_data institutionData;

        public FormInstitutionID(intitution_class_data institutionData)
        {
            InitializeComponent();

            this.institutionData = institutionData;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxInstitutionName.Text))
            {
                MessageBox.Show("Please complete all the fields");
            }
            else
            {
                this.institutionData.name = textBoxInstitutionName.Text;
                this.Close();
            }
        }
    }
}
