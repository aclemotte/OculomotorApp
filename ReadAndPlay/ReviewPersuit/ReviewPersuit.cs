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
using LookAndPlayForm.Review;

namespace ReviewPersuit
{
    public partial class ReviewPersuit : Form
    {

        bool newTest;
        bool eyetrackerDataFound;
        bool testDataFound;
        bool everythingOk;



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

            //eyetrackerDataFound = ReviewClass.loadEyetrackerDataFromJson(selectedPath);
            //testDataFound = ReviewClass.loadTestDataFromJson(selectedPath);


            //getStimulusFeactures(eyetrackerDataFound);
            //imageFound = class4Graphic.loadImage2Control(testDataFound, testData, pictureBoxStimulus);

            everythingOk = eyetrackerDataFound & testDataFound; // &imageFound;

        }

        //private double grados2radianes(double grados)
        //{
        //    return grados * Math.PI / 180;
        //}
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