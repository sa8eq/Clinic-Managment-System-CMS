using CMSData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLogic
{
    public class clsAppointment
    {
        public enum enStatus
        {
            Pending = 0,
            Completed = 1,
            Cancelled = 2,
            NoShow = 3
        }

        public enum Mode { AddNew = 0, Update = 1 }
        private Mode _mode = Mode.AddNew;

        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int UserID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public enStatus Status { get; set; }
        public string Notes { get; set; }

        public int SelectedServiceID { get; set; } = -1;

        public clsPatient PatientInfo { get; private set; }
        public clsDoctor DoctorInfo { get; private set; }

        public clsMedicalService SelectedServiceInfo
        {
            get
            {
                if (SelectedServiceID == -1) return null;
                return clsMedicalService.Find(SelectedServiceID);
            }
        }

        public clsInvoice InvoiceInfo { get; set; }

        public clsAppointment()
        {
            this.AppointmentID = -1;
            this.PatientID = -1;
            this.DoctorID = -1;
            this.UserID = -1;
            this.AppointmentDate = DateTime.Now;
            this.Status = enStatus.Pending;
            this.Notes = "";

            this.SelectedServiceID = -1;
            this.PatientInfo = null;
            this.DoctorInfo = null;
            this.InvoiceInfo = null;

            _mode = Mode.AddNew;
        }

        private clsAppointment(int appointmentID, int patientID, int doctorID, int userID, DateTime appointmentDate, enStatus status, string notes)
        {
            this.AppointmentID = appointmentID;
            this.PatientID = patientID;
            this.DoctorID = doctorID;
            this.UserID = userID;
            this.AppointmentDate = appointmentDate;
            this.Status = status;
            this.Notes = notes;

            this.PatientInfo = clsPatient.Find(patientID);
            this.DoctorInfo = clsDoctor.Find(doctorID);
            this.InvoiceInfo = clsInvoice.FindInvoiceByAppointmentID(appointmentID);

            if (this.InvoiceInfo != null && this.InvoiceInfo.InvoiceDetailsList != null && this.InvoiceInfo.InvoiceDetailsList.Rows.Count > 0)
            {
                this.SelectedServiceID = Convert.ToInt32(this.InvoiceInfo.InvoiceDetailsList.Rows[0]["ServiceID"]);
            }

            _mode = Mode.Update;
        }

        public static clsAppointment Find(int appointmentID)
        {
            int patientID = -1;
            int doctorID = -1;
            int userID = -1;
            DateTime appointmentDate = DateTime.Now;
            string statusText = "";
            string notes = "";

            bool isFound = clsAppointmentsData.GetAppointmentByID(
                appointmentID, ref patientID, ref doctorID, ref userID, ref appointmentDate, ref statusText, ref notes);

            if (isFound)
            {
                enStatus status = (enStatus)Enum.Parse(typeof(enStatus), statusText);
                return new clsAppointment(appointmentID, patientID, doctorID, userID, appointmentDate, status, notes);
            }
            return null;
        }

        private bool _AddNew()
        {
            this.AppointmentID = clsAppointmentsData.AddNewAppointment(
                this.PatientID, this.DoctorID, this.UserID, this.AppointmentDate, this.Status.ToString(), this.Notes);

            return (this.AppointmentID != -1);
        }

        private bool _Update()
        {
            return clsAppointmentsData.UpdateAppointment(
                this.AppointmentID, this.PatientID, this.DoctorID, this.UserID, this.AppointmentDate, this.Status.ToString(), this.Notes);
        }

        public bool Save()
        {
            switch (_mode)
            {
                case Mode.AddNew:
                    if (_AddNew())
                    {
                        this.PatientInfo = clsPatient.Find(this.PatientID);
                        this.DoctorInfo = clsDoctor.Find(this.DoctorID);

                        _mode = Mode.Update;
                        return true;
                    }
                    return false;

                case Mode.Update:
                    if (_Update())
                    {
                        this.PatientInfo = clsPatient.Find(this.PatientID);
                        this.DoctorInfo = clsDoctor.Find(this.DoctorID);
                        return true;
                    }
                    return false;
            }
            return false;
        }

        public static DataTable GetAllAppointments()
        {
            return clsAppointmentsData.GetAllAppointments();
        }

        public static bool CheckAppointmentConflict(int doctorID, DateTime appointmentDate, int excludeAppointmentID = -1)
        {
            return clsAppointmentsData.CheckAppointmentConflict(doctorID, appointmentDate, excludeAppointmentID);
        }

        public static List<string> GetBookedSlotsForDoctor(int doctorID, DateTime appointmentDate)
        {
            return clsAppointmentsData.GetBookedSlotsForDoctor(doctorID, appointmentDate);
        }
    }
}