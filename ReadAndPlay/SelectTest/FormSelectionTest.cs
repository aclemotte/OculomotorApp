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

        public FormSelectionTest()
        {
            InitializeComponent();

            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //testSelected = testType.reading;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (radioButtonPersuit.Checked)
            {
               //testSelected = testType.persuit;
               Program.datosCompartidos.testSelected = testType.persuit;
            }
            else if (radioButtonRead.Checked && camposCorrectamenteCompletados())
            {
                //testSelected = testType.reading;
                Program.datosCompartidos.testSelected = testType.reading;
                Program.datosCompartidos.readingTestTypeSelected = getReadingTestType();
            }
            else
                this.DialogResult = DialogResult.None;
        }

        private readingTestType getReadingTestType()
        {
            if (radioButtonOutloudReading.Checked)
                return readingTestType.readingOutloud;            
            else //if (radioButtonSilentReading.Checked)
                return readingTestType.readingSilent;

        }

        private bool camposCorrectamenteCompletados()
        {
            if (comboBoxSampleText.SelectedItem == null)
            {
                MessageBox.Show("Please select a sample text", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return true;
        }

        private void comboBoxSampleText_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxSampleText.SelectedIndex != -1)
            {
                Program.datosCompartidos.image2read = comboBoxSampleText.SelectedItem.ToString();
            }
        }
    }
}