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

namespace CMS_UI
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.FindByUsername(txtUsername.Text);

            if(user==null)
            {
                MessageBox.Show($"There Is No User With This Username: {txtUsername.Text}");
                return;
            }

            if(!user.IsActive)
            {
                MessageBox.Show($"This Username: {txtUsername.Text} Has Been DeActivated. Contact You Adminestrator");
                return;
            }

            if(!clsPasswordHasher.VerifyPassword(txtPassword.Text, user.PasswordHash))
            {
                MessageBox.Show($"There Is No User With This Username: {txtUsername.Text}");
                return;
            }

            if(chxRememberMe.Checked)
            {
                clsRegistry.SaveCredentialsToRegistry(txtUsername.Text, txtPassword.Text);
            }
            else
            {
                clsRegistry.ClearCredentialsFromRegistry();
                txtPassword.Text = "";
                txtUsername.Text = "";
            }

            clsCurrentUser.CurrentUser = user;
            //MessageBox.Show($"الرقم المخزن في السيستم: {clsCurrentUser.CurrentUser.RoleID}\nاسم الدور الحقيقي: {clsCurrentUser.CurrentUser.UserRole.RoleName}");

            AdminDashboard frm = new AdminDashboard();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> credentials = clsRegistry.GetCredentialFromRegistry();

            if (credentials.Count > 0 && credentials.ContainsKey("Username") && !string.IsNullOrEmpty(credentials["Username"]))
            {
                txtUsername.Text = credentials["Username"];
                txtPassword.Text = credentials["Password"];
                chxRememberMe.Checked = true; 
            }
        }
    }
}
