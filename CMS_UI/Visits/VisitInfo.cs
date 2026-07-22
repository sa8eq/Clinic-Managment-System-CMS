using CMSLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS_UI.Visits
{
    public partial class VisitInfo : Form
    {
        private int _VisitID;
        private clsVisit vis;
        public VisitInfo(int visitID)
        {
            InitializeComponent();
            _VisitID = visitID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VisitInfo_Load(object sender, EventArgs e)
        {
            vis = clsVisit.Find(_VisitID);

            if (vis == null)
            {
                MessageBox.Show($"There Is No Visit To Show Its Info With This ID: {_VisitID}");
                this.Close();
                return;
            }
            lblVisitID.Text = vis.VisitID.ToString();
            lblAppointmentID.Text = vis.AppointmentInfo.AppointmentID.ToString();
            lblVisitDate.Text = vis.VisitDate.ToShortDateString();

            lblSymptoms.Text = vis.Symptoms;
            lblDiagnosis.Text = vis.Diagnosis;

            lblBP.Text = vis.VitalSigns_BP;
            lblPulse.Text = vis.VitalSigns_Pulse.ToString();
            lblTemp.Text = vis.VitalSigns_Temp.ToString();

            lblPatientID.Text = vis.AppointmentInfo.PatientID.ToString();
            lblPatientContactNumber.Text = vis.AppointmentInfo.PatientInfo.PersonInfo.Phone;
            lblPatientName.Text = vis.AppointmentInfo.PatientInfo.FullName;
            lblAge.Text = (DateTime.Now.Year - vis.AppointmentInfo.PatientInfo.PersonInfo.DateOfBirth.Year).ToString();
            lblBloodType.Text = vis.AppointmentInfo.PatientInfo.BloodType;

            lblDoctorID.Text = vis.AppointmentInfo.DoctorID.ToString();
            lblDoctorName.Text = vis.AppointmentInfo.DoctorInfo.PersonInfo.FullName;
            lblDoctorContactNumber.Text = vis.AppointmentInfo.DoctorInfo.PersonInfo.Phone;
            lblLicenseNumber.Text = vis.AppointmentInfo.DoctorInfo.LicenseNumber;
            lblSpecialty.Text = vis.AppointmentInfo.DoctorInfo.DoctorSpecialty.SpecialtyName;
        }
    }
}
