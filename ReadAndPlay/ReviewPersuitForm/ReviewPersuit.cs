using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LookAndPlayForm;
using LookAndPlayForm.Comments;
using LookAndPlayForm.LogEyeTracker;
using LookAndPlayForm.Review;
using LookAndPlayForm.TestPersuit;
using LookAndPlayForm.DataBase;
using LookAndPlayForm.Utility;

namespace ReviewPersuit
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ReviewPersuit : Form
    {
        /// Properties
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public bool everythingOk { get; set; }
        public bool closeApp { get; set; }
        public bool toHome { get; set; }

        #endregion

        ///
        #region Private Variables

        /// <summary>
        /// 
        /// </summary>
        private eyetrackerDataEyeX eyetrackerDataL;
        private StimuloPersuitSetup stimuloPersuitSetup;
        private TestData1 _testData;
        string date;
        string date_loc;
        string user_id;

        #endregion

        /// Init
        #region Init

        /// <summary>
        /// 
        /// </summary>
        /// <param name="showLastTest"></param>
        /// <param name="newTestAvailable"></param>
        /// <param name="inputData"></param>
        /// <param name="eyetrackerDataJson"></param>
        /// <param name="testData"></param>
        public ReviewPersuit(bool showLastTest, bool newTestAvailable, string inputData, string eyetrackerDataJson, OutputTestData2 testData)
        {
            InitializeComponentBlock();
            Init(showLastTest, newTestAvailable, inputData, eyetrackerDataJson, testData);            
        }

        private void InitializeComponentBlock()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception)
            {
                try
                {
                    InitializeComponent();
                }
                catch (Exception ex)
                {
                    LookAndPlayForm.ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                }
            }
        }

        private void Init(bool showLastTest, bool newTestAvailable, string inputData, string eyetrackerDataJson, OutputTestData2 testData)
        {
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            closeApp = true;

            if (showLastTest)
            {
                inputData = DataBaseWorker.LoadLastPursuitData(out date, out user_id, out eyetrackerDataJson, out testData);
            }

            this.date_loc = testData.date_loc;
            this.user_id = testData.user_id;
            date = testData.date;

            buttonNewTest.Enabled = newTestAvailable;

            //Console.WriteLine("selectedPath: " + selectedPath);

            toolStripStatusLabelFileName.Text = string.Format("{0}-us{1}", date_loc, user_id);

            eyetrackerDataL = ReviewClass.loadEyetrackerDataFromJson(eyetrackerDataJson);
            _testData = DataConverter.TestData2ToTestData1(testData);
            stimuloPersuitSetup = ReviewClass.loadPersuitDataFromJson(inputData);

            everythingOk = ReviewClass.eyetrackerDataFound(eyetrackerDataL) & ReviewClass.testDataFound(_testData) & ReviewClass.persuitDataFound(stimuloPersuitSetup);

            if (everythingOk)
            {
                plotGazeData2Control();
            }
        }

        #endregion

        private void buttonPlot_Click(object sender, EventArgs e)
        {
            if (everythingOk)
            {
                plotGazeData2Control();
            }
        }

        private void plotGazeData2Control()
        {
            foreach (var series in chartHorizontalGaze.Series)
            {
                series.Points.Clear();
            }

            plotReference();

            List<ReviewClass.GazePositionAndTimeClass> gazeDataDoubleList;

            if (checkBoxL.Checked)
            {
                gazeDataDoubleList = ReviewClass.getGazePositionAndTimeList(eyetrackerDataL, _testData, Eye.left);
                plotGazeDataList(gazeDataDoubleList, Eye.left, settings.leftEyeColor);
            }

            if (checkBoxR.Checked)
            {
                gazeDataDoubleList = ReviewClass.getGazePositionAndTimeList(eyetrackerDataL, _testData, Eye.right);
                plotGazeDataList(gazeDataDoubleList, Eye.right, settings.rightEyeColor);
            }
        }

        private void plotReference()
        {
            string nombreSerie = "Reference";

            for (int indice = 0; indice < stimuloPersuitSetup.stimulusDataList.Count; indice++)
            {
                chartHorizontalGaze.Series[nombreSerie].Points.AddXY(stimuloPersuitSetup.stimulusDataList[indice].timeSegundos, stimuloPersuitSetup.stimulusDataList[indice].dotPositionPixels.X);
            }

            //chartHorizontalGaze.Series[nombreSerie].Color = eyeColor;
            chartHorizontalGaze.Invalidate();
        }

        private void plotGazeDataList(List<ReviewClass.GazePositionAndTimeClass> gazeDataDoubleList, Eye eye2Plot, Color eyeColor)
        {
            string nombreSerieX;
            string nombreSerieY;
            if (eye2Plot == Eye.left)
            {
                nombreSerieX = "Left Gaze X";
                nombreSerieY = "Left Gaze Y";
            }
            else
            {
                nombreSerieX = "Right Gaze X";
                nombreSerieY = "Right Gaze Y";
            }

            for(int indice = 0; indice < gazeDataDoubleList.Count; indice++)
            {
                chartHorizontalGaze.Series[nombreSerieX].Points.AddXY(gazeDataDoubleList[indice].timeSegundos, gazeDataDoubleList[indice].gazePosition.X);
                chartHorizontalGaze.Series[nombreSerieY].Points.AddXY(gazeDataDoubleList[indice].timeSegundos, gazeDataDoubleList[indice].gazePosition.Y);
            }

            chartHorizontalGaze.Series[nombreSerieX].Color = eyeColor;
            chartHorizontalGaze.Invalidate();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            toHome = true;
            closeApp = false;
            this.Close();
        }

        private void buttonComment_Click(object sender, EventArgs e)
        {
            CommentsForm commentsF = new CommentsForm(date, user_id);
            commentsF.Show();
        }

        private void buttonNewTest_Click(object sender, EventArgs e)
        {
            toHome = false;
            closeApp = false;
            this.Close();
        }
    }
}