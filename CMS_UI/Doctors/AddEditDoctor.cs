using CMS_UI.Global;
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

namespace CMS_UI.Doctors
{
    public partial class AddEditDoctor : Form
    {
        private enum enMode { AddNew, Edit }
        private enMode _Mode;
        private int _DoctorID;
        private clsDoctor _Doctor;
        public AddEditDoctor()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public AddEditDoctor(int doctorID)
        {
            InitializeComponent();
            _DoctorID = doctorID;
            _Mode = enMode.Edit;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillCMBs()
        {
            DataTable rolesdt, specialtiesdt;
            rolesdt = clsRole.GetAllRoles();
            specialtiesdt = clsSpecialty.GetAllSpecialties();

            cmbRoles.DataSource = rolesdt;
            cmbSpecialty.DataSource = specialtiesdt;

            cmbRoles.DisplayMember = "RoleName";
            cmbSpecialty.DisplayMember = "SpecialtyName";
            

            cmbRoles.ValueMember = "RoleID";
            cmbSpecialty.ValueMember = "SpecialtyID";

            cmbRoles.SelectedValue = 3;
            cmbRoles.Enabled = false;
        }

        private void Reload()
        {
            FillCMBs();

            
        }

        private void AddEditDoctor_Load(object sender, EventArgs e)
        {
            Reload();
            if (_Mode==enMode.Edit)
            {
                label1.Text = "Edit Doctor Information";
                _Doctor = clsDoctor.Find(_DoctorID);
                if(_Doctor==null)
                {
                    MessageBox.Show($"There Is No Doctor Found With ID: {_DoctorID}");
                    this.Close();
                    return;
                }
                lblDoctorID.Text = _Doctor.DoctorID.ToString();
                lblUserID.Text = _Doctor.UserInfo.UserID.ToString();
                lblPersonID.Text = _Doctor.PersonID.ToString();
                lblNote.Visible = true;
                ctrlPerson1.LoadPerson(_Doctor.PersonInfo);
                txtUsername.Text = _Doctor.UserInfo.Username;
                cmbRoles.SelectedValue = _Doctor.UserInfo.RoleID;
                if(_Doctor.UserInfo.IsActive)
                {
                    rdbYes.Checked = true;
                }
                else
                {
                    rdbNo.Checked = true;
                }
                cmbSpecialty.SelectedValue = _Doctor.DoctorSpecialty.SpecialtyID;
                txtLicenseNumber.Text = _Doctor.LicenseNumber;
                if(_Doctor.IsActive)
                {
                    rdbAppointmentsAvalible.Checked = true;
                }
                else
                {
                    rdbAppoitnmentsNotAvalible.Checked = true;
                }
            }
        }

        private void Lock()
        {
            ctrlPerson1.Enabled = false;
            txtLicenseNumber.Enabled = false;
            txtPassword.Enabled = false;
            txtUsername.Enabled = false;
            rdbAppointmentsAvalible.Enabled = false;
            rdbAppoitnmentsNotAvalible.Enabled = false;
            rdbNo.Enabled = false;
            rdbYes.Enabled = false;
            cmbRoles.Enabled = false;
            cmbSpecialty.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren() || !ctrlPerson1.ValidateChildren())
            {
                MessageBox.Show($"Make sure all mandatory fields are correctly filled, hover over the error mark to know to to fic the error");
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                _Doctor = new clsDoctor();
            }
            ctrlPerson1.FillPerson(_Doctor.PersonInfo);

            _Doctor.UserInfo.Username = txtUsername.Text;
            if (_Mode == enMode.AddNew)
            {
                _Doctor.UserInfo.PasswordHash = clsPasswordHasher.HashPassword(txtPassword.Text);
            }
            else if (_Mode == enMode.Edit && !string.IsNullOrEmpty(txtPassword.Text))
            {
                _Doctor.UserInfo.PasswordHash = clsPasswordHasher.HashPassword(txtPassword.Text);
            }
            _Doctor.UserInfo.RoleID = Convert.ToInt32(cmbRoles.SelectedValue);
            if(rdbYes.Checked)
            {
                _Doctor.UserInfo.IsActive = true;
            }
            else
            {
                _Doctor.UserInfo.IsActive = false;
            }

            _Doctor.HireDate = DateTime.Now;
            _Doctor.IsActive = rdbAppointmentsAvalible.Checked ? true : false;
            _Doctor.LicenseNumber = txtLicenseNumber.Text;
            _Doctor.SpecialtyID = Convert.ToInt32(cmbSpecialty.SelectedValue);

            if(_Doctor.Save())
            {
                MessageBox.Show(_Mode == enMode.AddNew? "Doctor Has Been Succesffuly Saved" : "Doctor Information Has Been Successfully Updated");
                _Mode = enMode.Edit;
                _DoctorID = _Doctor.DoctorID;
                lblDoctorID.Text = _Doctor.DoctorID.ToString();
                lblUserID.Text = _Doctor.UserInfo.UserID.ToString();
                lblPersonID.Text = _Doctor.PersonID.ToString();
                Lock();
                

            }
            else
            {
                MessageBox.Show("Failed Saving Doctor");
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
                if (txtUsername.Text != _Doctor.UserInfo.Username && clsUser.ExistsByUsername(txtUsername.Text))
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
                error.SetError(txtPassword, "");
            }
        }

        private void txtLicenseNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLicenseNumber.Text))
            {
                e.Cancel = true;
                error.SetError(txtLicenseNumber, "License Number Is Mandatory");
                return;
            }
            if (_Mode == enMode.AddNew)
            {
                if (clsDoctor.ExistsByLicenseNumber(txtLicenseNumber.Text))
                {
                    e.Cancel = true;
                    error.SetError(txtLicenseNumber, "License Number Is Already Registered");
                    return;
                }
            }
            else
            {
                if (txtLicenseNumber.Text != _Doctor.LicenseNumber && clsDoctor.ExistsByLicenseNumber(txtLicenseNumber.Text))
                {
                    e.Cancel = true;
                    error.SetError(txtLicenseNumber, "License Number Is Already Registered");
                    return;
                }
            }

            e.Cancel = false;
            error.SetError(txtLicenseNumber, "");
        }
    }
}
