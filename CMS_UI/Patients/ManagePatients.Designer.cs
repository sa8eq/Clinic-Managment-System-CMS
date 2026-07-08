namespace CMS_UI.Patients
{
    partial class ManagePatients
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPatientInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPatientInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bookNewAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAppointmentsHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showVisitsHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPriscribtionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.invoicesAndPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewPatient = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-5, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 98);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CMS_UI.Properties.Resources.patient;
            this.pictureBox1.Location = new System.Drawing.Point(452, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(396, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Patients";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(933, 318);
            this.dataGridView1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPatientInformationToolStripMenuItem,
            this.editPatientInformationToolStripMenuItem,
            this.addNewPatientToolStripMenuItem,
            this.toolStripSeparator1,
            this.bookNewAppointmentToolStripMenuItem,
            this.showAppointmentsHistoryToolStripMenuItem,
            this.toolStripSeparator2,
            this.showVisitsHistoryToolStripMenuItem,
            this.showPriscribtionHistoryToolStripMenuItem,
            this.toolStripSeparator3,
            this.invoicesAndPaymentsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(224, 220);
            // 
            // showPatientInformationToolStripMenuItem
            // 
            this.showPatientInformationToolStripMenuItem.Name = "showPatientInformationToolStripMenuItem";
            this.showPatientInformationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.showPatientInformationToolStripMenuItem.Text = "Show Patient Information";
            // 
            // editPatientInformationToolStripMenuItem
            // 
            this.editPatientInformationToolStripMenuItem.Name = "editPatientInformationToolStripMenuItem";
            this.editPatientInformationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.editPatientInformationToolStripMenuItem.Text = "Edit Patient Information";
            this.editPatientInformationToolStripMenuItem.Click += new System.EventHandler(this.editPatientInformationToolStripMenuItem_Click);
            // 
            // addNewPatientToolStripMenuItem
            // 
            this.addNewPatientToolStripMenuItem.Name = "addNewPatientToolStripMenuItem";
            this.addNewPatientToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.addNewPatientToolStripMenuItem.Text = "Add New Patient";
            this.addNewPatientToolStripMenuItem.Click += new System.EventHandler(this.addNewPatientToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // bookNewAppointmentToolStripMenuItem
            // 
            this.bookNewAppointmentToolStripMenuItem.Name = "bookNewAppointmentToolStripMenuItem";
            this.bookNewAppointmentToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.bookNewAppointmentToolStripMenuItem.Text = "Book New Appointment";
            // 
            // showAppointmentsHistoryToolStripMenuItem
            // 
            this.showAppointmentsHistoryToolStripMenuItem.Name = "showAppointmentsHistoryToolStripMenuItem";
            this.showAppointmentsHistoryToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.showAppointmentsHistoryToolStripMenuItem.Text = "Show Appointments History";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(220, 6);
            // 
            // showVisitsHistoryToolStripMenuItem
            // 
            this.showVisitsHistoryToolStripMenuItem.Name = "showVisitsHistoryToolStripMenuItem";
            this.showVisitsHistoryToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.showVisitsHistoryToolStripMenuItem.Text = "Show Visits History";
            // 
            // showPriscribtionHistoryToolStripMenuItem
            // 
            this.showPriscribtionHistoryToolStripMenuItem.Name = "showPriscribtionHistoryToolStripMenuItem";
            this.showPriscribtionHistoryToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.showPriscribtionHistoryToolStripMenuItem.Text = "Show Priscribtion History";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(220, 6);
            // 
            // invoicesAndPaymentsToolStripMenuItem
            // 
            this.invoicesAndPaymentsToolStripMenuItem.Name = "invoicesAndPaymentsToolStripMenuItem";
            this.invoicesAndPaymentsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.invoicesAndPaymentsToolStripMenuItem.Text = "Invoices And Payments";
            // 
            // btnAddNewPatient
            // 
            this.btnAddNewPatient.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAddNewPatient.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewPatient.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddNewPatient.Location = new System.Drawing.Point(743, 99);
            this.btnAddNewPatient.Name = "btnAddNewPatient";
            this.btnAddNewPatient.Size = new System.Drawing.Size(202, 44);
            this.btnAddNewPatient.TabIndex = 2;
            this.btnAddNewPatient.Text = "Add New Patient";
            this.btnAddNewPatient.UseVisualStyleBackColor = false;
            this.btnAddNewPatient.Click += new System.EventHandler(this.btnAddNewPatient_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MidnightBlue;
            this.button2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(743, 473);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(202, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 492);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Patients Count: ";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(159, 492);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(48, 19);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "###";
            // 
            // ManagePatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 527);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAddNewPatient);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManagePatients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagePatients";
            this.Load += new System.EventHandler(this.ManagePatients_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddNewPatient;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPatientInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPatientInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem bookNewAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAppointmentsHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem showVisitsHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPriscribtionHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem invoicesAndPaymentsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
    }
}