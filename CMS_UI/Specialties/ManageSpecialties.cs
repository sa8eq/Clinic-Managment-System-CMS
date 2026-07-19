using CMS_UI.Doctors;
using CMSLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS_UI.Specialties
{
    public partial class ManageSpecialties : Form
    {
        private DataTable _dt;
        public ManageSpecialties()
        {
            InitializeComponent();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reload()
        {
            _dt = clsSpecialty.GetAllSpecialties();
            dataGridView1.DataSource = _dt;
            if(_dt.Rows.Count > 0)
            {
                dataGridView1.Columns["SpecialtyID"].HeaderText = "ID";
                dataGridView1.Columns["SpecialtyName"].HeaderText = "Name";
                dataGridView1.Columns["Description"].HeaderText = "Description";

                dataGridView1.Columns["SpecialtyID"].Width = 100;
                dataGridView1.Columns["SpecialtyName"].Width = 100;
                dataGridView1.Columns["Description"].Width = 680;
            }
            lblCount.Text = '#' + dataGridView1.Rows.Count.ToString();

        }

        private void ManageSpecialties_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void showDepartmentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow == null || dataGridView1.Rows.Count  == 0)
            {
                MessageBox.Show("Make Sure You Choose A Specialty To Show Its Info");
                return;
            }
            int selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SpecialtyID"].Value);
            SpecialtyInfo frm = new SpecialtyInfo(selectedID);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void deleteDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Make Sure You Choose A Specialty To Delete");
                return;
            }
            int selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SpecialtyID"].Value);

            if (MessageBox.Show("Are You Sure You Want To Delete This Department? ", "Deletion Confermation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(clsSpecialty.DeleteSpecialty(selectedID))
                {
                    MessageBox.Show("Department Has Been Successfully Deleted");
                }
                else
                {
                    MessageBox.Show("Faild Deleting Department");
                }
            }
            Reload();
        }

        private void addNewDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditSpecialty frm = new AddEditSpecialty();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void editDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Make Sure You Choose A Specialty To Edit");
                return;
            }
            int selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SpecialtyID"].Value);
            AddEditSpecialty frm = new AddEditSpecialty(selectedID);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddEditSpecialty frm = new AddEditSpecialty();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void showDoctorsInDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Make Sure You Choose A Specialty To Show The Doctors");
                return;
            }
            int selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SpecialtyID"].Value);
            ManageDoctors frm = new ManageDoctors(selectedID);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }
    }
}
