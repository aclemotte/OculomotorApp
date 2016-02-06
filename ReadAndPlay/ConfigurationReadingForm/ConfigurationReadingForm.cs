using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.ConfigurationReadingForm
{
    public partial class ConfigurationReadingForm : Form
    {
        public bool closeApp { get; set; }
        public ConfigurationReadingForm()
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            closeApp = true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (radioButtonOutloudReading.Checked && camposCorrectamenteCompletados())
            {
                Program.datosCompartidos.readingTestTypeSelected = ReadingTestType.readingOutloud;
                closeApp = false;
            }
            else if (radioButtonSilentReading.Checked && camposCorrectamenteCompletados())
            {
                Program.datosCompartidos.readingTestTypeSelected = ReadingTestType.readingSilent;
                closeApp = false;
            }
            else
                this.DialogResult = DialogResult.None;
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
