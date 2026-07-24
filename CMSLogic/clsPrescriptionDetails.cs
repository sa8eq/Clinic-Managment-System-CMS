using System;
using System.Collections.Generic;
using System.Data;
using CMSData;

namespace CMSLogic
{
    public class clsPrescriptionDetails
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PrescriptionDetailID { get; set; }
        public int PrescriptionID { get; set; }
        public int MedicineID { get; set; }

        public clsMedicine MedicineInfo { get; set; }

        public string Dosage { get; set; }
        public string Duration { get; set; }

        public clsPrescriptionDetails()
        {
            this.PrescriptionDetailID = -1;
            this.PrescriptionID = -1;
            this.MedicineID = -1;
            this.MedicineInfo = null;
            this.Dosage = string.Empty;
            this.Duration = string.Empty;
            this.Mode = enMode.AddNew;
        }

        public clsPrescriptionDetails(int prescriptionDetailID, int prescriptionID, int medicineID, string dosage, string duration)
        {
            this.PrescriptionDetailID = prescriptionDetailID;
            this.PrescriptionID = prescriptionID;
            this.MedicineID = medicineID;
            this.MedicineInfo = clsMedicine.Find(medicineID); 
            this.Dosage = dosage;
            this.Duration = duration;
            this.Mode = enMode.Update;
        }

        private bool _AddNewPrescriptionDetail()
        {
            return clsPrescriptionDetailsData.AddPrescriptionDetail(this.PrescriptionID, this.MedicineID, this.Dosage, this.Duration);
        }

        private bool _UpdatePrescriptionDetail()
        {
            return clsPrescriptionDetailsData.UpdatePrescriptionDetail(this.PrescriptionDetailID, this.PrescriptionID, this.MedicineID, this.Dosage, this.Duration);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPrescriptionDetail())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdatePrescriptionDetail();
            }
            return false;
        }

        public static List<clsPrescriptionDetails> GetPrescriptionDetailsByPrescriptionID(int prescriptionID)
        {
            List<clsPrescriptionDetails> listDetails = new List<clsPrescriptionDetails>();

            DataTable dt = clsPrescriptionDetailsData.GetPrescriptionDetailsByPrescriptionID(prescriptionID);

            foreach (DataRow row in dt.Rows)
            {
                listDetails.Add(new clsPrescriptionDetails(
                    Convert.ToInt32(row["PrescriptionDetailID"]),
                    Convert.ToInt32(row["PrescriptionID"]),
                    Convert.ToInt32(row["MedicineID"]),
                    row["Dosage"].ToString(),
                    row["Duration"].ToString()
                ));
            }

            return listDetails;
        }

        public static bool Delete(int prescriptionDetailID)
        {
            return clsPrescriptionDetailsData.DeletePrescriptionDetail(prescriptionDetailID);
        }

        public static DataTable GetAllPrescriptionDetails()
        {
            return clsPrescriptionDetailsData.GetAllPrescriptionDetails();
        }
    }
}