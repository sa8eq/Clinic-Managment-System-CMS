using System;
using System.Data;
using CMSData;

namespace CMSLogic
{
    public class clsInsuranceCompany
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int InsuranceCompanyID { get; set; }
        public string CompanyName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public decimal CoveragePercentage { get; set; }

        // المشيد الافتراضي
        public clsInsuranceCompany()
        {
            this.InsuranceCompanyID = -1;
            this.CompanyName = "";
            this.ContactPhone = "";
            this.ContactEmail = "";
            this.CoveragePercentage = 0.00m;

            Mode = enMode.AddNew;
        }

        // المشيد الخاص
        private clsInsuranceCompany(int InsuranceCompanyID, string CompanyName, string ContactPhone, string ContactEmail, decimal CoveragePercentage)
        {
            this.InsuranceCompanyID = InsuranceCompanyID;
            this.CompanyName = CompanyName;
            this.ContactPhone = ContactPhone;
            this.ContactEmail = ContactEmail;
            this.CoveragePercentage = CoveragePercentage;

            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.InsuranceCompanyID = clsInsuranceCompaniesData.AddNewInsuranceCompany(this.CompanyName, this.ContactPhone, this.ContactEmail, this.CoveragePercentage);
            return (this.InsuranceCompanyID != -1);
        }

        private bool _Update()
        {
            return clsInsuranceCompaniesData.UpdateInsuranceCompany(this.InsuranceCompanyID, this.CompanyName, this.ContactPhone, this.ContactEmail, this.CoveragePercentage);
        }

        // دالة البحث واسترجاع الكائن
        public static clsInsuranceCompany Find(int InsuranceCompanyID)
        {
            string CompanyName = "", ContactPhone = "", ContactEmail = "";
            decimal CoveragePercentage = 0.00m;

            bool isFound = clsInsuranceCompaniesData.GetInsuranceCompanyByID(InsuranceCompanyID, ref CompanyName, ref ContactPhone, ref ContactEmail, ref CoveragePercentage);

            if (isFound)
                return new clsInsuranceCompany(InsuranceCompanyID, CompanyName, ContactPhone, ContactEmail, CoveragePercentage);
            else
                return null;
        }

        // دالة الحفظ الذكية
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static bool Delete(int InsuranceCompanyID)
        {
            return clsInsuranceCompaniesData.DeleteInsuranceCompany(InsuranceCompanyID);
        }

        public static DataTable GetAllInsuranceCompanies()
        {
            return clsInsuranceCompaniesData.GetAllInsuranceCompanies();
        }

        public static clsInsuranceCompany FindByCompanyName(string CompanyName)
        {
            int InsuranceCompanyID = -1;
            string ContactPhone = "", ContactEmail = "";
            decimal CoveragePercentage = 0.00m;

            bool IsFound = clsInsuranceCompaniesData.GetInsuranceCompanyByName(CompanyName,
                                                                               ref InsuranceCompanyID,
                                                                               ref ContactPhone,
                                                                               ref ContactEmail,
                                                                               ref CoveragePercentage);

            if (IsFound)
                return new clsInsuranceCompany(InsuranceCompanyID,
                                               CompanyName,
                                               ContactPhone,
                                               ContactEmail,
                                               CoveragePercentage);
            else
                return null;
        }

        public static bool ExistsByCompanyName(string CompanyName)
        {
            return clsInsuranceCompaniesData.IsInsuranceCompanyExistsByName(CompanyName);
        }
    }
}
