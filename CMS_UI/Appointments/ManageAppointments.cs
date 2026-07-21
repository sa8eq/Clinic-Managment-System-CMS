using CMSLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CMS_UI.Appointments
{
    public partial class ManageAppointments : Form
    {
        private DataTable _dt;
        private clsPatient _Patient;
        private clsDoctor _Doctor;
        public ManageAppointments()
        {
            InitializeComponent();
        }
        public ManageAppointments(clsDoctor doc)
        {
            InitializeComponent();
            _Doctor = doc;
        }
        public ManageAppointments(clsPatient pat)
        {
            InitializeComponent();
            _Patient = pat;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpdateCount()
        {
            if (dataGridView1.Rows != null)
            {
                lblCount.Text = "#" + dataGridView1.Rows.Count.ToString();
            }
            else
            {
                lblCount.Text = "#0";
            }
        }
        private void Reload()
        {
            _dt = clsAppointment.GetAllAppointments();
            _FillSpecialtiesComboBox();
            if (_dt.Rows.Count>0)
            {
                dataGridView1.DataSource = _dt;

                if (dataGridView1.Columns.Contains("PatientID"))
                    dataGridView1.Columns["PatientID"].Visible = false;

                if (dataGridView1.Columns.Contains("DoctorID"))
                    dataGridView1.Columns["DoctorID"].Visible = false;


                dataGridView1.Columns["AppointmentID"].HeaderText = "ID";
                dataGridView1.Columns["PatientName"].HeaderText = "Patient Name";
                dataGridView1.Columns["DoctorName"].HeaderText = "Doctor Name";

                if (dataGridView1.Columns.Contains("SpecialtyName"))
                    dataGridView1.Columns["SpecialtyName"].HeaderText = "Specialty";

                dataGridView1.Columns["AppointmentDate"].HeaderText = "Date & Time";
                dataGridView1.Columns["Status"].HeaderText = "Status";
                dataGridView1.Columns["Notes"].HeaderText = "Notes";
                dataGridView1.Columns["ServiceID"].Visible = false;

                dataGridView1.Columns["AppointmentDate"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss tt";


                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            cmbFilterBy.SelectedItem = "None";
            cmbStatusFilter.SelectedItem = "Pending";
            cmbStatusFilter.Enabled = false;
            txtFilterValue.Enabled = false;
            cmbDepartment.Enabled = false;

            UpdateCount();


        }
        private void _FillSpecialtiesComboBox()
        {
            DataTable dtSpecialties = clsSpecialty.GetAllSpecialties();

            if (dtSpecialties != null && dtSpecialties.Rows.Count > 0)
            {
                cmbDepartment.DataSource = dtSpecialties;
                cmbDepartment.DisplayMember = "SpecialtyName";
                cmbDepartment.ValueMember = "SpecialtyID";
            }
        }
        private void ManageAppointments_Load(object sender, EventArgs e)
        {
            Reload();

            if (_Doctor != null)
            {
                cmbFilterBy.SelectedItem = "Doctor Name";
                cmbFilterBy.Enabled = false;

                txtFilterValue.Text = _Doctor.PersonInfo.FullName;
                txtFilterValue.Enabled = false;

                btnAddNewAppointment.Enabled = false;

            }

            if (_Patient != null)
            {
                cmbFilterBy.SelectedItem = "Patient Name";
                cmbFilterBy.Enabled = false;

                txtFilterValue.Text = _Patient.FullName;
                txtFilterValue.Enabled = false;

                btnAddNewAppointment.Enabled = false;

            }
        }
        private void ApplyFilter()
        {
            if (_dt == null || _dt.Rows.Count == 0) return;

            if (cmbFilterBy.SelectedItem == null) return;

            string filterColumn = "";
            string selectedFilter = cmbFilterBy.SelectedItem.ToString();

            switch (selectedFilter)
            {
                case "Patient Name":
                    filterColumn = "PatientName";
                    break;
                case "Doctor Name":
                    filterColumn = "DoctorName";
                    break;
                case "Department": 
                    filterColumn = "SpecialtyName";
                    break;
                case "Status":
                    filterColumn = "Status";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }
            if (filterColumn == "None" ||
                (filterColumn != "Status" && filterColumn 
                != "SpecialtyName" 
                && string.IsNullOrWhiteSpace(txtFilterValue.Text)))
            {
                _dt.DefaultView.RowFilter = "";
                UpdateCount();
                return;
            }

            string filterExpression = "";

            if (filterColumn == "Status")
            {
                filterExpression = $"{filterColumn} = '{cmbStatusFilter.Text}'";
            }
            else if (filterColumn == "SpecialtyName")
            {
                filterExpression = $"{filterColumn} = '{cmbDepartment.Text}'";
            }
            else
            {
                filterExpression = $"{filterColumn} LIKE '%{txtFilterValue.Text.Trim()}%'";
            }

            _dt.DefaultView.RowFilter = filterExpression;
            UpdateCount();
        }
        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dt != null)
            {
                _dt.DefaultView.RowFilter = "";
            }
            txtFilterValue.Text = ""; 
            UpdateCount();

            if (cmbFilterBy.SelectedItem.ToString() == "None")
            {
                cmbStatusFilter.Enabled = false;
                txtFilterValue.Enabled = false;
                cmbDepartment.Enabled = false;
            }
            else if (cmbFilterBy.SelectedItem.ToString() == "Status")
            {
                cmbStatusFilter.Enabled = true;
                cmbStatusFilter.Visible = true;

                txtFilterValue.Enabled = false;
                txtFilterValue.Visible = false;

                cmbDepartment.Enabled = false;
                cmbDepartment.Visible = false;

            }
            else if (cmbFilterBy.SelectedItem.ToString() == "Department")
            {
                cmbStatusFilter.Enabled = false;
                cmbStatusFilter.Visible = false;

                txtFilterValue.Enabled = false;
                txtFilterValue.Visible = false;

                cmbDepartment.Enabled = true;
                cmbDepartment.Visible = true;

            }
            else
            {
                cmbStatusFilter.Enabled = false;
                cmbStatusFilter.Visible = false;

                txtFilterValue.Enabled = true;
                txtFilterValue.Visible = true;

                cmbDepartment.Enabled = false;
                cmbDepartment.Visible = false;

                txtFilterValue.Focus(); 
            }
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            AddEditAppointment frm = new AddEditAppointment();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose Appointment To Show its Info");
                return;
            }
            int appID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);

            AppoitnmentDetails frm = new AppoitnmentDetails(appID);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }
        private void editAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose Appointment To Edit its Info");
                return;
            }
            int appID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);

            AddEditAppointment frm = new AddEditAppointment(appID);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }
        private void completedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);

            clsAppointment app = clsAppointment.Find(appID);

            app.Status = clsAppointment.enStatus.Completed;
            if (MessageBox.Show("Are You Sure You Want To Change This Appointment Status To Completed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if(app.Save())
                {
                    MessageBox.Show("Status Has Been Successfully Changed To Completed");
                    Reload();
                }
            }
        }
        private void cancelledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);

            clsAppointment app = clsAppointment.Find(appID);

            app.Status = clsAppointment.enStatus.Cancelled;
            if (MessageBox.Show("Are You Sure You Want To Cancel This Appointment?", "Cancelation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if(app.Save())
                {
                    MessageBox.Show("Appointment Has been Cancelled");
                    Reload();
                }
            }
        }
        private void noShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);

            clsAppointment app = clsAppointment.Find(appID);

            app.Status = clsAppointment.enStatus.NoShow;
            if (MessageBox.Show("Are You Sure You Want To Set This Appointment To No-Show", "No-Show Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (app.Save())
                {
                    MessageBox.Show("Appointment Has been Set To No Show");
                    Reload();
                }
            }
        }
        private void startVisitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddEditAppointment frm = new AddEditAppointment();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                e.Cancel = true;
                return;
            }
            int appID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);
            clsAppointment app = clsAppointment.Find(appID);
            if (app.Status == clsAppointment.enStatus.Pending || app.Status == clsAppointment.enStatus.NoShow)
            {
                changeStautsToolStripMenuItem.Enabled = true;
                editAppointmentToolStripMenuItem.Enabled = true;
                startVisitToolStripMenuItem.Enabled = true;

                if(app.Status == clsAppointment.enStatus.NoShow)
                {
                    noShowToolStripMenuItem.Enabled = false;
                }
                else
                {
                    noShowToolStripMenuItem.Enabled = true;
                }

                if(app.Status == clsAppointment.enStatus.Pending)
                {
                    pendingToolStripMenuItem.Enabled = false;
                }
                else
                {
                    pendingToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                changeStautsToolStripMenuItem.Enabled = false;
                editAppointmentToolStripMenuItem.Enabled = false;
                startVisitToolStripMenuItem.Enabled = false;
            } 
        }
        private void pendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);

            clsAppointment app = clsAppointment.Find(appID);

            app.Status = clsAppointment.enStatus.Pending;
            if (MessageBox.Show("Are You Sure You Want To Re-Set This Appointment To Pending", "Pending Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (app.Save())
                {
                    MessageBox.Show("Appointment Has been Set To Pending");
                    Reload();
                }
            }
        }
    }
}
