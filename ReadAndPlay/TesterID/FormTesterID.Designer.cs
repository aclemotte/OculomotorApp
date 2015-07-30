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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTesterID)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTesterName
            // 
            this.labelTesterName.AutoSize = true;
            this.labelTesterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTesterName.Location = new System.Drawing.Point(50, 93);
            this.labelTesterName.Name = "labelTesterName";
            this.labelTesterName.Size = new System.Drawing.Size(61, 24);
            this.labelTesterName.TabIndex = 0;
            this.labelTesterName.Text = "Name";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(127, 145);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(207, 29);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxTesterName
            // 
            this.textBoxTesterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTesterName.Location = new System.Drawing.Point(127, 93);
            this.textBoxTesterName.Name = "textBoxTesterName";
            this.textBoxTesterName.Size = new System.Drawing.Size(207, 29);
            this.textBoxTesterName.TabIndex = 2;
            // 
            // labelTesterID
            // 
            this.labelTesterID.AutoSize = true;
            this.labelTesterID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTesterID.Location = new System.Drawing.Point(26, 42);
            this.labelTesterID.Name = "labelTesterID";
            this.labelTesterID.Size = new System.Drawing.Size(85, 24);
            this.labelTesterID.TabIndex = 4;
            this.labelTesterID.Text = "Tester ID";
            // 
            // numericUpDownTesterID
            // 
            this.numericUpDownTesterID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTesterID.Location = new System.Drawing.Point(127, 42);
            this.numericUpDownTesterID.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTesterID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTesterID.Name = "numericUpDownTesterID";
            this.numericUpDownTesterID.Size = new System.Drawing.Size(207, 29);
            this.numericUpDownTesterID.TabIndex = 5;
            this.numericUpDownTesterID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTesterID.ValueChanged += new System.EventHandler(this.numericUpDownTesterID_ValueChanged);
            // 
            // FormTesterID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 223);
            this.Controls.Add(this.numericUpDownTesterID);
            this.Controls.Add(this.labelTesterID);
            this.Controls.Add(this.textBoxTesterName);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelTesterName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormTesterID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tester Window";
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
    }
}