using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.InstructionPursuitForm
{
    public partial class InstructionPursuit : Form
    {
        public bool closeApp { get; set; }

        public InstructionPursuit()
        {
            InitializeComponent();
            closeApp = true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            closeApp = false;
        }
    }
}
