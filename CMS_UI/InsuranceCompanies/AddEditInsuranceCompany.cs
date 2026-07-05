using CMS_UI.Global;
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

namespace CMS_UI.InsuranceCompanies
{
    public partial class AddEditInsuranceCompany : Form
    {
        private clsInsuranceCompany _InsuranceCompany;
        private int _InsuranceCompanyID;
        private enum enMode { AddNew, Edit}
        private enMode _Mode;

        public AddEditInsuranceCompany()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _InsuranceCompany = new clsInsuranceCompany();
        }

        public AddEditInsuranceCompany(int InsuranceCompanyID)
        {
            InitializeComponent();
            _InsuranceCompanyID = InsuranceCompanyID;
            _Mode = enMode.Edit;
        }

        private void AddEditInsuranceCompany_Load(object sender, EventArgs e)
        {
            if(_Mode==enMode.Edit)
            {
                _InsuranceCompany = clsInsuranceCompany.Find(_InsuranceCompanyID);
                if (_InsuranceCompany != null)
                {
                    label1.Text = "Edit Insurance Company";
                    txtCompanyName.Text = _InsuranceCompany.CompanyName;
                    lblCompanyID.Text = _InsuranceCompany.InsuranceCompanyID.ToString();
                    txtCoveragePercent.Text = _InsuranceCompany.CoveragePercentage.ToString();
                    txtContactEmail.Text = _InsuranceCompany.ContactEmail;
                    txtContactPhone.Text = _InsuranceCompany.ContactPhone;
                }
                else
                {
                    MessageBox.Show($"There Is Not Insureance Company With ID: {_InsuranceCompanyID}");
                }
            }
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCompanyName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                e.Cancel = true;
                error.SetError(txtCompanyName, "Company Name Can Not Be Empty");
                return;
            }
            if (_Mode == enMode.AddNew && clsInsuranceCompany.ExistsByCompanyName(txtCompanyName.Text))
            {
                e.Cancel = true;
                error.SetError(txtCompanyName, "This Company Name Already Used, Try Diffrent Name");
                return;
            }
            if(_Mode == enMode.Edit && txtCompanyName.Text != _InsuranceCompany.CompanyName)
            {
                if(clsInsuranceCompany.ExistsByCompanyName(txtCompanyName.Text))
                {
                    e.Cancel = true;
                    error.SetError(txtCompanyName, "New Company Name Already Used, Try Diffrent Name");
                    return;
                }
            }

            e.Cancel = false;
            error.SetError(txtCompanyName, "");
        }

        private void txtCoveragePercent_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCoveragePercent.Text))
            {
                e.Cancel = true;
                error.SetError(txtCoveragePercent, "Coverage Percent Can Not Be Empty");
                return;
            }

            if (!decimal.TryParse(txtCoveragePercent.Text, out decimal percent))
            {
                e.Cancel = true;
                error.SetError(txtCoveragePercent, "Please enter a valid number for coverage percent");
                return;
            }

            if (percent < 0 || percent > 100)
            {
                e.Cancel = true;
                error.SetError(txtCoveragePercent, "Coverage percent must be between 0 and 100");
                return;
            }

            e.Cancel = false;
            error.SetError(txtCoveragePercent, "");
        }

        private void txtContactEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContactEmail.Text))
            {
                e.Cancel = true;
                error.SetError(txtContactEmail, "Contact Email Can Not Be Empty");
                return;
            }
            if (_Mode == enMode.AddNew && clsInsuranceCompany.ExistByCompanyEmail(txtContactEmail.Text))
            {
                e.Cancel = true;
                error.SetError(txtContactEmail, "This Company Email Already Used, Try Diffrent Name");
                return;

            }
            if (!clsValidate.IsValidEmail(txtContactEmail.Text))
            {
                e.Cancel = true;
                error.SetError(txtContactEmail, "Invalid Company Email");
                return;

            }
            if (_Mode == enMode.Edit && txtContactEmail.Text != _InsuranceCompany.ContactEmail)
            {
                if (clsInsuranceCompany.ExistByCompanyEmail(txtContactEmail.Text))
                {
                    e.Cancel = true;
                    error.SetError(txtContactEmail, "New Company Email Already Used, Try Diffrent Name");
                    return;

                }
            }

            e.Cancel = false;
            error.SetError(txtContactEmail, "");
        }

        private void txtContactPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContactPhone.Text))
            {
                e.Cancel = true;
                error.SetError(txtContactPhone, "Contact Phone Can Not Be Empty");
                return;
            }

            if (_Mode == enMode.AddNew && clsInsuranceCompany.ExistByCompanyPhone(txtContactPhone.Text))
            {
                e.Cancel = true;
                error.SetError(txtContactPhone, "This Company Phone Already Used, Try Diffrent Name");
                return;
            }

            if (_Mode == enMode.Edit && txtContactPhone.Text != _InsuranceCompany.ContactPhone)
            {
                if (clsInsuranceCompany.ExistByCompanyPhone(txtContactPhone.Text))
                {
                    e.Cancel = true;
                    error.SetError(txtContactPhone, "New Company Phone Already Used, Try Diffrent Name");
                    return;
                }
            }

            e.Cancel = false;
            error.SetError(txtContactPhone, "");
        }

        private void Lock()
        {
            btnSave.Enabled = false;
            txtCompanyName.Enabled = false;
            txtContactEmail.Enabled = false;
            txtContactPhone.Enabled = false;
            txtCoveragePercent.Enabled = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            {

                _InsuranceCompany.ContactPhone = txtContactPhone.Text;
                _InsuranceCompany.ContactEmail = txtContactEmail.Text;
                _InsuranceCompany.CompanyName = txtCompanyName.Text;
                decimal i;
                decimal.TryParse(txtCoveragePercent.Text, out i);
                _InsuranceCompany.CoveragePercentage = i;

                if(_InsuranceCompany.Save())
                {
                    MessageBox.Show(_Mode==enMode.AddNew? "Successfully Saved New Insurance Company" : "Successfully Edited Insurance Company");
                    _Mode = enMode.Edit;
                    lblCompanyID.Text = _InsuranceCompany.InsuranceCompanyID.ToString();
                    Lock();
                }
                else
                {
                    MessageBox.Show("Failed Saving Insurance Company Information", "Error");
                }

            }
            else
            {
                MessageBox.Show("Some Missing Fields Are Mandatory, Hover Above The Error Mark Infront The Field To Learn How To Fix It");
            }
        }
    }
}
