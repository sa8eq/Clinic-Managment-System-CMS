using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSData
{
    public class clsAppointmentsData
    {
        public static int AddNewAppointment(int patientID, int doctorID, int userID, DateTime appointmentDate, string status, string notes)
        {
            int appointmentID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddAppointment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;
                    command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorID;
                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                    command.Parameters.Add("@AppointmentDate", SqlDbType.DateTime).Value = appointmentDate;
                    command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value = status;

                    if (string.IsNullOrEmpty(notes))
                        command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = notes;

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            appointmentID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in AddNewAppointment: " + ex.Message);
                    }
                }
            }

            return appointmentID;
        }

        public static bool UpdateAppointment(int appointmentID, int patientID, int doctorID, int userID, DateTime appointmentDate, string status, string notes)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateAppointment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointmentID;
                    command.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;
                    command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorID;
                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                    command.Parameters.Add("@AppointmentDate", SqlDbType.DateTime).Value = appointmentDate;
                    command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value = status;

                    if (string.IsNullOrEmpty(notes))
                        command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = notes;

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in UpdateAppointment: " + ex.Message);
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool GetAppointmentByID(int appointmentID, ref int patientID, ref int doctorID, ref int userID, ref DateTime appointmentDate, ref string status, ref string notes)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAppointmentByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointmentID;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                patientID = (int)reader["PatientID"];
                                doctorID = (int)reader["DoctorID"];
                                userID = (int)reader["UserID"];
                                appointmentDate = (DateTime)reader["AppointmentDate"];
                                status = reader["Status"].ToString();
                                notes = reader["Notes"] == DBNull.Value ? "" : reader["Notes"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in GetAppointmentByID: " + ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static DataTable GetAllAppointments()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllAppointments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

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
                        throw new Exception("Error in GetAllAppointments: " + ex.Message);
                    }
                }
            }

            return dt;
        }

        public static bool CheckAppointmentConflict(int doctorID, DateTime appointmentDate, int excludeAppointmentID = -1)
        {
            bool isConflict = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_CheckAppointmentConflict", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorID;
                    command.Parameters.Add("@AppointmentDate", SqlDbType.DateTime).Value = appointmentDate;
                    command.Parameters.Add("@ExcludeAppointmentID", SqlDbType.Int).Value = excludeAppointmentID;

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && bool.TryParse(result.ToString(), out bool hasConflict))
                        {
                            isConflict = hasConflict;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in CheckAppointmentConflict: " + ex.Message);
                    }
                }
            }

            return isConflict;
        }
    }
}
