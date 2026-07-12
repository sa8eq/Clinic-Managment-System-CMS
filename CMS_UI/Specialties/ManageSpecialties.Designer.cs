namespace CMS_UI.Specialties
{
    partial class ManageSpecialties
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDepartmentInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDoctorsInDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 110);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(374, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Departments";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 173);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(933, 287);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAddNew.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddNew.Location = new System.Drawing.Point(769, 113);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(176, 54);
            this.btnAddNew.TabIndex = 2;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(769, 466);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(176, 54);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Departments Count:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(170, 486);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(30, 18);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "#0";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDepartmentInfoToolStripMenuItem,
            this.showDoctorsInDepartmentToolStripMenuItem,
            this.toolStripSeparator1,
            this.addNewDepartmentToolStripMenuItem,
            this.editDepartmentToolStripMenuItem,
            this.deleteDepartmentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 120);
            // 
            // showDepartmentInfoToolStripMenuItem
            // 
            this.showDepartmentInfoToolStripMenuItem.Name = "showDepartmentInfoToolStripMenuItem";
            this.showDepartmentInfoToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.showDepartmentInfoToolStripMenuItem.Text = "Show Department Info";
            this.showDepartmentInfoToolStripMenuItem.Click += new System.EventHandler(this.showDepartmentInfoToolStripMenuItem_Click);
            // 
            // showDoctorsInDepartmentToolStripMenuItem
            // 
            this.showDoctorsInDepartmentToolStripMenuItem.Name = "showDoctorsInDepartmentToolStripMenuItem";
            this.showDoctorsInDepartmentToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.showDoctorsInDepartmentToolStripMenuItem.Text = "Show Doctors In Department";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // addNewDepartmentToolStripMenuItem
            // 
            this.addNewDepartmentToolStripMenuItem.Name = "addNewDepartmentToolStripMenuItem";
            this.addNewDepartmentToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.addNewDepartmentToolStripMenuItem.Text = "Add New Department";
            this.addNewDepartmentToolStripMenuItem.Click += new System.EventHandler(this.addNewDepartmentToolStripMenuItem_Click);
            // 
            // editDepartmentToolStripMenuItem
            // 
            this.editDepartmentToolStripMenuItem.Name = "editDepartmentToolStripMenuItem";
            this.editDepartmentToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.editDepartmentToolStripMenuItem.Text = "Edit Department";
            this.editDepartmentToolStripMenuItem.Click += new System.EventHandler(this.editDepartmentToolStripMenuItem_Click);
            // 
            // deleteDepartmentToolStripMenuItem
            // 
            this.deleteDepartmentToolStripMenuItem.Name = "deleteDepartmentToolStripMenuItem";
            this.deleteDepartmentToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.deleteDepartmentToolStripMenuItem.Text = "Delete Department";
            this.deleteDepartmentToolStripMenuItem.Click += new System.EventHandler(this.deleteDepartmentToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CMS_UI.Properties.Resources.department;
            this.pictureBox1.Location = new System.Drawing.Point(460, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ManageSpecialties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 527);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageSpecialties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Specialties";
            this.Load += new System.EventHandler(this.ManageSpecialties_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDepartmentInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDoctorsInDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addNewDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDepartmentToolStripMenuItem;
    }
}