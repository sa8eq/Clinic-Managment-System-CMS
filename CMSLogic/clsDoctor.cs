using System;
using System.Data;
using CMSData;

namespace CMSLogic
{
    public class clsDoctor
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int DoctorID { get; set; }
        public int PersonID { get; set; }
        public int SpecialtyID { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public clsPerson PersonInfo { get; set; }
        public clsSpecialty DoctorSpecialty { get; set; }
        public clsDoctor()
        {
            this.DoctorID = -1;
            this.PersonID = -1;
            this.SpecialtyID = -1;
            this.LicenseNumber = "";
            this.HireDate = DateTime.Now;
            this.IsActive = true;

            this.PersonInfo = new clsPerson();
            this.DoctorSpecialty = new clsSpecialty();

            Mode = enMode.AddNew;
        }
        private clsDoctor(int DoctorID, int PersonID, int SpecialtyID, string LicenseNumber, DateTime HireDate, bool IsActive)
        {
            this.DoctorID = DoctorID;
            this.PersonID = PersonID;
            this.SpecialtyID = SpecialtyID;
            this.LicenseNumber = LicenseNumber;
            this.HireDate = HireDate;
            this.IsActive = IsActive;

            this.PersonInfo = clsPerson.Find(PersonID);
            this.DoctorSpecialty = clsSpecialty.Find(SpecialtyID);

            Mode = enMode.Update;
        }
        private bool _AddNewDoctor()
        {
            this.DoctorID = clsDoctorsData.AddNewDoctor(this.PersonID, this.SpecialtyID, this.LicenseNumber, this.HireDate, this.IsActive);
            return (this.DoctorID != -1);
        }
        private bool _UpdateDoctor()
        {
            return clsDoctorsData.UpdateDoctor(this.DoctorID, this.PersonID, this.SpecialtyID, this.LicenseNumber, this.HireDate, this.IsActive);
        }
        public static clsDoctor Find(int DoctorID)
        {
            int PersonID = -1, SpecialtyID = -1;
            string LicenseNumber = "";
            DateTime HireDate = DateTime.Now;
            bool IsActive = true;

            bool isFound = clsDoctorsData.GetDoctorByID(DoctorID, ref PersonID, ref SpecialtyID, ref LicenseNumber, ref HireDate, ref IsActive);

            if (isFound)
                return new clsDoctor(DoctorID, PersonID, SpecialtyID, LicenseNumber, HireDate, IsActive);
            else
                return null;
        }
        public bool Save()
        {
            if (!this.PersonInfo.Save())
            {
                return false; 
            }
            this.PersonID = this.PersonInfo.PersonID;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDoctor())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateDoctor();
            }
            return false;
        }
        public static bool Delete(int DoctorID)
        {
            return clsDoctorsData.DeleteDoctor(DoctorID);
        }
        public static DataTable GetAllDoctors()
        {
            return clsDoctorsData.GetAllDoctors();
        }
        public static clsDoctor FindByLicenseNumber(string LicenseNumber)
        {
            int DoctorID = -1;
            int PersonID = -1;
            int SpecialtyID = -1;
            DateTime HireDate = DateTime.Now;
            bool IsActive = true;
            bool IsFound = clsDoctorsData.GetDoctorByLicenseNumber(LicenseNumber,
                                                                   ref DoctorID,
                                                                   ref PersonID,
                                                                   ref SpecialtyID,
                                                                   ref HireDate,
                                                                   ref IsActive);

            if (IsFound)
                return new clsDoctor(DoctorID, PersonID, SpecialtyID, LicenseNumber, HireDate, IsActive);
            else
                return null;
        }
        public static bool ExistsByLicenseNumber(string LicenseNumber)
        {
            return clsDoctorsData.IsDoctorExistsByLicenseNumber(LicenseNumber);
        }
    }
}