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

namespace CMS_UI.Specialties
{
    public partial class SpecialtyInfo : Form
    {
        private int _SpecialtyID;
        private clsSpecialty _Specialty;
        public SpecialtyInfo(int specialtyID)
        {
            InitializeComponent();
            _SpecialtyID = specialtyID;
        }

        private void SpecialtyInfo_Load(object sender, EventArgs e)
        {
            _Specialty = clsSpecialty.Find(_SpecialtyID);
            if(_Specialty==null)
            {
                MessageBox.Show($"There Is No Specialty With This ID: {_SpecialtyID}");
                this.Close();
                return;
            }

            lblID.Text = _Specialty.SpecialtyID.ToString();
            lblName.Text = _Specialty.SpecialtyName;
            lblDescription.Text = _Specialty.Description;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
