using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.ConsentForm
{
    public partial class consentForm : Form
    {
        public consentForm()
        {
            InitializeComponent();
        }

        private void buttonAgree_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
