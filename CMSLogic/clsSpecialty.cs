using CMSData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLogic
{
    public class clsSpecialty
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int SpecialtyID { get; private set; }
        public string SpecialtyName { get; set; }
        public string Description { get; set; }

        public clsSpecialty()
        {
            this.SpecialtyID = -1;
            this.SpecialtyName = "";
            this.Description = "";

            Mode = enMode.AddNew;
        }

        private clsSpecialty(int specialtyID, string specialtyName, string description)
        {
            this.SpecialtyID = specialtyID;
            this.SpecialtyName = specialtyName;
            this.Description = description;

            Mode = enMode.Update;
        }

        public static clsSpecialty Find(int specialtyID)
        {
            string specialtyName = "";
            string description = "";

            if (clsSpecialtiesData.GetSpecialtyByID(specialtyID, ref specialtyName, ref description))
            {
                return new clsSpecialty(specialtyID, specialtyName, description);
            }
            else
            {
                return null; 
            }
        }

        private bool _AddNewSpecialty()
        {
            this.SpecialtyID = clsSpecialtiesData.AddNewSpecialty(this.SpecialtyName, this.Description);
            return (this.SpecialtyID != -1);
        }

        private bool _UpdateSpecialty()
        {
            return clsSpecialtiesData.UpdateSpecialty(this.SpecialtyID, this.SpecialtyName, this.Description);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSpecialty())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateSpecialty();
            }

            return false;
        }

        public static DataTable GetAllSpecialties()
        {
            return clsSpecialtiesData.GetAllSpecialties();
        }

        public static bool DeleteSpecialty(int specialtyID)
        {
            return clsSpecialtiesData.DeleteSpecialty(specialtyID);
        }
    }
}
