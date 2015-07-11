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
            this.labelTesterName = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxTesterName = new System.Windows.Forms.TextBox();
            this.labelTesterInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTesterName
            // 
            this.labelTesterName.AutoSize = true;
            this.labelTesterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTesterName.Location = new System.Drawing.Point(29, 75);
            this.labelTesterName.Name = "labelTesterName";
            this.labelTesterName.Size = new System.Drawing.Size(61, 24);
            this.labelTesterName.TabIndex = 0;
            this.labelTesterName.Text = "Name";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(111, 128);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(198, 34);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxTesterName
            // 
            this.textBoxTesterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTesterName.Location = new System.Drawing.Point(111, 75);
            this.textBoxTesterName.Name = "textBoxTesterName";
            this.textBoxTesterName.Size = new System.Drawing.Size(198, 29);
            this.textBoxTesterName.TabIndex = 2;
            // 
            // labelTesterInfo
            // 
            this.labelTesterInfo.AutoSize = true;
            this.labelTesterInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTesterInfo.Location = new System.Drawing.Point(29, 23);
            this.labelTesterInfo.Name = "labelTesterInfo";
            this.labelTesterInfo.Size = new System.Drawing.Size(98, 24);
            this.labelTesterInfo.TabIndex = 3;
            this.labelTesterInfo.Text = "Tester info";
            // 
            // FormTesterID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 218);
            this.Controls.Add(this.labelTesterInfo);
            this.Controls.Add(this.textBoxTesterName);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelTesterName);
            this.Name = "FormTesterID";
            this.Text = "FormTesterID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTesterName;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxTesterName;
        private System.Windows.Forms.Label labelTesterInfo;
    }
}