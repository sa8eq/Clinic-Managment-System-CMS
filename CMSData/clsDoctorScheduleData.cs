using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSData
{
    public class clsDoctorScheduleData
    {
        public static bool AddDoctorSchedule(int doctorID, int dayOfWeek, TimeSpan startTime, TimeSpan endTime)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddDoctorSchadule", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorID;
                    command.Parameters.Add("@DayOfWeek", SqlDbType.Int).Value = dayOfWeek;
                    command.Parameters.Add("@StartTime", SqlDbType.Time).Value = startTime;
                    command.Parameters.Add("@EndTime", SqlDbType.Time).Value = endTime;

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetDoctorScheduleByDoctorID(int doctorID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetDoctorScheduleByDoctorID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorID;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return dt;
        }

        public static bool DeleteDoctorSchedulesByDoctorID(int doctorID)
        {
            bool isDeletedSuccessfully = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteDoctorSchedulesByDoctorID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorID;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        isDeletedSuccessfully = true; // تم التنفيذ بنجاح دون استثناءات (أخطاء)
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            return isDeletedSuccessfully;
        }
    }
}
