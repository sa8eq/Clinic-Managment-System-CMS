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

namespace CMS_UI.Users
{
    public partial class ManageUsers : Form
    {
        private DataTable _dt;
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadForm()
        {
            _dt = clsUser.GetAllUsers();

            dataGridView1.DataSource = _dt;

            dataGridView1.Columns["PasswordHash"].Visible = false;

            dataGridView1.Columns["UserID"].HeaderText = "User ID";
            dataGridView1.Columns["FullName"].HeaderText = "Full Name";
            dataGridView1.Columns["Username"].HeaderText = "Username";
            dataGridView1.Columns["RoleName"].HeaderText = "Role";
            dataGridView1.Columns["IsActive"].HeaderText = "Active";

            dataGridView1.Columns["UserID"].Width = 80;
            dataGridView1.Columns["FullName"].Width = 220;
            dataGridView1.Columns["Username"].Width = 150;
            dataGridView1.Columns["RoleName"].Width = 120;
            dataGridView1.Columns["IsActive"].Width = 80;


            if(dataGridView1.Rows.Count>0)
            {
                lblCount.Text = '#' + dataGridView1.Rows.Count.ToString();
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            AddEditUser frm = new AddEditUser();
            frm.ShowDialog();
            LoadForm();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditUser frm = new AddEditUser();
            frm.ShowDialog();
            LoadForm();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a user to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedUserID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value);

            AddEditUser frm = new AddEditUser(selectedUserID);
            frm.ShowDialog();
            LoadForm();
        }
    }
}
