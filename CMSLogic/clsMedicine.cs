using System;
using System.Data;
using CMSData; 

namespace CMSLogic
{
    public class clsMedicine
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public string ActiveIngredient { get; set; }
        public string Form { get; set; }

        public clsMedicine()
        {
            this.MedicineID = -1;
            this.MedicineName = string.Empty;
            this.ActiveIngredient = string.Empty;
            this.Form = string.Empty;
            this.Mode = enMode.AddNew;
        }
        private clsMedicine(int medicineID, string medicineName, string activeIngredient, string form)
        {
            this.MedicineID = medicineID;
            this.MedicineName = medicineName;
            this.ActiveIngredient = activeIngredient;
            this.Form = form;
            this.Mode = enMode.Update;
        }
        private bool _AddNewMedicine()
        {
            this.MedicineID = clsMedicinesData.AddNewMedicine(this.MedicineName, this.ActiveIngredient, this.Form);
            return (this.MedicineID != -1);
        }
        private bool _UpdateMedicine()
        {
            return clsMedicinesData.UpdateMedicine(this.MedicineID, this.MedicineName, this.ActiveIngredient, this.Form);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMedicine())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMedicine();
            }
            return false;
        }
        public static clsMedicine Find(int medicineID)
        {
            string medicineName = string.Empty;
            string activeIngredient = string.Empty;
            string form = string.Empty;

            bool isFound = clsMedicinesData.GetMedicineInfoByID(medicineID, ref medicineName, ref activeIngredient, ref form);

            if (isFound)
            {
                return new clsMedicine(medicineID, medicineName, activeIngredient, form);
            }
            else
            {
                return null;
            }
        }
        public static bool Delete(int medicineID)
        {
            return clsMedicinesData.DeleteMedicine(medicineID);
        }
        public static DataTable GetAllMedicines()
        {
            return clsMedicinesData.GetAllMedicines();
        }
    }
}
