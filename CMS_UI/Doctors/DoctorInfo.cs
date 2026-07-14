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
    public partial class DoctorInfo : Form
    {
        private int _DoctorID;
        private clsDoctor _Doctor;
        public DoctorInfo(int doctorID)
        {
            InitializeComponent();
            _DoctorID = doctorID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reload()
        {
            _Doctor = clsDoctor.Find(_DoctorID);
            if(_Doctor==null)
            {
                MessageBox.Show($"There Is No Doctor With ID: {_DoctorID}");
                this.Close();
                return;
            }

            ctrlPersonCard1.LoadPersonData(_Doctor.PersonID);
            lblDoctorID.Text = _Doctor.DoctorID.ToString();
            lblHireDate.Text = _Doctor.HireDate.ToShortDateString();
            lblIsActive.Text = _Doctor.IsActive ? "Yes" : "No";
            lblLicenseNumber.Text = _Doctor.LicenseNumber;
            lblSpecialtyID.Text = _Doctor.SpecialtyID.ToString();
            lblSpecialtyName.Text = _Doctor.DoctorSpecialty.SpecialtyName;

        }

        private void DoctorInfo_Load(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
