using System;
using System.Data;
using CMSData;

namespace CMSLogic
{
    public class clsPatient
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        // الخصائص الخاصة بجدول المرضى
        public int PatientID { get; set; }
        public int PersonID { get; set; }
        public string BloodType { get; set; }
        public int? InsuranceCompanyID { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public string EmergencyContactPhone { get; set; }

        // 1. الـ Composition الإلزامي (بيانات الشخص الأساسية)
        public clsPerson PersonInfo { get; set; }
        public string FullName
        {
            get
            {
                return (PersonInfo != null) ? PersonInfo.FullName : "";
            }
        }
        // 2. الـ Composition الاختياري (بيانات شركة التأمين)
        // افترضنا هنا وجود كلاس بزنس لشركات التأمين اسمه clsInsuranceCompany
        public clsInsuranceCompany InsuranceCompanyInfo { get; set; }
        public string InsuranceCompanyName
        {
            get
            {
                return (InsuranceCompanyInfo != null) ? InsuranceCompanyInfo.CompanyName : "";
            }
        }
        // المشيد الافتراضي - لإضافة مريض جديد
        public clsPatient()
        {
            this.PatientID = -1;
            this.PersonID = -1;
            this.BloodType = "";
            this.InsuranceCompanyID = null;
            this.InsurancePolicyNumber = "";
            this.EmergencyContactPhone = "";

            this.PersonInfo = new clsPerson();
            this.InsuranceCompanyInfo = null; // لا توجد شركة تأمين بعد

            Mode = enMode.AddNew;
        }

        // المشيد الخاص - لجلب بيانات مريض موجود مسبقاً
        private clsPatient(int PatientID, int PersonID, string BloodType,
                           int? InsuranceCompanyID, string InsurancePolicyNumber, string EmergencyContactPhone)
        {
            this.PatientID = PatientID;
            this.PersonID = PersonID;
            this.BloodType = BloodType;
            this.InsuranceCompanyID = InsuranceCompanyID;
            this.InsurancePolicyNumber = InsurancePolicyNumber;
            this.EmergencyContactPhone = EmergencyContactPhone;

            // جلب بيانات الشخص المرتبط بالمريض تلقائياً
            this.PersonInfo = clsPerson.Find(PersonID);

            // جلب بيانات شركة التأمين بذكاء (فقط إذا كان للمريض شركة تأمين)
            if (this.InsuranceCompanyID.HasValue)
            {
                // سيقوم باستدعاء كلاس البزنس الخاص بشركات التأمين لجلب تفاصيلها
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

        // البحث عن مريض بواسطة الـ ID
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

        // حفظ البيانات الشامل (شخص + مريض)
        public bool Save()
        {
            // حفظ بيانات الشخص أولاً
            if (!this.PersonInfo.Save())
                return false;

            // أخذ PersonID الذي تم إنشاؤه أو تحديثه
            this.PersonID = this.PersonInfo.PersonID;

            // في حال اختيار شركة تأمين من الكائن
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
