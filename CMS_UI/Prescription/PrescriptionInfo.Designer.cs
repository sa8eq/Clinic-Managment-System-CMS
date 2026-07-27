namespace CMS_UI
{
    partial class PrescriptionInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvMeds = new System.Windows.Forms.DataGridView();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.lblPrescriptionID = new System.Windows.Forms.Label();
            this.lblVisitID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblVisitDate = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-5, -6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 120);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CMS_UI.Properties.Resources.syringe;
            this.pictureBox1.Location = new System.Drawing.Point(448, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(333, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recommended Treatment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prescription ID:";
            // 
            // dgvMeds
            // 
            this.dgvMeds.AllowUserToAddRows = false;
            this.dgvMeds.AllowUserToDeleteRows = false;
            this.dgvMeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeds.Location = new System.Drawing.Point(15, 207);
            this.dgvMeds.Name = "dgvMeds";
            this.dgvMeds.ReadOnly = true;
            this.dgvMeds.Size = new System.Drawing.Size(460, 259);
            this.dgvMeds.TabIndex = 2;
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Location = new System.Drawing.Point(485, 207);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.Size = new System.Drawing.Size(460, 259);
            this.dgvServices.TabIndex = 3;
            // 
            // lblPrescriptionID
            // 
            this.lblPrescriptionID.AutoSize = true;
            this.lblPrescriptionID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrescriptionID.Location = new System.Drawing.Point(121, 128);
            this.lblPrescriptionID.Name = "lblPrescriptionID";
            this.lblPrescriptionID.Size = new System.Drawing.Size(31, 13);
            this.lblPrescriptionID.TabIndex = 4;
            this.lblPrescriptionID.Text = "###";
            // 
            // lblVisitID
            // 
            this.lblVisitID.AutoSize = true;
            this.lblVisitID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitID.Location = new System.Drawing.Point(476, 128);
            this.lblVisitID.Name = "lblVisitID";
            this.lblVisitID.Size = new System.Drawing.Size(31, 13);
            this.lblVisitID.TabIndex = 6;
            this.lblVisitID.Text = "###";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(412, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Visit ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Prescription Details:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(482, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Recommended Services:";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(121, 161);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(31, 13);
            this.lblPatientName.TabIndex = 10;
            this.lblPatientName.Text = "###";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Patient Name:";
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorName.Location = new System.Drawing.Point(476, 161);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(31, 13);
            this.lblDoctorName.TabIndex = 12;
            this.lblDoctorName.Text = "###";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(375, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 16);
            this.label11.TabIndex = 11;
            this.label11.Text = "Doctor Name:";
            // 
            // lblVisitDate
            // 
            this.lblVisitDate.AutoSize = true;
            this.lblVisitDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitDate.Location = new System.Drawing.Point(843, 128);
            this.lblVisitDate.Name = "lblVisitDate";
            this.lblVisitDate.Size = new System.Drawing.Size(31, 13);
            this.lblVisitDate.TabIndex = 14;
            this.lblVisitDate.Text = "###";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(762, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 16);
            this.label13.TabIndex = 13;
            this.label13.Text = "Visit Date:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(760, 472);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(185, 43);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PrescriptionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 527);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblVisitDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblDoctorName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblVisitID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPrescriptionID);
            this.Controls.Add(this.dgvServices);
            this.Controls.Add(this.dgvMeds);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PrescriptionInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrescriptionInfo";
            this.Load += new System.EventHandler(this.PrescriptionInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvMeds;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Label lblPrescriptionID;
        private System.Windows.Forms.Label lblVisitID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblVisitDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClose;
    }
}