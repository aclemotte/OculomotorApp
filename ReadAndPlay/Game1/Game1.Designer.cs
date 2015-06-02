
namespace LookAndPlayForm
{
    partial class Game1
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
            this.buttonSalir = new System.Windows.Forms.Button();
            this.pictureBoxFrame = new System.Windows.Forms.PictureBox();
            this.pictureBoxStimulus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStimulus)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(12, 12);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 0;
            this.buttonSalir.Text = "Exit";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // pictureBoxFrame
            // 
            this.pictureBoxFrame.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFrame.Name = "pictureBoxFrame";
            this.pictureBoxFrame.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxFrame.TabIndex = 2;
            this.pictureBoxFrame.TabStop = false;
            // 
            // pictureBoxStimulus
            // 
            this.pictureBoxStimulus.Location = new System.Drawing.Point(102, 54);
            this.pictureBoxStimulus.Name = "pictureBoxStimulus";
            this.pictureBoxStimulus.Size = new System.Drawing.Size(80, 61);
            this.pictureBoxStimulus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStimulus.TabIndex = 1;
            this.pictureBoxStimulus.TabStop = false;
            // 
            // Game1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(567, 404);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxStimulus);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.pictureBoxFrame);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Game1";
            this.Text = "Game1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game1_FormClosed);
            this.Load += new System.EventHandler(this.Game1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStimulus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.PictureBox pictureBoxStimulus;
        private System.Windows.Forms.PictureBox pictureBoxFrame;
    }
}