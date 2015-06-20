namespace LookAndPlayForm
{
    partial class FormUserID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserID));
            this.labelUser = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUserInstitution = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.numericUpDownUserID = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.buttonResume = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserID)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(58, 42);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(71, 24);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "User ID";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(58, 86);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(61, 24);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Institution";
            // 
            // textBoxUserInstitution
            // 
            this.textBoxUserInstitution.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserInstitution.Location = new System.Drawing.Point(159, 128);
            this.textBoxUserInstitution.Name = "textBoxUserInstitution";
            this.textBoxUserInstitution.Size = new System.Drawing.Size(207, 29);
            this.textBoxUserInstitution.TabIndex = 3;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(419, 188);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(161, 35);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.Location = new System.Drawing.Point(159, 86);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(207, 29);
            this.textBoxUserName.TabIndex = 2;
            // 
            // numericUpDownUserID
            // 
            this.numericUpDownUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownUserID.Location = new System.Drawing.Point(159, 42);
            this.numericUpDownUserID.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownUserID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownUserID.Name = "numericUpDownUserID";
            this.numericUpDownUserID.Size = new System.Drawing.Size(207, 29);
            this.numericUpDownUserID.TabIndex = 1;
            this.numericUpDownUserID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownUserID.ValueChanged += new System.EventHandler(this.numericUpDownUserID_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(419, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 115);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text sample";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "asdfa";
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "text 1",
            "text 15",
            "text 16",
            "text 17",
            "text 2",
            "text 29",
            "text 3",
            "text 30",
            "text 31",
            "text 87",
            "text 88",
            "text 89"});
            this.comboBox1.Location = new System.Drawing.Point(13, 47);
            this.comboBox1.MaxDropDownItems = 12;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 32);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 11;
            this.comboBox1.Text = "Select a text";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelVersion.Location = new System.Drawing.Point(12, 227);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(42, 13);
            this.labelVersion.TabIndex = 9;
            this.labelVersion.Text = "Version";
            // 
            // buttonResume
            // 
            this.buttonResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResume.Location = new System.Drawing.Point(264, 188);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(102, 35);
            this.buttonResume.TabIndex = 10;
            this.buttonResume.Text = "Resume";
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // FormUserID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 249);
            this.Controls.Add(this.buttonResume);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.numericUpDownUserID);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxUserInstitution);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormUserID";
            this.Text = "User ID";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserID)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUserInstitution;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.NumericUpDown numericUpDownUserID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

