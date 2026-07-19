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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CMS_UI.Invoices
{
    public partial class Invoice : Form
    {
        private clsAppointment _Appointment;
        private clsInvoice _Invoice;
        public Invoice(clsAppointment app)
        {
            InitializeComponent();
            _Appointment = app;
        }





        private void Invoice_Load(object sender, EventArgs e)
        {
            if (_Appointment == null) return;

            _Invoice = clsInvoice.FindInvoiceByAppointmentID(_Appointment.AppointmentID);

            if (_Invoice == null)
            {
                _Invoice = new clsInvoice(_Appointment);
                lblInvoiceID.Text = "##";
                lblPaymentStatus.Text = "Pending";
                rdbPayNow.Checked = true;
                rdbPayNow.Enabled = true;
                rdbPayLater.Enabled = true;
            }
            else
            {
                lblInvoiceID.Text = _Invoice.InvoiceID.ToString();
                lblPaymentStatus.Text = _Invoice.PaymentStatus;

                if (string.Equals(_Invoice.PaymentStatus, "Paid", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(_Invoice.PaymentStatus, "Partially_Paid", StringComparison.OrdinalIgnoreCase))
                {
                    rdbPayNow.Checked = true;
                    rdbPayNow.Enabled = false;
                    rdbPayLater.Enabled = false;
                }
                else
                {
                    rdbPayNow.Enabled = true;
                    rdbPayLater.Enabled = true;

                    if (string.Equals(_Invoice.PaymentStatus, "Unpaid", StringComparison.OrdinalIgnoreCase))
                        rdbPayLater.Checked = true;
                    else
                        rdbPayNow.Checked = true;
                }
            }

            lblPatientName.Text = _Appointment.PatientInfo.FullName;
            lblDoctorName.Text = _Appointment.DoctorInfo.PersonInfo.FullName;
            lblAppointmentDate.Text = _Appointment.AppointmentDate.ToString("dd/MM/yyyy - hh:mm tt");
            lblDepartment.Text = _Appointment.DoctorInfo.DoctorSpecialty.SpecialtyName;
            lblMedicalService.Text = _Appointment.SelectedServiceInfo.ServiceName;

            decimal price = _Appointment.SelectedServiceInfo.Price;
            decimal discountAmount = 0;

            if (_Appointment.PatientInfo.InsuranceCompanyID != null && _Appointment.PatientInfo.InsuranceCompanyInfo != null)
            {
                decimal percentage = _Appointment.PatientInfo.InsuranceCompanyInfo.CoveragePercentage;
                discountAmount = (price * percentage) / 100;
            }

            decimal total = price - discountAmount;
            lblServicePrice.Text = price.ToString("C");
            lblDiscount.Text = discountAmount.ToString("C");
            lblTotalAmount.Text = total.ToString("C");


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Invoice == null) return;

            decimal price = _Appointment.SelectedServiceInfo.Price;
            decimal discountPercentage = (_Appointment.PatientInfo.InsuranceCompanyInfo?.CoveragePercentage) ?? 0;

            _Invoice.TotalAmount = price;
            _Invoice.InsuranceCoverAmount = (price * discountPercentage) / 100;
            _Invoice.PatientShareAmount = _Invoice.TotalAmount - _Invoice.InsuranceCoverAmount;

            if (_Invoice.InsuranceCoverAmount > 0)
            {
                _Invoice.PaymentStatus = "Partially_Paid";
            }
            else if (rdbPayLater.Checked)
            {
                _Invoice.PaymentStatus = "Unpaid";
            }
            else if (rdbPayNow.Checked)
            {
                _Invoice.PaymentStatus = "Paid";
            }

            _Invoice.InvoiceDetailsList.Clear();
            clsInvoiceDetails newDetail = new clsInvoiceDetails();
            newDetail.ServiceID = _Appointment.SelectedServiceID;
            newDetail.Price = price;
            newDetail.Quantity = 1;
            _Invoice.InvoiceDetailsList.Add(newDetail);

            if (_Invoice.Save())
            {
                MessageBox.Show("Appointment Saved. Invoice Issued Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed Saving Invoice", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}