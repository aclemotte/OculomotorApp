using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tobii.Gaze.Core;

namespace LookAndPlayForm
{
    public partial class CalibrationResultForm : Form
    {
        public CalibrationResultForm()
        {
            InitializeComponent();
        }

        public void SetPlotData(Tobii.Gaze.Core.Calibration calibration)
        {
            _leftPlot.Initialize(calibration.GetCalibrationPointDataItems());
            _rightPlot.Initialize(calibration.GetCalibrationPointDataItems());
            textBoxCalibrationErrorLeft.Text = Program.datosCompartidos.meanCalibrationErrorLeftPx.ToString();
            textBoxCalibrationErrorRight.Text = Program.datosCompartidos.meanCalibrationErrorRightPx.ToString();
            labelError.Text = "Error (px)";
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}