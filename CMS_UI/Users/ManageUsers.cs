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
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReloadForm()
        {

        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            ReloadForm();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            AddEditUser frm = new AddEditUser();
            frm.ShowDialog();
            ReloadForm();
        }
    }
}
