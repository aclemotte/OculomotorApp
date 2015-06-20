//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------

namespace LookAndPlayForm
{
    partial class EyeXWinForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EyeXWinForm));
            this.buttonGame1 = new System.Windows.Forms.Button();
            this.progressBar4Distance = new System.Windows.Forms.ProgressBar();
            this.buttonViewCalibration = new System.Windows.Forms.Button();
            this.buttonResumen = new System.Windows.Forms.Button();
            this.buttonCalibrate = new System.Windows.Forms.Button();
            this.labelDistance = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._trackStatusControlMirada = new LookAndPlayForm.TrackStatusControlMirada();
            this._trackStatus = new LookAndPlayForm.TrackStatusControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCalibration = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGame1
            // 
            this.buttonGame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGame1.Location = new System.Drawing.Point(145, 19);
            this.buttonGame1.Name = "buttonGame1";
            this.buttonGame1.Size = new System.Drawing.Size(100, 30);
            this.buttonGame1.TabIndex = 2;
            this.buttonGame1.Text = "Test 1";
            this.buttonGame1.UseVisualStyleBackColor = true;
            this.buttonGame1.Click += new System.EventHandler(this.buttonGame1_Click);
            // 
            // progressBar4Distance
            // 
            this.progressBar4Distance.Location = new System.Drawing.Point(9, 242);
            this.progressBar4Distance.Name = "progressBar4Distance";
            this.progressBar4Distance.Size = new System.Drawing.Size(256, 23);
            this.progressBar4Distance.TabIndex = 5;
            // 
            // buttonViewCalibration
            // 
            this.buttonViewCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewCalibration.Location = new System.Drawing.Point(153, 19);
            this.buttonViewCalibration.Name = "buttonViewCalibration";
            this.buttonViewCalibration.Size = new System.Drawing.Size(100, 30);
            this.buttonViewCalibration.TabIndex = 6;
            this.buttonViewCalibration.Text = "Calibration";
            this.buttonViewCalibration.UseVisualStyleBackColor = true;
            this.buttonViewCalibration.Click += new System.EventHandler(this.buttonViewCalibration_Click);
            // 
            // buttonResumen
            // 
            this.buttonResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResumen.Location = new System.Drawing.Point(24, 19);
            this.buttonResumen.Name = "buttonResumen";
            this.buttonResumen.Size = new System.Drawing.Size(100, 30);
            this.buttonResumen.TabIndex = 7;
            this.buttonResumen.Text = "Resume";
            this.buttonResumen.UseVisualStyleBackColor = true;
            this.buttonResumen.Click += new System.EventHandler(this.buttonResumen_Click);
            // 
            // buttonCalibrate
            // 
            this.buttonCalibrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalibrate.Location = new System.Drawing.Point(19, 19);
            this.buttonCalibrate.Name = "buttonCalibrate";
            this.buttonCalibrate.Size = new System.Drawing.Size(100, 30);
            this.buttonCalibrate.TabIndex = 22;
            this.buttonCalibrate.Text = "Calibrate";
            this.buttonCalibrate.UseVisualStyleBackColor = true;
            this.buttonCalibrate.Click += new System.EventHandler(this.buttonCalibrate_Click);
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.ForeColor = System.Drawing.Color.Black;
            this.labelDistance.Location = new System.Drawing.Point(10, 268);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(67, 13);
            this.labelDistance.TabIndex = 23;
            this.labelDistance.Text = "Distance OK";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonGame1);
            this.groupBox1.Controls.Add(this.buttonResumen);
            this.groupBox1.Location = new System.Drawing.Point(291, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 64);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCalibrate);
            this.groupBox2.Controls.Add(this.buttonViewCalibration);
            this.groupBox2.Location = new System.Drawing.Point(12, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 64);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 24);
            this.label1.TabIndex = 26;
            this.label1.Text = "Eye position";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(356, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 24);
            this.label3.TabIndex = 27;
            this.label3.Text = "Gaze position";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.progressBar4Distance);
            this.groupBox3.Controls.Add(this.labelDistance);
            this.groupBox3.Location = new System.Drawing.Point(291, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 291);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(12, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(273, 291);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            // 
            // _trackStatusControlMirada
            // 
            this._trackStatusControlMirada.BackColor = System.Drawing.Color.Black;
            this._trackStatusControlMirada.Location = new System.Drawing.Point(300, 46);
            this._trackStatusControlMirada.Name = "_trackStatusControlMirada";
            this._trackStatusControlMirada.Size = new System.Drawing.Size(256, 201);
            this._trackStatusControlMirada.TabIndex = 4;
            // 
            // _trackStatus
            // 
            this._trackStatus.BackColor = System.Drawing.Color.Black;
            this._trackStatus.Location = new System.Drawing.Point(20, 46);
            this._trackStatus.Name = "_trackStatus";
            this._trackStatus.Size = new System.Drawing.Size(256, 226);
            this._trackStatus.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCalibration});
            this.statusStrip1.Location = new System.Drawing.Point(0, 399);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(576, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCalibration
            // 
            this.toolStripStatusLabelCalibration.Name = "toolStripStatusLabelCalibration";
            this.toolStripStatusLabelCalibration.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabelCalibration.Text = "Calibration Result";
            // 
            // EyeXWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 421);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._trackStatusControlMirada);
            this.Controls.Add(this._trackStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "EyeXWinForm";
            this.Text = "Read analysis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EyeXWinForm_FormClosed);
            this.Load += new System.EventHandler(this.EyeXWinForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGame1;
        private TrackStatusControl _trackStatus;
        private TrackStatusControlMirada _trackStatusControlMirada;
        private System.Windows.Forms.ProgressBar progressBar4Distance;
        private System.Windows.Forms.Button buttonViewCalibration;
        private System.Windows.Forms.Button buttonResumen;
        private System.Windows.Forms.Button buttonCalibrate;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCalibration;
    }
}

