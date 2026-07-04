using CMS_UI.Users;
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

namespace CMS_UI.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        private int _UserID;
        private clsUser _User;
        public ctrlUserCard()
        {
            InitializeComponent();
        }
        public void LoadUserInfo(int userid)
        {
            _UserID = userid;
            _User = clsUser.Find(_UserID);
            if(_User == null)
            {
                MessageBox.Show($"User With ID {_UserID} Was Not Found!");
                return;
            }

            lblIsActive.Text = _User.IsActive ? "Yes" : "No";
            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.Username;
            lblRole.Text = _User.UserRole.RoleName;

            ctrlPersonCard1.LoadPersonData(_User.PersonID);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddEditUser frm = new AddEditUser(_User.UserID);
            frm.ShowDialog();
        }
    }
}
