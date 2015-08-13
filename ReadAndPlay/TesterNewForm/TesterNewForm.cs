﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LookAndPlayForm.TesterID;

namespace LookAndPlayForm.TesterNewForm
{
    public partial class TesterNewForm : Form
    {
        public TesterLoginEngineData testerDataSelected { get; set; } 
        public bool newUser { get; set; }





        public TesterNewForm(decimal patientID)
        {
            InitializeComponent();
            newUser = false;
            numericUpDownUserID.Value = patientID;
        }

        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (camposCorrectamenteCompletados())
            {
                testerDataSelected = new TesterLoginEngineData();
                testerDataSelected.tester_id = numericUpDownUserID.Value.ToString();
                testerDataSelected.tester_name = textBoxUserName.Text;
                newUser = true;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private bool camposCorrectamenteCompletados()
        {
            if (textBoxUserName.Text == "")
            {
                MessageBox.Show("Name field is required", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            newUser = false;
            this.Close();
        }

    }
}