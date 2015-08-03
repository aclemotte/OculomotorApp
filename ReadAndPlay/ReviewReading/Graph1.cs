using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LookAndPlayForm.FixDetector;
using LookAndPlayForm.LogEyeTracker;

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
                    class4Graphic.plotGazeDataList(gazeDataDoubleList, settings.leftEyeColor, gazeDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                }

                if (checkBoxR.Checked)
                {
                    gazeDataDoubleList = class4Graphic.getGazeData2List(eyetrackerDataL, testData, eye.right);
                    class4Graphic.plotGazeDataList(gazeDataDoubleList, settings.rightEyeColor, gazeDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
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
                    class4Graphic.plotFixDataList(fixDataList, settings.leftEyeColor, fixDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                    class4Graphic.plotLinesBetweenFixs(fixDataList, settings.leftEyeColor, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                }

                if (checkBoxR.Checked)
                {
                    fixDataList = class4Graphic.fixData2List(fixData, eye.right);
                    class4Graphic.plotFixDataList(fixDataList, settings.rightEyeColor, fixDotRadius, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                    class4Graphic.plotLinesBetweenFixs(fixDataList, settings.rightEyeColor, this, pictureBoxStimulus, stimulusSize, stimulusLocation);
                }
            }
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
