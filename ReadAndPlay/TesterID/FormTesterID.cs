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

        public tester_class_data testerDataSelected { get; set; }
        public bool newUser { get; set; }

        private tester_class_engine tester_engine;






        public FormTesterID(tester_class_engine tester_engine)
        {
            InitializeComponent();

            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            this.tester_engine = tester_engine;

            testers2Form();
        }

        public void updateCsv()
        {
            tester_engine.updateCsv(numericUpDownTesterID, testerDataSelected);
        }







        private bool testers2Form()
        {
            if(tester_engine.testersList != null)
            {
                numericUpDownTesterID.Maximum = Convert.ToDecimal(tester_engine.testersList.Last().tester_id) + 1;
                numericUpDownTesterID.Value = Convert.ToDecimal(tester_engine.testersList.Last().tester_id);

                if (numericUpDownTesterID.Value == 1)
                {
                    textBoxTesterName.Text = tester_engine.testersList[0].tester_name;
                    textBoxTesterName.ReadOnly = true;
                }
            }
            else
            {
                numericUpDownTesterID.Maximum = 1;
                numericUpDownTesterID.Value = 1;
                //textBoxTesterName.Text = "Name";
            }

            return true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (camposCorrectamenteCompletados())
            {
                testerDataSelected = new tester_class_data();
                testerDataSelected.tester_id = numericUpDownTesterID.Value.ToString();
                testerDataSelected.tester_name = textBoxTesterName.Text;
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
                MessageBox.Show("Name field is required", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return true;
        }

        private void numericUpDownTesterID_ValueChanged(object sender, EventArgs e)
        {
            //1. para cuando se llega al numero de un nuevo usuario se rellena con texto generico
            //2. para cuando se llega al numero de un usuario conocido se rellena con texto del usuario

            //1.
            //numericUpDownTesterID


            if (numericUpDownTesterID.Value > Convert.ToDecimal(tester_engine.testersList.Last().tester_id))
            {
                textBoxTesterName.Text = "";// String.Empty;
                textBoxTesterName.ReadOnly = false;
                newUser = true;
            }
            //2.
            else
            {
                int userIndex = Convert.ToInt32(numericUpDownTesterID.Value) - 1;

                textBoxTesterName.Text = tester_engine.testersList[userIndex].tester_name;
                textBoxTesterName.ReadOnly = true;
                newUser = false;
            }
        }

    }
}
