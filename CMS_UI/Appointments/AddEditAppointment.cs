using CMS_UI.Global;
using CMS_UI.Invoices;
using CMS_UI.Patients;
using CMSLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS_UI.Appointments
{
    public partial class AddEditAppointment : Form
    {
        public AddEditAppointment()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public AddEditAppointment(int Appointmentid)
        {
            InitializeComponent();
            _AppointmentID = Appointmentid;
            _Mode = enMode.Edit;
        }
        private string _SelectedTime = "";
        private DataTable dtPatients;
        private DataTable dtDoctors;
        private int _AppointmentID;
        private enum enMode { AddNew, Edit}
        private enMode _Mode;
        private clsAppointment _Appointment;
        private void FiltersSetup()
        {
            cmbPatientFilterBy.SelectedItem = "None";
            cmbDoctorFilterBy.SelectedItem = "None";

            cmbDepartment.Enabled = false;
            cmbDepartment.Visible = false;

            txtDoctorFilter.Enabled = false;
            txtPatientFilter.Enabled = false;
            txtPatientFilter.Visible = false;
            txtDoctorFilter.Visible = false;

            cmbDepartment.DataSource = clsSpecialty.GetAllSpecialties();
            cmbDepartment.DisplayMember = "SpecialtyName";
            cmbDepartment.ValueMember = "SpecialtyID";

            _LoadMedicalServices(null);
        }
        private void _LoadMedicalServices(int? specialtyID)
        {
            DataTable dtServices = clsMedicalService.GetMedicalServicesBySpecialty(specialtyID);

            cmbMedicalService.DataSource = dtServices;
            cmbMedicalService.DisplayMember = "ServiceName";
            cmbMedicalService.ValueMember = "ServiceID";

            cmbMedicalService.SelectedIndex = 0;
        }
        private void DGVSetup()
        {
            dgvPatients.DataSource = dtPatients;
            if(dtPatients.Rows.Count>0)
            {
                dgvPatients.Columns["BloodType"].Visible = false;
                dgvPatients.Columns["InsuranceCompanyName"].Visible = false;
                dgvPatients.Columns["InsurancePolicyNumber"].Visible = false;
                dgvPatients.Columns["EmergencyContactPhone"].Visible = false;

                dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            dgvDoctors.DataSource = dtDoctors;
            if (dtDoctors.Rows.Count > 0)
            {
                dgvDoctors.Columns["PersonID"].Visible = false;
                dgvDoctors.Columns["SpecialtyID"].Visible = false;
                dgvDoctors.Columns["LicenseNumber"].Visible = false;
                dgvDoctors.Columns["HireDate"].Visible = false;
                dgvDoctors.Columns["IsActive"].Visible = false;
                dgvDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }
        private void Reload()
        {
            FiltersSetup();

            dtPatients = clsPatient.GetAllPatients();

            DataTable dtAllDoctors = clsDoctor.GetAllDoctors();

            DataView dvDoctors = dtAllDoctors.DefaultView;
            dvDoctors.RowFilter = "IsActive = true";
            dtDoctors = dvDoctors.ToTable();
           
            DGVSetup();
            
        }
        private void AddEditAppointment_Load(object sender, EventArgs e)
        {
            dtpAppointmentDate.MinDate = DateTime.Now.AddDays(1);

            Reload();

            if (_Mode == enMode.Edit)
            {
                _Appointment = clsAppointment.Find(_AppointmentID);

                if (_Appointment == null)
                {
                    MessageBox.Show("This appointment was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                if (_Appointment.Status != clsAppointment.enStatus.Pending)
                {
                    MessageBox.Show("This appointment cannot be edited because its current status is: " + _Appointment.Status.ToString(),
                                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnSave.Enabled = false;
                    dtpAppointmentDate.Enabled = false;
                    flpSlots.Enabled = false;
                }

                lblPatientID.Text = _Appointment.PatientID.ToString();
                lblPatientName.Text = _Appointment.PatientInfo.PersonInfo.FullName;

                lblDoctorID.Text = _Appointment.DoctorID.ToString();
                lblDoctorName.Text = _Appointment.DoctorInfo.PersonInfo.FullName;
                lblSpecialtyName.Text = _Appointment.DoctorInfo.DoctorSpecialty.SpecialtyName;

                _LoadMedicalServices(_Appointment.DoctorInfo.SpecialtyID);

                if (_Appointment.SelectedServiceID != -1)
                {
                    cmbMedicalService.SelectedValue = _Appointment.SelectedServiceID;
                }

                if (_Appointment.AppointmentDate < dtpAppointmentDate.MinDate)
                {
                    dtpAppointmentDate.MinDate = _Appointment.AppointmentDate.Date;
                }
                dtpAppointmentDate.Value = _Appointment.AppointmentDate.Date;

                UpdateAvailableSlots();

                string oldTime = _Appointment.AppointmentDate.ToString(@"hh\:mm");

                foreach (Control control in flpSlots.Controls)
                {
                    if (control is Button btn && btn.Text == oldTime)
                    {
                        btn.PerformClick();
                        break;
                    }
                }
            }
        }
        private void cmbPatientFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPatientFilter.Text = "";
            if (dtPatients != null)
            {
                dtPatients.DefaultView.RowFilter = "";
            }

            if(cmbPatientFilterBy.SelectedItem == "None")
            {
                txtPatientFilter.Enabled = false;
                txtPatientFilter.Visible = false;
            }
            else
            {
                txtPatientFilter.Enabled = true;
                txtPatientFilter.Visible = true;
            }
        }
        private void cmbDoctorFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDoctorFilter.Text = "";
            if(dtDoctors!=null)
            {
                dtDoctors.DefaultView.RowFilter = "";
            }
            if (cmbDoctorFilterBy.SelectedItem == "None")
            {
                txtDoctorFilter.Enabled = false;
                txtDoctorFilter.Visible = false;

                cmbDepartment.Enabled = false;
                cmbDepartment.Visible = false;
            }
            else if(cmbDoctorFilterBy.SelectedItem == "Department")
            {
                txtDoctorFilter.Enabled = false;
                txtDoctorFilter.Visible = false;

                cmbDepartment.Enabled = true;
                cmbDepartment.Visible = true;
            }
            else
            {
                txtDoctorFilter.Enabled = true;
                txtDoctorFilter.Visible = true;

                cmbDepartment.Enabled = false;
                cmbDepartment.Visible = false;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Lock()
        {
            flpSlots.Enabled = false;
            cmbMedicalService.Enabled = false;
            dtpAppointmentDate.Enabled = false;
            btnSave.Enabled = false;
      
            pictureBox2.Enabled = false;
            cmbDoctorFilterBy.Enabled = false;
            cmbPatientFilterBy.Enabled = false;
            cmbDepartment.Enabled = false;

            txtDoctorFilter.Enabled = false;
            txtPatientFilter.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbMedicalService.SelectedIndex == -1 || cmbMedicalService.SelectedValue == null)
            {
                MessageBox.Show("Please select a medical service.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lblPatientID.Text == "???" || string.IsNullOrEmpty(lblPatientID.Text))
            {
                MessageBox.Show("Please select a patient first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lblDoctorID.Text == "???" || string.IsNullOrEmpty(lblDoctorID.Text))
            {
                MessageBox.Show("Please select a doctor first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(_SelectedTime))
            {
                MessageBox.Show("Please select an available time slot.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime appointmentDate = dtpAppointmentDate.Value.Date; 
            TimeSpan timeSlot = TimeSpan.Parse(_SelectedTime);       
            appointmentDate = appointmentDate.Add(timeSlot);          

            if (_Mode == enMode.AddNew)
            {
                _Appointment = new clsAppointment();
            }

            _Appointment.PatientID = Convert.ToInt32(lblPatientID.Text);
            _Appointment.DoctorID = Convert.ToInt32(lblDoctorID.Text);
            _Appointment.AppointmentDate = appointmentDate;
            _Appointment.SelectedServiceID = (int)cmbMedicalService.SelectedValue;
            _Appointment.Notes = ""; 
            _Appointment.Status = clsAppointment.enStatus.Pending;

            _Appointment.UserID = clsCurrentUser.CurrentUser.UserID;

            if (_Appointment.Save())
            {
                if (_Appointment.SelectedServiceInfo != null && _Appointment.SelectedServiceInfo.Price > 0)
                {
                    Invoice frm = new Invoice(_Appointment);
                    frm.ShowDialog();
                    MessageBox.Show("Appointment Saved. Opening payment invoice...", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Appointment Saved Successfully! (Payment Postponed/Free)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _Mode = enMode.Edit;
                _AppointmentID = _Appointment.AppointmentID;
                _Lock();
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Error: Appointment could not be saved.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtDoctors == null) return;

            if (cmbDoctorFilterBy.SelectedItem.ToString() == "Department" && cmbDepartment.SelectedValue != null)
            {
                if (int.TryParse(cmbDepartment.SelectedValue.ToString(), out int selectedSpecialtyID))
                {
                    dtDoctors.DefaultView.RowFilter = $"SpecialtyID = {selectedSpecialtyID}";
                }
            }
        }
        private void txtPatientFilter_TextChanged(object sender, EventArgs e)
        {
            if (dtPatients == null) return;

            if (string.IsNullOrEmpty(txtPatientFilter.Text))
            {
                dtPatients.DefaultView.RowFilter = "";
                return;
            }

            if (cmbPatientFilterBy.SelectedItem.ToString() == "Name")
            {
                dtPatients.DefaultView.RowFilter = $"FullName LIKE '{txtPatientFilter.Text}%'";
            }
            else if (cmbPatientFilterBy.SelectedItem.ToString() == "Patient ID")
            {
                if (int.TryParse(txtPatientFilter.Text, out int patientID))
                {
                    dtPatients.DefaultView.RowFilter = $"PatientID = {patientID}";
                }
                else
                {
                    dtPatients.DefaultView.RowFilter = "1 = 0";
                }
            }

        }
        private void txtDoctorFilter_TextChanged(object sender, EventArgs e)
        {
            if (dtDoctors == null) return;

            if (string.IsNullOrEmpty(txtDoctorFilter.Text))
            {
                dtDoctors.DefaultView.RowFilter = "";
                return;
            }

            if (cmbDoctorFilterBy.SelectedItem.ToString() == "Name")
            {
                dtDoctors.DefaultView.RowFilter = $"FullName LIKE '{txtDoctorFilter.Text}%'";
            }
            else if (cmbDoctorFilterBy.SelectedItem.ToString() == "Doctor ID")
            {
                if (int.TryParse(txtDoctorFilter.Text, out int doctorID))
                {
                    dtDoctors.DefaultView.RowFilter = $"DoctorID = {doctorID}";
                }
                else
                {
                    dtDoctors.DefaultView.RowFilter = "1 = 0";
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddEditPatient frm = new AddEditPatient();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Reload();
        }
        private void selectThisDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDoctors.CurrentRow == null || dgvDoctors.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Doctor To Book An Appointment");
                return;
            }

            int selecteddoctor = Convert.ToInt32(dgvDoctors.CurrentRow.Cells["DoctorID"].Value);

            clsDoctor d = clsDoctor.Find(selecteddoctor);
            if (d != null)
            {
                lblDoctorID.Text = d.DoctorID.ToString();
                lblDoctorName.Text = d.PersonInfo.FullName;
                lblSpecialtyName.Text = d.DoctorSpecialty.SpecialtyName;

                _LoadMedicalServices(d.SpecialtyID);

                UpdateAvailableSlots();
            }
        }
        private void selectThisPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvPatients.CurrentRow == null || dgvPatients.Rows.Count == 0)
            {
                MessageBox.Show("Choose A Patient To Book An Appointment");
                return;
            }

            int selectedpatient = Convert.ToInt32(dgvPatients.CurrentRow.Cells["PatientID"].Value);

            clsPatient p = clsPatient.Find(selectedpatient);
            if(p!=null)
            {
                lblPatientID.Text = p.PatientID.ToString();
                lblPatientName.Text = p.PersonInfo.FullName;
            }
        }
        private void UpdateAvailableSlots()
        {
            flpSlots.Controls.Clear();
            _SelectedTime = "";

            if (!int.TryParse(lblDoctorID.Text, out int doctorID))
            {
                return;
            }

            DateTime selectedDate = dtpAppointmentDate.Value.Date;

            List<string> allSlots = new List<string>();
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            TimeSpan interval = new TimeSpan(0, 20, 0);

            while (startTime < endTime)
            {
                allSlots.Add(startTime.ToString(@"hh\:mm"));
                startTime = startTime.Add(interval);
            }

            List<string> bookedSlots = clsAppointment.GetBookedSlotsForDoctor(doctorID, selectedDate);

            if (_Mode == enMode.Edit && _Appointment != null && _Appointment.AppointmentDate.Date == selectedDate)
            {
                string currentAppointmentTime = _Appointment.AppointmentDate.ToString(@"hh\:mm");
                bookedSlots.Remove(currentAppointmentTime);
            }

            List<string> availableSlots = allSlots.Except(bookedSlots).ToList();

            foreach (string slot in availableSlots)
            {
                Button btnSlot = new Button();
                btnSlot.Text = slot;
                btnSlot.Size = new Size(60, 40);
                btnSlot.Cursor = Cursors.Hand;
                btnSlot.FlatStyle = FlatStyle.Flat;
                btnSlot.FlatAppearance.BorderSize = 1;
                btnSlot.FlatAppearance.BorderColor = Color.LightGray;
                btnSlot.BackColor = Color.White;
                btnSlot.ForeColor = Color.Black;

                btnSlot.Click += (s, ev) => {
                    foreach (Button btn in flpSlots.Controls)
                    {
                        btn.BackColor = Color.White;
                        btn.ForeColor = Color.Black;
                        btn.FlatAppearance.BorderColor = Color.LightGray;
                    }

                    btnSlot.BackColor = Color.DodgerBlue;
                    btnSlot.ForeColor = Color.White;
                    btnSlot.FlatAppearance.BorderColor = Color.DodgerBlue;

                    _SelectedTime = btnSlot.Text;
                };

                flpSlots.Controls.Add(btnSlot);
            }

            if (availableSlots.Count == 0)
            {
                Label lblMessage = new Label();
                lblMessage.Text = "No Available Appointments For This Day";
                lblMessage.AutoSize = true;
                lblMessage.ForeColor = Color.Red;
                flpSlots.Controls.Add(lblMessage);
            }
        }
        private void dtpAppointmentDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateAvailableSlots();
        }
        private void cmbMedicalService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedicalService.SelectedValue == null) return;

            if (int.TryParse(cmbMedicalService.SelectedValue.ToString(), out int serviceID))
            {
                clsMedicalService selectedService = clsMedicalService.Find(serviceID);
            }
        }
    }
}
