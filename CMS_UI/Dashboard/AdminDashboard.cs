using CMS_UI.Global;
using CMS_UI.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            ReLoadForm();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ManageUsers frm = new ManageUsers();
            frm.ShowDialog();
            ReLoadForm();
        }
    }
}
