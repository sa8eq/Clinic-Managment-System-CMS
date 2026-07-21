using CMSLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS_UI.Invoices
{
    public partial class ManageInvoices : Form
    {
        public ManageInvoices()
        {
            InitializeComponent();
        }
        public ManageInvoices(int patientID)
        {
            InitializeComponent();
            _PatientID = patientID;
        }
        private int _PatientID = -1;
        private DataTable _dtInvoices;
        private DataTable _dtInvoiceDetails;
        private clsInvoice _SelectedInvoice;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadInfo()
        {

            _dtInvoices = clsInvoice.GetAllInvoices();
            _dtInvoiceDetails = clsInvoiceDetails.GetAllInvoicesDetails();
            if (_dtInvoices.Rows.Count>0)
            {
                dgvInvoices.DataSource = _dtInvoices;

                dgvInvoices.Columns["AppointmentID"].Visible = false;
                dgvInvoices.Columns["VisitID"].Visible = false;
                dgvInvoices.Columns["TotalAmount"].Visible = false;
                dgvInvoices.Columns["InsuranceCoveredAmount"].Visible = false;
                dgvInvoices.Columns["PatientShareAmount"].Visible = false;


                dgvInvoices.Columns["InvoiceID"].HeaderText = "Invoice ID";
                dgvInvoices.Columns["InvoiceDate"].HeaderText = "Date";
                dgvInvoices.Columns["InvoiceDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvInvoices.Columns["PatientID"].HeaderText = "Patient ID";
                dgvInvoices.Columns["PatientName"].HeaderText = "Patient Name";
                dgvInvoices.Columns["PaymentStatus"].HeaderText = "Payment Status";

                dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            

            cmbFilter.SelectedItem = "None";
            txtFilter.Enabled = false;
        }
        private void ManageInvoices_Load(object sender, EventArgs e)
        {
            LoadInfo();

            if(_PatientID!=-1)
            {
                cmbFilter.SelectedItem = "Patient ID";
                txtFilter.Text = _PatientID.ToString();

                txtFilter.Enabled = false;
                cmbFilter.Enabled = false;
            }

        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblInvoiceID.Text = _SelectedInvoice.InvoiceID.ToString();
            lblVisitID.Text = _SelectedInvoice.VisitID == null? "###" : _SelectedInvoice.VisitID.ToString();
            lblAppointmentID.Text = _SelectedInvoice.AppointmentID.ToString();
            lblInvoiceDate.Text = _SelectedInvoice.InvoiceDate.ToShortDateString();
            lblTotalAmount.Text = _SelectedInvoice.TotalAmount.ToString("0.00");
            lblInsuranceCoveredAmount.Text = _SelectedInvoice.InsuranceCoverAmount.ToString("0.00");
            lblPatientShareAmount.Text = _SelectedInvoice.PatientShareAmount.ToString("0.00");
            lblPaymentStatus.Text = _SelectedInvoice.PaymentStatus;
            string filtetcolumn = "InvoiceID";
            string filter = _SelectedInvoice.InvoiceID.ToString();
            _dtInvoiceDetails.DefaultView.RowFilter = $"{filtetcolumn} = {filter}";

            if (_dtInvoiceDetails.Rows.Count > 0)
            {
                dgvInvoiceDetails.DataSource = _dtInvoiceDetails;

                dgvInvoiceDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void cmsInvoices_Opening(object sender, CancelEventArgs e)
        {
            if (dgvInvoices.CurrentRow == null || dgvInvoices.Rows.Count == 0)
            {
                MessageBox.Show("Choose An Invoice To Show Its Details");
                return;
            }
            int invID = Convert.ToInt32(dgvInvoices.CurrentRow.Cells["InvoiceID"].Value);

            _SelectedInvoice = clsInvoice.Find(invID);

            if (_SelectedInvoice == null)
            {
                MessageBox.Show($"There is no invoice found with this ID: {invID}");
                return;
            }

            if(_SelectedInvoice.PaymentStatus != "Paid")
            {
                markAsPaidToolStripMenuItem.Enabled = true;
            }
            else
            {
                markAsPaidToolStripMenuItem.Enabled = false;
            }
        }
        private void markAsPaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Change This Invoice Payment Status To 'Paid' ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(_SelectedInvoice.UpdatePaymentStatus("Paid"))
                {
                    MessageBox.Show("Invoice Has Been Successfully Paid");
                }
            }
            LoadInfo();
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtInvoices.DefaultView.RowFilter = "";
            if (cmbFilter.SelectedItem=="None")
            {
                txtFilter.Enabled = false;
                txtFilter.Visible = false;
            }
            else
            {
                txtFilter.Enabled = true;
                txtFilter.Visible = true;
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filterColumn = "";

            switch (cmbFilter.SelectedItem?.ToString())
            {
                case "Invoice ID":
                    filterColumn = "InvoiceID";
                    break;
                case "Patient ID":
                    filterColumn = "PatientID";
                    break;
                case "Patient Name":
                    filterColumn = "PatientName";
                    break;
                default:
                    filterColumn = "";
                    break;
            }

            string filterValue = txtFilter.Text.Trim();

            if (string.IsNullOrWhiteSpace(filterValue) || string.IsNullOrEmpty(filterColumn))
            {
                _dtInvoices.DefaultView.RowFilter = "";
                return;
            }

            if (filterColumn == "InvoiceID" || filterColumn == "PatientID")
            {
                if (int.TryParse(filterValue, out int id))
                {
                    _dtInvoices.DefaultView.RowFilter = $"{filterColumn} = {id}";
                }
                else
                {
                    _dtInvoices.DefaultView.RowFilter = "0 = 1"; 
                }
            }
            else 
            {
                _dtInvoices.DefaultView.RowFilter = $"{filterColumn} LIKE '%{filterValue}%'";
            }
        }
    }
}
