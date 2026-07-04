using CMS_UI.Global;
using CMSLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS_UI.Users
{
    public partial class AddEditUser : Form
    {
        public enum enMode { AddNew, Edit};
        private enMode _Mode;
        private clsUser _User;
        private int _SelectedUserID;
        public AddEditUser()
        {
            InitializeComponent();
            _User = new clsUser();
            _Mode = enMode.AddNew;
        }

        public AddEditUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Edit;
            _SelectedUserID = UserID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Reload()
        {
            DataTable dt = clsRole.GetAllRoles();

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Failed To Load Roles");
                btnSave.Enabled = false;
                return;
            }

            cmbRoles.DataSource = dt;
            cmbRoles.DisplayMember = "RoleName";
            cmbRoles.ValueMember = "RoleID";
            rdbIsActive.Checked = true;
        }

        private void LoadUserData()
        {
            label1.Text = "Edit User";
            ctrlPerson1.LoadPerson(_User.PersonInfo);
            txtUsername.Text = _User.Username;
            cmbRoles.SelectedValue = _User.RoleID;
            rdbIsActive.Checked = _User.IsActive;
            rdbIsNotActive.Checked = !_User.IsActive;
            lblpassowrdnote.Enabled = true;
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
            Reload();
            

            if (_Mode == enMode.Edit)
            {
                _User = clsUser.Find(_SelectedUserID);
                if (_User == null)
                {
                    MessageBox.Show("User Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                LoadUserData();
            }
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

        }
        private void LockTextBoxes()
        {

            this.AutoValidate = AutoValidate.Disable;
            ctrlPerson1.AutoValidate = AutoValidate.Disable;


            rdbIsNotActive.Enabled = false;
            rdbIsActive.Enabled = false;
            txtPassword.Enabled = false;
            txtUsername.Enabled = false;
            cmbRoles.Enabled = false;
            btnSave.Enabled = false;
            ctrlPerson1.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrlPerson1.ValidateChildren() && this.ValidateChildren())
            {
                ctrlPerson1.FillPerson(_User.PersonInfo);
                _User.Username = txtUsername.Text;
                if (_Mode == enMode.AddNew || !string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    _User.PasswordHash = clsPasswordHasher.HashPassword(txtPassword.Text);
                }
                _User.RoleID = (int)cmbRoles.SelectedValue;
                _User.IsActive = rdbIsActive.Checked;
                if (_User.Save())
                {
                    string Message = (_Mode == enMode.AddNew)? "User Added Successfully": "User Updated Successfully";
                    MessageBox.Show($"{Message}\n\nUser ID: {_User.UserID}\nUsername: {_User.Username}","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    UserInfo frm = new UserInfo(_User.UserID);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed Saving User...");
                }
            }
            else
            {
                MessageBox.Show("Check Filed With Error Mark To Fix It");
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                error.SetError(txtUsername, "Username Is Mandatory");
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                if (clsUser.ExistsByUsername(txtUsername.Text))
                {
                    e.Cancel = true;
                    error.SetError(txtUsername, "Username Is Already Used");
                    return;
                }
            }
            else
            {
                if (txtUsername.Text != _User.Username &&
                    clsUser.ExistsByUsername(txtUsername.Text))
                {
                    e.Cancel = true;
                    error.SetError(txtUsername, "Username Is Already Used");
                    return;
                }
            }

            error.SetError(txtUsername, "");
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            // في حالة الإضافة كلمة المرور إجبارية
            if (_Mode == enMode.AddNew)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    e.Cancel = true;
                    error.SetError(txtPassword, "Password Is Mandatory");
                }
                else if (txtPassword.Text.Length < 8)
                {
                    e.Cancel = true;
                    error.SetError(txtPassword, "Password Must Be At Least 8 Characters");
                }
                else
                {
                    error.SetError(txtPassword, "");
                }

                return;
            }

            // في حالة التعديل كلمة المرور اختيارية
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (txtPassword.Text.Length < 8)
                {
                    e.Cancel = true;
                    error.SetError(txtPassword, "Password Must Be At Least 8 Characters");
                }
                else
                {
                    error.SetError(txtPassword, "");
                }
            }
            else
            {
                // تركها فارغة يعني لا تغيير لكلمة المرور
                error.SetError(txtPassword, "");
            }
        }
    }
}
