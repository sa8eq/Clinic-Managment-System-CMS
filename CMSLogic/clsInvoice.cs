using CMSData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLogic
{
    public class clsInvoice
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int InvoiceID { get; set; }
        public int? VisitID { get; set; }
        public int? AppointmentID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal InsuranceCoverAmount { get; set; }
        public decimal PatientShareAmount { get; set; }
        public string PaymentStatus { get; set; }

        public DataTable InvoiceDetailsList { get; set; }

        public clsInvoice()
        {
            this.InvoiceID = -1;
            this.VisitID = null;
            this.AppointmentID = null;
            this.InvoiceDate = DateTime.Now;
            this.TotalAmount = 0;
            this.InsuranceCoverAmount = 0;
            this.PatientShareAmount = 0;
            this.PaymentStatus = "";

            this.InvoiceDetailsList = new DataTable();

            Mode = enMode.AddNew;
        }

        private clsInvoice(int invoiceID, int? visitID, int? appointmentID, DateTime invoiceDate,
            decimal totalAmount, decimal insuranceCoverAmount, decimal patientShareAmount, string paymentStatus)
        {
            this.InvoiceID = invoiceID;
            this.VisitID = visitID;
            this.AppointmentID = appointmentID;
            this.InvoiceDate = invoiceDate;
            this.TotalAmount = totalAmount;
            this.InsuranceCoverAmount = insuranceCoverAmount;
            this.PatientShareAmount = patientShareAmount;
            this.PaymentStatus = paymentStatus;

            this.InvoiceDetailsList = clsInvoiceDetails.GetInvoiceDetailsByInvoiceID(invoiceID);

            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.InvoiceID = clsInvoicesData.AddNewInvoice(
                this.VisitID,
                this.AppointmentID,
                this.InvoiceDate,
                this.TotalAmount,
                this.InsuranceCoverAmount,
                this.PatientShareAmount,
                this.PaymentStatus
            );

            return (this.InvoiceID != -1);
        }

        private bool _Update()
        {
            return clsInvoicesData.UpdateInvoice(
                this.InvoiceID,
                this.VisitID,
                this.AppointmentID,
                this.InvoiceDate,
                this.TotalAmount,
                this.InsuranceCoverAmount,
                this.PatientShareAmount,
                this.PaymentStatus
            );
        }

        public static clsInvoice Find(int invoiceID)
        {
            int? visitID = null;
            int? appointmentID = null;
            DateTime invoiceDate = DateTime.Now;
            decimal totalAmount = 0;
            decimal insuranceCoverAmount = 0;
            decimal patientShareAmount = 0;
            string paymentStatus = "";

            bool isFound = clsInvoicesData.GetInvoiceByID(
                invoiceID,
                ref visitID,
                ref appointmentID,
                ref invoiceDate,
                ref totalAmount,
                ref insuranceCoverAmount,
                ref patientShareAmount,
                ref paymentStatus
            );

            if (isFound)
            {
                return new clsInvoice(invoiceID, visitID, appointmentID, invoiceDate, totalAmount, insuranceCoverAmount, patientShareAmount, paymentStatus);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static DataTable GetAllInvoices()
        {
            return clsInvoicesData.GetAllInvoices();
        }

        public static bool DeleteInvoice(int invoiceID)
        {
            return clsInvoicesData.DeleteInvoice(invoiceID);
        }

        public static clsInvoice FindInvoiceByAppointmentID(int appointmentID)
        {
            int invoiceID = -1;
            int? visitID = null;
            DateTime invoiceDate = DateTime.Now;
            decimal totalAmount = 0;
            decimal insuranceCoverAmount = 0;
            decimal patientShareAmount = 0;
            string paymentStatus = "";

            bool isFound = clsInvoicesData.GetInvoiceByAppointmentID(
                appointmentID, ref invoiceID, ref visitID, ref invoiceDate, ref totalAmount, ref insuranceCoverAmount, ref patientShareAmount, ref paymentStatus);

            if (isFound)
            {
                return new clsInvoice(invoiceID, visitID, appointmentID, invoiceDate, totalAmount, insuranceCoverAmount, patientShareAmount, paymentStatus);
            }
            return null;
        }
    }
}