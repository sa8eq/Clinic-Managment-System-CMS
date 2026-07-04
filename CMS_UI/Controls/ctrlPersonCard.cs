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
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID;
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        public void LoadPersonData(int personID)
        {
            _PersonID = personID;

            clsPerson person = clsPerson.Find(_PersonID);

            if (person == null)
            {
                MessageBox.Show($"Person With ID {_PersonID} Was Not Found!");
                return;
            }

            lblPersonID.Text = person.PersonID.ToString();
            lblFirstName.Text = person.FirstName;
            lblSecondName.Text = person.SecondName;
            lblThirdName.Text = person.ThirdName;
            lblLastName.Text = person.LastName;

            lblGender.Text = person.Gender == 0 ? "Female" : "Male";
            lblPhone.Text = person.Phone;
            lblAddress.Text = person.Address;
            lblEmail.Text = person.Email;

            lblCreationDate.Text = person.CreatedAt.Value.ToString("yyyy-MM-dd");
            lblDateOfBirth.Text = person.DateOfBirth.ToString("yyyy-MM-dd");
        }
        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {
            
        }
    }
}
