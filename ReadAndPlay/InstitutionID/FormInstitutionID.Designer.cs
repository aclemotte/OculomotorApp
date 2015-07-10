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
            this.labelInstitution = new System.Windows.Forms.Label();
            this.textBoxInstitutionName = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelInstitutionData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelInstitution
            // 
            this.labelInstitution.AutoSize = true;
            this.labelInstitution.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstitution.Location = new System.Drawing.Point(33, 70);
            this.labelInstitution.Name = "labelInstitution";
            this.labelInstitution.Size = new System.Drawing.Size(61, 24);
            this.labelInstitution.TabIndex = 0;
            this.labelInstitution.Text = "Name";
            // 
            // textBoxInstitutionName
            // 
            this.textBoxInstitutionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInstitutionName.Location = new System.Drawing.Point(121, 70);
            this.textBoxInstitutionName.Name = "textBoxInstitutionName";
            this.textBoxInstitutionName.Size = new System.Drawing.Size(190, 29);
            this.textBoxInstitutionName.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(121, 134);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(190, 32);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelInstitutionData
            // 
            this.labelInstitutionData.AutoSize = true;
            this.labelInstitutionData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstitutionData.Location = new System.Drawing.Point(33, 23);
            this.labelInstitutionData.Name = "labelInstitutionData";
            this.labelInstitutionData.Size = new System.Drawing.Size(122, 24);
            this.labelInstitutionData.TabIndex = 3;
            this.labelInstitutionData.Text = "Institution info";
            // 
            // FormInstitutionID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 211);
            this.Controls.Add(this.labelInstitutionData);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxInstitutionName);
            this.Controls.Add(this.labelInstitution);
            this.Name = "FormInstitutionID";
            this.Text = "FormInstitutionID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInstitution;
        private System.Windows.Forms.TextBox textBoxInstitutionName;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelInstitutionData;
    }
}