using CMS_UI.Appointments;
using CMS_UI.Doctors;
using CMS_UI.Global;
using CMS_UI.InsuranceCompanies;
using CMS_UI.Invoices;
using CMS_UI.Patients;
using CMS_UI.Specialties;
using CMS_UI.Users;
using CMS_UI.Visits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CMSLogic.clsRole;

namespace CMS_UI
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        
        
        public void ReLoadForm()
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToShortTimeString();
            lblUsername.Text = clsCurrentUser.CurrentUser.Username;
            lblRoleName.Text = clsCurrentUser.CurrentUser.UserRole.RoleName;
        }

        private enum enRoles { Admin = 1, Receptionist = 2, Doctor = 3 }
        private void ApplyUserPermissions()
        {
            enRoles currentRole = (enRoles)clsCurrentUser.CurrentUser.RoleID;
            if (currentRole == enRoles.Admin)
            {
                return;
            }
            if (currentRole == enRoles.Receptionist)
            {
                btnUsers.Enabled = false;
                btnDoctors.Enabled = false;
                btnSettings.Enabled = false;
                btnReports.Enabled = false;
                btnVisits.Enabled = false;
                btnDepartments.Enabled = false;

                btnDepartments.Visible = false;
                btnUsers.Visible = false;
                btnDoctors.Visible = false;
                btnSettings.Visible = false;
                btnReports.Visible = false;
                btnVisits.Visible = false;
            }

            else if (currentRole == enRoles.Doctor)
            {
                btnUsers.Enabled = false;
                btnDoctors.Enabled = false;
                btnInvoices.Enabled = false;
                btnSettings.Enabled = false;
                btnReports.Enabled = false;
                btnInsuranceCompanies.Enabled = false;
                btnDepartments.Enabled = false;

                btnDepartments.Visible = false;

                btnUsers.Visible = false;
                btnDoctors.Visible = false;
                btnInvoices.Visible = false;
                btnSettings.Visible = false;
                btnReports.Visible = false;
                btnInsuranceCompanies.Visible = false;
            }
        }
        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            ReLoadForm();

            ApplyUserPermissions();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ManageUsers frm = new ManageUsers();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            ReLoadForm();
        }

        private void btnInsuranceCompanies_Click(object sender, EventArgs e)
        {
            ManageInsuraanceCompanies frm = new ManageInsuraanceCompanies();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            ReLoadForm();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            ManagePatients frm = new ManagePatients();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            ReLoadForm();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            ManageSpecialties frm = new ManageSpecialties();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            ReLoadForm();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            ManageDoctors frm = new ManageDoctors();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            ReLoadForm();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            ManageAppointments frm = new ManageAppointments();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            ReLoadForm();
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            ManageInvoices frm = new ManageInvoices();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            ReLoadForm();
        }

        private void btnVisits_Click(object sender, EventArgs e)
        {
            ManageVisits frm = new ManageVisits();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            ReLoadForm();
        }
    }
}
