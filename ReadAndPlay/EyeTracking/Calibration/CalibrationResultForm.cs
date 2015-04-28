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
        sharedData datosCompartidos;

        public CalibrationResultForm()
        {
            this.datosCompartidos = LookAndPlayForm.Program.datosCompartidos;
            InitializeComponent();
        }

        public void SetPlotData(Tobii.Gaze.Core.Calibration calibration)
        {
            _leftPlot.Initialize(calibration.GetCalibrationPointDataItems());
            _rightPlot.Initialize(calibration.GetCalibrationPointDataItems());
            textBoxCalibrationErrorLeft.Text = datosCompartidos.meanCalibrationErrorLeftPx.ToString();
            textBoxCalibrationErrorRight.Text = datosCompartidos.meanCalibrationErrorRightPx.ToString();
            labelError.Text = "Error (px)";
        }

        //public void SetPlotData(TETCSharpClient.Data.CalibrationResult calibration)
        //{
        //    _leftPlot.Initialize(calibration);
        //    _rightPlot.Initialize(calibration);
        //    textBoxCalibrationErrorLeft.Text = datosCompartidos.averageErrorDegreeLeft.ToString();
        //    textBoxCalibrationErrorRight.Text = datosCompartidos.averageErrorDegreeRight.ToString();
        //    labelError.Text = "Error (de)";
        //}

        private void _okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}