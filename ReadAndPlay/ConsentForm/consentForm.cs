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
        public bool closeApp { get; set; }

        public consentForm()
        {
            InitializeComponent();

            closeApp = true;
        }

        private void buttonAgree_Click(object sender, EventArgs e)
        {
            closeApp = false;
        }
    }
}
