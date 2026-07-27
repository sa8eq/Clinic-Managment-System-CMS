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

namespace CMS_UI
{
    public partial class PrescriptionInfo : Form
    {
        int _VisitID;
        clsVisit _Visit;
        public PrescriptionInfo(int visid)
        {
            InitializeComponent();
            _VisitID = visid;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadData()
        {
            dgvMeds.Visible = false;
            dgvServices.Visible = false;

            lblVisitDate.Text = _Visit.AppointmentInfo.AppointmentDate.ToShortDateString();
            lblVisitID.Text = _Visit.VisitID.ToString();
            lblDoctorName.Text = _Visit.AppointmentInfo.DoctorInfo.PersonInfo.FullName;
            lblPatientName.Text = _Visit.AppointmentInfo.PatientInfo.FullName;

            clsPrescription pre = clsPrescription.FindByVisitID(_Visit.VisitID);
            if (pre != null)
            {
                lblPrescriptionID.Text = pre.PrescriptionID.ToString();
                if (pre.PrescriptionDetails.Count > 0)
                {
                    dgvMeds.Visible = true;
                    dgvMeds.DataSource = pre.PrescriptionDetails;
                    dgvMeds.Columns["MedicineID"].Visible = false;
                    dgvMeds.Columns["PrescriptionID"].Visible = false;
                    dgvMeds.Columns["PrescriptionDetailID"].Visible = false;
                    dgvMeds.Columns["MedicineInfo"].Visible = false;

                    dgvMeds.Columns["MedicineName"].HeaderText = "Medicine Name";

                    dgvMeds.Columns["MedicineName"].Width = 260;
                    dgvMeds.Columns["Dosage"].Width = 78;
                    dgvMeds.Columns["Duration"].Width = 78;
                }
            }

            clsInvoice inv = clsInvoice.FindInvoiceByAppointmentID(_Visit.AppointmentID);
            if (inv != null)
            {
                if(inv.InvoiceDetailsList.Count > 0)
                {
                    dgvServices.Visible = true;
                    dgvServices.DataSource = inv.InvoiceDetailsList;

                    dgvServices.Columns["InvoiceDetailID"].Visible = false;
                    dgvServices.Columns["InvoiceID"].Visible = false;
                    dgvServices.Columns["ServiceID"].Visible = false;
                    dgvServices.Columns["Price"].Visible = false;

                    dgvServices.Columns["ServiceName"].HeaderText = "Service Name";
                    dgvServices.Columns["ServiceName"].Width = 290;

                    dgvServices.Columns["Quantity"].HeaderText = "Qty";
                    dgvServices.Columns["Quantity"].Width = 60;

                    dgvServices.Columns["LineTotal"].HeaderText = "Total";
                    dgvServices.Columns["LineTotal"].Width = 60;
                }
            }
            
        }
        private void PrescriptionInfo_Load(object sender, EventArgs e)
        {
            _Visit = clsVisit.Find(_VisitID);

            if(_Visit==null)
            {
                MessageBox.Show($"There No Visit With The ID: {_VisitID}");
                this.Close();
                return;
            }

            LoadData();
        }
    }
}
