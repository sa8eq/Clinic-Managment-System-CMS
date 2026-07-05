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

namespace CMS_UI.InsuranceCompanies
{
    public partial class ManageInsuraanceCompanies : Form
    {
        private DataTable _dt;
        public ManageInsuraanceCompanies()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNEwInsuranceCmopany_Click(object sender, EventArgs e)
        {
            AddEditInsuranceCompany frm = new AddEditInsuranceCompany();
            frm.ShowDialog();
            LoadForm();
        }

        private void LoadForm()
        {
            _dt = clsInsuranceCompany.GetAllInsuranceCompanies();
            dataGridView1.DataSource = _dt;
            lblCount.Text = "#" + dataGridView1.RowCount.ToString();


            if (_dt!=null && _dt.Rows.Count > 0)
            {

                dataGridView1.Columns["InsuranceCompanyID"].HeaderText = "Insurance Company ID";
                dataGridView1.Columns["CompanyName"].HeaderText = "Company Name";
                dataGridView1.Columns["ContactPhone"].HeaderText = "Contact Phone";
                dataGridView1.Columns["ContactEmail"].HeaderText = "Contact Email";
                dataGridView1.Columns["CoveragePercentage"].HeaderText = "Coverage Percentage";

                dataGridView1.Columns["InsuranceCompanyID"].Width = 160;
                dataGridView1.Columns["CompanyName"].Width = 180;
                dataGridView1.Columns["ContactPhone"].Width = 150;
                dataGridView1.Columns["ContactEmail"].Width = 150;
                dataGridView1.Columns["CoveragePercentage"].Width = 200;

            }
        }

        private void ManageInsuraanceCompanies_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void addNewInsuranceCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditInsuranceCompany frm = new AddEditInsuranceCompany();
            frm.ShowDialog();
            LoadForm();
        }

        private void editInsuranceCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a company to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedid = (int)dataGridView1.CurrentRow.Cells["InsuranceCompanyID"].Value;
            AddEditInsuranceCompany frm = new AddEditInsuranceCompany(selectedid);
            frm.ShowDialog();
            LoadForm();
        }
    }
}
