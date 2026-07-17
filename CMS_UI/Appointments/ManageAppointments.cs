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

namespace CMS_UI.Appointments
{
    public partial class ManageAppointments : Form
    {
        private DataTable _dt;

        public ManageAppointments()
        {
            InitializeComponent();
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

        }
    }
}
