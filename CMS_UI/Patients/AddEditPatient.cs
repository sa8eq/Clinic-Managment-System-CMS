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

namespace CMS_UI.Patients
{
    public partial class AddEditPatient : Form
    {
        private clsPatient _Patient;
        private int _PatientID;
        private enMode _Mode;

        public enum enMode { AddNew, Edit }

        public AddEditPatient()
        {
            InitializeComponent();
            _Patient = new clsPatient();
            _Mode = enMode.AddNew;
        }

        public AddEditPatient(int patientID)
        {
            InitializeComponent();
            _PatientID = patientID;
            _Mode = enMode.Edit;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillInsuranceCompanyComboBox()
        {
            DataTable dtSource = clsInsuranceCompany.GetAllInsuranceCompanies();

            DataTable dtFinal = new DataTable();
            dtFinal.Columns.Add("InsuranceCompanyID", typeof(int));
            dtFinal.Columns.Add("CompanyName", typeof(string));

            DataRow defaultRow = dtFinal.NewRow();
            defaultRow["InsuranceCompanyID"] = -1;
            defaultRow["CompanyName"] = "None (Cash)";
            dtFinal.Rows.Add(defaultRow);

            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    DataRow newRow = dtFinal.NewRow();
                    newRow["InsuranceCompanyID"] = row["InsuranceCompanyID"];
                    newRow["CompanyName"] = row["CompanyName"];
                    dtFinal.Rows.Add(newRow);
                }
            }

            cmbInsuranceCompanies.DataSource = dtFinal;
            cmbInsuranceCompanies.DisplayMember = "CompanyName";
            cmbInsuranceCompanies.ValueMember = "InsuranceCompanyID";

            cmbInsuranceCompanies.SelectedValue = -1;

            if (_Mode == enMode.AddNew)
            {
                txtInsurancePolicyNumber.Enabled = false;
            }

        }

        private void Reload()
        {
            FillInsuranceCompanyComboBox();
        }

        private void LoadUserData()
        {
            label1.Text = "Edit Patient Info";
            ctrlPerson1.LoadPerson(_Patient.PersonInfo);
            txtBloodType.Text = _Patient.BloodType;
            txtEmergencyContactNumber.Text = _Patient.EmergencyContactPhone;
            txtInsurancePolicyNumber.Text = _Patient.InsurancePolicyNumber;

            if (_Patient.InsuranceCompanyID != null && _Patient.InsuranceCompanyID != -1)
            {
                cmbInsuranceCompanies.SelectedValue = _Patient.InsuranceCompanyID;
            }
            else
            {
                cmbInsuranceCompanies.SelectedValue = -1;
            }
        }

        private void AddEditPatient_Load(object sender, EventArgs e)
        {

            Reload();

            if (_Mode == enMode.Edit)
            {
                _Patient = clsPatient.Find(_PatientID);
                if(_Patient == null)
                {
                    MessageBox.Show("Patient Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                LoadUserData();
            }
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

        }

        private void txtBloodType_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBloodType.Text))
            {
                e.Cancel = true;
                error.SetError(txtBloodType, "Blood Type Should Be Specified");
                return;
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtBloodType, "");
            }
        }

        private void txtEmergencyContactNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmergencyContactNumber.Text))
            {
                e.Cancel = true;
                error.SetError(txtEmergencyContactNumber, "Emergency Contact Number Can Not Be Empty");
                return;
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtEmergencyContactNumber, "");
            }
        }

        private void Lock()
        {
            btnSave.Enabled = false;
            ctrlPerson1.Enabled = false;
            txtBloodType.Enabled = false;
            txtEmergencyContactNumber.Enabled = false;
            cmbInsuranceCompanies.Enabled = false;
            txtInsurancePolicyNumber.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(this.ValidateChildren())
            {
                ctrlPerson1.FillPerson(_Patient.PersonInfo);

                if (_Mode == enMode.AddNew)
                {
                    if (clsPerson.ExistsByPhone(_Patient.PersonInfo.Phone))
                    {
                        MessageBox.Show("This Phone Number is already registered for another patient!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (clsPerson.ExistsByEmail(_Patient.PersonInfo.Email))
                    {
                        MessageBox.Show("This Email is already registered for another patient!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                _Patient.BloodType = txtBloodType.Text;
                _Patient.EmergencyContactPhone = txtEmergencyContactNumber.Text;
                _Patient.InsurancePolicyNumber = txtInsurancePolicyNumber.Text;

                //if ((int)cmbInsuranceCompanies.SelectedValue == -1)
                //{
                //    _Patient.InsuranceCompanyID = null;
                //}
                //else
                //{
                //    _Patient.InsuranceCompanyID = (int)cmbInsuranceCompanies.SelectedValue;
                //}

                if (cmbInsuranceCompanies.SelectedValue != null && int.TryParse(cmbInsuranceCompanies.SelectedValue.ToString(), out int selectedCompanyID))
                {
                    if (selectedCompanyID == -1)
                    {
                        _Patient.InsuranceCompanyID = null;       
                        _Patient.InsurancePolicyNumber = null;   
                    }
                    else
                    {
                        _Patient.InsuranceCompanyID = selectedCompanyID;
                        _Patient.InsurancePolicyNumber = txtInsurancePolicyNumber.Text;
                    }
                }
                else
                {
                    _Patient.InsuranceCompanyID = null;
                    _Patient.InsurancePolicyNumber = null;
                }


                if (_Patient.Save())
                {
                    MessageBox.Show(_Mode == enMode.AddNew? "Patient Has Been Successfully Saved" : "Patient Updated Successfully");
                    _Mode = enMode.Edit;
                    Lock();
                }
                else
                {
                    MessageBox.Show("Failed Saving Patient");
                }
            }
            else
            {
                MessageBox.Show("Some Fields Are Mandatory, Check The Error Marks Infront The Fields To Learn How To Fix");
            }
        }

        private void cmbInsuranceCompanies_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbInsuranceCompanies.SelectedValue != null && int.TryParse(cmbInsuranceCompanies.SelectedValue.ToString(), out int selectedCompanyID))
            {
                if (selectedCompanyID != -1)
                {
                    txtInsurancePolicyNumber.Enabled = true;
                }
                else
                {
                    txtInsurancePolicyNumber.Enabled = false;
                    txtInsurancePolicyNumber.Text = "";
                    error.SetError(txtInsurancePolicyNumber, "");
                }
            }
        }

        private void txtInsurancePolicyNumber_Validating(object sender, CancelEventArgs e)
        {
            if(txtInsurancePolicyNumber.Enabled)
            {
                if(string.IsNullOrWhiteSpace(txtInsurancePolicyNumber.Text))
                {
                    e.Cancel = true;
                    error.SetError(txtInsurancePolicyNumber, "Policy Number Can No Be Empty If You Choose A Insurance Company, Fill The Policy Number Or Choose None(Cash) Option From The Insurance Companies Section");
                }
                else
                {
                    e.Cancel = false;
                    error.SetError(txtInsurancePolicyNumber, "");
                }
            
            }
        }
    }
}
