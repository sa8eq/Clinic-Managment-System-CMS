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

namespace CMS_UI.Appointments
{
    public partial class AppoitnmentDetails : Form
    {
        private int _AppointmentID;
        public AppoitnmentDetails(int appID)
        {
            InitializeComponent();
            _AppointmentID = appID;
        }

        private void AppoitnmentDetails_Load(object sender, EventArgs e)
        {
            clsAppointment app = clsAppointment.Find(_AppointmentID);

            if(app==null)
            {
                MessageBox.Show($"There Is No Appointment Found With This ID: {_AppointmentID}");
                this.Close();
                return;
            }
            clsDoctor doc = clsDoctor.Find(app.DoctorID);
            clsPatient pat = clsPatient.Find(app.PatientID);

            lblBloodType.Text = pat.BloodType;
            lblPatientContactNumber.Text = pat.PersonInfo.Phone;
            lblPatientID.Text = pat.PatientID.ToString();
            lblPatientName.Text = pat.PersonInfo.FullName;
            lblInsurancePolicyNumber.Text = pat.InsuranceCompanyInfo != null ? pat.InsurancePolicyNumber : "N/A";
            lblEmergecyContact.Text = pat.EmergencyContactPhone;

            lblDoctorID.Text = doc.DoctorID.ToString();
            lblDepartment.Text = doc.DoctorSpecialty.SpecialtyName;
            lblDoctorName.Text = doc.PersonInfo.FullName;
            lblDoctorContactNumber.Text = doc.PersonInfo.Phone;
            lblLicenseNumber.Text = doc.LicenseNumber;

            lblAppointmentID.Text = app.AppointmentID.ToString();
            lblServiceName.Text = app.SelectedServiceInfo.ServiceName;
            lblAppointmentDate.Text = app.AppointmentDate.ToString();
            lblStatus.Text = app.Status.ToString();

            clsInvoice inv = clsInvoice.FindInvoiceByAppointmentID(app.AppointmentID);

            if(inv==null) { return; }

            lblInvoiceID.Text = inv.InvoiceID.ToString();
            lblInvoiceDate.Text = inv.InvoiceDate.ToShortDateString();
            lblTotalAmount.Text = inv.TotalAmount.ToString();
            lblInsuranceCoverage.Text = inv.InsuranceCoverAmount.ToString();
            lblPatientShare.Text = inv.PatientShareAmount.ToString();
            lblPaymentStatus.Text = inv.PaymentStatus;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
