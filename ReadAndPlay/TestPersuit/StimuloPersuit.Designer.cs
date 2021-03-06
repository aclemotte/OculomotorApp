﻿namespace StimuloPersuitHorizontal
{
    partial class StimuloPersuit
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
            this.components = new System.ComponentModel.Container();
            this.pictureBoxDotStimulus = new System.Windows.Forms.PictureBox();
            this.timerMoveDot = new System.Windows.Forms.Timer(this.components);
            this.timerPausaInicial = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDotStimulus)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDotStimulus
            // 
            this.pictureBoxDotStimulus.Image = global::LookAndPlayForm.Properties.Resources.dotGrey;
            this.pictureBoxDotStimulus.Location = new System.Drawing.Point(58, 62);
            this.pictureBoxDotStimulus.Name = "pictureBoxDotStimulus";
            this.pictureBoxDotStimulus.Size = new System.Drawing.Size(10, 10);
            this.pictureBoxDotStimulus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDotStimulus.TabIndex = 0;
            this.pictureBoxDotStimulus.TabStop = false;
            this.pictureBoxDotStimulus.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDotStimulus_Paint);
            // 
            // timerPausaInicial
            // 
            this.timerPausaInicial.Interval = 1000;
            this.timerPausaInicial.Tick += new System.EventHandler(this.timerPausaInicial_Tick);
            // 
            // StimuloPersuit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 499);
            this.Controls.Add(this.pictureBoxDotStimulus);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StimuloPersuit";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.StimuloPersuit_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StimuloPersuit_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDotStimulus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDotStimulus;
        private System.Windows.Forms.Timer timerMoveDot;
        private System.Windows.Forms.Timer timerPausaInicial;
    }
}

