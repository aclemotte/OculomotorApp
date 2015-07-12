namespace LookAndPlayForm.InstitutionID
{
    partial class FormInstitutionID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInstitutionID));
            this.labelInstitutionName = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelInstitutionID = new System.Windows.Forms.Label();
            this.numericUpDownInstitutionID = new System.Windows.Forms.NumericUpDown();
            this.textBoxInstitutionName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInstitutionID)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInstitutionName
            // 
            this.labelInstitutionName.AutoSize = true;
            this.labelInstitutionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstitutionName.Location = new System.Drawing.Point(72, 87);
            this.labelInstitutionName.Name = "labelInstitutionName";
            this.labelInstitutionName.Size = new System.Drawing.Size(61, 24);
            this.labelInstitutionName.TabIndex = 0;
            this.labelInstitutionName.Text = "Name";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(152, 137);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(207, 29);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelInstitutionID
            // 
            this.labelInstitutionID.AutoSize = true;
            this.labelInstitutionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstitutionID.Location = new System.Drawing.Point(24, 32);
            this.labelInstitutionID.Name = "labelInstitutionID";
            this.labelInstitutionID.Size = new System.Drawing.Size(109, 24);
            this.labelInstitutionID.TabIndex = 3;
            this.labelInstitutionID.Text = "Institution ID";
            // 
            // numericUpDownInstitutionID
            // 
            this.numericUpDownInstitutionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownInstitutionID.Location = new System.Drawing.Point(152, 27);
            this.numericUpDownInstitutionID.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownInstitutionID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownInstitutionID.Name = "numericUpDownInstitutionID";
            this.numericUpDownInstitutionID.Size = new System.Drawing.Size(207, 29);
            this.numericUpDownInstitutionID.TabIndex = 4;
            this.numericUpDownInstitutionID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownInstitutionID.ValueChanged += new System.EventHandler(this.numericUpDownInstitutionID_ValueChanged);
            // 
            // textBoxInstitutionName
            // 
            this.textBoxInstitutionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInstitutionName.Location = new System.Drawing.Point(152, 84);
            this.textBoxInstitutionName.Name = "textBoxInstitutionName";
            this.textBoxInstitutionName.Size = new System.Drawing.Size(207, 29);
            this.textBoxInstitutionName.TabIndex = 5;
            // 
            // FormInstitutionID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 196);
            this.Controls.Add(this.textBoxInstitutionName);
            this.Controls.Add(this.numericUpDownInstitutionID);
            this.Controls.Add(this.labelInstitutionID);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelInstitutionName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInstitutionID";
            this.Text = "Institution ID";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInstitutionID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInstitutionName;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelInstitutionID;
        private System.Windows.Forms.NumericUpDown numericUpDownInstitutionID;
        private System.Windows.Forms.TextBox textBoxInstitutionName;
    }
}