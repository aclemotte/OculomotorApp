using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.SelectTest
{
    public partial class FormSelectionTest : Form
    {

        public bool closeApp { get; set; }

        public FormSelectionTest()
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            closeApp = true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (radioButtonPersuit.Checked)
            {
               Program.datosCompartidos.testSelected = TestType.pursuit;
               closeApp = false;
            }
            else if (radioButtonReading.Checked )
            {
                Program.datosCompartidos.testSelected = TestType.reading;
                closeApp = false;
            }
            else
                this.DialogResult = DialogResult.None;

        }
    }
}