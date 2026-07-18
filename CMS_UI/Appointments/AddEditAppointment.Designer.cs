namespace CMS_UI.Appointments
{
    partial class AddEditAppointment
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
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.cmPatients = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectThisPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDoctors = new System.Windows.Forms.DataGridView();
            this.cmDoctors = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectThisDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPatientFilter = new System.Windows.Forms.TextBox();
            this.cmbPatientFilterBy = new System.Windows.Forms.ComboBox();
            this.cmbDoctorFilterBy = new System.Windows.Forms.ComboBox();
            this.txtDoctorFilter = new System.Windows.Forms.TextBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.lblDoctorID = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSpecialtyName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.flpSlots = new System.Windows.Forms.FlowLayoutPanel();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.cmbMedicalService = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.cmPatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            this.cmDoctors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-5, -9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 107);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CMS_UI.Properties.Resources.medical_appointment;
            this.pictureBox1.Location = new System.Drawing.Point(447, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(399, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Appointment";
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.ContextMenuStrip = this.cmPatients;
            this.dgvPatients.Location = new System.Drawing.Point(7, 139);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.Size = new System.Drawing.Size(380, 174);
            this.dgvPatients.TabIndex = 1;
            // 
            // cmPatients
            // 
            this.cmPatients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectThisPatientToolStripMenuItem});
            this.cmPatients.Name = "cmPatients";
            this.cmPatients.Size = new System.Drawing.Size(106, 26);
            // 
            // selectThisPatientToolStripMenuItem
            // 
            this.selectThisPatientToolStripMenuItem.Name = "selectThisPatientToolStripMenuItem";
            this.selectThisPatientToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.selectThisPatientToolStripMenuItem.Text = "Select";
            this.selectThisPatientToolStripMenuItem.Click += new System.EventHandler(this.selectThisPatientToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter By:";
            // 
            // dgvDoctors
            // 
            this.dgvDoctors.AllowUserToAddRows = false;
            this.dgvDoctors.AllowUserToDeleteRows = false;
            this.dgvDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctors.ContextMenuStrip = this.cmDoctors;
            this.dgvDoctors.Location = new System.Drawing.Point(6, 347);
            this.dgvDoctors.Name = "dgvDoctors";
            this.dgvDoctors.ReadOnly = true;
            this.dgvDoctors.Size = new System.Drawing.Size(380, 174);
            this.dgvDoctors.TabIndex = 4;
            // 
            // cmDoctors
            // 
            this.cmDoctors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectThisDoctorToolStripMenuItem});
            this.cmDoctors.Name = "cmDoctors";
            this.cmDoctors.Size = new System.Drawing.Size(106, 26);
            // 
            // selectThisDoctorToolStripMenuItem
            // 
            this.selectThisDoctorToolStripMenuItem.Name = "selectThisDoctorToolStripMenuItem";
            this.selectThisDoctorToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.selectThisDoctorToolStripMenuItem.Text = "Select";
            this.selectThisDoctorToolStripMenuItem.Click += new System.EventHandler(this.selectThisDoctorToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Filter By:";
            // 
            // txtPatientFilter
            // 
            this.txtPatientFilter.Location = new System.Drawing.Point(214, 110);
            this.txtPatientFilter.Name = "txtPatientFilter";
            this.txtPatientFilter.Size = new System.Drawing.Size(121, 20);
            this.txtPatientFilter.TabIndex = 6;
            this.txtPatientFilter.TextChanged += new System.EventHandler(this.txtPatientFilter_TextChanged);
            // 
            // cmbPatientFilterBy
            // 
            this.cmbPatientFilterBy.FormattingEnabled = true;
            this.cmbPatientFilterBy.Items.AddRange(new object[] {
            "None",
            "Patient ID",
            "Name"});
            this.cmbPatientFilterBy.Location = new System.Drawing.Point(77, 110);
            this.cmbPatientFilterBy.Name = "cmbPatientFilterBy";
            this.cmbPatientFilterBy.Size = new System.Drawing.Size(121, 21);
            this.cmbPatientFilterBy.TabIndex = 7;
            this.cmbPatientFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbPatientFilterBy_SelectedIndexChanged);
            // 
            // cmbDoctorFilterBy
            // 
            this.cmbDoctorFilterBy.FormattingEnabled = true;
            this.cmbDoctorFilterBy.Items.AddRange(new object[] {
            "None",
            "Doctor ID",
            "Name",
            "Department"});
            this.cmbDoctorFilterBy.Location = new System.Drawing.Point(76, 320);
            this.cmbDoctorFilterBy.Name = "cmbDoctorFilterBy";
            this.cmbDoctorFilterBy.Size = new System.Drawing.Size(121, 21);
            this.cmbDoctorFilterBy.TabIndex = 9;
            this.cmbDoctorFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbDoctorFilterBy_SelectedIndexChanged);
            // 
            // txtDoctorFilter
            // 
            this.txtDoctorFilter.Location = new System.Drawing.Point(212, 320);
            this.txtDoctorFilter.Name = "txtDoctorFilter";
            this.txtDoctorFilter.Size = new System.Drawing.Size(121, 20);
            this.txtDoctorFilter.TabIndex = 8;
            this.txtDoctorFilter.TextChanged += new System.EventHandler(this.txtDoctorFilter_TextChanged);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Items.AddRange(new object[] {
            "None",
            "Patient ID",
            "Name"});
            this.cmbDepartment.Location = new System.Drawing.Point(214, 320);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(121, 21);
            this.cmbDepartment.TabIndex = 10;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(771, 468);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(174, 47);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(591, 468);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(174, 47);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CMS_UI.Properties.Resources.plus;
            this.pictureBox2.Location = new System.Drawing.Point(356, 104);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(393, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Patient ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(393, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Doctor ID:";
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientID.Location = new System.Drawing.Point(466, 139);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(34, 16);
            this.lblPatientID.TabIndex = 18;
            this.lblPatientID.Text = "###";
            // 
            // lblDoctorID
            // 
            this.lblDoctorID.AutoSize = true;
            this.lblDoctorID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorID.Location = new System.Drawing.Point(463, 224);
            this.lblDoctorID.Name = "lblDoctorID";
            this.lblDoctorID.Size = new System.Drawing.Size(34, 16);
            this.lblDoctorID.TabIndex = 19;
            this.lblDoctorID.Text = "###";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(487, 183);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(34, 16);
            this.lblPatientName.TabIndex = 21;
            this.lblPatientName.Text = "###";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(393, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Patient Name:";
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorName.Location = new System.Drawing.Point(484, 268);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(34, 16);
            this.lblDoctorName.TabIndex = 23;
            this.lblDoctorName.Text = "###";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(393, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Doctor Name:";
            // 
            // lblSpecialtyName
            // 
            this.lblSpecialtyName.AutoSize = true;
            this.lblSpecialtyName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecialtyName.Location = new System.Drawing.Point(479, 312);
            this.lblSpecialtyName.Name = "lblSpecialtyName";
            this.lblSpecialtyName.Size = new System.Drawing.Size(34, 16);
            this.lblSpecialtyName.TabIndex = 25;
            this.lblSpecialtyName.Text = "###";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(393, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "Department:";
            // 
            // flpSlots
            // 
            this.flpSlots.AutoScroll = true;
            this.flpSlots.Location = new System.Drawing.Point(591, 168);
            this.flpSlots.Name = "flpSlots";
            this.flpSlots.Size = new System.Drawing.Size(354, 252);
            this.flpSlots.TabIndex = 26;
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.Location = new System.Drawing.Point(591, 139);
            this.dtpAppointmentDate.MinDate = new System.DateTime(2026, 7, 18, 0, 0, 0, 0);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(354, 20);
            this.dtpAppointmentDate.TabIndex = 27;
            this.dtpAppointmentDate.ValueChanged += new System.EventHandler(this.dtpAppointmentDate_ValueChanged);
            // 
            // cmbMedicalService
            // 
            this.cmbMedicalService.FormattingEnabled = true;
            this.cmbMedicalService.Location = new System.Drawing.Point(392, 397);
            this.cmbMedicalService.Name = "cmbMedicalService";
            this.cmbMedicalService.Size = new System.Drawing.Size(174, 21);
            this.cmbMedicalService.TabIndex = 28;
            this.cmbMedicalService.SelectedIndexChanged += new System.EventHandler(this.cmbMedicalService_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(392, 378);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.label10.TabIndex = 32;
            this.label10.Text = "Medical Service:";
            // 
            // AddEditAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 527);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbMedicalService);
            this.Controls.Add(this.dtpAppointmentDate);
            this.Controls.Add(this.flpSlots);
            this.Controls.Add(this.lblSpecialtyName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblDoctorName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDoctorID);
            this.Controls.Add(this.lblPatientID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbDoctorFilterBy);
            this.Controls.Add(this.txtDoctorFilter);
            this.Controls.Add(this.cmbPatientFilterBy);
            this.Controls.Add(this.txtPatientFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDoctors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPatients);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddEditAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEditAppointment";
            this.Load += new System.EventHandler(this.AddEditAppointment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.cmPatients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            this.cmDoctors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDoctors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPatientFilter;
        private System.Windows.Forms.ComboBox cmbPatientFilterBy;
        private System.Windows.Forms.ComboBox cmbDoctorFilterBy;
        private System.Windows.Forms.TextBox txtDoctorFilter;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip cmPatients;
        private System.Windows.Forms.ToolStripMenuItem selectThisPatientToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmDoctors;
        private System.Windows.Forms.ToolStripMenuItem selectThisDoctorToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPatientID;
        private System.Windows.Forms.Label lblDoctorID;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSpecialtyName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FlowLayoutPanel flpSlots;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.ComboBox cmbMedicalService;
        private System.Windows.Forms.Label label10;
    }
}