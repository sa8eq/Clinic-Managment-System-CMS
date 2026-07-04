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
            
            if (dataGridView1.Rows.Count > 0)
            {
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
            this.Hide();
            frm.ShowDialog();
            this.Show();
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

        private void showUserInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a user to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedUserID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value);
            UserInfo frm = new UserInfo(selectedUserID);
            frm.ShowDialog();
            LoadForm();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a user to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedUserID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value);
            if (MessageBox.Show("Are You Sure You Want To Delete This User?", "Deleting User", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(clsUser.Delete(selectedUserID))
                {
                    MessageBox.Show("User Has Been Successfully Deleted");
                    LoadForm();
                }
                else
                {
                    MessageBox.Show("Failed Deleting User");
                }
            }
        }

        private void deActivateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a user to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedUserID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value);

            clsUser user = clsUser.Find(selectedUserID);

            if(!user.IsActive)
            {
                MessageBox.Show("User Already Deactivated");
                return;
            }
            user.IsActive = false;

            if(user.Save())
            {
                MessageBox.Show("User De-Activated Successfully");
                LoadForm();
            }
            else
            {
                MessageBox.Show($"Could Not De-Activate User With ID: {user.UserID}");
            }
        }

        private void reActivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a user to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedUserID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value);

            clsUser user = clsUser.Find(selectedUserID);

            if (user.IsActive)
            {
                MessageBox.Show("User Already Activated");
                return;
            }
            user.IsActive = true;

            if (user.Save())
            {
                MessageBox.Show("User Re-Activated Successfully");
                LoadForm();
            }
            else
            {
                MessageBox.Show($"Could Not Re-Activate User With ID: {user.UserID}");
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bool IsActive = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["IsActive"].Value);

            if(!IsActive)
            {
                reActivateToolStripMenuItem.Enabled = true;
                deActivateUserToolStripMenuItem.Enabled = false;
            }
            else
            {
                reActivateToolStripMenuItem.Enabled = false;
                deActivateUserToolStripMenuItem.Enabled = true;
            }
        }
    }
}
