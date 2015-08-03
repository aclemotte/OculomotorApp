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
using LookAndPlayForm.LogEyeTracker;
using LookAndPlayForm.Review;

namespace ReviewPersuit
{
    public partial class ReviewPersuit : Form
    {

        bool newTest;
        bool everythingOk;

        eyetrackerDataEyeX eyetrackerDataL;
        TestData testData;



        public ReviewPersuit(bool showLastTest, bool newTestAvailable, string selectedPath)
        {
            InitializeComponent();

            newTest = false;

            if (showLastTest)
            {
                selectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\" +
                                Program.datosCompartidos.startTimeTest +
                                @"-us" + Program.datosCompartidos.activeUser + @"\";
            }

            buttonNewTest.Enabled = newTestAvailable;//se quito. era para cuando se le llamaba desde el form de paciente

            Console.WriteLine("selectedPath: " + selectedPath);

            toolStripStatusLabelFileName.Text = selectedPath;

            eyetrackerDataL = ReviewClass.loadEyetrackerDataFromJson(selectedPath);
            testData = ReviewClass.loadTestDataFromJson(selectedPath);
            //getStimulusFeactures(ReviewClass.eyetrackerDataFound(eyetrackerDataL));
            //imageFound = class4Graphic.loadImage2Control(ReviewClass.testDataFound(testData), testData, pictureBoxStimulus);

            everythingOk = ReviewClass.eyetrackerDataFound(eyetrackerDataL) & ReviewClass.testDataFound(testData);

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
    }
}



//Random rdn = new Random();

//for (int i = 0; i < 720; i++)
//{
//    chartHorizontalGaze.Series["Reference"].Points.AddXY(i, Math.Sin(grados2radianes(i)));
//    chartHorizontalGaze.Series["Right Gaze"].Points.AddXY(i, Math.Sin(grados2radianes(i + rdn.Next(0, 10))));
//    chartHorizontalGaze.Series["Left Gaze"].Points.AddXY(i, Math.Sin(grados2radianes(i + rdn.Next(0, 10))));
//}

//chartHorizontalGaze.Series["Reference"].ChartType = SeriesChartType.FastLine;
//chartHorizontalGaze.Series["Reference"].Color = Color.Red;

//chartHorizontalGaze.Series["Right Gaze"].ChartType = SeriesChartType.FastLine;
//chartHorizontalGaze.Series["Right Gaze"].Color = Color.Blue;

//chartHorizontalGaze.Series["Left Gaze"].ChartType = SeriesChartType.FastLine;
//chartHorizontalGaze.Series["Left Gaze"].Color = Color.Green;

//chartHorizontalGaze.Invalidate();