using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.InitialForm
{
    public partial class initialForm : Form
    {
        initial_class_engine initial_engine;
            
        public initialForm(initial_class_engine initial_engine)
        {
            InitializeComponent();

            this.initial_engine = initial_engine;
        }

        private void buttonReviewTest_Click(object sender, EventArgs e)
        {

        }

        private void buttonNewTest_Click(object sender, EventArgs e)
        {

        }
    }
}
