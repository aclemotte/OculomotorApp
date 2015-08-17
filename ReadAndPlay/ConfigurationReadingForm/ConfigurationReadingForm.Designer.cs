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
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(356, 395);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(151, 33);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // comboBoxSampleText
            // 
            this.comboBoxSampleText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxSampleText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxSampleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSampleText.FormattingEnabled = true;
            this.comboBoxSampleText.Items.AddRange(new object[] {
            "Level 1. Text 1",
            "Level 1. Text 2",
            "Level 1. Text 3",
            "Level 2. Text 15",
            "Level 2. Text 16",
            "Level 2. Text 17",
            "Level 3. Text 29",
            "Level 3. Text 30",
            "Level 3. Text 31",
            "Level 7. Text 87",
            "Level 7. Text 88",
            "Level 7. Text 89"});
            this.comboBoxSampleText.Location = new System.Drawing.Point(310, 155);
            this.comboBoxSampleText.MaxDropDownItems = 12;
            this.comboBoxSampleText.Name = "comboBoxSampleText";
            this.comboBoxSampleText.Size = new System.Drawing.Size(197, 32);
            this.comboBoxSampleText.TabIndex = 36;
            this.comboBoxSampleText.Text = "Sample texts";
            this.comboBoxSampleText.SelectedValueChanged += new System.EventHandler(this.comboBoxSampleText_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 24);
            this.label1.TabIndex = 37;
            this.label1.Text = "1. Select a Reading Text level:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(121, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 31);
            this.label2.TabIndex = 38;
            this.label2.Text = "Let´s see how your eyes";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(143, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 31);
            this.label3.TabIndex = 39;
            this.label3.Text = "move when you read";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 24);
            this.label4.TabIndex = 40;
            this.label4.Text = "2. Choose what kind of reading: ";
            // 
            // radioButtonSilentReading
            // 
            this.radioButtonSilentReading.AutoSize = true;
            this.radioButtonSilentReading.Checked = true;
            this.radioButtonSilentReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSilentReading.Location = new System.Drawing.Point(310, 269);
            this.radioButtonSilentReading.Name = "radioButtonSilentReading";
            this.radioButtonSilentReading.Size = new System.Drawing.Size(176, 28);
            this.radioButtonSilentReading.TabIndex = 42;
            this.radioButtonSilentReading.TabStop = true;
            this.radioButtonSilentReading.Text = "Silent reading test";
            this.radioButtonSilentReading.UseVisualStyleBackColor = true;
            // 
            // radioButtonOutloudReading
            // 
            this.radioButtonOutloudReading.AutoSize = true;
            this.radioButtonOutloudReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOutloudReading.Location = new System.Drawing.Point(310, 315);
            this.radioButtonOutloudReading.Name = "radioButtonOutloudReading";
            this.radioButtonOutloudReading.Size = new System.Drawing.Size(197, 28);
            this.radioButtonOutloudReading.TabIndex = 41;
            this.radioButtonOutloudReading.Text = "Outloud reading test";
            this.radioButtonOutloudReading.UseVisualStyleBackColor = true;
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelVersion.Location = new System.Drawing.Point(26, 418);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(42, 13);
            this.labelVersion.TabIndex = 43;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ConfigurationReadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 440);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.radioButtonSilentReading);
            this.Controls.Add(this.radioButtonOutloudReading);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSampleText);
            this.Controls.Add(this.buttonOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfigurationReadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reading test configuration";
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
    }
}