namespace LookAndPlayForm.ConfigurationReadingForm
{
    partial class ConfigurationReadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationReadingForm));
            this.buttonOk = new System.Windows.Forms.Button();
            this.comboBoxSampleText = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonSilentReading = new System.Windows.Forms.RadioButton();
            this.radioButtonOutloudReading = new System.Windows.Forms.RadioButton();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // comboBoxSampleText
            // 
            resources.ApplyResources(this.comboBoxSampleText, "comboBoxSampleText");
            this.comboBoxSampleText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxSampleText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxSampleText.FormattingEnabled = true;
            this.comboBoxSampleText.Items.AddRange(new object[] {
            resources.GetString("comboBoxSampleText.Items"),
            resources.GetString("comboBoxSampleText.Items1"),
            resources.GetString("comboBoxSampleText.Items2"),
            resources.GetString("comboBoxSampleText.Items3"),
            resources.GetString("comboBoxSampleText.Items4"),
            resources.GetString("comboBoxSampleText.Items5")});
            this.comboBoxSampleText.Name = "comboBoxSampleText";
            this.comboBoxSampleText.SelectedValueChanged += new System.EventHandler(this.comboBoxSampleText_SelectedValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // radioButtonSilentReading
            // 
            resources.ApplyResources(this.radioButtonSilentReading, "radioButtonSilentReading");
            this.radioButtonSilentReading.Checked = true;
            this.radioButtonSilentReading.Name = "radioButtonSilentReading";
            this.radioButtonSilentReading.TabStop = true;
            this.radioButtonSilentReading.UseVisualStyleBackColor = true;
            // 
            // radioButtonOutloudReading
            // 
            resources.ApplyResources(this.radioButtonOutloudReading, "radioButtonOutloudReading");
            this.radioButtonOutloudReading.Name = "radioButtonOutloudReading";
            this.radioButtonOutloudReading.UseVisualStyleBackColor = true;
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
            // ConfigurationReadingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.radioButtonSilentReading);
            this.Controls.Add(this.radioButtonOutloudReading);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSampleText);
            this.Controls.Add(this.buttonOk);
            this.MaximizeBox = false;
            this.Name = "ConfigurationReadingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ComboBox comboBoxSampleText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonSilentReading;
        private System.Windows.Forms.RadioButton radioButtonOutloudReading;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
    }
}