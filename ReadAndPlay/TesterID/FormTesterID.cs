using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.TesterID
{
    public partial class FormTesterID : Form
    {

        public string testerName;

        public FormTesterID()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTesterName.Text))
            {
                MessageBox.Show("Please complete the data");
                //this.DialogResult = DialogResult.None;
            }
            else
            {
                this.testerName = textBoxTesterName.Text;
            }
        }
    }
}
