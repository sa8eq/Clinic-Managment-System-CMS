namespace CMS_UI.Visits
{
    partial class StartVisit
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpVisitDiagnosis = new System.Windows.Forms.TabPage();
            this.txtTemp = new System.Windows.Forms.TextBox();
            this.txtPulse = new System.Windows.Forms.TextBox();
            this.txtBP = new System.Windows.Forms.TextBox();
            this.lblVisitDate = new System.Windows.Forms.Label();
            this.lblAppointmentID = new System.Windows.Forms.Label();
            this.lblVisitID = new System.Windows.Forms.Label();
            this.tpPrescription = new System.Windows.Forms.TabPage();
            this.tpRecommendedProceduresAndServices = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbMeds = new System.Windows.Forms.ComboBox();
            this.Dosage = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnAddMedication = new System.Windows.Forms.Button();
            this.dgvMeds = new System.Windows.Forms.DataGridView();
            this.cmsMeds = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteMedicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvService = new System.Windows.Forms.DataGridView();
            this.btnAddService = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbServices = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmsServices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblLineTotal = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpVisitDiagnosis.SuspendLayout();
            this.tpPrescription.SuspendLayout();
            this.tpRecommendedProceduresAndServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeds)).BeginInit();
            this.cmsMeds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).BeginInit();
            this.cmsServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-6, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 106);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CMS_UI.Properties.Resources.doctor_visit;
            this.pictureBox1.Location = new System.Drawing.Point(433, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(447, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visit ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Visit ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(365, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Appointment ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(710, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Visit Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Symptoms:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(498, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Diagnosis:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Vitals Signs BP:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(362, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Vital Signs Pulse:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(667, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Vital Signs Temp:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpVisitDiagnosis);
            this.tabControl1.Controls.Add(this.tpPrescription);
            this.tabControl1.Controls.Add(this.tpRecommendedProceduresAndServices);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 107);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(933, 356);
            this.tabControl1.TabIndex = 10;
            // 
            // tpVisitDiagnosis
            // 
            this.tpVisitDiagnosis.Controls.Add(this.textBox2);
            this.tpVisitDiagnosis.Controls.Add(this.textBox1);
            this.tpVisitDiagnosis.Controls.Add(this.txtTemp);
            this.tpVisitDiagnosis.Controls.Add(this.txtPulse);
            this.tpVisitDiagnosis.Controls.Add(this.txtBP);
            this.tpVisitDiagnosis.Controls.Add(this.lblVisitDate);
            this.tpVisitDiagnosis.Controls.Add(this.lblAppointmentID);
            this.tpVisitDiagnosis.Controls.Add(this.lblVisitID);
            this.tpVisitDiagnosis.Controls.Add(this.label4);
            this.tpVisitDiagnosis.Controls.Add(this.label9);
            this.tpVisitDiagnosis.Controls.Add(this.label3);
            this.tpVisitDiagnosis.Controls.Add(this.label8);
            this.tpVisitDiagnosis.Controls.Add(this.label2);
            this.tpVisitDiagnosis.Controls.Add(this.label7);
            this.tpVisitDiagnosis.Controls.Add(this.label5);
            this.tpVisitDiagnosis.Controls.Add(this.label6);
            this.tpVisitDiagnosis.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpVisitDiagnosis.Location = new System.Drawing.Point(4, 25);
            this.tpVisitDiagnosis.Name = "tpVisitDiagnosis";
            this.tpVisitDiagnosis.Padding = new System.Windows.Forms.Padding(3);
            this.tpVisitDiagnosis.Size = new System.Drawing.Size(925, 327);
            this.tpVisitDiagnosis.TabIndex = 0;
            this.tpVisitDiagnosis.Text = "Visit / Diagnosis";
            this.tpVisitDiagnosis.UseVisualStyleBackColor = true;
            // 
            // txtTemp
            // 
            this.txtTemp.Location = new System.Drawing.Point(794, 94);
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(122, 23);
            this.txtTemp.TabIndex = 15;
            // 
            // txtPulse
            // 
            this.txtPulse.Location = new System.Drawing.Point(485, 94);
            this.txtPulse.Name = "txtPulse";
            this.txtPulse.Size = new System.Drawing.Size(122, 23);
            this.txtPulse.TabIndex = 14;
            // 
            // txtBP
            // 
            this.txtBP.Location = new System.Drawing.Point(143, 94);
            this.txtBP.Name = "txtBP";
            this.txtBP.Size = new System.Drawing.Size(122, 23);
            this.txtBP.TabIndex = 13;
            // 
            // lblVisitDate
            // 
            this.lblVisitDate.AutoSize = true;
            this.lblVisitDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitDate.Location = new System.Drawing.Point(791, 40);
            this.lblVisitDate.Name = "lblVisitDate";
            this.lblVisitDate.Size = new System.Drawing.Size(31, 13);
            this.lblVisitDate.TabIndex = 12;
            this.lblVisitDate.Text = "###";
            // 
            // lblAppointmentID
            // 
            this.lblAppointmentID.AutoSize = true;
            this.lblAppointmentID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentID.Location = new System.Drawing.Point(485, 40);
            this.lblAppointmentID.Name = "lblAppointmentID";
            this.lblAppointmentID.Size = new System.Drawing.Size(31, 13);
            this.lblAppointmentID.TabIndex = 11;
            this.lblAppointmentID.Text = "###";
            // 
            // lblVisitID
            // 
            this.lblVisitID.AutoSize = true;
            this.lblVisitID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitID.Location = new System.Drawing.Point(140, 40);
            this.lblVisitID.Name = "lblVisitID";
            this.lblVisitID.Size = new System.Drawing.Size(31, 13);
            this.lblVisitID.TabIndex = 10;
            this.lblVisitID.Text = "###";
            // 
            // tpPrescription
            // 
            this.tpPrescription.Controls.Add(this.dgvMeds);
            this.tpPrescription.Controls.Add(this.btnAddMedication);
            this.tpPrescription.Controls.Add(this.label14);
            this.tpPrescription.Controls.Add(this.label13);
            this.tpPrescription.Controls.Add(this.txtDuration);
            this.tpPrescription.Controls.Add(this.Dosage);
            this.tpPrescription.Controls.Add(this.cmbMeds);
            this.tpPrescription.Controls.Add(this.label12);
            this.tpPrescription.Controls.Add(this.label11);
            this.tpPrescription.Controls.Add(this.label10);
            this.tpPrescription.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpPrescription.Location = new System.Drawing.Point(4, 25);
            this.tpPrescription.Name = "tpPrescription";
            this.tpPrescription.Padding = new System.Windows.Forms.Padding(3);
            this.tpPrescription.Size = new System.Drawing.Size(925, 327);
            this.tpPrescription.TabIndex = 1;
            this.tpPrescription.Text = "Prescription";
            this.tpPrescription.UseVisualStyleBackColor = true;
            // 
            // tpRecommendedProceduresAndServices
            // 
            this.tpRecommendedProceduresAndServices.Controls.Add(this.lblLineTotal);
            this.tpRecommendedProceduresAndServices.Controls.Add(this.lblPrice);
            this.tpRecommendedProceduresAndServices.Controls.Add(this.nudQuantity);
            this.tpRecommendedProceduresAndServices.Controls.Add(this.dgvService);
            this.tpRecommendedProceduresAndServices.Controls.Add(this.btnAddService);
            this.tpRecommendedProceduresAndServices.Controls.Add(this.label15);
            this.tpRecommendedProceduresAndServices.Controls.Add(this.cmbServices);
            this.tpRecommendedProceduresAndServices.Controls.Add(this.label17);
            this.tpRecommendedProceduresAndServices.Controls.Add(this.label18);
            this.tpRecommendedProceduresAndServices.Controls.Add(this.label19);
            this.tpRecommendedProceduresAndServices.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpRecommendedProceduresAndServices.Location = new System.Drawing.Point(4, 25);
            this.tpRecommendedProceduresAndServices.Name = "tpRecommendedProceduresAndServices";
            this.tpRecommendedProceduresAndServices.Padding = new System.Windows.Forms.Padding(3);
            this.tpRecommendedProceduresAndServices.Size = new System.Drawing.Size(925, 327);
            this.tpRecommendedProceduresAndServices.TabIndex = 2;
            this.tpRecommendedProceduresAndServices.Text = "Recommended Procedures / Services";
            this.tpRecommendedProceduresAndServices.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(778, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 46);
            this.button1.TabIndex = 11;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MidnightBlue;
            this.button2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(609, 469);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 46);
            this.button2.TabIndex = 12;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 181);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(336, 131);
            this.textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(498, 181);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(358, 131);
            this.textBox2.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Medication:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(65, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Dosage:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(57, 234);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Duration:";
            // 
            // cmbMeds
            // 
            this.cmbMeds.FormattingEnabled = true;
            this.cmbMeds.Location = new System.Drawing.Point(158, 30);
            this.cmbMeds.Name = "cmbMeds";
            this.cmbMeds.Size = new System.Drawing.Size(264, 24);
            this.cmbMeds.TabIndex = 3;
            // 
            // Dosage
            // 
            this.Dosage.Location = new System.Drawing.Point(158, 131);
            this.Dosage.Name = "Dosage";
            this.Dosage.Size = new System.Drawing.Size(264, 23);
            this.Dosage.TabIndex = 4;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(158, 231);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(264, 23);
            this.txtDuration.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(428, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 16);
            this.label13.TabIndex = 6;
            this.label13.Text = "mg";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(428, 234);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 16);
            this.label14.TabIndex = 7;
            this.label14.Text = "Days";
            // 
            // btnAddMedication
            // 
            this.btnAddMedication.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAddMedication.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMedication.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddMedication.Location = new System.Drawing.Point(392, 274);
            this.btnAddMedication.Name = "btnAddMedication";
            this.btnAddMedication.Size = new System.Drawing.Size(146, 41);
            this.btnAddMedication.TabIndex = 13;
            this.btnAddMedication.Text = "Add Medication";
            this.btnAddMedication.UseVisualStyleBackColor = false;
            // 
            // dgvMeds
            // 
            this.dgvMeds.AllowUserToAddRows = false;
            this.dgvMeds.AllowUserToDeleteRows = false;
            this.dgvMeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeds.ContextMenuStrip = this.cmsMeds;
            this.dgvMeds.Location = new System.Drawing.Point(505, 30);
            this.dgvMeds.Name = "dgvMeds";
            this.dgvMeds.ReadOnly = true;
            this.dgvMeds.Size = new System.Drawing.Size(414, 224);
            this.dgvMeds.TabIndex = 14;
            // 
            // cmsMeds
            // 
            this.cmsMeds.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteMedicationToolStripMenuItem});
            this.cmsMeds.Name = "cmsMeds";
            this.cmsMeds.Size = new System.Drawing.Size(171, 26);
            // 
            // deleteMedicationToolStripMenuItem
            // 
            this.deleteMedicationToolStripMenuItem.Name = "deleteMedicationToolStripMenuItem";
            this.deleteMedicationToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.deleteMedicationToolStripMenuItem.Text = "Delete Medication";
            // 
            // dgvService
            // 
            this.dgvService.AllowUserToAddRows = false;
            this.dgvService.AllowUserToDeleteRows = false;
            this.dgvService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvService.ContextMenuStrip = this.cmsServices;
            this.dgvService.Location = new System.Drawing.Point(505, 30);
            this.dgvService.Name = "dgvService";
            this.dgvService.ReadOnly = true;
            this.dgvService.Size = new System.Drawing.Size(414, 224);
            this.dgvService.TabIndex = 24;
            // 
            // btnAddService
            // 
            this.btnAddService.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAddService.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddService.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddService.Location = new System.Drawing.Point(392, 274);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(146, 41);
            this.btnAddService.TabIndex = 23;
            this.btnAddService.Text = "Add Service";
            this.btnAddService.UseVisualStyleBackColor = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(51, 238);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 16);
            this.label15.TabIndex = 22;
            this.label15.Text = "Line Total:";
            // 
            // cmbServices
            // 
            this.cmbServices.FormattingEnabled = true;
            this.cmbServices.Location = new System.Drawing.Point(158, 30);
            this.cmbServices.Name = "cmbServices";
            this.cmbServices.Size = new System.Drawing.Size(264, 24);
            this.cmbServices.TabIndex = 18;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(81, 170);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 16);
            this.label17.TabIndex = 17;
            this.label17.Text = "Price:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(57, 102);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 16);
            this.label18.TabIndex = 16;
            this.label18.Text = "Quantity:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(65, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 16);
            this.label19.TabIndex = 15;
            this.label19.Text = "Service:";
            // 
            // cmsServices
            // 
            this.cmsServices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cmsServices.Name = "cmsMeds";
            this.cmsServices.Size = new System.Drawing.Size(171, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem1.Text = "Delete Medication";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Enabled = false;
            this.nudQuantity.Location = new System.Drawing.Point(158, 99);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(264, 23);
            this.nudQuantity.TabIndex = 25;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(155, 170);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 16);
            this.lblPrice.TabIndex = 26;
            this.lblPrice.Text = "###";
            // 
            // lblLineTotal
            // 
            this.lblLineTotal.AutoSize = true;
            this.lblLineTotal.Location = new System.Drawing.Point(155, 238);
            this.lblLineTotal.Name = "lblLineTotal";
            this.lblLineTotal.Size = new System.Drawing.Size(34, 16);
            this.lblLineTotal.TabIndex = 27;
            this.lblLineTotal.Text = "###";
            // 
            // StartVisit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 527);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartVisit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartVisit";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpVisitDiagnosis.ResumeLayout(false);
            this.tpVisitDiagnosis.PerformLayout();
            this.tpPrescription.ResumeLayout(false);
            this.tpPrescription.PerformLayout();
            this.tpRecommendedProceduresAndServices.ResumeLayout(false);
            this.tpRecommendedProceduresAndServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeds)).EndInit();
            this.cmsMeds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).EndInit();
            this.cmsServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpVisitDiagnosis;
        private System.Windows.Forms.TabPage tpPrescription;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tpRecommendedProceduresAndServices;
        private System.Windows.Forms.Label lblVisitID;
        private System.Windows.Forms.Label lblAppointmentID;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.TextBox txtPulse;
        private System.Windows.Forms.TextBox txtBP;
        private System.Windows.Forms.Label lblVisitDate;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox Dosage;
        private System.Windows.Forms.ComboBox cmbMeds;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvMeds;
        private System.Windows.Forms.Button btnAddMedication;
        private System.Windows.Forms.ContextMenuStrip cmsMeds;
        private System.Windows.Forms.ToolStripMenuItem deleteMedicationToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvService;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbServices;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ContextMenuStrip cmsServices;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblLineTotal;
        private System.Windows.Forms.Label lblPrice;
    }
}