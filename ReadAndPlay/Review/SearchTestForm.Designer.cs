﻿namespace LookAndPlayForm.Review
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.buttonCancel = new System.Windows.Forms.Button();
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
            this.lbTitle.Location = new System.Drawing.Point(104, 23);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(279, 29);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "Please enter some filters";
            // 
            // lbCopyright
            // 
            this.lbCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCopyright.Location = new System.Drawing.Point(28, 548);
            this.lbCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(236, 17);
            this.lbCopyright.TabIndex = 16;
            this.lbCopyright.Text = "© All rights reserved. Mr Patch 2016";
            // 
            // lbVersion
            // 
            this.lbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(28, 528);
            this.lbVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(64, 17);
            this.lbVersion.TabIndex = 15;
            this.lbVersion.Text = "Version: ";
            // 
            // tbFilter_PatientName
            // 
            this.tbFilter_PatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilter_PatientName.Location = new System.Drawing.Point(32, 96);
            this.tbFilter_PatientName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFilter_PatientName.Name = "tbFilter_PatientName";
            this.tbFilter_PatientName.Size = new System.Drawing.Size(432, 34);
            this.tbFilter_PatientName.TabIndex = 0;
            this.tbFilter_PatientName.TextChanged += new System.EventHandler(this.tbFilter_PatientName_TextChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(668, 521);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(212, 47);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Patient,
            this.PatientID,
            this.Tester,
            this.Test,
            this.Date,
            this.DateUTC});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTests.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTests.Location = new System.Drawing.Point(492, 15);
            this.dgvTests.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTests.MultiSelect = false;
            this.dgvTests.Name = "dgvTests";
            this.dgvTests.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTests.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTests.RowHeadersVisible = false;
            this.dgvTests.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTests.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTests.Size = new System.Drawing.Size(805, 498);
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
            this.lbFilter_PatientName.Location = new System.Drawing.Point(28, 66);
            this.lbFilter_PatientName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFilter_PatientName.Name = "lbFilter_PatientName";
            this.lbFilter_PatientName.Size = new System.Drawing.Size(251, 25);
            this.lbFilter_PatientName.TabIndex = 18;
            this.lbFilter_PatientName.Text = "Search by patient name: ";
            // 
            // lbFilter_TesterName
            // 
            this.lbFilter_TesterName.AutoSize = true;
            this.lbFilter_TesterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbFilter_TesterName.Location = new System.Drawing.Point(28, 142);
            this.lbFilter_TesterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFilter_TesterName.Name = "lbFilter_TesterName";
            this.lbFilter_TesterName.Size = new System.Drawing.Size(240, 25);
            this.lbFilter_TesterName.TabIndex = 20;
            this.lbFilter_TesterName.Text = "Search by tester name: ";
            // 
            // tbFilter_TesterName
            // 
            this.tbFilter_TesterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilter_TesterName.Location = new System.Drawing.Point(32, 171);
            this.tbFilter_TesterName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFilter_TesterName.Name = "tbFilter_TesterName";
            this.tbFilter_TesterName.Size = new System.Drawing.Size(432, 34);
            this.tbFilter_TesterName.TabIndex = 1;
            this.tbFilter_TesterName.TextChanged += new System.EventHandler(this.tbFilter_TesterName_TextChanged);
            // 
            // lbFilter_Date
            // 
            this.lbFilter_Date.AutoSize = true;
            this.lbFilter_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbFilter_Date.Location = new System.Drawing.Point(28, 219);
            this.lbFilter_Date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFilter_Date.Name = "lbFilter_Date";
            this.lbFilter_Date.Size = new System.Drawing.Size(169, 25);
            this.lbFilter_Date.TabIndex = 22;
            this.lbFilter_Date.Text = "Search by date: ";
            // 
            // lbFilter_TestType
            // 
            this.lbFilter_TestType.AutoSize = true;
            this.lbFilter_TestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbFilter_TestType.Location = new System.Drawing.Point(28, 299);
            this.lbFilter_TestType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFilter_TestType.Name = "lbFilter_TestType";
            this.lbFilter_TestType.Size = new System.Drawing.Size(209, 25);
            this.lbFilter_TestType.TabIndex = 24;
            this.lbFilter_TestType.Text = "Search by test type: ";
            // 
            // bFilter_Reading
            // 
            this.bFilter_Reading.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.bFilter_Reading.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.bFilter_Reading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFilter_Reading.Location = new System.Drawing.Point(33, 327);
            this.bFilter_Reading.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bFilter_Reading.Name = "bFilter_Reading";
            this.bFilter_Reading.Size = new System.Drawing.Size(212, 47);
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
            this.bFilter_Pursuit.Location = new System.Drawing.Point(253, 327);
            this.bFilter_Pursuit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bFilter_Pursuit.Name = "bFilter_Pursuit";
            this.bFilter_Pursuit.Size = new System.Drawing.Size(212, 47);
            this.bFilter_Pursuit.TabIndex = 4;
            this.bFilter_Pursuit.Text = "Pursuit";
            this.bFilter_Pursuit.UseVisualStyleBackColor = true;
            this.bFilter_Pursuit.Click += new System.EventHandler(this.bFilter_Pursuit_Click);
            // 
            // bSearch
            // 
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(143, 382);
            this.bSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(212, 47);
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
            this.dtpFilter_Date.Location = new System.Drawing.Point(33, 247);
            this.dtpFilter_Date.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFilter_Date.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpFilter_Date.Name = "dtpFilter_Date";
            this.dtpFilter_Date.ShowCheckBox = true;
            this.dtpFilter_Date.Size = new System.Drawing.Size(431, 34);
            this.dtpFilter_Date.TabIndex = 2;
            this.dtpFilter_Date.ValueChanged += new System.EventHandler(this.dtpFilter_Date_ValueChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(907, 521);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(212, 47);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // SearchTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 572);
            this.Controls.Add(this.buttonCancel);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button buttonCancel;
    }
}