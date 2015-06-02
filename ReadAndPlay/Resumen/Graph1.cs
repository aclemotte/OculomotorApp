using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LookAndPlayForm.FixDetector;

namespace LookAndPlayForm.Resumen
{
    public partial class Graph1 : Form
    {

        TestData testData;
        fixationData fixData;
        eyetrackerDataEyeX eyetrackerDataL;
        Size stimulusSize;
        Point stimulusLocation;

        CheckBox checkBoxGaze;
        CheckBox checkBoxFixations;
        CheckBox checkBoxL;
        CheckBox checkBoxR;

        int fixDotRadius = 7;
        int gazeDotRadius = 2;


        public Graph1(TestData testData, Size stimulusSize, Point stimulusLocation, fixationData fixData, eyetrackerDataEyeX eyetrackerDataL, CheckBox checkBoxGaze, CheckBox checkBoxFixations, CheckBox checkBoxL, CheckBox checkBoxR)
        {
            InitializeComponent();

            this.testData = testData;
            this.fixData = fixData;
            this.stimulusSize = stimulusSize;
            this.stimulusLocation = stimulusLocation;
            this.eyetrackerDataL = eyetrackerDataL; 
            class4Graphic.loadImage2Control(true, testData, pictureBoxStimulus);


            pictureBoxStimulus.Size = stimulusSize;
            pictureBoxStimulus.Location = stimulusLocation;

            this.checkBoxGaze = checkBoxGaze;
            this.checkBoxFixations = checkBoxFixations;
            this.checkBoxL = checkBoxL;
            this.checkBoxR = checkBoxR;

        }


        //Botones
        private void buttonPlot_Click(object sender, EventArgs e)
        {
            plotGazeData2Control();
            plotFixData2Control();
        }

        private void plotGazeData2Control()
        {
            List<Point> gazeDataDoubleList;

            if (checkBoxGaze.Checked)
            {
                if (checkBoxL.Checked)
                {
                    gazeDataDoubleList = class4Graphic.getGazeData2List(eyetrackerDataL, testData, eye.left);
                    class4Graphic.plotGazeDataList(gazeDataDoubleList, Color.Red, gazeDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                }

                if (checkBoxR.Checked)
                {
                    gazeDataDoubleList = class4Graphic.getGazeData2List(eyetrackerDataL, testData, eye.right);
                    class4Graphic.plotGazeDataList(gazeDataDoubleList, Color.Blue, gazeDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                }
            }
        }

        private void plotFixData2Control()
        {
            List<Point> fixDataList = new List<Point>();

            if (checkBoxFixations.Checked)
            {
                if (checkBoxL.Checked)
                {

                    fixDataList = class4Graphic.fixData2List(fixData, eye.left);
                    class4Graphic.plotFixDataList(fixDataList, Color.Red, fixDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                    class4Graphic.plotLinesBetweenFixs(fixDataList, Color.Red, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                }

                if (checkBoxR.Checked)
                {
                    fixDataList = class4Graphic.fixData2List(fixData, eye.right);
                    class4Graphic.plotFixDataList(fixDataList, Color.Blue, fixDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                    class4Graphic.plotLinesBetweenFixs(fixDataList, Color.Blue, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                }
            }
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
