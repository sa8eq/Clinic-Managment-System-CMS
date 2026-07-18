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

namespace CMS_UI.Invoices
{
    public partial class Invoice : Form
    {
        private clsAppointment _Appointment;

        public Invoice(clsAppointment app)
        {
            InitializeComponent();
            _Appointment = app;
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            if (_Appointment == null) return;

            lblInvoiceID.Text = "##";
            lblPatientName.Text = _Appointment.PatientInfo.FullName;
            lblDoctorName.Text = _Appointment.DoctorInfo.PersonInfo.FullName;
            lblAppointmentDate.Text = _Appointment.AppointmentDate.ToString("dd/MM/yyyy - hh:mm tt");
            lblDepartment.Text = _Appointment.DoctorInfo.DoctorSpecialty.SpecialtyName;

            decimal price = _Appointment.SelectedServiceInfo.Price;
            decimal discountAmount = 0;

            if (_Appointment.PatientInfo.InsuranceCompanyID != null && _Appointment.PatientInfo.InsuranceCompanyInfo != null)
            {
                decimal percentage = _Appointment.PatientInfo.InsuranceCompanyInfo.CoveragePercentage;

                discountAmount = (price * percentage) / 100;
            }

            decimal total = price - discountAmount;

            lblMedicalService.Text = _Appointment.SelectedServiceInfo.ServiceName;
            lblServicePrice.Text = price.ToString("C");
            lblDiscount.Text = discountAmount.ToString("C"); 
            lblTotalAmount.Text = total.ToString("C");       

            lblPaymentStatus.Text = "Pending";
            rdbPayNow.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}