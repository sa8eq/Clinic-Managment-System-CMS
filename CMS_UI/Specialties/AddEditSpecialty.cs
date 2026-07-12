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

namespace CMS_UI.Specialties
{
    public partial class AddEditSpecialty : Form
    {
        private enum enMode { AddNew, Edit}
        private enMode _Mode;
        private int _SpecialtyID;
        private clsSpecialty _Specialty;
        public AddEditSpecialty()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            
        }
        public AddEditSpecialty(int SpecialtyID)
        {
            InitializeComponent();
            _SpecialtyID = SpecialtyID;
            _Mode = enMode.Edit;
        }

        private void AddEditSpecialty_Load(object sender, EventArgs e)
        {
            if(_Mode == enMode.Edit)
            {
                label1.Text = "Edit Specialty";
                _Specialty = clsSpecialty.Find(_SpecialtyID);
                if(_Specialty==null)
                {
                    MessageBox.Show("Choose A Specialty To Edit");
                    this.Close();
                    return;
                }
                lblID.Text = _Specialty.SpecialtyID.ToString();
                txtName.Text = _Specialty.SpecialtyName;
                txtDescription.Text = _Specialty.Description;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lock()
        {
            btnSave.Enabled = false;
            txtDescription.Enabled = false;
            txtName.Enabled = false;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (_Mode == enMode.AddNew)
                {
                    _Specialty = new clsSpecialty();

                }
                _Specialty.SpecialtyName = txtName.Text;
                _Specialty.Description = txtDescription.Text;

                if(_Specialty.Save())
                {
                    MessageBox.Show(_Mode == enMode.AddNew ? "New Specialty Has Been Added Successfully" : "Specialty Has Been Updated Succesffuly");
                    lblID.Text = _Specialty.SpecialtyID.ToString();
                    if(_Mode == enMode.AddNew)
                    {
                        _Mode = enMode.Edit;
                    }
                    Lock();
                }
                else
                {
                    MessageBox.Show("Failed Saving Specialty");
                }
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                error.SetError(txtName, "Specialty Name Field Is Mandatory");
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtName, "");
            }
        }
    }
}
