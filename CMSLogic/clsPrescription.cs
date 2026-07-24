using System;
using System.Collections.Generic;
using System.Data;
using CMSData;

namespace CMSLogic
{
    public class clsPrescription
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int PrescriptionID { get; set; }
        public int VisitID { get; set; }
        public string Notes { get; set; }
        public List<clsPrescriptionDetails> PrescriptionDetails { get; set; }
        public clsPrescription()
        {
            this.PrescriptionID = -1;
            this.VisitID = -1;
            this.Notes = string.Empty;
            this.PrescriptionDetails = new List<clsPrescriptionDetails>();
            this.Mode = enMode.AddNew;
        }
        private clsPrescription(int prescriptionID, int visitID, string notes)
        {
            this.PrescriptionID = prescriptionID;
            this.VisitID = visitID;
            this.Notes = notes;
            this.PrescriptionDetails = clsPrescriptionDetails.GetPrescriptionDetailsByPrescriptionID(prescriptionID);
            this.Mode = enMode.Update;
        }
        private bool _AddNewPrescription()
        {
            this.PrescriptionID = clsPrescriptionData.AddNewPrescription(this.VisitID, this.Notes);
            return (this.PrescriptionID != -1);
        }
        private bool _UpdatePrescription()
        {
            return clsPrescriptionData.UpdatePrescription(this.PrescriptionID, this.VisitID, this.Notes);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPrescription())
                    {
                        foreach (var detail in PrescriptionDetails)
                        {
                            detail.PrescriptionID = this.PrescriptionID;
                            detail.Save();
                        }

                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    if (_UpdatePrescription())
                    {
                        foreach (var detail in PrescriptionDetails)
                        {
                            detail.PrescriptionID = this.PrescriptionID;
                            detail.Save();
                        }
                        return true;
                    }
                    return false;
            }
            return false;
        }
        public static clsPrescription FindByVisitID(int visitID)
        {
            int prescriptionID = -1;
            string notes = string.Empty;

            bool isFound = clsPrescriptionData.GetPrescriptionInfoByVisitID(visitID, ref prescriptionID, ref notes);

            if (isFound)
            {
                return new clsPrescription(prescriptionID, visitID, notes);
            }
            else
            {
                return null;
            }
        }
        public static bool Delete(int prescriptionID)
        {
            return clsPrescriptionData.DeletePrescription(prescriptionID);
        }
        public static DataTable GetAllPrescriptions()
        {
            return clsPrescriptionData.GetAllPrescriptions();
        }
        public void AddPrescriptionDetail(int medicineID, string dosage, string duration)
        {
            clsPrescriptionDetails detail = new clsPrescriptionDetails();
            detail.MedicineID = medicineID;
            detail.Dosage = dosage;
            detail.Duration = duration;
            detail.MedicineInfo = clsMedicine.Find(medicineID); 
            this.PrescriptionDetails.Add(detail);
        }
    }
}