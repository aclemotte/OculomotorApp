namespace LookAndPlayForm.InitialForm
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.buttonNewTest = new System.Windows.Forms.Button();
            this.buttonReviewTest = new System.Windows.Forms.Button();
            this.labelOptions = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.pictureBoxIngles = new System.Windows.Forms.PictureBox();
            this.pictureBoxEspanhol = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIngles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEspanhol)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNewTest
            // 
            resources.ApplyResources(this.buttonNewTest, "buttonNewTest");
            this.buttonNewTest.Name = "buttonNewTest";
            this.buttonNewTest.UseVisualStyleBackColor = true;
            this.buttonNewTest.Click += new System.EventHandler(this.buttonNewTest_Click);
            // 
            // buttonReviewTest
            // 
            resources.ApplyResources(this.buttonReviewTest, "buttonReviewTest");
            this.buttonReviewTest.Name = "buttonReviewTest";
            this.buttonReviewTest.UseVisualStyleBackColor = true;
            this.buttonReviewTest.Click += new System.EventHandler(this.buttonReviewTest_Click);
            // 
            // labelOptions
            // 
            resources.ApplyResources(this.labelOptions, "labelOptions");
            this.labelOptions.Name = "labelOptions";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // labelVersion
            // 
            resources.ApplyResources(this.labelVersion, "labelVersion");
            this.labelVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelVersion.Name = "labelVersion";
            // 
            // labelCopyright
            // 
            resources.ApplyResources(this.labelCopyright, "labelCopyright");
            this.labelCopyright.Name = "labelCopyright";
            // 
            // pictureBoxIngles
            // 
            resources.ApplyResources(this.pictureBoxIngles, "pictureBoxIngles");
            this.pictureBoxIngles.Image = global::LookAndPlayForm.Properties.Resources.banderaInglaterra;
            this.pictureBoxIngles.Name = "pictureBoxIngles";
            this.pictureBoxIngles.TabStop = false;
            this.pictureBoxIngles.Click += new System.EventHandler(this.pictureBoxIngles_Click);
            // 
            // pictureBoxEspanhol
            // 
            resources.ApplyResources(this.pictureBoxEspanhol, "pictureBoxEspanhol");
            this.pictureBoxEspanhol.Image = global::LookAndPlayForm.Properties.Resources.banderaEspanha;
            this.pictureBoxEspanhol.Name = "pictureBoxEspanhol";
            this.pictureBoxEspanhol.TabStop = false;
            this.pictureBoxEspanhol.Click += new System.EventHandler(this.pictureBoxEspanhol_Click);
            // 
            // HomeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxEspanhol);
            this.Controls.Add(this.pictureBoxIngles);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelOptions);
            this.Controls.Add(this.buttonReviewTest);
            this.Controls.Add(this.buttonNewTest);
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIngles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEspanhol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNewTest;
        private System.Windows.Forms.Button buttonReviewTest;
        private System.Windows.Forms.Label labelOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.PictureBox pictureBoxIngles;
        private System.Windows.Forms.PictureBox pictureBoxEspanhol;
    }
}