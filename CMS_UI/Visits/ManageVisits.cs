using CMS_UI.Doctors;
using CMS_UI.Patients;
using CMSLogic;
using System;
using System.Data;
using System.Windows.Forms;

namespace CMS_UI.Visits
{
    public partial class ManageVisits : Form
    {
        private clsPatient _Patient;
        private clsDoctor _Doctor;
        private DataTable _dtVisits;
        public ManageVisits()
        {
            InitializeComponent();
        }
        public ManageVisits(clsPatient pat) 
        {
            InitializeComponent();
            _Patient = pat;
        }
        public ManageVisits(clsDoctor doc) 
        {InitializeComponent();
            _Doctor = doc;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Reload()
        {
            _dtVisits = clsVisit.GetAllVisits();
            dataGridView1.DataSource = _dtVisits;

            if (_dtVisits.Rows.Count > 0)
            {
                dataGridView1.Columns["VisitID"].HeaderText = "Visit ID";
                dataGridView1.Columns["VisitID"].Width = 70;

                dataGridView1.Columns["AppointmentID"].HeaderText = "App ID";
                dataGridView1.Columns["AppointmentID"].Width = 70;

                dataGridView1.Columns["PatientName"].HeaderText = "Patient Name";
                dataGridView1.Columns["PatientName"].Width = 110;

                dataGridView1.Columns["DoctorName"].HeaderText = "Doctor Name";
                dataGridView1.Columns["DoctorName"].Width = 110;

                dataGridView1.Columns["VisitDate"].HeaderText = "Visit Date & Time";
                dataGridView1.Columns["VisitDate"].Width = 130;

                dataGridView1.Columns["Symptoms"].HeaderText = "Symptoms";
                dataGridView1.Columns["Symptoms"].Width = 200;

                dataGridView1.Columns["Diagnosis"].HeaderText = "Diagnosis";
                dataGridView1.Columns["Diagnosis"].Width = 200;

                dataGridView1.Columns["VitalSigns_BP"].Visible = false;
                dataGridView1.Columns["VitalSigns_Pulse"].Visible = false;
                dataGridView1.Columns["VitalSigns_Temp"].Visible = false;
            }

            if (_Patient != null)
            {
                cmbFilter.SelectedItem = "Patient Name";

            }
            else if (_Doctor != null)
            {
                cmbFilter.SelectedItem = "Doctor Name";
            }
            else
            {
                cmbFilter.SelectedItem = "None";
            }

            lblCount.Text = "#" + dataGridView1.Rows.Count;
        }
        private void Manage_Visits_Load(object sender, EventArgs e)
        {
            Reload();
            if (_Doctor != null)
            {
                cmbFilter.SelectedItem = "Doctor Name";
                txtFilter.Text = _Doctor.PersonInfo.FullName;

                cmbFilter.Enabled = false;
                txtFilter.Enabled = false;
            }
            if (_Patient != null)
            {
                cmbFilter.SelectedItem = "Patient Name";
                txtFilter.Text = _Patient.PersonInfo.FullName;

                cmbFilter.Enabled = false;
                txtFilter.Enabled = false;
            }
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Clear();
            _dtVisits.DefaultView.RowFilter = "";

            if (cmbFilter.SelectedItem?.ToString() == "None")
            {
                
                txtFilter.Enabled = false;
            }
            else
            {
                txtFilter.Enabled = true;
                txtFilter.Focus();
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (_dtVisits == null || cmbFilter.SelectedItem == null || cmbFilter.SelectedItem.ToString() == "None")
            {
                if (_dtVisits != null) _dtVisits.DefaultView.RowFilter = "";
                return;
            }

            string filterText = txtFilter.Text.Trim();
            string selectedFilter = cmbFilter.SelectedItem.ToString();

            if (string.IsNullOrEmpty(filterText))
            {
                _dtVisits.DefaultView.RowFilter = "";
                lblCount.Text = "#" + dataGridView1.Rows.Count;
                return;
            }

            switch (selectedFilter)
            {
                case "Visit ID":
                case "Appointment ID":
                    if (int.TryParse(filterText, out int id))
                        _dtVisits.DefaultView.RowFilter = $"{selectedFilter.Replace(" ", "")} = {id}";
                    else
                        _dtVisits.DefaultView.RowFilter = "0 = 1";
                    break;

                case "Patient Name":
                case "Doctor Name":
                    _dtVisits.DefaultView.RowFilter = $"{selectedFilter.Replace(" ", "")} LIKE '%{filterText}%'";
                    break;
            }

            lblCount.Text = "#" + dataGridView1.Rows.Count;
        }
        private void reFreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reload();
        }
        private void showDoctorInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Visit To Show Its Doctor Info");
                return;
            }
            int selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["VisitID"].Value);

            clsVisit vis = clsVisit.Find(selectedID);

            if (vis != null)
            {
                DoctorInfo frm = new DoctorInfo(vis.AppointmentInfo.DoctorID);
                this.Hide();
                frm.ShowDialog();
                this.Show();
                Reload();
            }
            else
            {
                MessageBox.Show("There Is No Doctor Found To Show Its Info");
                return;
            }
        }
        private void showPatientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Visit To Show Its Patient Info");
                return;
            }
            int selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["VisitID"].Value);

            clsVisit vis = clsVisit.Find(selectedID);

            if (vis != null)
            {
                PatientInfo frm = new PatientInfo(vis.AppointmentInfo.PatientID);
                this.Hide();
                frm.ShowDialog();
                this.Show();
                Reload();
            }
            else
            {
                MessageBox.Show("There Is No Patient Found To Show Its Info");
                return;
            }
        }
        private void showVisitDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Visit To Show Its Info");
                return;
            }
            int selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["VisitID"].Value);

            VisitInfo frm = new VisitInfo(selectedID);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}