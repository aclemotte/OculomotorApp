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
    public partial class HomeForm : Form
    {
        HomeFormEngine initial_engine;
            
        public HomeForm(HomeFormEngine initial_engine)
        {
            InitializeComponent();

            this.initial_engine = initial_engine;
        }

        private void buttonReviewTest_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNewTest_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
