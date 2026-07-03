using System;
using System.Data;
using CMSData;

namespace CMSLogic
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedAt { get; set; }

        public string FullName
        {
            get { return FirstName + " " + (string.IsNullOrEmpty(SecondName) ? "" : SecondName + " ") + (string.IsNullOrEmpty(ThirdName) ? "" : ThirdName + " ") + LastName; }
        }

        public clsPerson()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Gender = 0;
            this.DateOfBirth = DateTime.Now;
            this.Phone = "";
            this.Email = "";
            this.Address = "";
            this.CreatedAt = null;

            Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string FirstName, string SecondName, string ThirdName,
                          string LastName, byte Gender, DateTime DateOfBirth, string Phone,
                          string Email, string Address, DateTime? CreatedAt)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.DateOfBirth = DateOfBirth;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.CreatedAt = CreatedAt;

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonsData.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName,
                                                        this.LastName, this.Gender, this.DateOfBirth,
                                                        this.Phone, this.Email, this.Address);
            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonsData.UpdatePerson(this.PersonID, this.FirstName, this.SecondName, this.ThirdName,
                                               this.LastName, this.Gender, this.DateOfBirth,
                                               this.Phone, this.Email, this.Address);
        }

        public static clsPerson Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Email = "", Address = "";
            byte Gender = 0;
            DateTime DateOfBirth = DateTime.Now;
            DateTime? CreatedAt = null;

            bool isFound = clsPersonsData.GetPersonByID(PersonID, ref FirstName, ref SecondName, ref ThirdName,
                                                       ref LastName, ref Gender, ref DateOfBirth,
                                                       ref Phone, ref Email, ref Address, ref CreatedAt);

            if (isFound)
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, Gender, DateOfBirth, Phone, Email, Address, CreatedAt);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdatePerson();
            }
            return false;
        }

        public static bool Delete(int PersonID)
        {
            return clsPersonsData.DeletePerson(PersonID);
        }

        public static DataTable GetAllPersons()
        {
            return clsPersonsData.GetAllPersons();
        }

        public static clsPerson FindByEmail(string Email)
        {
            int PersonID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Address = "";
            byte Gender = 0;
            DateTime DateOfBirth = DateTime.Now;
            DateTime? CreatedAt = null;

            bool IsFound = clsPersonsData.GetPersonByEmail(Email,
                ref PersonID,
                ref FirstName,
                ref SecondName,
                ref ThirdName,
                ref LastName,
                ref Gender,
                ref DateOfBirth,
                ref Phone,
                ref Address,
                ref CreatedAt);

            if (IsFound)
            {
                return new clsPerson(PersonID,
                                     FirstName,
                                     SecondName,
                                     ThirdName,
                                     LastName,
                                     Gender,
                                     DateOfBirth,
                                     Phone,
                                     Email,
                                     Address,
                                     CreatedAt);
            }
            else
            {
                return null;
            }
        }

        public static bool ExistsByEmail(string Email)
        {
            return clsPersonsData.IsPersonExistsByEmail(Email);
        }

        public static bool ExistsByPhone(string Phone)
        {
            return clsPersonsData.IsPersonExistsByPhone(Phone);
        }
    }
}