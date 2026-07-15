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

namespace CMS_UI.Controls
{
    public partial class ctrlPerson : UserControl
    {
        private enum enMode { AddNew, Edit }
        private enMode _Mode = enMode.AddNew;

        private string _OriginalEmail = "";
        private string _OriginalPhone = "";

        public string FirstName
        {
            get => txtFirstName.Text;
            set => txtFirstName.Text = value;
        }

        public string SecondName
        {
            get => txtSecondName.Text;
            set => txtSecondName.Text = value;
        }

        public string ThirdName
        {
            get => txtThirdName.Text;
            set => txtThirdName.Text = value;
        }

        public string LastName
        {
            get => txtLastName.Text;
            set => txtLastName.Text = value;
        }

        public string Phone
        {
            get => txtPhone.Text;
            set => txtPhone.Text = value;
        }

        public string Email
        {
            get => txtEmail.Text;
            set => txtEmail.Text = value;
        }

        public string Address
        {
            get => txtAddress.Text;
            set => txtAddress.Text = value;
        }

        public DateTime DateOfBirth
        {
            get => dateTimePicker1.Value;
            set => dateTimePicker1.Value = value;
        }

        public byte Gender
        {
            get
            {
                return (byte)(rdbMale.Checked ? 1 : 0);
            }
            set
            {
                rdbMale.Checked = (value == 1);
                rdbFemale.Checked = (value == 0);
            }
        }
        public ctrlPerson()
        {
            InitializeComponent();
        }
        private void Reload()
        {
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            rdbMale.Checked = true;
        }
        private void ctrlPerson_Load(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            Reload();
        }
        public void FillPerson(clsPerson person)
        {
            person.FirstName = FirstName;
            person.SecondName = SecondName;
            person.ThirdName = ThirdName;
            person.LastName = LastName;
            person.Gender = Gender;
            person.DateOfBirth = DateOfBirth;
            person.Phone = Phone;
            person.Email = Email;
            person.Address = Address;
        }
        public void LoadPerson(clsPerson person)
        {
            FirstName = person.FirstName;
            SecondName = person.SecondName;
            ThirdName = person.ThirdName;
            LastName = person.LastName;
            Gender = (byte)person.Gender;
            DateOfBirth = person.DateOfBirth;
            Phone = person.Phone;
            Email = person.Email;
            Address = person.Address;
            _OriginalEmail = person.Email;
            _OriginalPhone = person.Phone;

            _Mode = enMode.Edit;
        }
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                error.SetError(txtFirstName, "First Name Is Mandatory");
            }
            else
            {
                error.SetError(txtFirstName, "");
            }
        }
        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                error.SetError(txtLastName, "Last Name Is Mandatory");
            }
            else
            {
                error.SetError(txtLastName, "");
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                error.SetError(txtEmail, "Email Is Mandatory");
            }
            else if (!clsValidate.IsValidEmail(txtEmail.Text))
            {
                e.Cancel = true;
                error.SetError(txtEmail, "Email Is Not Valid");
            }
            else if (_Mode == enMode.AddNew && clsPerson.ExistsByEmail(txtEmail.Text))
            {
                e.Cancel = true;
                error.SetError(txtEmail, "Email Is Already Used");
            }
            else if (_Mode == enMode.Edit && txtEmail.Text != _OriginalEmail && clsPerson.ExistsByEmail(txtEmail.Text))
            {
                e.Cancel = true;
                error.SetError(txtEmail, "Email Is Already Used");
            }
            else
            {
                error.SetError(txtEmail, "");
            }
        }
        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                e.Cancel = true;
                error.SetError(txtAddress, "Address Is Mandatory");
            }
            else
            {
                error.SetError(txtAddress, "");
            }
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                e.Cancel = true;
                error.SetError(txtPhone, "Phone Number Is Mandatory");
            }
            else if (_Mode == enMode.AddNew && clsPerson.ExistsByPhone(txtPhone.Text))
            {
                e.Cancel = true;
                error.SetError(txtPhone, "Phone Is Already Used");
            }
            else if (_Mode == enMode.Edit && txtPhone.Text != _OriginalPhone && clsPerson.ExistsByPhone(txtPhone.Text))
            {
                e.Cancel = true;
                error.SetError(txtPhone, "Phone Is Already Used");
            }
            else
            {
                error.SetError(txtPhone, "");
            }
        }
    }
}
