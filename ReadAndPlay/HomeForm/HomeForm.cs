using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LookAndPlayForm.BackupClass;
using LookAndPlayForm.TesterID;

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
            this.Hide();

            tester_class_engine tester_engine = new tester_class_engine();
            FormTesterID fTester = new FormTesterID(tester_engine);
            fTester.ShowDialog();

            if(fTester.closeApp)
                this.Close();
            else
            {

                //fTester.updateCsv();
                //aws_class_engine.UpdateTestersFile(institution_engine.institutionsList[0].institution_name);
                fTester.Dispose();
                fTester = null;


                this.Show();
            }
        }
    }
}
