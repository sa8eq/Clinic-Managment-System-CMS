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

namespace CMS_UI.Patients
{
    public partial class ManagePatients : Form
    {
        private DataTable _dt;
        public ManagePatients()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reload()
        {
            _dt = clsPatient.GetAllPatients();
            dataGridView1.DataSource = _dt;

            if (dataGridView1.Rows.Count > 0)
            {
                

                dataGridView1.Columns["PatientID"].HeaderText = "Patient ID";
                dataGridView1.Columns["FullName"].HeaderText = "Full Name";
                dataGridView1.Columns["BloodType"].HeaderText = "Blood Type";
                dataGridView1.Columns["InsuranceCompanyName"].HeaderText = "Insurance Company Name";
                dataGridView1.Columns["InsurancePolicyNumber"].HeaderText = "Insurance Policy Number";
                dataGridView1.Columns["EmergencyContactPhone"].HeaderText = "Emergency Contact Phone";

                dataGridView1.Columns["PatientID"].Width =80;
                dataGridView1.Columns["FullName"].Width = 140;
                dataGridView1.Columns["BloodType"].Width = 120;
                dataGridView1.Columns["InsuranceCompanyName"].Width = 200;
                dataGridView1.Columns["InsurancePolicyNumber"].Width = 150;
                dataGridView1.Columns["EmergencyContactPhone"].Width = 180;

                lblCount.Text = '#' + dataGridView1.Rows.Count.ToString();
            }
        }

        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            AddEditPatient frm = new AddEditPatient();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void ManagePatients_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void editPatientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {

                MessageBox.Show("Please select a patient to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            int selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PatientID"].Value);
            AddEditPatient frm = new AddEditPatient(selectedID);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void addNewPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPatient frm = new AddEditPatient();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }
    }
}
