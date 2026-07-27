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

namespace CMS_UI.Visits
{
    public partial class StartVisit : Form
    {
        private int _AppID;
        private DataTable _dtMeds;
        private DataTable _dtServices;
        private decimal _currentServiceUnitPrice = 0;
        private clsAppointment _App;
        private List<clsInvoiceDetails> _ServicesList;
        private List<clsPrescriptionDetails> _PrescriptionList;
        private clsInvoice _Inv;
        public StartVisit(int appid)
        {
            InitializeComponent();
            _AppID = appid;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ComboBoxesSetup()
        {
            _dtMeds = clsMedicine.GetAllMedicines();
            _dtServices = clsMedicalService.GetAllMedicalServices();

            if(_dtMeds.Rows.Count==0)
            {
                MessageBox.Show("Couldn't Retrieve Medication List Into the Combo Box");
                this.Close();
                return;
            }

            if (_dtServices.Rows.Count == 0)
            {
                MessageBox.Show("Couldn't Retrieve Medical Services List Into the Combo Box");
                this.Close();
                return;
            }
            cmbMeds.DataSource = _dtMeds;
            cmbServices.DataSource = _dtServices;

            cmbServices.DisplayMember = "ServiceName";
            cmbServices.ValueMember = "ServiceID";

            cmbMeds.ValueMember = "MedicineID";
            cmbMeds.DisplayMember = "MedicineName";
        }
        private void StartVisit_Load(object sender, EventArgs e)
        {
            _App = clsAppointment.Find(_AppID);

            if (_App == null)
            {
                MessageBox.Show($"There Is No Appointment With This ID: {_AppID}");
                this.Close();
                return;
            }
            ComboBoxesSetup();
            lblAppointmentID.Text = _App.AppointmentID.ToString();
            lblVisitDate.Text = DateTime.Now.ToShortDateString();

            _ServicesList = new List<clsInvoiceDetails>();
            _PrescriptionList = new List<clsPrescriptionDetails>();

            _Inv = clsInvoice.FindInvoiceByAppointmentID(_App.AppointmentID);
            if (_Inv == null)
            {
                MessageBox.Show("No invoice found for this appointment!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            nudQuantity.Minimum = 1;
        }
        private void dgvMedsSetup()
        {
            dgvMeds.DataSource = null;
            dgvMeds.DataSource = _PrescriptionList;

            if(_PrescriptionList.Count > 0)
            {
                dgvMeds.Columns["PrescriptionDetailID"].Visible = false;
                dgvMeds.Columns["PrescriptionID"].Visible = false;
                dgvMeds.Columns["MedicineID"].Visible = false;
                dgvMeds.Columns["MedicineInfo"].Visible = false;

                dgvMeds.Columns["MedicineName"].HeaderText = "Medicine Name";

                dgvMeds.Columns["MedicineName"].Width = 230;
                dgvMeds.Columns["Dosage"].Width = 85;
                dgvMeds.Columns["Duration"].Width = 85;


                dgvMeds.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
            }
        }
        private void btnAddMedication_Click(object sender, EventArgs e)
        {
            if (!ValidatePrescription())
            {
                MessageBox.Show("Some Fields In Prescription Tab Are Mandatory, Fill Them To Be Able To Save The Visit");
                return;
            }
            if(_PrescriptionList.Any(s=>s.MedicineID== Convert.ToInt32(cmbMeds.SelectedValue)))
            {
                MessageBox.Show("This Medication Is Already Added");
                return;
            }
            clsPrescriptionDetails pre = new clsPrescriptionDetails
            {
                MedicineID = Convert.ToInt32(cmbMeds.SelectedValue),
                Dosage = txtDosage.Text,
                Duration = txtDuration.Text
            };

            _PrescriptionList.Add(pre);

            txtDuration.Text = "";
            txtDosage.Text = "";
            dgvMedsSetup();
        }
        private void dgvServicesSetup()
        {
            dgvService.DataSource = null;
            dgvService.DataSource = _ServicesList;

            if(_ServicesList.Count>0)
            {
                dgvService.Columns["ServiceID"].Visible = false;
                dgvService.Columns["InvoiceDetailID"].Visible = false;
                dgvService.Columns["InvoiceID"].Visible = false;

                dgvService.Columns["ServiceName"].HeaderText = "Service Name";
                dgvService.Columns["Quantity"].HeaderText = "Qty";
                dgvService.Columns["Price"].HeaderText = "Price";
                dgvService.Columns["LineTotal"].HeaderText = "Total";

                dgvService.Columns["ServiceName"].Width = 220;
                dgvService.Columns["Quantity"].Width = 60;
                dgvService.Columns["Price"].Width = 60;
                dgvService.Columns["LineTotal"].Width = 60;
                dgvService.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
            }
        }
        private void btnAddService_Click(object sender, EventArgs e)
        {
            int serviceID = Convert.ToInt32(cmbServices.SelectedValue);

            if (_ServicesList.Any(s => s.ServiceID == serviceID))
            {
                MessageBox.Show("This service is already added!", "Duplicate",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsInvoiceDetails id = new clsInvoiceDetails
            {
                InvoiceID = _Inv.InvoiceID,
                Quantity = (int)nudQuantity.Value,
                ServiceID = serviceID,
                Price = Convert.ToDecimal(lblPrice.Text),
            };
            _ServicesList.Add(id);
            dgvServicesSetup();
        }
        private void cmbServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudQuantity.Value = 1;
            if (cmbServices.SelectedItem != null && cmbServices.SelectedIndex != -1)
            {
                DataRowView row = (DataRowView)cmbServices.SelectedItem;

                if (row != null)
                {
                    _currentServiceUnitPrice = Convert.ToDecimal(row["Price"]);
                    lblPrice.Text = _currentServiceUnitPrice.ToString("N2");
                    lblLineTotal.Text = lblPrice.Text;
                }
            }
        }
        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            decimal lineTotal = _currentServiceUnitPrice * nudQuantity.Value;
            lblLineTotal.Text = lineTotal.ToString("N2");
        }
        private void txtBP_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBP.Text))
            {
                e.Cancel = true;
                error.SetError(txtBP, "Please enter blood pressure in format like 120/80");
                return;
            }
            if (!txtBP.Text.Contains("/"))
            {
                e.Cancel = true;
                error.SetError(txtBP, "Please enter blood pressure in format like 120/80");
                return;
            }
            foreach (char c in txtBP.Text)
            {
                if (!char.IsDigit(c) && c != '/')
                {
                    e.Cancel = true;
                    error.SetError(txtBP, "Blood pressure cannot contain letters or symbols except '/'");
                    return;
                }
            }
            error.SetError(txtBP, "");
        }
        private void txtPulse_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPulse.Text))
            {
                e.Cancel = true;
                error.SetError(txtPulse, "Pulse rate cannot be empty");
                return;
            }
            foreach (char c in txtPulse.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Cancel = true;
                    error.SetError(txtPulse, "Pulse rate cannot contain letters or symbols");
                    return;
                }
            }
            if (!int.TryParse(txtPulse.Text, out int pulse) || pulse < 30 || pulse > 250)
            {
                e.Cancel = true;
                error.SetError(txtPulse, "Please enter a valid pulse rate between 30 and 250");
            }
            else
            {
                error.SetError(txtPulse, "");
            }
        }
        private void txtTemp_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTemp.Text))
            {
                e.Cancel = true;
                error.SetError(txtTemp, "Temperature cannot be empty");
                return;
            }
            foreach (char c in txtTemp.Text)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    e.Cancel = true;
                    error.SetError(txtTemp, "Temperature cannot contain letters or symbols except '.'");
                    return;
                }
            }
            if (!decimal.TryParse(txtTemp.Text, out decimal temp) || temp < 30m || temp > 45m)
            {
                e.Cancel = true;
                error.SetError(txtTemp, "Please enter a valid temperature between 30 and 45");
            }
            else
            {
                error.SetError(txtTemp, "");
            }
        }
        private void txtDosage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDosage.Text))
            {
                e.Cancel = true;
                error.SetError(txtDosage, "Dosage cannot be blank");
            }
            else if (!int.TryParse(txtDosage.Text, out int dosage) || dosage <= 0)
            {
                e.Cancel = true;
                error.SetError(txtDosage, "Please enter a valid number");
            }
            else
            {
                error.SetError(txtDosage, "");
            }
        }
        private void txtDuration_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDuration.Text))
            {
                e.Cancel = true;
                error.SetError(txtDuration, "Duration cannot be blank");
            }
            else if (!int.TryParse(txtDuration.Text, out int duration) || duration <= 0)
            {
                e.Cancel = true;
                error.SetError(txtDuration, "Please enter a valid number");
            }
            else
            {
                error.SetError(txtDuration, "");
            }
        }
        private void txtSymptoms_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSymptoms.Text))
            {
                e.Cancel = true;
                error.SetError(txtSymptoms, "Symptoms cannot be blank");
            }
            else
            {
                error.SetError(txtSymptoms, "");
            }
        }
        private void txtDiagnosis_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                e.Cancel = true;
                error.SetError(txtDiagnosis, "Diagnosis cannot be blank");
            }
            else
            {
                error.SetError(txtDiagnosis, "");
            }
        }
        private void LockForm()
        {
            tabControl1.Enabled = false;
            btnSave.Enabled = false;
        }
        private bool ValidateVisit()
        {
            if (string.IsNullOrWhiteSpace(txtSymptoms.Text)
                || string.IsNullOrWhiteSpace(txtDiagnosis.Text)
                || string.IsNullOrWhiteSpace(txtBP.Text)
                || string.IsNullOrWhiteSpace(txtPulse.Text)
                || string.IsNullOrWhiteSpace(txtTemp.Text))
            {
                return false;
            }
            return true;
        }
        private bool ValidatePrescription()
        {
            if(string.IsNullOrWhiteSpace(txtDosage.Text) || !int.TryParse(txtDosage.Text, out int a))
            {
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateVisit())
            {
                MessageBox.Show("Some Fields Are Mandatory, Fill Them To Be Able To Save The Visit");
                return;
            }



            clsVisit vis = new clsVisit();
            clsPrescription pre = new clsPrescription();




            vis.AppointmentID = _App.AppointmentID;
            vis.VisitDate = DateTime.Now;
            vis.Symptoms = txtSymptoms.Text;
            vis.Diagnosis = txtDiagnosis.Text;
            vis.VitalSigns_BP = txtBP.Text;
            vis.VitalSigns_Pulse = int.TryParse(txtPulse.Text, out int pulse) ? pulse : 0;
            vis.VitalSigns_Temp = decimal.TryParse(txtTemp.Text, out decimal temp) ? temp : 0;
            
            
            
            if (!vis.Save())
            {

                MessageBox.Show("Failed Saving Visit Information");
                return;
            }

            if(dgvMeds.Rows.Count > 0)
            {
                

                pre.VisitID = vis.VisitID;
                pre.Notes = txtNote.Text;
                foreach(var i in _PrescriptionList)
                {
                    pre.PrescriptionDetails.Add(i);
                }

                if (!pre.Save())
                {
                    clsVisit.DeleteVisit(vis.VisitID);
                    MessageBox.Show("Failed Saving Prescription Information");
                    return;
                }
            }

            if (dgvService.Rows.Count > 0)
            {
                if (_Inv != null)
                {
                    _Inv.VisitID = vis.VisitID;
                    List<clsInvoiceDetails> newDetailsList = new List<clsInvoiceDetails>();

                    foreach (var existing in _Inv.InvoiceDetailsList)
                    {
                        existing.InvoiceDetailID = -1;
                        existing.Mode = clsInvoiceDetails.enMode.AddNew;
                        newDetailsList.Add(existing);
                    }

                    foreach (var i in _ServicesList)
                    {
                        if (!newDetailsList.Any(d => d.ServiceID == i.ServiceID))
                        {
                            i.InvoiceID = _Inv.InvoiceID;
                            i.Mode = clsInvoiceDetails.enMode.AddNew;
                            newDetailsList.Add(i);
                        }
                    }

                    _Inv.InvoiceDetailsList = newDetailsList;  

                    decimal insurancePercentage = _App.PatientInfo?.InsuranceCompanyInfo?.CoveragePercentage ?? 0;

                    _Inv.TotalAmount = _Inv.InvoiceDetailsList.Sum(d => d.LineTotal);
                    _Inv.InsuranceCoverAmount = (_Inv.TotalAmount * insurancePercentage) / 100;
                    _Inv.PatientShareAmount = _Inv.TotalAmount - _Inv.InsuranceCoverAmount;

                    _Inv.Mode = clsInvoice.enMode.Update;

                    if (!_Inv.Save())
                    {
                        if (dgvMeds.Rows.Count > 0)
                            clsPrescription.Delete(pre.PrescriptionID);
                        clsVisit.DeleteVisit(vis.VisitID);
                        _Inv = clsInvoice.Find(_Inv.InvoiceID);  

                        MessageBox.Show("Failed Saving Recommended Service Information");
                        return;
                    }
                }
            }


            MessageBox.Show("Visit & Prescription Information Has Been Saved Successfully");
            _App.Status = clsAppointment.enStatus.Completed;
            if (_App.Save())
            {
                
                LockForm();
            }
        }
        private void deleteMedicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMeds.CurrentRow == null || dgvMeds.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please Choose A Medicine To delete From Prescription", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string med = dgvMeds.CurrentRow.Cells["MedicineName"].Value?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(med))
            {
                MessageBox.Show("Please Choose A Medicine To delete From Prescription", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _PrescriptionList.RemoveAll(i=>i.MedicineName == med);
            dgvMedsSetup();

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvService.CurrentRow == null || dgvService.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please Choose A Service To delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string serv = dgvService.CurrentRow.Cells["ServiceName"].Value?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(serv))
            {
                MessageBox.Show("Please Choose A Service To delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _ServicesList.RemoveAll(i => i.ServiceName == serv);
            dgvServicesSetup();
        }
    }
}
