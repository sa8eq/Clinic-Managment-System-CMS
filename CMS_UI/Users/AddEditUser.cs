using CMS_UI.Global;
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
    public partial class AddEditUser : Form
    {
        public AddEditUser()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reload()
        {
           
            cmbRoles.DataSource = clsRole.GetAllRoles();
            cmbRoles.DisplayMember = "RoleName";
            cmbRoles.ValueMember = "RoleID";

            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);

            
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                clsUser user = new clsUser();

                user.PersonInfo.FirstName = txtFirstName.Text;
                user.PersonInfo.SecondName = txtSecondName.Text;
                user.PersonInfo.ThirdName = txtThirdName.Text;
                user.PersonInfo.LastName = txtLastName.Text;

                if (rdbMale.Checked)
                {
                    user.PersonInfo.Gender = 1;
                }
                else
                {
                    user.PersonInfo.Gender = 0;
                }

                user.PersonInfo.DateOfBirth = dateTimePicker1.Value.Date;
                user.PersonInfo.Phone = txtPhone.Text;
                user.PersonInfo.Email = txtEmail.Text;
                user.PersonInfo.Address = txtAddress.Text;

                user.Username = txtUsername.Text;
                user.PasswordHash = clsPasswordHasher.HashPassword(txtPassword.Text);
                user.RoleID = (int)cmbRoles.SelectedValue;

                if (user.Save())
                {
                    MessageBox.Show($"User Has Been Added With UserId Of {user.UserID}");
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

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                error.SetError(txtFirstName, "First Name Is Mandatory");
            }
            else
            {
                error.SetError(txtFirstName, "");
            }
        }
    }
}
