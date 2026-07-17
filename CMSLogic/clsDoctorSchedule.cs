using CMSData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLogic
{
    public class clsDoctorSchedule
    {

        public int ScheduleID { get; set; }
        public int DoctorID { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public clsDoctorSchedule()
        {
            this.ScheduleID = -1;
            this.DoctorID = -1;
            this.DayOfWeek = -1;
            this.StartTime = TimeSpan.Zero;
            this.EndTime = TimeSpan.Zero;
        }

        public bool Save()
        {
            return clsDoctorScheduleData.AddDoctorSchedule(this.DoctorID, this.DayOfWeek, this.StartTime, this.EndTime);
        }

        public static DataTable GetDoctorSchedule(int doctorID)
        {
            return clsDoctorScheduleData.GetDoctorScheduleByDoctorID(doctorID);
        }

        public static bool DeleteSchedulesByDoctorID(int doctorID)
        {
            return clsDoctorScheduleData.DeleteDoctorSchedulesByDoctorID(doctorID);
        }
    }
    
}
