using LookAndPlayForm.DataBase;
using LookAndPlayForm.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.Review
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SearchTestForm : Form
    {
        /// Private Variables
        #region Private Variables

        /// <summary>
        /// 
        /// </summary>
        int testType = -1;

        #endregion

        /// Properties
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public TestType TestType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public OutputTestData2 TestData { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string EyeTrackerData { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string FixData { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string PursuitData { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsTestSelected { get; private set; }

        #endregion

        /// Init
        #region Init

        /// <summary>
        /// Constructor
        /// </summary>
        public SearchTestForm()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            lbVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            buttonBackColor = bFilter_Pursuit.BackColor;
            buttonFocusedBackColor = bFilter_Pursuit.FlatAppearance.MouseDownBackColor;
        }

        #endregion

        /// Functions
        #region Functions

        /// <summary>
        /// 
        /// </summary>
        private void Search()
        {
            //string date = DataValidation.DateValidation(tbFilter_Date.Text);
            string date = dtpFilter_Date.Checked ? dtpFilter_Date.Value.ToString() : "";
            testType = ((bFilter_Reading.Tag != null) ? 2 : 0) + ((bFilter_Pursuit.Tag != null) ? 1 : 0);
            dgvTests.Rows.Clear();
            DataTable dt = DataBaseWorker.SearchTest(tbFilter_PatientName.Text, tbFilter_TesterName.Text, date, testType);
            if (dt == null)
                return;
            
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    dgvTests.Rows.Add();
                    dgvTests.Rows[i].Cells["Patient"].Value = row["Patient"].ToString();
                    dgvTests.Rows[i].Cells["PatientID"].Value = row["PatientID"].ToString();
                    dgvTests.Rows[i].Cells["Tester"].Value = row["Tester"].ToString();
                    dgvTests.Rows[i].Cells["Date"].Value = row["Date"].ToString();
                    dgvTests.Rows[i].Cells["DateUTC"].Value = DataConverter.UTCDateFromLocalTime(row["DateUTC"].ToString());
                    int testTypex = int.Parse(row["TestType"].ToString());
                    dgvTests.Rows[i].Cells["Test"].Value = (TestType)testTypex;
                    i++;
                }
                catch(Exception ex)
                {
                    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());;
                }
            }
        }

        Color buttonBackColor = Color.White;
        Color buttonFocusedBackColor = Color.DarkBlue;

        private void ButtonTestClicked(Button sender)
        {
            if (sender == null)
                return;

            if (sender.Tag == null)
            {
                sender.Tag = 1;
                sender.BackColor = buttonFocusedBackColor;
            }
            else
            {
                sender.BackColor = buttonBackColor;
                sender.Tag = null;
            }
        }
            

        #endregion

        private void tbFilter_PatientName_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void tbFilter_TesterName_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void tbFilter_Date_TextChanged(object sender, EventArgs e)
        {
            //Search();
        }

        private void bFilter_Reading_Click(object sender, EventArgs e)
        {
            ButtonTestClicked(bFilter_Reading);
            Search();
        }

        private void bFilter_Pursuit_Click(object sender, EventArgs e)
        {
            ButtonTestClicked(bFilter_Pursuit);
            Search();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            IsTestSelected = false;

            try
            {
                if (dgvTests.SelectedRows != null && dgvTests.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvTests.SelectedRows[0];
                    //string date = DataConverter.UTCDateFormat(row.Cells["DateUTC"].Value.ToString());
                    string date = row.Cells["DateUTC"].Value.ToString();
                    string patient = row.Cells["Patient"].Value.ToString();
                    string ttype = row.Cells["Test"].Value.ToString();
                    TestType = (ttype == "reading") ? TestType.reading : TestType.persuit;
                    string user_id = row.Cells["PatientID"].Value.ToString();
                    TestData = DataBaseWorker.LoadTestDataByDateAndID(date, user_id);
                    EyeTrackerData = DataBaseWorker.LoadEyeTrackerData(date, user_id);
                    if (TestType == TestType.reading)
                        FixData = DataBaseWorker.LoadReadingData(date, user_id);
                    else
                        PursuitData = DataBaseWorker.LoadPursuitData(date, user_id);
                    IsTestSelected = true;
                }
                else
                    IsTestSelected = false;
            }
            catch(Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());;
            }
        }

        private void SearchTestForm_Shown(object sender, EventArgs e)
        {
            Search();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void dtpFilter_Date_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
