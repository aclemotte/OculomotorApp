namespace LookAndPlayForm.Resumen
{
    partial class Resumen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resumen));
            this.pictureBoxStimulus = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonPlot = new System.Windows.Forms.Button();
            this.textBoxStdFixL = new System.Windows.Forms.TextBox();
            this.textBoxMeanFixL = new System.Windows.Forms.TextBox();
            this.textBoxNumFixL = new System.Windows.Forms.TextBox();
            this.textBoxStdFixR = new System.Windows.Forms.TextBox();
            this.textBoxMeanFixR = new System.Windows.Forms.TextBox();
            this.textBoxNumFixR = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxL = new System.Windows.Forms.CheckBox();
            this.checkBoxR = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxFixs100WR = new System.Windows.Forms.TextBox();
            this.textBoxFixs100WL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSORR = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxSORL = new System.Windows.Forms.TextBox();
            this.textBoxWordsMin = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxFixations = new System.Windows.Forms.CheckBox();
            this.checkBoxGaze = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxCalibErrorR = new System.Windows.Forms.TextBox();
            this.textBoxCalibErrorL = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.statusStripResumen = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelString = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonPlotExtern = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStimulus)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStripResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxStimulus
            // 
            this.pictureBoxStimulus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxStimulus.Location = new System.Drawing.Point(12, 41);
            this.pictureBoxStimulus.Name = "pictureBoxStimulus";
            this.pictureBoxStimulus.Size = new System.Drawing.Size(850, 343);
            this.pictureBoxStimulus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStimulus.TabIndex = 5;
            this.pictureBoxStimulus.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 431);
            this.label1.MaximumSize = new System.Drawing.Size(140, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 48);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total number of fixation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(255, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mean and Std Duration (sec)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Words per minute";
            // 
            // buttonPlot
            // 
            this.buttonPlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlot.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonPlot.Location = new System.Drawing.Point(889, 41);
            this.buttonPlot.Name = "buttonPlot";
            this.buttonPlot.Size = new System.Drawing.Size(112, 38);
            this.buttonPlot.TabIndex = 1;
            this.buttonPlot.Text = "Plot";
            this.buttonPlot.UseVisualStyleBackColor = true;
            this.buttonPlot.Click += new System.EventHandler(this.buttonPlot_Click);
            // 
            // textBoxStdFixL
            // 
            this.textBoxStdFixL.BackColor = System.Drawing.Color.White;
            this.textBoxStdFixL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStdFixL.Location = new System.Drawing.Point(412, 482);
            this.textBoxStdFixL.Name = "textBoxStdFixL";
            this.textBoxStdFixL.ReadOnly = true;
            this.textBoxStdFixL.Size = new System.Drawing.Size(70, 29);
            this.textBoxStdFixL.TabIndex = 13;
            // 
            // textBoxMeanFixL
            // 
            this.textBoxMeanFixL.BackColor = System.Drawing.Color.White;
            this.textBoxMeanFixL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMeanFixL.Location = new System.Drawing.Point(272, 482);
            this.textBoxMeanFixL.Name = "textBoxMeanFixL";
            this.textBoxMeanFixL.ReadOnly = true;
            this.textBoxMeanFixL.Size = new System.Drawing.Size(70, 29);
            this.textBoxMeanFixL.TabIndex = 12;
            // 
            // textBoxNumFixL
            // 
            this.textBoxNumFixL.BackColor = System.Drawing.Color.White;
            this.textBoxNumFixL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumFixL.Location = new System.Drawing.Point(135, 482);
            this.textBoxNumFixL.Name = "textBoxNumFixL";
            this.textBoxNumFixL.ReadOnly = true;
            this.textBoxNumFixL.Size = new System.Drawing.Size(70, 29);
            this.textBoxNumFixL.TabIndex = 11;
            // 
            // textBoxStdFixR
            // 
            this.textBoxStdFixR.BackColor = System.Drawing.Color.White;
            this.textBoxStdFixR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStdFixR.Location = new System.Drawing.Point(412, 536);
            this.textBoxStdFixR.Name = "textBoxStdFixR";
            this.textBoxStdFixR.ReadOnly = true;
            this.textBoxStdFixR.Size = new System.Drawing.Size(70, 29);
            this.textBoxStdFixR.TabIndex = 17;
            // 
            // textBoxMeanFixR
            // 
            this.textBoxMeanFixR.BackColor = System.Drawing.Color.White;
            this.textBoxMeanFixR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMeanFixR.Location = new System.Drawing.Point(272, 536);
            this.textBoxMeanFixR.Name = "textBoxMeanFixR";
            this.textBoxMeanFixR.ReadOnly = true;
            this.textBoxMeanFixR.Size = new System.Drawing.Size(70, 29);
            this.textBoxMeanFixR.TabIndex = 16;
            // 
            // textBoxNumFixR
            // 
            this.textBoxNumFixR.BackColor = System.Drawing.Color.White;
            this.textBoxNumFixR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumFixR.Location = new System.Drawing.Point(135, 536);
            this.textBoxNumFixR.Name = "textBoxNumFixR";
            this.textBoxNumFixR.ReadOnly = true;
            this.textBoxNumFixR.Size = new System.Drawing.Size(70, 29);
            this.textBoxNumFixR.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 536);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 24);
            this.label6.TabIndex = 20;
            this.label6.Text = "R";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(60, 482);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 24);
            this.label7.TabIndex = 21;
            this.label7.Text = "L";
            // 
            // checkBoxL
            // 
            this.checkBoxL.AutoSize = true;
            this.checkBoxL.Checked = true;
            this.checkBoxL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxL.ForeColor = System.Drawing.Color.Red;
            this.checkBoxL.Location = new System.Drawing.Point(911, 109);
            this.checkBoxL.Name = "checkBoxL";
            this.checkBoxL.Size = new System.Drawing.Size(39, 28);
            this.checkBoxL.TabIndex = 22;
            this.checkBoxL.Text = "L";
            this.checkBoxL.UseVisualStyleBackColor = true;
            // 
            // checkBoxR
            // 
            this.checkBoxR.AutoSize = true;
            this.checkBoxR.Checked = true;
            this.checkBoxR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxR.ForeColor = System.Drawing.Color.Blue;
            this.checkBoxR.Location = new System.Drawing.Point(911, 162);
            this.checkBoxR.Name = "checkBoxR";
            this.checkBoxR.Size = new System.Drawing.Size(42, 28);
            this.checkBoxR.TabIndex = 23;
            this.checkBoxR.Text = "R";
            this.checkBoxR.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFixs100WR);
            this.groupBox1.Controls.Add(this.textBoxFixs100WL);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxSORR);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxSORL);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxWordsMin);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 240);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fixation analysis";
            // 
            // textBoxFixs100WR
            // 
            this.textBoxFixs100WR.BackColor = System.Drawing.Color.White;
            this.textBoxFixs100WR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFixs100WR.Location = new System.Drawing.Point(676, 148);
            this.textBoxFixs100WR.Name = "textBoxFixs100WR";
            this.textBoxFixs100WR.ReadOnly = true;
            this.textBoxFixs100WR.Size = new System.Drawing.Size(70, 29);
            this.textBoxFixs100WR.TabIndex = 106;
            // 
            // textBoxFixs100WL
            // 
            this.textBoxFixs100WL.BackColor = System.Drawing.Color.White;
            this.textBoxFixs100WL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFixs100WL.Location = new System.Drawing.Point(676, 94);
            this.textBoxFixs100WL.Name = "textBoxFixs100WL";
            this.textBoxFixs100WL.ReadOnly = true;
            this.textBoxFixs100WL.Size = new System.Drawing.Size(70, 29);
            this.textBoxFixs100WL.TabIndex = 105;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(643, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 24);
            this.label5.TabIndex = 104;
            this.label5.Text = "Fixs/100Words";
            // 
            // textBoxSORR
            // 
            this.textBoxSORR.BackColor = System.Drawing.Color.White;
            this.textBoxSORR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSORR.Location = new System.Drawing.Point(532, 148);
            this.textBoxSORR.Name = "textBoxSORR";
            this.textBoxSORR.ReadOnly = true;
            this.textBoxSORR.Size = new System.Drawing.Size(70, 29);
            this.textBoxSORR.TabIndex = 103;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(519, 44);
            this.label10.MaximumSize = new System.Drawing.Size(120, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 48);
            this.label10.TabIndex = 101;
            this.label10.Text = "Span of Recognition";
            // 
            // textBoxSORL
            // 
            this.textBoxSORL.BackColor = System.Drawing.Color.White;
            this.textBoxSORL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSORL.Location = new System.Drawing.Point(532, 94);
            this.textBoxSORL.Name = "textBoxSORL";
            this.textBoxSORL.ReadOnly = true;
            this.textBoxSORL.Size = new System.Drawing.Size(70, 29);
            this.textBoxSORL.TabIndex = 102;
            // 
            // textBoxWordsMin
            // 
            this.textBoxWordsMin.BackColor = System.Drawing.Color.White;
            this.textBoxWordsMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWordsMin.Location = new System.Drawing.Point(260, 196);
            this.textBoxWordsMin.Name = "textBoxWordsMin";
            this.textBoxWordsMin.ReadOnly = true;
            this.textBoxWordsMin.Size = new System.Drawing.Size(70, 29);
            this.textBoxWordsMin.TabIndex = 4;
            this.textBoxWordsMin.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(889, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 109);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // checkBoxFixations
            // 
            this.checkBoxFixations.AutoSize = true;
            this.checkBoxFixations.Checked = true;
            this.checkBoxFixations.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFixations.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFixations.Location = new System.Drawing.Point(908, 227);
            this.checkBoxFixations.Name = "checkBoxFixations";
            this.checkBoxFixations.Size = new System.Drawing.Size(104, 28);
            this.checkBoxFixations.TabIndex = 27;
            this.checkBoxFixations.Text = "Fixations";
            this.checkBoxFixations.UseVisualStyleBackColor = true;
            // 
            // checkBoxGaze
            // 
            this.checkBoxGaze.AutoSize = true;
            this.checkBoxGaze.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGaze.Location = new System.Drawing.Point(908, 271);
            this.checkBoxGaze.Name = "checkBoxGaze";
            this.checkBoxGaze.Size = new System.Drawing.Size(73, 28);
            this.checkBoxGaze.TabIndex = 28;
            this.checkBoxGaze.Text = "Gaze";
            this.checkBoxGaze.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(889, 206);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(133, 109);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            // 
            // textBoxCalibErrorR
            // 
            this.textBoxCalibErrorR.BackColor = System.Drawing.Color.White;
            this.textBoxCalibErrorR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCalibErrorR.Location = new System.Drawing.Point(932, 579);
            this.textBoxCalibErrorR.Name = "textBoxCalibErrorR";
            this.textBoxCalibErrorR.ReadOnly = true;
            this.textBoxCalibErrorR.Size = new System.Drawing.Size(70, 26);
            this.textBoxCalibErrorR.TabIndex = 30;
            // 
            // textBoxCalibErrorL
            // 
            this.textBoxCalibErrorL.BackColor = System.Drawing.Color.White;
            this.textBoxCalibErrorL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCalibErrorL.Location = new System.Drawing.Point(932, 524);
            this.textBoxCalibErrorL.Name = "textBoxCalibErrorL";
            this.textBoxCalibErrorL.ReadOnly = true;
            this.textBoxCalibErrorL.Size = new System.Drawing.Size(70, 26);
            this.textBoxCalibErrorL.TabIndex = 29;
            // 
            // groupBox4
            // 
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(889, 477);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(133, 157);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Calibration";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(906, 524);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 24);
            this.label8.TabIndex = 32;
            this.label8.Text = "L";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(906, 578);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 24);
            this.label9.TabIndex = 31;
            this.label9.Text = "R";
            // 
            // statusStripResumen
            // 
            this.statusStripResumen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelString,
            this.toolStripStatusLabelFileName});
            this.statusStripResumen.Location = new System.Drawing.Point(0, 633);
            this.statusStripResumen.Name = "statusStripResumen";
            this.statusStripResumen.Size = new System.Drawing.Size(1034, 26);
            this.statusStripResumen.TabIndex = 101;
            this.statusStripResumen.Text = "File name";
            // 
            // toolStripStatusLabelString
            // 
            this.toolStripStatusLabelString.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelString.Name = "toolStripStatusLabelString";
            this.toolStripStatusLabelString.Size = new System.Drawing.Size(83, 21);
            this.toolStripStatusLabelString.Text = "File Name:";
            // 
            // toolStripStatusLabelFileName
            // 
            this.toolStripStatusLabelFileName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelFileName.Name = "toolStripStatusLabelFileName";
            this.toolStripStatusLabelFileName.Size = new System.Drawing.Size(0, 21);
            // 
            // buttonPlotExtern
            // 
            this.buttonPlotExtern.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlotExtern.Location = new System.Drawing.Point(890, 334);
            this.buttonPlotExtern.Name = "buttonPlotExtern";
            this.buttonPlotExtern.Size = new System.Drawing.Size(132, 50);
            this.buttonPlotExtern.TabIndex = 102;
            this.buttonPlotExtern.Text = "Plot (new window)";
            this.buttonPlotExtern.UseVisualStyleBackColor = true;
            this.buttonPlotExtern.Click += new System.EventHandler(this.buttonPlotExtern_Click);
            // 
            // Resumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 659);
            this.Controls.Add(this.buttonPlotExtern);
            this.Controls.Add(this.statusStripResumen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxCalibErrorR);
            this.Controls.Add(this.textBoxCalibErrorL);
            this.Controls.Add(this.checkBoxGaze);
            this.Controls.Add(this.checkBoxFixations);
            this.Controls.Add(this.checkBoxR);
            this.Controls.Add(this.checkBoxL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxStdFixR);
            this.Controls.Add(this.textBoxMeanFixR);
            this.Controls.Add(this.textBoxNumFixR);
            this.Controls.Add(this.textBoxStdFixL);
            this.Controls.Add(this.textBoxMeanFixL);
            this.Controls.Add(this.textBoxNumFixL);
            this.Controls.Add(this.buttonPlot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxStimulus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Resumen";
            this.Text = "Resume";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStimulus)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStripResumen.ResumeLayout(false);
            this.statusStripResumen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxStimulus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonPlot;
        private System.Windows.Forms.TextBox textBoxStdFixL;
        private System.Windows.Forms.TextBox textBoxMeanFixL;
        private System.Windows.Forms.TextBox textBoxNumFixL;
        private System.Windows.Forms.TextBox textBoxStdFixR;
        private System.Windows.Forms.TextBox textBoxMeanFixR;
        private System.Windows.Forms.TextBox textBoxNumFixR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxL;
        private System.Windows.Forms.CheckBox checkBoxR;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxFixations;
        private System.Windows.Forms.CheckBox checkBoxGaze;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxCalibErrorR;
        private System.Windows.Forms.TextBox textBoxCalibErrorL;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxSORR;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxSORL;
        private System.Windows.Forms.StatusStrip statusStripResumen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelString;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFileName;
        private System.Windows.Forms.TextBox textBoxWordsMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFixs100WR;
        private System.Windows.Forms.TextBox textBoxFixs100WL;
        private System.Windows.Forms.Button buttonPlotExtern;




    }
}