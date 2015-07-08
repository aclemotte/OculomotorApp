using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.FormMedicalID
{
    public partial class medicalID : Form
    {

        public string userName { get; set; }

        public medicalID()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMedicalID.Text))
                MessageBox.Show("Please fill the data");
            else
            {
                this.userName = textBoxMedicalID.Text;
                this.Close();
            }
        }
    }
}
