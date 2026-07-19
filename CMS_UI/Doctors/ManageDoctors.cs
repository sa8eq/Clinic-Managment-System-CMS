using CMS_UI.Appointments;
using CMS_UI.DoctorSchadule;
using CMSLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS_UI.Doctors
{
    public partial class ManageDoctors : Form
    {
        public ManageDoctors()
        {
            InitializeComponent();
        }
        public ManageDoctors(int depID)
        {
            InitializeComponent();
            _SpecialtyID = depID;
        }

        private int _SpecialtyID = -1;
        private DataTable _dt;

        private void Reload()
        {
            _dt = clsDoctor.GetAllDoctors();
            dataGridView1.DataSource = _dt;
            if(_dt.Rows.Count>0)
            {
                dataGridView1.Columns["DoctorID"].HeaderText = "Doctor ID";
                dataGridView1.Columns["PersonID"].HeaderText = "Person ID";
                dataGridView1.Columns["FullName"].HeaderText = "Full Name";
                dataGridView1.Columns["SpecialtyName"].HeaderText = "Specialty Name";
                dataGridView1.Columns["LicenseNumber"].HeaderText = "License Number";
                dataGridView1.Columns["HireDate"].HeaderText = "Hire Date";
                dataGridView1.Columns["IsActive"].HeaderText = "Is Active";

                dataGridView1.Columns["SpecialtyID"].Visible = false;

                dataGridView1.Columns["DoctorID"].Width = 80;
                dataGridView1.Columns["PersonID"].Width = 80;
                dataGridView1.Columns["FullName"].Width = 200;
                dataGridView1.Columns["SpecialtyName"].Width = 150;
                dataGridView1.Columns["LicenseNumber"].Width = 150;
                dataGridView1.Columns["HireDate"].Width = 100;
                dataGridView1.Columns["IsActive"].Width = 80;

            }
            lblCount.Text = "#" + dataGridView1.RowCount.ToString();
            txtFilter.Enabled = false;
            cmbFilter.SelectedItem = "None";
            cmbSpecialty.DataSource = clsSpecialty.GetAllSpecialties();
            cmbSpecialty.DisplayMember = "SpecialtyName";
            
        }

        private void ManageDoctors_Load(object sender, EventArgs e)
        {
            Reload();

            if(_SpecialtyID != -1)
            {
                clsSpecialty spec = clsSpecialty.Find(_SpecialtyID);
                cmbFilter.SelectedItem = "Specialty";
                cmbFilter.Enabled = false;

                cmbSpecialty.Text = spec.SpecialtyName;
                cmbSpecialty.Enabled = false;

                btnAddDoctor.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            if (_dt != null)
            {
                _dt.DefaultView.RowFilter = "";
                lblCount.Text = "#" + dataGridView1.RowCount.ToString();
            }

            if (cmbFilter.SelectedItem.ToString() == "None")
            {
                txtFilter.Visible = false;
                cmbSpecialty.Visible = false;
            }
            else if (cmbFilter.SelectedItem.ToString() == "Specialty")
            {
                txtFilter.Visible = false;
                cmbSpecialty.Visible = true;
                cmbSpecialty.Enabled = true;

                cmbSpecialty_SelectedIndexChanged(null, null);
            }
            else 
            {
                txtFilter.Visible = true;
                txtFilter.Enabled = true;
                cmbSpecialty.Visible = false;
                txtFilter.Focus();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (_dt == null || _dt.Rows.Count == 0)
                return;

            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                _dt.DefaultView.RowFilter = "";
                lblCount.Text = "#" + dataGridView1.RowCount.ToString();
                return;
            }

            string filterColumn = "";
            string filterValue = txtFilter.Text.Trim().Replace("'", "''");

            switch (cmbFilter.SelectedItem.ToString())
            {
                case "Name":
                    filterColumn = "FullName";
                    break;

                case "License Number":
                    filterColumn = "LicenseNumber";
                    break;

                default:
                    filterColumn = "None";
                    break;
            }

            if (filterColumn != "None")
            {
                _dt.DefaultView.RowFilter = $"{filterColumn} LIKE '{filterValue}%'";
            }
            else
            {
                _dt.DefaultView.RowFilter = "";
            }

            lblCount.Text = "#" + dataGridView1.RowCount.ToString();
        }

        private void cmbSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dt == null || _dt.Rows.Count == 0 || cmbFilter.SelectedItem.ToString() != "Specialty")
                return;

            string selectedSpecialty = cmbSpecialty.Text.Trim().Replace("'", "''");

            if (!string.IsNullOrEmpty(selectedSpecialty))
            {
                _dt.DefaultView.RowFilter = $"SpecialtyName = '{selectedSpecialty}'";
            }
            else
            {
                _dt.DefaultView.RowFilter = "";
            }

            lblCount.Text = "#" + dataGridView1.RowCount.ToString();
        }

        private void showDoctorInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Doctor To show His/Her Information");
                return;
            }
            int selectedid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DoctorID"].Value);

            DoctorInfo frm = new DoctorInfo(selectedid);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void deleteDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Doctor To Delete");
                return;
            }
            int selectedid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DoctorID"].Value);

            if(MessageBox.Show("Are You Sure You Want To Delete This Doctor?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(clsDoctor.Delete(selectedid))
                {
                    MessageBox.Show("Doctor Has Been Successfully Deleted");
                    Reload();

                }
                else
                {
                    MessageBox.Show("Failed Deleting Doctor");
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(dataGridView1.Rows.Count==0 || dataGridView1.CurrentRow == null)
            {
                contextMenuStrip1.Enabled = false;
                return;
            }
            contextMenuStrip1.Enabled = true;
            bool IsActive = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["IsActive"].Value);

            if (!IsActive)
            {
                reActivateDoctorToolStripMenuItem.Enabled = true;
                deActivateDoctorToolStripMenuItem.Enabled = false;
            }
            else
            {
                reActivateDoctorToolStripMenuItem.Enabled = false;
                deActivateDoctorToolStripMenuItem.Enabled = true;
            }
        }

        private void deActivateDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Doctor To DeActivate");
                return;
            }
            int selectedid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DoctorID"].Value);

            clsDoctor doctor = clsDoctor.Find(selectedid);
            doctor.PersonInfo = clsPerson.Find(doctor.PersonID);
            doctor.IsActive = false;

            if (MessageBox.Show("Are You Sure You Want To DeActivate This Doctor?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (doctor.Save())
                {
                    MessageBox.Show("Doctor Has Been Successfully DeAvtivated");
                    Reload();
                }
                else
                {
                    MessageBox.Show("Failed DeActivating Doctor");
                }
            }
        }

        private void reActivateDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Doctor To ReActivate");
                return;
            }
            int selectedid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DoctorID"].Value);

            clsDoctor doctor = clsDoctor.Find(selectedid);
            doctor.IsActive = true;

            if (MessageBox.Show("Are You Sure You Want To ReActivate This Doctor?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (doctor.Save())
                {
                    MessageBox.Show("Doctor Has Been Successfully ReAvtivated");
                    Reload();
                }
                else
                {
                    MessageBox.Show("Failed ReActivating Doctor");
                }
            }
        }

        private void addNewDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditDoctor frm = new AddEditDoctor();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            AddEditDoctor frm = new AddEditDoctor();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void editDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Doctor To Edit");
                return;
            }
            int selectedid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DoctorID"].Value);
            AddEditDoctor frm = new AddEditDoctor(selectedid);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void showDoctorScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Doctor To Edit Hes/Her Schedule");
                return;
            }
            int selectedid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DoctorID"].Value);
            ManageDoctorSchedule frm = new ManageDoctorSchedule(selectedid);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void bookAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Doctor To Book Appointment With");
                return;
            }
            int selectedid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DoctorID"].Value);
            clsDoctor doc = clsDoctor.Find(selectedid);
            AddEditAppointment frm = new AddEditAppointment(doc);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void showDoctorAppointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Doctor To Show Appointment History");
                return;
            }
            int selectedid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DoctorID"].Value);
            clsDoctor doc = clsDoctor.Find(selectedid);
            ManageAppointments frm = new ManageAppointments(doc);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }
    }
}
