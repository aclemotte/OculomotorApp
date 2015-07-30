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
            this.radioButtonRead = new System.Windows.Forms.RadioButton();
            this.radioButtonPersuit = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxSampleText = new System.Windows.Forms.ComboBox();
            this.labelSampleText = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonRead
            // 
            this.radioButtonRead.AutoSize = true;
            this.radioButtonRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonRead.Location = new System.Drawing.Point(19, 69);
            this.radioButtonRead.Name = "radioButtonRead";
            this.radioButtonRead.Size = new System.Drawing.Size(132, 28);
            this.radioButtonRead.TabIndex = 0;
            this.radioButtonRead.TabStop = true;
            this.radioButtonRead.Text = "Reading test";
            this.radioButtonRead.UseVisualStyleBackColor = true;
            // 
            // radioButtonPersuit
            // 
            this.radioButtonPersuit.AutoSize = true;
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
            this.groupBox1.Controls.Add(this.comboBoxSampleText);
            this.groupBox1.Controls.Add(this.radioButtonRead);
            this.groupBox1.Controls.Add(this.labelSampleText);
            this.groupBox1.Controls.Add(this.radioButtonPersuit);
            this.groupBox1.Location = new System.Drawing.Point(37, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 194);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
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
            this.comboBoxSampleText.Location = new System.Drawing.Point(38, 137);
            this.comboBoxSampleText.MaxDropDownItems = 12;
            this.comboBoxSampleText.Name = "comboBoxSampleText";
            this.comboBoxSampleText.Size = new System.Drawing.Size(207, 32);
            this.comboBoxSampleText.TabIndex = 35;
            // 
            // labelSampleText
            // 
            this.labelSampleText.AutoSize = true;
            this.labelSampleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSampleText.Location = new System.Drawing.Point(36, 107);
            this.labelSampleText.Name = "labelSampleText";
            this.labelSampleText.Size = new System.Drawing.Size(108, 24);
            this.labelSampleText.TabIndex = 34;
            this.labelSampleText.Text = "Sample text";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelVersion.Location = new System.Drawing.Point(12, 242);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(42, 13);
            this.labelVersion.TabIndex = 35;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(226, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 31);
            this.button1.TabIndex = 36;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormSelectionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 275);
            this.Controls.Add(this.button1);
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

        private System.Windows.Forms.RadioButton radioButtonRead;
        private System.Windows.Forms.RadioButton radioButtonPersuit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelSampleText;
        private System.Windows.Forms.ComboBox comboBoxSampleText;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button button1;
    }
}