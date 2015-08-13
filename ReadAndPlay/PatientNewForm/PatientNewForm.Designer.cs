namespace LookAndPlayForm
{
    partial class FormPatientID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatientID));
            this.labelUser = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.numericUpDownUserID = new System.Windows.Forms.NumericUpDown();
            this.labelVersion = new System.Windows.Forms.Label();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.checkBoxMyopia = new System.Windows.Forms.CheckBox();
            this.checkBoxCranialNervePalsy = new System.Windows.Forms.CheckBox();
            this.checkBoxDislexia = new System.Windows.Forms.CheckBox();
            this.checkBoxNystagmus = new System.Windows.Forms.CheckBox();
            this.checkBoxADHD = new System.Windows.Forms.CheckBox();
            this.checkBoxAstigmatism = new System.Windows.Forms.CheckBox();
            this.checkBoxHypermetropia = new System.Windows.Forms.CheckBox();
            this.checkBoxOther = new System.Windows.Forms.CheckBox();
            this.checkBoxAmblyopia = new System.Windows.Forms.CheckBox();
            this.groupBoxDiagnosedConditions = new System.Windows.Forms.GroupBox();
            this.checkBoxConvergenceInsufficiency = new System.Windows.Forms.CheckBox();
            this.checkBoxStrabismusEsotropia = new System.Windows.Forms.CheckBox();
            this.checkBoxStrabismusExotropia = new System.Windows.Forms.CheckBox();
            this.groupBoxGender = new System.Windows.Forms.GroupBox();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.labelRequiredFields = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserID)).BeginInit();
            this.groupBoxDiagnosedConditions.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(58, 45);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(88, 24);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "Patient ID";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(79, 99);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(73, 24);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name *";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(691, 362);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(156, 35);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Save";
            this.buttonOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.Location = new System.Drawing.Point(159, 99);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(207, 29);
            this.textBoxUserName.TabIndex = 3;
            // 
            // numericUpDownUserID
            // 
            this.numericUpDownUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownUserID.Location = new System.Drawing.Point(159, 45);
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
            this.numericUpDownUserID.ReadOnly = true;
            this.numericUpDownUserID.Size = new System.Drawing.Size(207, 29);
            this.numericUpDownUserID.TabIndex = 2;
            this.numericUpDownUserID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelVersion.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelVersion.Location = new System.Drawing.Point(12, 399);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(42, 13);
            this.labelVersion.TabIndex = 9;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAge.Location = new System.Drawing.Point(159, 207);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(207, 29);
            this.textBoxAge.TabIndex = 5;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(159, 153);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(207, 29);
            this.textBoxEmail.TabIndex = 4;
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAge.Location = new System.Drawing.Point(94, 207);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(57, 24);
            this.labelAge.TabIndex = 15;
            this.labelAge.Text = "Age *";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.Location = new System.Drawing.Point(78, 315);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(74, 24);
            this.labelGender.TabIndex = 16;
            this.labelGender.Text = "Gender";
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCountry.Location = new System.Drawing.Point(77, 261);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(75, 24);
            this.labelCountry.TabIndex = 17;
            this.labelCountry.Text = "Country";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(79, 153);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(73, 24);
            this.labelEmail.TabIndex = 18;
            this.labelEmail.Text = "e-mail *";
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Checked = true;
            this.radioButtonMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMale.Location = new System.Drawing.Point(165, 315);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(69, 28);
            this.radioButtonMale.TabIndex = 19;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFemale.Location = new System.Drawing.Point(269, 315);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(92, 28);
            this.radioButtonFemale.TabIndex = 20;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // checkBoxMyopia
            // 
            this.checkBoxMyopia.AutoSize = true;
            this.checkBoxMyopia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMyopia.Location = new System.Drawing.Point(282, 220);
            this.checkBoxMyopia.Name = "checkBoxMyopia";
            this.checkBoxMyopia.Size = new System.Drawing.Size(90, 28);
            this.checkBoxMyopia.TabIndex = 22;
            this.checkBoxMyopia.Text = "Myopia";
            this.checkBoxMyopia.UseVisualStyleBackColor = true;
            // 
            // checkBoxCranialNervePalsy
            // 
            this.checkBoxCranialNervePalsy.AutoSize = true;
            this.checkBoxCranialNervePalsy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCranialNervePalsy.Location = new System.Drawing.Point(25, 174);
            this.checkBoxCranialNervePalsy.Name = "checkBoxCranialNervePalsy";
            this.checkBoxCranialNervePalsy.Size = new System.Drawing.Size(188, 28);
            this.checkBoxCranialNervePalsy.TabIndex = 24;
            this.checkBoxCranialNervePalsy.Text = "Cranial nerve palsy";
            this.checkBoxCranialNervePalsy.UseVisualStyleBackColor = true;
            // 
            // checkBoxDislexia
            // 
            this.checkBoxDislexia.AutoSize = true;
            this.checkBoxDislexia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDislexia.Location = new System.Drawing.Point(282, 174);
            this.checkBoxDislexia.Name = "checkBoxDislexia";
            this.checkBoxDislexia.Size = new System.Drawing.Size(99, 28);
            this.checkBoxDislexia.TabIndex = 28;
            this.checkBoxDislexia.Text = "Dyslexia";
            this.checkBoxDislexia.UseVisualStyleBackColor = true;
            // 
            // checkBoxNystagmus
            // 
            this.checkBoxNystagmus.AutoSize = true;
            this.checkBoxNystagmus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNystagmus.Location = new System.Drawing.Point(25, 266);
            this.checkBoxNystagmus.Name = "checkBoxNystagmus";
            this.checkBoxNystagmus.Size = new System.Drawing.Size(122, 28);
            this.checkBoxNystagmus.TabIndex = 27;
            this.checkBoxNystagmus.Text = "Nystagmus";
            this.checkBoxNystagmus.UseVisualStyleBackColor = true;
            // 
            // checkBoxADHD
            // 
            this.checkBoxADHD.AutoSize = true;
            this.checkBoxADHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxADHD.Location = new System.Drawing.Point(282, 36);
            this.checkBoxADHD.Name = "checkBoxADHD";
            this.checkBoxADHD.Size = new System.Drawing.Size(82, 28);
            this.checkBoxADHD.TabIndex = 26;
            this.checkBoxADHD.Text = "ADHD";
            this.checkBoxADHD.UseVisualStyleBackColor = true;
            // 
            // checkBoxAstigmatism
            // 
            this.checkBoxAstigmatism.AutoSize = true;
            this.checkBoxAstigmatism.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAstigmatism.Location = new System.Drawing.Point(25, 220);
            this.checkBoxAstigmatism.Name = "checkBoxAstigmatism";
            this.checkBoxAstigmatism.Size = new System.Drawing.Size(129, 28);
            this.checkBoxAstigmatism.TabIndex = 25;
            this.checkBoxAstigmatism.Text = "Astigmatism";
            this.checkBoxAstigmatism.UseVisualStyleBackColor = true;
            // 
            // checkBoxHypermetropia
            // 
            this.checkBoxHypermetropia.AutoSize = true;
            this.checkBoxHypermetropia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHypermetropia.Location = new System.Drawing.Point(282, 128);
            this.checkBoxHypermetropia.Name = "checkBoxHypermetropia";
            this.checkBoxHypermetropia.Size = new System.Drawing.Size(153, 28);
            this.checkBoxHypermetropia.TabIndex = 31;
            this.checkBoxHypermetropia.Text = "Hypermetropia";
            this.checkBoxHypermetropia.UseVisualStyleBackColor = true;
            // 
            // checkBoxOther
            // 
            this.checkBoxOther.AutoSize = true;
            this.checkBoxOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxOther.Location = new System.Drawing.Point(282, 266);
            this.checkBoxOther.Name = "checkBoxOther";
            this.checkBoxOther.Size = new System.Drawing.Size(76, 28);
            this.checkBoxOther.TabIndex = 30;
            this.checkBoxOther.Text = "Other";
            this.checkBoxOther.UseVisualStyleBackColor = true;
            // 
            // checkBoxAmblyopia
            // 
            this.checkBoxAmblyopia.AutoSize = true;
            this.checkBoxAmblyopia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAmblyopia.Location = new System.Drawing.Point(282, 82);
            this.checkBoxAmblyopia.Name = "checkBoxAmblyopia";
            this.checkBoxAmblyopia.Size = new System.Drawing.Size(118, 28);
            this.checkBoxAmblyopia.TabIndex = 29;
            this.checkBoxAmblyopia.Text = "Amblyopia";
            this.checkBoxAmblyopia.UseVisualStyleBackColor = true;
            // 
            // groupBoxDiagnosedConditions
            // 
            this.groupBoxDiagnosedConditions.Controls.Add(this.checkBoxConvergenceInsufficiency);
            this.groupBoxDiagnosedConditions.Controls.Add(this.checkBoxStrabismusEsotropia);
            this.groupBoxDiagnosedConditions.Controls.Add(this.checkBoxStrabismusExotropia);
            this.groupBoxDiagnosedConditions.Controls.Add(this.checkBoxHypermetropia);
            this.groupBoxDiagnosedConditions.Controls.Add(this.checkBoxADHD);
            this.groupBoxDiagnosedConditions.Controls.Add(this.checkBoxDislexia);
            this.groupBoxDiagnosedConditions.Controls.Add(this.checkBoxAstigmatism);
            this.groupBoxDiagnosedConditions.Controls.Add(this.checkBoxOther);
            this.groupBoxDiagnosedConditions.Controls.Add(this.checkBoxCranialNervePalsy);
            this.groupBoxDiagnosedConditions.Controls.Add(this.checkBoxAmblyopia);
            this.groupBoxDiagnosedConditions.Controls.Add(this.checkBoxMyopia);
            this.groupBoxDiagnosedConditions.Controls.Add(this.checkBoxNystagmus);
            this.groupBoxDiagnosedConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDiagnosedConditions.Location = new System.Drawing.Point(409, 45);
            this.groupBoxDiagnosedConditions.Name = "groupBoxDiagnosedConditions";
            this.groupBoxDiagnosedConditions.Size = new System.Drawing.Size(438, 303);
            this.groupBoxDiagnosedConditions.TabIndex = 32;
            this.groupBoxDiagnosedConditions.TabStop = false;
            this.groupBoxDiagnosedConditions.Text = "Diagnosed conditions";
            // 
            // checkBoxConvergenceInsufficiency
            // 
            this.checkBoxConvergenceInsufficiency.AutoSize = true;
            this.checkBoxConvergenceInsufficiency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxConvergenceInsufficiency.Location = new System.Drawing.Point(25, 36);
            this.checkBoxConvergenceInsufficiency.Name = "checkBoxConvergenceInsufficiency";
            this.checkBoxConvergenceInsufficiency.Size = new System.Drawing.Size(251, 28);
            this.checkBoxConvergenceInsufficiency.TabIndex = 34;
            this.checkBoxConvergenceInsufficiency.Text = "Convergence insufficiency";
            this.checkBoxConvergenceInsufficiency.UseVisualStyleBackColor = true;
            // 
            // checkBoxStrabismusEsotropia
            // 
            this.checkBoxStrabismusEsotropia.AutoSize = true;
            this.checkBoxStrabismusEsotropia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStrabismusEsotropia.Location = new System.Drawing.Point(25, 128);
            this.checkBoxStrabismusEsotropia.Name = "checkBoxStrabismusEsotropia";
            this.checkBoxStrabismusEsotropia.Size = new System.Drawing.Size(205, 28);
            this.checkBoxStrabismusEsotropia.TabIndex = 33;
            this.checkBoxStrabismusEsotropia.Text = "Strabismus Esotropia";
            this.checkBoxStrabismusEsotropia.UseVisualStyleBackColor = true;
            // 
            // checkBoxStrabismusExotropia
            // 
            this.checkBoxStrabismusExotropia.AutoSize = true;
            this.checkBoxStrabismusExotropia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStrabismusExotropia.Location = new System.Drawing.Point(25, 82);
            this.checkBoxStrabismusExotropia.Name = "checkBoxStrabismusExotropia";
            this.checkBoxStrabismusExotropia.Size = new System.Drawing.Size(206, 28);
            this.checkBoxStrabismusExotropia.TabIndex = 32;
            this.checkBoxStrabismusExotropia.Text = "Strabismus Exotropia";
            this.checkBoxStrabismusExotropia.UseVisualStyleBackColor = true;
            // 
            // groupBoxGender
            // 
            this.groupBoxGender.Location = new System.Drawing.Point(159, 307);
            this.groupBoxGender.Name = "groupBoxGender";
            this.groupBoxGender.Size = new System.Drawing.Size(207, 41);
            this.groupBoxGender.TabIndex = 34;
            this.groupBoxGender.TabStop = false;
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Items.AddRange(new object[] {
            "Afghanistan",
            "Albania",
            "Algeria",
            "American Samoa",
            "Andorra",
            "Angola",
            "Anguilla",
            "Antarctica",
            "Antigua and Barbuda",
            "Argentina",
            "Armenia",
            "Aruba",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bermuda",
            "Bhutan",
            "Bolivia",
            "Bosnia and Herzegovina",
            "Botswana",
            "Bouvet Island",
            "Brazil",
            "British Indian Ocean Territory",
            "Brunei Darussalam",
            "Bulgaria",
            "Burkina Faso",
            "Burundi",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Cape Verde",
            "Cayman Islands",
            "Central African Republic",
            "Chad",
            "Chile",
            "China",
            "Christmas Island",
            "Cocos (Keeling) Islands",
            "Colombia",
            "Comoros",
            "Congo",
            "Congo, the Democratic Republic of the",
            "Cook Islands",
            "Costa Rica",
            "Cote D\'Ivoire",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czech Republic",
            "Denmark",
            "Djibouti",
            "Dominica",
            "Dominican Republic",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Ethiopia",
            "Falkland Islands (Malvinas)",
            "Faroe Islands",
            "Fiji",
            "Finland",
            "France",
            "French Guiana",
            "French Polynesia",
            "French Southern Territories",
            "Gabon",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Gibraltar",
            "Greece",
            "Greenland",
            "Grenada",
            "Guadeloupe",
            "Guam",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Heard Island and Mcdonald Islands",
            "Holy See (Vatican City State)",
            "Honduras",
            "Hong Kong",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran, Islamic Republic of",
            "Iraq",
            "Ireland",
            "Israel",
            "Italy",
            "Jamaica",
            "Japan",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Korea, Democratic People\'s Republic of",
            "Korea, Republic of",
            "Kuwait",
            "Kyrgyzstan",
            "Lao People\'s Democratic Republic",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libyan Arab Jamahiriya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Macao",
            "Macedonia, the Former Yugoslav Republic of",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Marshall Islands",
            "Martinique",
            "Mauritania",
            "Mauritius",
            "Mayotte",
            "Mexico",
            "Micronesia, Federated States of",
            "Moldova, Republic of",
            "Monaco",
            "Mongolia",
            "Montserrat",
            "Morocco",
            "Mozambique",
            "Myanmar",
            "Namibia",
            "Nauru",
            "Nepal",
            "Netherlands",
            "Netherlands Antilles",
            "New Caledonia",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "Niue",
            "Norfolk Island",
            "Northern Mariana Islands",
            "Norway",
            "Oman",
            "Pakistan",
            "Palau",
            "Palestinian Territory, Occupied",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Pitcairn",
            "Poland",
            "Portugal",
            "Puerto Rico",
            "Qatar",
            "Reunion",
            "Romania",
            "Russian Federation",
            "Rwanda",
            "Saint Helena",
            "Saint Kitts and Nevis",
            "Saint Lucia",
            "Saint Pierre and Miquelon",
            "Saint Vincent and the Grenadines",
            "Samoa",
            "San Marino",
            "Sao Tome and Principe",
            "Saudi Arabia",
            "Senegal",
            "Serbia and Montenegro",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Slovakia",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "South Georgia and the South Sandwich Islands",
            "Spain",
            "Sri Lanka",
            "Sudan",
            "Suriname",
            "Svalbard and Jan Mayen",
            "Swaziland",
            "Sweden",
            "Switzerland",
            "Syrian Arab Republic",
            "Taiwan, Province of China",
            "Tajikistan",
            "Tanzania, United Republic of",
            "Thailand",
            "Timor-Leste",
            "Togo",
            "Tokelau",
            "Tonga",
            "Trinidad and Tobago",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Turks and Caicos Islands",
            "Tuvalu",
            "Uganda",
            "Ukraine",
            "United Arab Emirates",
            "United Kingdom",
            "United States",
            "United States Minor Outlying Islands",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Venezuela",
            "Viet Nam",
            "Virgin Islands, British",
            "Virgin Islands, US",
            "Wallis and Futuna",
            "Western Sahara",
            "Yemen",
            "Zambia",
            "Zimbabwe"});
            this.comboBoxCountry.Location = new System.Drawing.Point(159, 261);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(207, 32);
            this.comboBoxCountry.TabIndex = 6;
            // 
            // labelRequiredFields
            // 
            this.labelRequiredFields.AutoSize = true;
            this.labelRequiredFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRequiredFields.Location = new System.Drawing.Point(155, 9);
            this.labelRequiredFields.Name = "labelRequiredFields";
            this.labelRequiredFields.Size = new System.Drawing.Size(211, 24);
            this.labelRequiredFields.TabIndex = 37;
            this.labelRequiredFields.Text = "* Indicate required fields";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(409, 362);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(156, 35);
            this.buttonCancel.TabIndex = 38;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormPatientID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 418);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelRequiredFields);
            this.Controls.Add(this.comboBoxCountry);
            this.Controls.Add(this.radioButtonFemale);
            this.Controls.Add(this.radioButtonMale);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.numericUpDownUserID);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.groupBoxDiagnosedConditions);
            this.Controls.Add(this.groupBoxGender);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPatientID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New patient";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserID)).EndInit();
            this.groupBoxDiagnosedConditions.ResumeLayout(false);
            this.groupBoxDiagnosedConditions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.NumericUpDown numericUpDownUserID;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.CheckBox checkBoxMyopia;
        private System.Windows.Forms.CheckBox checkBoxCranialNervePalsy;
        private System.Windows.Forms.CheckBox checkBoxDislexia;
        private System.Windows.Forms.CheckBox checkBoxNystagmus;
        private System.Windows.Forms.CheckBox checkBoxADHD;
        private System.Windows.Forms.CheckBox checkBoxAstigmatism;
        private System.Windows.Forms.CheckBox checkBoxHypermetropia;
        private System.Windows.Forms.CheckBox checkBoxOther;
        private System.Windows.Forms.CheckBox checkBoxAmblyopia;
        private System.Windows.Forms.GroupBox groupBoxDiagnosedConditions;
        private System.Windows.Forms.GroupBox groupBoxGender;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.Label labelRequiredFields;
        private System.Windows.Forms.CheckBox checkBoxStrabismusEsotropia;
        private System.Windows.Forms.CheckBox checkBoxStrabismusExotropia;
        private System.Windows.Forms.CheckBox checkBoxConvergenceInsufficiency;
        private System.Windows.Forms.Button buttonCancel;
    }
}

