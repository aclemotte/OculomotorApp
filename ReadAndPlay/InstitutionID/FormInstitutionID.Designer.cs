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
            this.textBoxInstitutionName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelInstitutionName
            // 
            this.labelInstitutionName.AutoSize = true;
            this.labelInstitutionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstitutionName.Location = new System.Drawing.Point(12, 24);
            this.labelInstitutionName.Name = "labelInstitutionName";
            this.labelInstitutionName.Size = new System.Drawing.Size(339, 24);
            this.labelInstitutionName.TabIndex = 0;
            this.labelInstitutionName.Text = "Please write the name of your institution";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(269, 123);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(90, 29);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxInstitutionName
            // 
            this.textBoxInstitutionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInstitutionName.Location = new System.Drawing.Point(16, 74);
            this.textBoxInstitutionName.Name = "textBoxInstitutionName";
            this.textBoxInstitutionName.Size = new System.Drawing.Size(343, 29);
            this.textBoxInstitutionName.TabIndex = 5;
            // 
            // FormInstitutionID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 177);
            this.Controls.Add(this.textBoxInstitutionName);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelInstitutionName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormInstitutionID";
            this.Text = "Institution ID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInstitutionName;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxInstitutionName;
    }
}