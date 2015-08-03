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

namespace ReviewPersuit
{
    public partial class ReviewPersuit : Form
    {
        public ReviewPersuit(bool showLastTest, bool newTestAvailable, string selectedPath)
        {
            InitializeComponent();

            Random rdn = new Random();

            for (int i = 0; i < 720; i++)
            {
                chartHorizontalGaze.Series["Reference"].Points.AddXY(i, Math.Sin(grados2radianes(i)));
                chartHorizontalGaze.Series["Right Gaze"].Points.AddXY(i, Math.Sin(grados2radianes(i + rdn.Next(0, 10))));
                chartHorizontalGaze.Series["Left Gaze"].Points.AddXY(i, Math.Sin(grados2radianes(i + rdn.Next(0, 10))));
            }

            chartHorizontalGaze.Series["Reference"].ChartType = SeriesChartType.FastLine;
            chartHorizontalGaze.Series["Reference"].Color = Color.Red;

            chartHorizontalGaze.Series["Right Gaze"].ChartType = SeriesChartType.FastLine;
            chartHorizontalGaze.Series["Right Gaze"].Color = Color.Blue;

            chartHorizontalGaze.Series["Left Gaze"].ChartType = SeriesChartType.FastLine;
            chartHorizontalGaze.Series["Left Gaze"].Color = Color.Green;

            chartHorizontalGaze.Invalidate();
        }

        private double grados2radianes(double grados)
        {
            return grados * Math.PI / 180;
        }
    }
}
