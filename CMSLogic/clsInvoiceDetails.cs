using CMSData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLogic
{
    public class clsInvoiceDetails
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int InvoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public int ServiceID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal LineTotal
        {
            get { return Quantity * Price; }
        }

        public clsInvoiceDetails()
        {
            this.InvoiceDetailID = -1;
            this.InvoiceID = -1;
            this.ServiceID = -1;
            this.Quantity = 1; 
            this.Price = 0;

            Mode = enMode.AddNew;
        }

        // مشيد التحديث والـ Find
        private clsInvoiceDetails(int invoiceDetailID, int invoiceID, int serviceID, int quantity, decimal price)
        {
            this.InvoiceDetailID = invoiceDetailID;
            this.InvoiceID = invoiceID;
            this.ServiceID = serviceID;
            this.Quantity = quantity;
            this.Price = price;

            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.InvoiceDetailID = clsInvoiceDetailsData.AddNewInvoiceDetail(
                this.InvoiceID,
                this.ServiceID,
                this.Quantity,
                this.Price
            );

            return (this.InvoiceDetailID != -1);
        }

        private bool _Update()
        {
            return clsInvoiceDetailsData.UpdateInvoiceDetail(
                this.InvoiceDetailID,
                this.InvoiceID,
                this.ServiceID,
                this.Quantity,
                this.Price
            );
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

        public static DataTable GetInvoiceDetailsByInvoiceID(int invoiceID)
        {
            return clsInvoiceDetailsData.GetInvoiceDetailsByInvoiceID(invoiceID);
        }

        public static bool DeleteInvoiceDetail(int invoiceDetailID)
        {
            return clsInvoiceDetailsData.DeleteInvoiceDetail(invoiceDetailID);
        }
    }
}

