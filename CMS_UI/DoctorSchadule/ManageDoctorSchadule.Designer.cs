namespace CMS_UI.DoctorSchadule
{
    partial class ManageDoctorSchedule
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDoctorID = new System.Windows.Forms.Label();
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.lblDoctorSpecialty = new System.Windows.Forms.Label();
            this.cbxMonday = new System.Windows.Forms.CheckBox();
            this.cbxTuesday = new System.Windows.Forms.CheckBox();
            this.cbxWednesday = new System.Windows.Forms.CheckBox();
            this.cbxThursday = new System.Windows.Forms.CheckBox();
            this.cbxFriday = new System.Windows.Forms.CheckBox();
            this.cbxSaturday = new System.Windows.Forms.CheckBox();
            this.cbxSunday = new System.Windows.Forms.CheckBox();
            this.dtpMondayStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpTuesdayStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpWednesdayStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpThursdayStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpFridayStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpSaturdayStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpSundayStartTime = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtpSundayEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpSaturdayEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpFridayEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpThursdayEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpWednesdayEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpTuesdayEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpMondayEndTime = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-6, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 104);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CMS_UI.Properties.Resources.schadule;
            this.pictureBox1.Location = new System.Drawing.Point(175, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(135, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Schadule";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Doctor ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(108, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Doctor Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(81, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Doctor Specialty:";
            // 
            // lblDoctorID
            // 
            this.lblDoctorID.AutoSize = true;
            this.lblDoctorID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorID.Location = new System.Drawing.Point(226, 117);
            this.lblDoctorID.Name = "lblDoctorID";
            this.lblDoctorID.Size = new System.Drawing.Size(34, 16);
            this.lblDoctorID.TabIndex = 4;
            this.lblDoctorID.Text = "###";
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorName.Location = new System.Drawing.Point(226, 143);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(34, 16);
            this.lblDoctorName.TabIndex = 5;
            this.lblDoctorName.Text = "###";
            // 
            // lblDoctorSpecialty
            // 
            this.lblDoctorSpecialty.AutoSize = true;
            this.lblDoctorSpecialty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorSpecialty.Location = new System.Drawing.Point(226, 169);
            this.lblDoctorSpecialty.Name = "lblDoctorSpecialty";
            this.lblDoctorSpecialty.Size = new System.Drawing.Size(34, 16);
            this.lblDoctorSpecialty.TabIndex = 6;
            this.lblDoctorSpecialty.Text = "###";
            // 
            // cbxMonday
            // 
            this.cbxMonday.AutoSize = true;
            this.cbxMonday.Location = new System.Drawing.Point(39, 207);
            this.cbxMonday.Name = "cbxMonday";
            this.cbxMonday.Size = new System.Drawing.Size(64, 17);
            this.cbxMonday.TabIndex = 7;
            this.cbxMonday.Text = "Monday";
            this.cbxMonday.UseVisualStyleBackColor = true;
            this.cbxMonday.CheckedChanged += new System.EventHandler(this.cbxMonday_CheckedChanged);
            // 
            // cbxTuesday
            // 
            this.cbxTuesday.AutoSize = true;
            this.cbxTuesday.Location = new System.Drawing.Point(39, 246);
            this.cbxTuesday.Name = "cbxTuesday";
            this.cbxTuesday.Size = new System.Drawing.Size(67, 17);
            this.cbxTuesday.TabIndex = 8;
            this.cbxTuesday.Text = "Tuesday";
            this.cbxTuesday.UseVisualStyleBackColor = true;
            this.cbxTuesday.CheckedChanged += new System.EventHandler(this.cbxTuesday_CheckedChanged);
            // 
            // cbxWednesday
            // 
            this.cbxWednesday.AutoSize = true;
            this.cbxWednesday.Location = new System.Drawing.Point(39, 285);
            this.cbxWednesday.Name = "cbxWednesday";
            this.cbxWednesday.Size = new System.Drawing.Size(83, 17);
            this.cbxWednesday.TabIndex = 9;
            this.cbxWednesday.Text = "Wednesday";
            this.cbxWednesday.UseVisualStyleBackColor = true;
            this.cbxWednesday.CheckedChanged += new System.EventHandler(this.cbxWednesday_CheckedChanged);
            // 
            // cbxThursday
            // 
            this.cbxThursday.AutoSize = true;
            this.cbxThursday.Location = new System.Drawing.Point(39, 324);
            this.cbxThursday.Name = "cbxThursday";
            this.cbxThursday.Size = new System.Drawing.Size(71, 17);
            this.cbxThursday.TabIndex = 10;
            this.cbxThursday.Text = "Thursday";
            this.cbxThursday.UseVisualStyleBackColor = true;
            this.cbxThursday.CheckedChanged += new System.EventHandler(this.cbxThursday_CheckedChanged);
            // 
            // cbxFriday
            // 
            this.cbxFriday.AutoSize = true;
            this.cbxFriday.Location = new System.Drawing.Point(39, 363);
            this.cbxFriday.Name = "cbxFriday";
            this.cbxFriday.Size = new System.Drawing.Size(56, 17);
            this.cbxFriday.TabIndex = 11;
            this.cbxFriday.Text = "Friday";
            this.cbxFriday.UseVisualStyleBackColor = true;
            this.cbxFriday.CheckedChanged += new System.EventHandler(this.cbxFriday_CheckedChanged);
            // 
            // cbxSaturday
            // 
            this.cbxSaturday.AutoSize = true;
            this.cbxSaturday.Location = new System.Drawing.Point(39, 402);
            this.cbxSaturday.Name = "cbxSaturday";
            this.cbxSaturday.Size = new System.Drawing.Size(70, 17);
            this.cbxSaturday.TabIndex = 12;
            this.cbxSaturday.Text = "Saturday";
            this.cbxSaturday.UseVisualStyleBackColor = true;
            this.cbxSaturday.CheckedChanged += new System.EventHandler(this.cbxSaturday_CheckedChanged);
            // 
            // cbxSunday
            // 
            this.cbxSunday.AutoSize = true;
            this.cbxSunday.Location = new System.Drawing.Point(39, 441);
            this.cbxSunday.Name = "cbxSunday";
            this.cbxSunday.Size = new System.Drawing.Size(62, 17);
            this.cbxSunday.TabIndex = 13;
            this.cbxSunday.Text = "Sunday";
            this.cbxSunday.UseVisualStyleBackColor = true;
            this.cbxSunday.CheckedChanged += new System.EventHandler(this.cbxSunday_CheckedChanged);
            // 
            // dtpMondayStartTime
            // 
            this.dtpMondayStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpMondayStartTime.Location = new System.Drawing.Point(166, 205);
            this.dtpMondayStartTime.Name = "dtpMondayStartTime";
            this.dtpMondayStartTime.ShowUpDown = true;
            this.dtpMondayStartTime.Size = new System.Drawing.Size(112, 20);
            this.dtpMondayStartTime.TabIndex = 14;
            // 
            // dtpTuesdayStartTime
            // 
            this.dtpTuesdayStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTuesdayStartTime.Location = new System.Drawing.Point(166, 244);
            this.dtpTuesdayStartTime.Name = "dtpTuesdayStartTime";
            this.dtpTuesdayStartTime.ShowUpDown = true;
            this.dtpTuesdayStartTime.Size = new System.Drawing.Size(112, 20);
            this.dtpTuesdayStartTime.TabIndex = 15;
            // 
            // dtpWednesdayStartTime
            // 
            this.dtpWednesdayStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpWednesdayStartTime.Location = new System.Drawing.Point(166, 283);
            this.dtpWednesdayStartTime.Name = "dtpWednesdayStartTime";
            this.dtpWednesdayStartTime.ShowUpDown = true;
            this.dtpWednesdayStartTime.Size = new System.Drawing.Size(112, 20);
            this.dtpWednesdayStartTime.TabIndex = 16;
            // 
            // dtpThursdayStartTime
            // 
            this.dtpThursdayStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpThursdayStartTime.Location = new System.Drawing.Point(166, 322);
            this.dtpThursdayStartTime.Name = "dtpThursdayStartTime";
            this.dtpThursdayStartTime.ShowUpDown = true;
            this.dtpThursdayStartTime.Size = new System.Drawing.Size(112, 20);
            this.dtpThursdayStartTime.TabIndex = 17;
            // 
            // dtpFridayStartTime
            // 
            this.dtpFridayStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFridayStartTime.Location = new System.Drawing.Point(166, 361);
            this.dtpFridayStartTime.Name = "dtpFridayStartTime";
            this.dtpFridayStartTime.ShowUpDown = true;
            this.dtpFridayStartTime.Size = new System.Drawing.Size(112, 20);
            this.dtpFridayStartTime.TabIndex = 18;
            // 
            // dtpSaturdayStartTime
            // 
            this.dtpSaturdayStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSaturdayStartTime.Location = new System.Drawing.Point(166, 400);
            this.dtpSaturdayStartTime.Name = "dtpSaturdayStartTime";
            this.dtpSaturdayStartTime.ShowUpDown = true;
            this.dtpSaturdayStartTime.Size = new System.Drawing.Size(112, 20);
            this.dtpSaturdayStartTime.TabIndex = 19;
            // 
            // dtpSundayStartTime
            // 
            this.dtpSundayStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSundayStartTime.Location = new System.Drawing.Point(166, 439);
            this.dtpSundayStartTime.Name = "dtpSundayStartTime";
            this.dtpSundayStartTime.ShowUpDown = true;
            this.dtpSundayStartTime.Size = new System.Drawing.Size(112, 20);
            this.dtpSundayStartTime.TabIndex = 20;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(243, 475);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 45);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(75, 475);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(158, 45);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtpSundayEndTime
            // 
            this.dtpSundayEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSundayEndTime.Location = new System.Drawing.Point(312, 439);
            this.dtpSundayEndTime.Name = "dtpSundayEndTime";
            this.dtpSundayEndTime.ShowUpDown = true;
            this.dtpSundayEndTime.Size = new System.Drawing.Size(107, 20);
            this.dtpSundayEndTime.TabIndex = 29;
            // 
            // dtpSaturdayEndTime
            // 
            this.dtpSaturdayEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSaturdayEndTime.Location = new System.Drawing.Point(312, 400);
            this.dtpSaturdayEndTime.Name = "dtpSaturdayEndTime";
            this.dtpSaturdayEndTime.ShowUpDown = true;
            this.dtpSaturdayEndTime.Size = new System.Drawing.Size(107, 20);
            this.dtpSaturdayEndTime.TabIndex = 28;
            // 
            // dtpFridayEndTime
            // 
            this.dtpFridayEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFridayEndTime.Location = new System.Drawing.Point(312, 361);
            this.dtpFridayEndTime.Name = "dtpFridayEndTime";
            this.dtpFridayEndTime.ShowUpDown = true;
            this.dtpFridayEndTime.Size = new System.Drawing.Size(107, 20);
            this.dtpFridayEndTime.TabIndex = 27;
            // 
            // dtpThursdayEndTime
            // 
            this.dtpThursdayEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpThursdayEndTime.Location = new System.Drawing.Point(312, 322);
            this.dtpThursdayEndTime.Name = "dtpThursdayEndTime";
            this.dtpThursdayEndTime.ShowUpDown = true;
            this.dtpThursdayEndTime.Size = new System.Drawing.Size(107, 20);
            this.dtpThursdayEndTime.TabIndex = 26;
            // 
            // dtpWednesdayEndTime
            // 
            this.dtpWednesdayEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpWednesdayEndTime.Location = new System.Drawing.Point(312, 283);
            this.dtpWednesdayEndTime.Name = "dtpWednesdayEndTime";
            this.dtpWednesdayEndTime.ShowUpDown = true;
            this.dtpWednesdayEndTime.Size = new System.Drawing.Size(107, 20);
            this.dtpWednesdayEndTime.TabIndex = 25;
            // 
            // dtpTuesdayEndTime
            // 
            this.dtpTuesdayEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTuesdayEndTime.Location = new System.Drawing.Point(312, 244);
            this.dtpTuesdayEndTime.Name = "dtpTuesdayEndTime";
            this.dtpTuesdayEndTime.ShowUpDown = true;
            this.dtpTuesdayEndTime.Size = new System.Drawing.Size(107, 20);
            this.dtpTuesdayEndTime.TabIndex = 24;
            // 
            // dtpMondayEndTime
            // 
            this.dtpMondayEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpMondayEndTime.Location = new System.Drawing.Point(312, 205);
            this.dtpMondayEndTime.Name = "dtpMondayEndTime";
            this.dtpMondayEndTime.ShowUpDown = true;
            this.dtpMondayEndTime.Size = new System.Drawing.Size(107, 20);
            this.dtpMondayEndTime.TabIndex = 23;
            // 
            // ManageDoctorSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 527);
            this.Controls.Add(this.dtpSundayEndTime);
            this.Controls.Add(this.dtpSaturdayEndTime);
            this.Controls.Add(this.dtpFridayEndTime);
            this.Controls.Add(this.dtpThursdayEndTime);
            this.Controls.Add(this.dtpWednesdayEndTime);
            this.Controls.Add(this.dtpTuesdayEndTime);
            this.Controls.Add(this.dtpMondayEndTime);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpSundayStartTime);
            this.Controls.Add(this.dtpSaturdayStartTime);
            this.Controls.Add(this.dtpFridayStartTime);
            this.Controls.Add(this.dtpThursdayStartTime);
            this.Controls.Add(this.dtpWednesdayStartTime);
            this.Controls.Add(this.dtpTuesdayStartTime);
            this.Controls.Add(this.dtpMondayStartTime);
            this.Controls.Add(this.cbxSunday);
            this.Controls.Add(this.cbxSaturday);
            this.Controls.Add(this.cbxFriday);
            this.Controls.Add(this.cbxThursday);
            this.Controls.Add(this.cbxWednesday);
            this.Controls.Add(this.cbxTuesday);
            this.Controls.Add(this.cbxMonday);
            this.Controls.Add(this.lblDoctorSpecialty);
            this.Controls.Add(this.lblDoctorName);
            this.Controls.Add(this.lblDoctorID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageDoctorSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageDoctorSchadule";
            this.Load += new System.EventHandler(this.ManageDoctorSchadule_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDoctorID;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Label lblDoctorSpecialty;
        private System.Windows.Forms.CheckBox cbxMonday;
        private System.Windows.Forms.CheckBox cbxTuesday;
        private System.Windows.Forms.CheckBox cbxWednesday;
        private System.Windows.Forms.CheckBox cbxThursday;
        private System.Windows.Forms.CheckBox cbxFriday;
        private System.Windows.Forms.CheckBox cbxSaturday;
        private System.Windows.Forms.CheckBox cbxSunday;
        private System.Windows.Forms.DateTimePicker dtpMondayStartTime;
        private System.Windows.Forms.DateTimePicker dtpTuesdayStartTime;
        private System.Windows.Forms.DateTimePicker dtpWednesdayStartTime;
        private System.Windows.Forms.DateTimePicker dtpThursdayStartTime;
        private System.Windows.Forms.DateTimePicker dtpFridayStartTime;
        private System.Windows.Forms.DateTimePicker dtpSaturdayStartTime;
        private System.Windows.Forms.DateTimePicker dtpSundayStartTime;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpSundayEndTime;
        private System.Windows.Forms.DateTimePicker dtpSaturdayEndTime;
        private System.Windows.Forms.DateTimePicker dtpFridayEndTime;
        private System.Windows.Forms.DateTimePicker dtpThursdayEndTime;
        private System.Windows.Forms.DateTimePicker dtpWednesdayEndTime;
        private System.Windows.Forms.DateTimePicker dtpTuesdayEndTime;
        private System.Windows.Forms.DateTimePicker dtpMondayEndTime;
    }
}