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
            if (camposCorrectamenteCompletados())
            {
                this.testerName = textBoxTesterName.Text;                
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private bool camposCorrectamenteCompletados()
        {
            if (string.IsNullOrEmpty(textBoxTesterName.Text))
            {
                MessageBox.Show("Name field is required", "Empty field");
                return false;
            }
            else
                return true;
        }

        //string.IsNullOrEmpty(textBoxTesterName.Text)
    }
}
