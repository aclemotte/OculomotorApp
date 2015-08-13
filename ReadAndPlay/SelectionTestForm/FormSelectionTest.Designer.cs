namespace LookAndPlayForm.SelectTest
{
    partial class FormSelectionTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectionTest));
            this.radioButtonPersuit = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSilentReading = new System.Windows.Forms.RadioButton();
            this.radioButtonOutloudReading = new System.Windows.Forms.RadioButton();
            this.comboBoxSampleText = new System.Windows.Forms.ComboBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonPersuit
            // 
            this.radioButtonPersuit.AutoSize = true;
            this.radioButtonPersuit.Checked = true;
            this.radioButtonPersuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPersuit.Location = new System.Drawing.Point(19, 23);
            this.radioButtonPersuit.Name = "radioButtonPersuit";
            this.radioButtonPersuit.Size = new System.Drawing.Size(118, 28);
            this.radioButtonPersuit.TabIndex = 1;
            this.radioButtonPersuit.TabStop = true;
            this.radioButtonPersuit.Text = "Persuit test";
            this.radioButtonPersuit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButtonSilentReading);
            this.groupBox1.Controls.Add(this.radioButtonOutloudReading);
            this.groupBox1.Controls.Add(this.comboBoxSampleText);
            this.groupBox1.Controls.Add(this.radioButtonPersuit);
            this.groupBox1.Location = new System.Drawing.Point(37, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 237);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonSilentReading
            // 
            this.radioButtonSilentReading.AutoSize = true;
            this.radioButtonSilentReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSilentReading.Location = new System.Drawing.Point(19, 69);
            this.radioButtonSilentReading.Name = "radioButtonSilentReading";
            this.radioButtonSilentReading.Size = new System.Drawing.Size(176, 28);
            this.radioButtonSilentReading.TabIndex = 38;
            this.radioButtonSilentReading.Text = "Silent reading test";
            this.radioButtonSilentReading.UseVisualStyleBackColor = true;
            // 
            // radioButtonOutloudReading
            // 
            this.radioButtonOutloudReading.AutoSize = true;
            this.radioButtonOutloudReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOutloudReading.Location = new System.Drawing.Point(19, 115);
            this.radioButtonOutloudReading.Name = "radioButtonOutloudReading";
            this.radioButtonOutloudReading.Size = new System.Drawing.Size(197, 28);
            this.radioButtonOutloudReading.TabIndex = 37;
            this.radioButtonOutloudReading.Text = "Outloud reading test";
            this.radioButtonOutloudReading.UseVisualStyleBackColor = true;
            // 
            // comboBoxSampleText
            // 
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
            this.comboBoxSampleText.Location = new System.Drawing.Point(44, 164);
            this.comboBoxSampleText.MaxDropDownItems = 12;
            this.comboBoxSampleText.Name = "comboBoxSampleText";
            this.comboBoxSampleText.Size = new System.Drawing.Size(172, 32);
            this.comboBoxSampleText.TabIndex = 35;
            this.comboBoxSampleText.Text = "Sample texts";
            this.comboBoxSampleText.SelectedValueChanged += new System.EventHandler(this.comboBoxSampleText_SelectedValueChanged);
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelVersion.Location = new System.Drawing.Point(12, 297);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(42, 13);
            this.labelVersion.TabIndex = 35;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(174, 286);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(111, 31);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // FormSelectionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 325);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSelectionTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test selection";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonPersuit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxSampleText;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.RadioButton radioButtonSilentReading;
        private System.Windows.Forms.RadioButton radioButtonOutloudReading;
    }
}