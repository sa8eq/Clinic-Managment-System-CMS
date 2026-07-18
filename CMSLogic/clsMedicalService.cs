using CMSData;
using System.Data;

namespace CMSLogic
{
    public class clsMedicalService
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public int? SpecialtyID { get; set; }
        public clsMedicalService()
        {
            this.ServiceID = -1;
            this.ServiceName = "";
            this.Price = 0.00m;
            this.SpecialtyID = null;

            Mode = enMode.AddNew;
        }
        private clsMedicalService(int serviceID, string serviceName, decimal price, int? specialtyID)
        {
            this.ServiceID = serviceID;
            this.ServiceName = serviceName;
            this.Price = price;
            this.SpecialtyID = specialtyID;

            Mode = enMode.Update;
        }
        private bool _AddNew()
        {
            this.ServiceID = clsMedicalServicesData.AddNewMedicalService(this.ServiceName, this.Price, this.SpecialtyID);
            return (this.ServiceID != -1);
        }
        private bool _Update()
        {
            return clsMedicalServicesData.UpdateMedicalService(this.ServiceID, this.ServiceName, this.Price, this.SpecialtyID);
        }
        public static clsMedicalService Find(int serviceID)
        {
            string serviceName = "";
            decimal price = 0.00m;
            int? specialtyID = null;

            bool isFound = clsMedicalServicesData.GetMedicalServiceByID(serviceID, ref serviceName, ref price, ref specialtyID);

            if (isFound)
            {
                return new clsMedicalService(serviceID, serviceName, price, specialtyID);
            }
            else
            {
                return null;
            }
        }
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
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }

            return false;
        }
        public static DataTable GetMedicalServicesBySpecialty(int? specialtyID)
        {
            return clsMedicalServicesData.GetMedicalServicesBySpecialty(specialtyID);
        }
        public static bool DeleteMedicalService(int serviceID)
        {
            return clsMedicalServicesData.DeleteMedicalService(serviceID);
        }
        public static DataTable GetAllMedicalServices()
        {
            return clsMedicalServicesData.GetAllMedicalServices();
        }
    }
}