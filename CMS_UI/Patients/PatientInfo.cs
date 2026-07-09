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

namespace CMS_UI.Patients
{
    public partial class PatientInfo : Form
    {
        private int _PatientID;
        private clsPatient _Patient;
        public PatientInfo(int patientId)
        {
            InitializeComponent();
            _PatientID = patientId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddEditPatient frm = new AddEditPatient(_PatientID);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }

        private void Reload()
        {
            _Patient = clsPatient.Find(_PatientID);

            if (_Patient == null)
            {
                MessageBox.Show($"There Is No Patient With ID: {_PatientID}");
                return;
            }
            ctrlPersonCard1.LoadPersonData(_Patient.PersonID);
            lblPatientID.Text = _Patient.PatientID.ToString();
            lblPersonID.Text = _Patient.PersonID.ToString();
            lblInsuranceCompanyName.Text = string.IsNullOrWhiteSpace(_Patient.InsuranceCompanyName) ? "N/A" : _Patient.InsuranceCompanyName;
            lblInsuranceCompanyID.Text = string.IsNullOrWhiteSpace(_Patient.InsuranceCompanyID.ToString()) ? "N/A" : _Patient.InsuranceCompanyID.ToString();
            lblEmergencyContactPhone.Text = _Patient.EmergencyContactPhone;
            lblBloodType.Text = _Patient.BloodType;
        }

        private void PatientInfo_Load(object sender, EventArgs e)
        {
            
            Reload();
        }
    }
}
