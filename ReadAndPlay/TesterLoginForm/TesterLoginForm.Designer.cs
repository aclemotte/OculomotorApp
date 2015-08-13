namespace LookAndPlayForm.TesterID
{
    partial class FormTesterID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTesterID));
            this.labelTesterName = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxTesterName = new System.Windows.Forms.TextBox();
            this.labelTesterID = new System.Windows.Forms.Label();
            this.numericUpDownTesterID = new System.Windows.Forms.NumericUpDown();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonNewTester = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTesterID)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTesterName
            // 
            this.labelTesterName.AutoSize = true;
            this.labelTesterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTesterName.Location = new System.Drawing.Point(83, 140);
            this.labelTesterName.Name = "labelTesterName";
            this.labelTesterName.Size = new System.Drawing.Size(61, 24);
            this.labelTesterName.TabIndex = 0;
            this.labelTesterName.Text = "Name";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(147, 190);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(207, 35);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxTesterName
            // 
            this.textBoxTesterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTesterName.Location = new System.Drawing.Point(147, 138);
            this.textBoxTesterName.Name = "textBoxTesterName";
            this.textBoxTesterName.ReadOnly = true;
            this.textBoxTesterName.Size = new System.Drawing.Size(207, 29);
            this.textBoxTesterName.TabIndex = 2;
            // 
            // labelTesterID
            // 
            this.labelTesterID.AutoSize = true;
            this.labelTesterID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTesterID.Location = new System.Drawing.Point(59, 89);
            this.labelTesterID.Name = "labelTesterID";
            this.labelTesterID.Size = new System.Drawing.Size(85, 24);
            this.labelTesterID.TabIndex = 4;
            this.labelTesterID.Text = "Tester ID";
            // 
            // numericUpDownTesterID
            // 
            this.numericUpDownTesterID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTesterID.Location = new System.Drawing.Point(147, 87);
            this.numericUpDownTesterID.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownTesterID.Name = "numericUpDownTesterID";
            this.numericUpDownTesterID.Size = new System.Drawing.Size(207, 29);
            this.numericUpDownTesterID.TabIndex = 5;
            this.numericUpDownTesterID.ValueChanged += new System.EventHandler(this.numericUpDownTesterID_ValueChanged);
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelVersion.Location = new System.Drawing.Point(12, 363);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(48, 13);
            this.labelVersion.TabIndex = 6;
            this.labelVersion.Text = "Version: ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(339, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Scrool Down and Up to search a Tester";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Or click on \"New tester\" to sign in";
            // 
            // buttonNewTester
            // 
            this.buttonNewTester.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewTester.Location = new System.Drawing.Point(152, 300);
            this.buttonNewTester.Name = "buttonNewTester";
            this.buttonNewTester.Size = new System.Drawing.Size(197, 35);
            this.buttonNewTester.TabIndex = 14;
            this.buttonNewTester.Text = "New tester";
            this.buttonNewTester.UseVisualStyleBackColor = true;
            this.buttonNewTester.Click += new System.EventHandler(this.buttonNewTester_Click);
            // 
            // FormTesterID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 390);
            this.Controls.Add(this.buttonNewTester);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.numericUpDownTesterID);
            this.Controls.Add(this.labelTesterID);
            this.Controls.Add(this.textBoxTesterName);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelTesterName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormTesterID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tester Login";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTesterID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTesterName;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxTesterName;
        private System.Windows.Forms.Label labelTesterID;
        private System.Windows.Forms.NumericUpDown numericUpDownTesterID;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonNewTester;
    }
}