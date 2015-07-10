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

        public string institutionName { get; set; }

        public FormInstitutionID()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxInstitutionName.Text))
            {
                MessageBox.Show("Please complete all the fields");
            }
            else
            {
                this.institutionName = textBoxInstitutionName.Text;
                this.Close();
            }
        }
    }
}
