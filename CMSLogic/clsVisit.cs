using CMSData;
using System;
using System.Data;

namespace CMSLogic
{
    public class clsVisit
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int VisitID { get; set; }
        public int AppointmentID { get; set; }
        public DateTime VisitDate { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string VitalSigns_BP { get; set; }
        public int? VitalSigns_Pulse { get; set; }
        public decimal? VitalSigns_Temp { get; set; }

        public clsAppointment AppointmentInfo { get; set; }

        public clsVisit()
        {
            this.VisitID = -1;
            this.AppointmentID = -1;
            this.VisitDate = DateTime.Now;
            this.Symptoms = "";
            this.Diagnosis = "";
            this.VitalSigns_BP = "";
            this.VitalSigns_Pulse = null;
            this.VitalSigns_Temp = null;

            Mode = enMode.AddNew;
        }

        private clsVisit(int visitID, int appointmentID, DateTime visitDate, string symptoms,
            string diagnosis, string vitalSigns_BP, int? vitalSigns_Pulse, decimal? vitalSigns_Temp)
        {
            this.VisitID = visitID;
            this.AppointmentID = appointmentID;
            this.VisitDate = visitDate;
            this.Symptoms = symptoms;
            this.Diagnosis = diagnosis;
            this.VitalSigns_BP = vitalSigns_BP;
            this.VitalSigns_Pulse = vitalSigns_Pulse;
            this.VitalSigns_Temp = vitalSigns_Temp;

            this.AppointmentInfo = clsAppointment.Find(appointmentID);

            Mode = enMode.Update;
        }

        private bool _AddNewVisit()
        {
            this.VisitID = clsVisitsData.AddNewVisit(
                this.AppointmentID,
                this.VisitDate,
                this.Symptoms,
                this.Diagnosis,
                this.VitalSigns_BP,
                this.VitalSigns_Pulse,
                this.VitalSigns_Temp
            );

            return (this.VisitID != -1);
        }

        private bool _UpdateVisit()
        {
            return clsVisitsData.UpdateVisit(
                this.VisitID,
                this.AppointmentID,
                this.VisitDate,
                this.Symptoms,
                this.Diagnosis,
                this.VitalSigns_BP,
                this.VitalSigns_Pulse,
                this.VitalSigns_Temp
            );
        }

        public static clsVisit Find(int visitID)
        {
            int appointmentID = -1;
            DateTime visitDate = DateTime.Now;
            string symptoms = "";
            string diagnosis = "";
            string vitalSigns_BP = "";
            int? vitalSigns_Pulse = null;
            decimal? vitalSigns_Temp = null;

            bool isFound = clsVisitsData.GetVisitInfoByID(
                visitID,
                ref appointmentID,
                ref visitDate,
                ref symptoms,
                ref diagnosis,
                ref vitalSigns_BP,
                ref vitalSigns_Pulse,
                ref vitalSigns_Temp
            );

            if (isFound)
            {
                return new clsVisit(visitID, appointmentID, visitDate, symptoms, diagnosis, vitalSigns_BP, vitalSigns_Pulse, vitalSigns_Temp);
            }
            else
            {
                return null;
            }
        }

        public static clsVisit FindByAppointmentID(int appointmentID)
        {
            int visitID = -1;
            DateTime visitDate = DateTime.Now;
            string symptoms = "";
            string diagnosis = "";
            string vitalSigns_BP = "";
            int? vitalSigns_Pulse = null;
            decimal? vitalSigns_Temp = null;

            bool isFound = clsVisitsData.GetVisitInfoByAppointmentID(
                appointmentID,
                ref visitID,
                ref visitDate,
                ref symptoms,
                ref diagnosis,
                ref vitalSigns_BP,
                ref vitalSigns_Pulse,
                ref vitalSigns_Temp
            );

            if (isFound)
            {
                return new clsVisit(visitID, appointmentID, visitDate, symptoms, diagnosis, vitalSigns_BP, vitalSigns_Pulse, vitalSigns_Temp);
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
                    if (_AddNewVisit())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateVisit();
            }
            return false;
        }

        public static DataTable GetAllVisits()
        {
            return clsVisitsData.GetAllVisits();
        }

        public static bool DeleteVisit(int visitID)
        {
            return clsVisitsData.DeleteVisit(visitID);
        }
    }
}