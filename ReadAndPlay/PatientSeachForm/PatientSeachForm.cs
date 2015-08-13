using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.PatientSeachForm
{
    public partial class PatientSeachForm : Form
    {
        public bool closeApp;

        public PatientSeachForm()
        {
            InitializeComponent();
            closeApp = true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            closeApp = false;
        }

        private void buttonNewPatient_Click(object sender, EventArgs e)
        {

        }
    }
}
