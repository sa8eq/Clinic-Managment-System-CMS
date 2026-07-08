using System;
using System.Data;
using CMSData;

namespace CMSLogic
{
    public class clsPatient
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PatientID { get; set; }
        public int PersonID { get; set; }
        public string BloodType { get; set; }
        public int? InsuranceCompanyID { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public string EmergencyContactPhone { get; set; }

        public clsPerson PersonInfo { get; set; }
        public string FullName
        {
            get
            {
                return (PersonInfo != null) ? PersonInfo.FullName : "";
            }
        }
        public clsInsuranceCompany InsuranceCompanyInfo { get; set; }
        public string InsuranceCompanyName
        {
            get
            {
                return (InsuranceCompanyInfo != null) ? InsuranceCompanyInfo.CompanyName : "";
            }
        }
        public clsPatient()
        {
            this.PatientID = -1;
            this.PersonID = -1;
            this.BloodType = "";
            this.InsuranceCompanyID = null;
            this.InsurancePolicyNumber = "";
            this.EmergencyContactPhone = "";

            this.PersonInfo = new clsPerson();
            this.InsuranceCompanyInfo = null; 

            Mode = enMode.AddNew;
        }

        private clsPatient(int PatientID, int PersonID, string BloodType,
                           int? InsuranceCompanyID, string InsurancePolicyNumber, string EmergencyContactPhone)
        {
            this.PatientID = PatientID;
            this.PersonID = PersonID;
            this.BloodType = BloodType;
            this.InsuranceCompanyID = InsuranceCompanyID;
            this.InsurancePolicyNumber = InsurancePolicyNumber;
            this.EmergencyContactPhone = EmergencyContactPhone;

            this.PersonInfo = clsPerson.Find(PersonID);

            if (this.InsuranceCompanyID.HasValue)
            {
                this.InsuranceCompanyInfo = clsInsuranceCompany.Find(this.InsuranceCompanyID.Value);
            }
            else
            {
                this.InsuranceCompanyInfo = null;
            }

            Mode = enMode.Update;
        }

        private bool _AddNewPatient()
        {
            this.PatientID = clsPatientsData.AddNewPatient(this.PersonID, this.BloodType, this.InsuranceCompanyID, this.InsurancePolicyNumber, this.EmergencyContactPhone);
            return (this.PatientID != -1);
        }

        private bool _UpdatePatient()
        {
            return clsPatientsData.UpdatePatient(this.PatientID, this.PersonID, this.BloodType, this.InsuranceCompanyID, this.InsurancePolicyNumber, this.EmergencyContactPhone);
        }

        public static clsPatient Find(int PatientID)
        {
            int PersonID = -1;
            int? InsuranceCompanyID = null;
            string BloodType = "", InsurancePolicyNumber = "", EmergencyContactPhone = "";

            bool isFound = clsPatientsData.GetPatientByID(PatientID, ref PersonID, ref BloodType, ref InsuranceCompanyID, ref InsurancePolicyNumber, ref EmergencyContactPhone);

            if (isFound)
                return new clsPatient(PatientID, PersonID, BloodType, InsuranceCompanyID, InsurancePolicyNumber, EmergencyContactPhone);
            else
                return null;
        }

        public bool Save()
        {
            if (!this.PersonInfo.Save())
                return false;

            this.PersonID = this.PersonInfo.PersonID;

            if (this.InsuranceCompanyID == null)
                this.InsuranceCompanyInfo = null; 
            
            if (this.InsuranceCompanyInfo != null)
                this.InsuranceCompanyID = this.InsuranceCompanyInfo.InsuranceCompanyID;

            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPatient())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdatePatient();
            }

            return false;
        }

        public static bool Delete(int PatientID)
        {
            return clsPatientsData.DeletePatient(PatientID);
        }

        public static DataTable GetAllPatients()
        {
            return clsPatientsData.GetAllPatients();
        }

        public static clsPatient FindByPersonID(int PersonID)
        {
            int PatientID = -1;
            int? InsuranceCompanyID = null;
            string BloodType = "", InsurancePolicyNumber = "", EmergencyContactPhone = "";

            bool IsFound = clsPatientsData.GetPatientByPersonID(PersonID,
                ref PatientID,
                ref BloodType,
                ref InsuranceCompanyID,
                ref InsurancePolicyNumber,
                ref EmergencyContactPhone);

            if (IsFound)
                return new clsPatient(PatientID, PersonID, BloodType,
                    InsuranceCompanyID, InsurancePolicyNumber, EmergencyContactPhone);
            else
                return null;
        }

        public static clsPatient FindByInsurancePolicyNumber(string InsurancePolicyNumber)
        {
            int PatientID = -1;
            int PersonID = -1;
            int? InsuranceCompanyID = null;
            string BloodType = "", EmergencyContactPhone = "";

            bool IsFound = clsPatientsData.GetPatientByInsurancePolicyNumber(
                InsurancePolicyNumber,
                ref PatientID,
                ref PersonID,
                ref BloodType,
                ref InsuranceCompanyID,
                ref EmergencyContactPhone);

            if (IsFound)
                return new clsPatient(PatientID, PersonID, BloodType,
                    InsuranceCompanyID, InsurancePolicyNumber, EmergencyContactPhone);
            else
                return null;
        }

        public static bool ExistsByPersonID(int PersonID)
        {
            return clsPatientsData.IsPatientExistsByPersonID(PersonID);
        }

        public static bool ExistsByInsurancePolicyNumber(string InsurancePolicyNumber)
        {
            return clsPatientsData.IsPatientExistsByInsurancePolicyNumber(InsurancePolicyNumber);
        }
    }
}
