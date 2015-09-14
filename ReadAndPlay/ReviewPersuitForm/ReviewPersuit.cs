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

namespace ReviewPersuit
{
    public partial class ReviewPersuit : Form
    {
        public bool everythingOk { get; set; }
        public bool closeApp { get; set; }
        public bool toHome { get; set; }


        private eyetrackerDataEyeX eyetrackerDataL;
        private TestData1 testData;
        private StimuloPersuitSetup stimuloPersuitSetup;
        private string selectedPath;







        public ReviewPersuit(bool showLastTest, bool newTestAvailable, string selectedPath)
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            closeApp = true;

            if (showLastTest)
            {
                selectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\" +
                                Program.datosCompartidos.startTimeTest +
                                @"-us" + Program.datosCompartidos.activeUser + @"\";
            }

            this.selectedPath = selectedPath;
            buttonHome.Enabled = newTestAvailable;//era para cuando se le llamaba desde el form de paciente. ahora siempre es true;

            Console.WriteLine("selectedPath: " + selectedPath);

            toolStripStatusLabelFileName.Text = selectedPath;

            eyetrackerDataL = ReviewClass.loadEyetrackerDataFromJson(selectedPath);
            testData = ReviewClass.loadTestDataFromJson(selectedPath);
            stimuloPersuitSetup = ReviewClass.loadPersuitDataFromJson(selectedPath);

            everythingOk = ReviewClass.eyetrackerDataFound(eyetrackerDataL) & ReviewClass.testDataFound(testData) & ReviewClass.persuitDataFound(stimuloPersuitSetup);

            if (everythingOk)
            {
                plotGazeData2Control();
            }
        }

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
                gazeDataDoubleList = ReviewClass.getGazePositionAndTimeList(eyetrackerDataL, testData, eye.left);
                plotGazeDataList(gazeDataDoubleList, eye.left, settings.leftEyeColor);
            }

            if (checkBoxR.Checked)
            {
                gazeDataDoubleList = ReviewClass.getGazePositionAndTimeList(eyetrackerDataL, testData, eye.right);
                plotGazeDataList(gazeDataDoubleList, eye.right, settings.rightEyeColor);
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

        private void plotGazeDataList(List<ReviewClass.GazePositionAndTimeClass> gazeDataDoubleList, eye eye2Plot, Color eyeColor)
        {
            string nombreSerieX;
            string nombreSerieY;
            if (eye2Plot == eye.left)
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
            CommentsForm commentsF = new CommentsForm(selectedPath);
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