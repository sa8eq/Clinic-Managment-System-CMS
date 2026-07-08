namespace CMS_UI.Patients
{
    partial class AddEditPatient
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBloodType = new System.Windows.Forms.TextBox();
            this.txtInsurancePolicyNumber = new System.Windows.Forms.TextBox();
            this.txtEmergencyContactNumber = new System.Windows.Forms.TextBox();
            this.cmbInsuranceCompanies = new System.Windows.Forms.ComboBox();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPerson1 = new CMS_UI.Controls.ctrlPerson();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-6, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 110);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CMS_UI.Properties.Resources.patient;
            this.pictureBox1.Location = new System.Drawing.Point(463, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(398, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Patient";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(796, 466);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 49);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(641, 466);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 49);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Blood Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(527, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Insurance Company:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Insurance Policy Number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(461, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Emergency Contact Number:";
            // 
            // txtBloodType
            // 
            this.txtBloodType.Location = new System.Drawing.Point(247, 370);
            this.txtBloodType.Name = "txtBloodType";
            this.txtBloodType.Size = new System.Drawing.Size(166, 20);
            this.txtBloodType.TabIndex = 8;
            this.txtBloodType.Validating += new System.ComponentModel.CancelEventHandler(this.txtBloodType_Validating);
            // 
            // txtInsurancePolicyNumber
            // 
            this.txtInsurancePolicyNumber.Location = new System.Drawing.Point(247, 419);
            this.txtInsurancePolicyNumber.Name = "txtInsurancePolicyNumber";
            this.txtInsurancePolicyNumber.Size = new System.Drawing.Size(166, 20);
            this.txtInsurancePolicyNumber.TabIndex = 9;
            this.txtInsurancePolicyNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtInsurancePolicyNumber_Validating);
            // 
            // txtEmergencyContactNumber
            // 
            this.txtEmergencyContactNumber.Location = new System.Drawing.Point(708, 420);
            this.txtEmergencyContactNumber.Name = "txtEmergencyContactNumber";
            this.txtEmergencyContactNumber.Size = new System.Drawing.Size(166, 20);
            this.txtEmergencyContactNumber.TabIndex = 11;
            this.txtEmergencyContactNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmergencyContactNumber_Validating);
            // 
            // cmbInsuranceCompanies
            // 
            this.cmbInsuranceCompanies.FormattingEnabled = true;
            this.cmbInsuranceCompanies.Location = new System.Drawing.Point(708, 374);
            this.cmbInsuranceCompanies.Name = "cmbInsuranceCompanies";
            this.cmbInsuranceCompanies.Size = new System.Drawing.Size(166, 21);
            this.cmbInsuranceCompanies.TabIndex = 12;
            this.cmbInsuranceCompanies.SelectedValueChanged += new System.EventHandler(this.cmbInsuranceCompanies_SelectedValueChanged);
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // ctrlPerson1
            // 
            this.ctrlPerson1.Address = "";
            this.ctrlPerson1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrlPerson1.DateOfBirth = new System.DateTime(2008, 7, 8, 21, 32, 44, 764);
            this.ctrlPerson1.Email = "";
            this.ctrlPerson1.FirstName = "";
            this.ctrlPerson1.Gender = ((byte)(1));
            this.ctrlPerson1.LastName = "";
            this.ctrlPerson1.Location = new System.Drawing.Point(107, 113);
            this.ctrlPerson1.Name = "ctrlPerson1";
            this.ctrlPerson1.Phone = "";
            this.ctrlPerson1.SecondName = "";
            this.ctrlPerson1.Size = new System.Drawing.Size(741, 236);
            this.ctrlPerson1.TabIndex = 0;
            this.ctrlPerson1.ThirdName = "";
            // 
            // AddEditPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 527);
            this.Controls.Add(this.cmbInsuranceCompanies);
            this.Controls.Add(this.txtEmergencyContactNumber);
            this.Controls.Add(this.txtInsurancePolicyNumber);
            this.Controls.Add(this.txtBloodType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ctrlPerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddEditPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEditPatient";
            this.Load += new System.EventHandler(this.AddEditPatient_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlPerson ctrlPerson1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBloodType;
        private System.Windows.Forms.TextBox txtInsurancePolicyNumber;
        private System.Windows.Forms.TextBox txtEmergencyContactNumber;
        private System.Windows.Forms.ComboBox cmbInsuranceCompanies;
        private System.Windows.Forms.ErrorProvider error;
    }
}