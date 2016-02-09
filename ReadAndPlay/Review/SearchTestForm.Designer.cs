namespace LookAndPlayForm.Review
{
    partial class SearchTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchTestForm));
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.tbFilter_PatientName = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.dgvTests = new System.Windows.Forms.DataGridView();
            this.Patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Test = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateUTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbFilter_PatientName = new System.Windows.Forms.Label();
            this.lbFilter_TesterName = new System.Windows.Forms.Label();
            this.tbFilter_TesterName = new System.Windows.Forms.TextBox();
            this.lbFilter_Date = new System.Windows.Forms.Label();
            this.lbFilter_TestType = new System.Windows.Forms.Label();
            this.bFilter_Reading = new System.Windows.Forms.Button();
            this.bFilter_Pursuit = new System.Windows.Forms.Button();
            this.bSearch = new System.Windows.Forms.Button();
            this.dtpFilter_Date = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTests)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTitle.Location = new System.Drawing.Point(78, 19);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(214, 24);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "Please enter some filters";
            // 
            // lbCopyright
            // 
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCopyright.Location = new System.Drawing.Point(21, 445);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(178, 13);
            this.lbCopyright.TabIndex = 16;
            this.lbCopyright.Text = "© All rights reserved. Mr Patch 2015";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(21, 429);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(48, 13);
            this.lbVersion.TabIndex = 15;
            this.lbVersion.Text = "Version: ";
            // 
            // tbFilter_PatientName
            // 
            this.tbFilter_PatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilter_PatientName.Location = new System.Drawing.Point(24, 78);
            this.tbFilter_PatientName.Name = "tbFilter_PatientName";
            this.tbFilter_PatientName.Size = new System.Drawing.Size(325, 29);
            this.tbFilter_PatientName.TabIndex = 0;
            this.tbFilter_PatientName.TextChanged += new System.EventHandler(this.tbFilter_PatientName_TextChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(591, 423);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(159, 38);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // dgvTests
            // 
            this.dgvTests.AllowUserToAddRows = false;
            this.dgvTests.AllowUserToDeleteRows = false;
            this.dgvTests.AllowUserToOrderColumns = true;
            this.dgvTests.AllowUserToResizeRows = false;
            this.dgvTests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTests.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTests.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Patient,
            this.PatientID,
            this.Tester,
            this.Test,
            this.Date,
            this.DateUTC});
            this.dgvTests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTests.Location = new System.Drawing.Point(369, 12);
            this.dgvTests.MultiSelect = false;
            this.dgvTests.Name = "dgvTests";
            this.dgvTests.ReadOnly = true;
            this.dgvTests.RowHeadersVisible = false;
            this.dgvTests.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTests.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTests.Size = new System.Drawing.Size(604, 405);
            this.dgvTests.TabIndex = 6;
            // 
            // Patient
            // 
            this.Patient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Patient.DataPropertyName = "Patient";
            this.Patient.HeaderText = "Patient";
            this.Patient.Name = "Patient";
            this.Patient.ReadOnly = true;
            // 
            // PatientID
            // 
            this.PatientID.HeaderText = "PatientID";
            this.PatientID.Name = "PatientID";
            this.PatientID.ReadOnly = true;
            this.PatientID.Visible = false;
            // 
            // Tester
            // 
            this.Tester.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tester.DataPropertyName = "Tester";
            this.Tester.HeaderText = "Tester";
            this.Tester.Name = "Tester";
            this.Tester.ReadOnly = true;
            // 
            // Test
            // 
            this.Test.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Test.DataPropertyName = "TestType";
            this.Test.HeaderText = "Test";
            this.Test.Name = "Test";
            this.Test.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // DateUTC
            // 
            this.DateUTC.HeaderText = "DateUTC";
            this.DateUTC.Name = "DateUTC";
            this.DateUTC.ReadOnly = true;
            this.DateUTC.Visible = false;
            // 
            // lbFilter_PatientName
            // 
            this.lbFilter_PatientName.AutoSize = true;
            this.lbFilter_PatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbFilter_PatientName.Location = new System.Drawing.Point(21, 54);
            this.lbFilter_PatientName.Name = "lbFilter_PatientName";
            this.lbFilter_PatientName.Size = new System.Drawing.Size(195, 20);
            this.lbFilter_PatientName.TabIndex = 18;
            this.lbFilter_PatientName.Text = "Search by patient name: ";
            // 
            // lbFilter_TesterName
            // 
            this.lbFilter_TesterName.AutoSize = true;
            this.lbFilter_TesterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbFilter_TesterName.Location = new System.Drawing.Point(21, 115);
            this.lbFilter_TesterName.Name = "lbFilter_TesterName";
            this.lbFilter_TesterName.Size = new System.Drawing.Size(188, 20);
            this.lbFilter_TesterName.TabIndex = 20;
            this.lbFilter_TesterName.Text = "Search by tester name: ";
            // 
            // tbFilter_TesterName
            // 
            this.tbFilter_TesterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilter_TesterName.Location = new System.Drawing.Point(24, 139);
            this.tbFilter_TesterName.Name = "tbFilter_TesterName";
            this.tbFilter_TesterName.Size = new System.Drawing.Size(325, 29);
            this.tbFilter_TesterName.TabIndex = 1;
            this.tbFilter_TesterName.TextChanged += new System.EventHandler(this.tbFilter_TesterName_TextChanged);
            // 
            // lbFilter_Date
            // 
            this.lbFilter_Date.AutoSize = true;
            this.lbFilter_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbFilter_Date.Location = new System.Drawing.Point(21, 178);
            this.lbFilter_Date.Name = "lbFilter_Date";
            this.lbFilter_Date.Size = new System.Drawing.Size(131, 20);
            this.lbFilter_Date.TabIndex = 22;
            this.lbFilter_Date.Text = "Search by date: ";
            // 
            // lbFilter_TestType
            // 
            this.lbFilter_TestType.AutoSize = true;
            this.lbFilter_TestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbFilter_TestType.Location = new System.Drawing.Point(21, 243);
            this.lbFilter_TestType.Name = "lbFilter_TestType";
            this.lbFilter_TestType.Size = new System.Drawing.Size(163, 20);
            this.lbFilter_TestType.TabIndex = 24;
            this.lbFilter_TestType.Text = "Search by test type: ";
            // 
            // bFilter_Reading
            // 
            this.bFilter_Reading.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.bFilter_Reading.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.bFilter_Reading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFilter_Reading.Location = new System.Drawing.Point(25, 266);
            this.bFilter_Reading.Name = "bFilter_Reading";
            this.bFilter_Reading.Size = new System.Drawing.Size(159, 38);
            this.bFilter_Reading.TabIndex = 3;
            this.bFilter_Reading.Text = "Reading";
            this.bFilter_Reading.UseVisualStyleBackColor = true;
            this.bFilter_Reading.Click += new System.EventHandler(this.bFilter_Reading_Click);
            // 
            // bFilter_Pursuit
            // 
            this.bFilter_Pursuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.bFilter_Pursuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.bFilter_Pursuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFilter_Pursuit.Location = new System.Drawing.Point(190, 266);
            this.bFilter_Pursuit.Name = "bFilter_Pursuit";
            this.bFilter_Pursuit.Size = new System.Drawing.Size(159, 38);
            this.bFilter_Pursuit.TabIndex = 4;
            this.bFilter_Pursuit.Text = "Pursuit";
            this.bFilter_Pursuit.UseVisualStyleBackColor = true;
            this.bFilter_Pursuit.Click += new System.EventHandler(this.bFilter_Pursuit_Click);
            // 
            // bSearch
            // 
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(107, 310);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(159, 38);
            this.bSearch.TabIndex = 5;
            this.bSearch.Text = "Search";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Visible = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // dtpFilter_Date
            // 
            this.dtpFilter_Date.Checked = false;
            this.dtpFilter_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.dtpFilter_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilter_Date.Location = new System.Drawing.Point(25, 201);
            this.dtpFilter_Date.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpFilter_Date.Name = "dtpFilter_Date";
            this.dtpFilter_Date.ShowCheckBox = true;
            this.dtpFilter_Date.Size = new System.Drawing.Size(324, 29);
            this.dtpFilter_Date.TabIndex = 2;
            this.dtpFilter_Date.ValueChanged += new System.EventHandler(this.dtpFilter_Date_ValueChanged);
            // 
            // SearchTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 465);
            this.Controls.Add(this.dtpFilter_Date);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.bFilter_Pursuit);
            this.Controls.Add(this.bFilter_Reading);
            this.Controls.Add(this.lbFilter_TestType);
            this.Controls.Add(this.lbFilter_Date);
            this.Controls.Add(this.lbFilter_TesterName);
            this.Controls.Add(this.tbFilter_TesterName);
            this.Controls.Add(this.lbFilter_PatientName);
            this.Controls.Add(this.dgvTests);
            this.Controls.Add(this.lbCopyright);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.tbFilter_PatientName);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.lbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Review a Test Done";
            this.Shown += new System.EventHandler(this.SearchTestForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.TextBox tbFilter_PatientName;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.DataGridView dgvTests;
        private System.Windows.Forms.Label lbFilter_PatientName;
        private System.Windows.Forms.Label lbFilter_TesterName;
        private System.Windows.Forms.TextBox tbFilter_TesterName;
        private System.Windows.Forms.Label lbFilter_Date;
        private System.Windows.Forms.Label lbFilter_TestType;
        private System.Windows.Forms.Button bFilter_Reading;
        private System.Windows.Forms.Button bFilter_Pursuit;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patient;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tester;
        private System.Windows.Forms.DataGridViewTextBoxColumn Test;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateUTC;
        private System.Windows.Forms.DateTimePicker dtpFilter_Date;
    }
}