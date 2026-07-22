using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSData
{
    public class clsVisitsData
    {
        public static bool GetVisitInfoByID(int visitID, ref int appointmentID, ref DateTime visitDate,
            ref string symptoms, ref string diagnosis, ref string vitalSigns_BP, ref int? vitalSigns_Pulse, ref decimal? vitalSigns_Temp)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SP_GetVisitByID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@VisitID", visitID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                appointmentID = (int)reader["AppointmentID"];
                                visitDate = (DateTime)reader["VisitDate"];

                                symptoms = reader["Symptoms"] == DBNull.Value ? "" : (string)reader["Symptoms"];
                                diagnosis = reader["Diagnosis"] == DBNull.Value ? "" : (string)reader["Diagnosis"];
                                vitalSigns_BP = reader["VitalSigns_BP"] == DBNull.Value ? "" : (string)reader["VitalSigns_BP"];

                                vitalSigns_Pulse = reader["VitalSigns_Pulse"] == DBNull.Value ? (int?)null : (int)reader["VitalSigns_Pulse"];
                                vitalSigns_Temp = reader["VitalSigns_Temp"] == DBNull.Value ? (decimal?)null : (decimal)reader["VitalSigns_Temp"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }
        public static int AddNewVisit(int appointmentID, DateTime visitDate, string symptoms,
            string diagnosis, string vitalSigns_BP, int? vitalSigns_Pulse, decimal? vitalSigns_Temp)
        {
            int visitID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SP_AddNewVisit";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AppointmentID", appointmentID);
                    command.Parameters.AddWithValue("@VisitDate", visitDate);

                    command.Parameters.AddWithValue("@Symptoms", string.IsNullOrEmpty(symptoms) ? (object)DBNull.Value : symptoms);
                    command.Parameters.AddWithValue("@Diagnosis", string.IsNullOrEmpty(diagnosis) ? (object)DBNull.Value : diagnosis);
                    command.Parameters.AddWithValue("@VitalSigns_BP", string.IsNullOrEmpty(vitalSigns_BP) ? (object)DBNull.Value : vitalSigns_BP);

                    command.Parameters.AddWithValue("@VitalSigns_Pulse", vitalSigns_Pulse.HasValue ? (object)vitalSigns_Pulse.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@VitalSigns_Temp", vitalSigns_Temp.HasValue ? (object)vitalSigns_Temp.Value : DBNull.Value);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            visitID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        visitID = -1;
                    }
                }
            }

            return visitID;
        }
        public static bool UpdateVisit(int visitID, int appointmentID, DateTime visitDate, string symptoms,
            string diagnosis, string vitalSigns_BP, int? vitalSigns_Pulse, decimal? vitalSigns_Temp)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SP_UpdateVisit";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@VisitID", visitID);
                    command.Parameters.AddWithValue("@AppointmentID", appointmentID);
                    command.Parameters.AddWithValue("@VisitDate", visitDate);

                    command.Parameters.AddWithValue("@Symptoms", string.IsNullOrEmpty(symptoms) ? (object)DBNull.Value : symptoms);
                    command.Parameters.AddWithValue("@Diagnosis", string.IsNullOrEmpty(diagnosis) ? (object)DBNull.Value : diagnosis);
                    command.Parameters.AddWithValue("@VitalSigns_BP", string.IsNullOrEmpty(vitalSigns_BP) ? (object)DBNull.Value : vitalSigns_BP);

                    command.Parameters.AddWithValue("@VitalSigns_Pulse", vitalSigns_Pulse.HasValue ? (object)vitalSigns_Pulse.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@VitalSigns_Temp", vitalSigns_Temp.HasValue ? (object)vitalSigns_Temp.Value : DBNull.Value);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        rowsAffected = 0;
                    }
                }
            }

            return (rowsAffected > 0);
        }
        public static bool DeleteVisit(int visitID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SP_DeleteVisit";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@VisitID", visitID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        rowsAffected = 0;
                    }
                }
            }

            return (rowsAffected > 0);
        }
        public static DataTable GetAllVisits()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SP_GetAllVisits";

                using (SqlCommand command = new SqlCommand(query, connection))
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
                        // يمكن إضافة تتبع للخطأ هنا
                    }
                }
            }

            return dt;
        }
        public static bool GetVisitInfoByAppointmentID(int appointmentID, ref int visitID, ref DateTime visitDate,
            ref string symptoms, ref string diagnosis, ref string vitalSigns_BP, ref int? vitalSigns_Pulse, ref decimal? vitalSigns_Temp)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SP_GetVisitByAppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AppointmentID", appointmentID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                visitID = (int)reader["VisitID"];
                                visitDate = (DateTime)reader["VisitDate"];

                                symptoms = reader["Symptoms"] == DBNull.Value ? "" : (string)reader["Symptoms"];
                                diagnosis = reader["Diagnosis"] == DBNull.Value ? "" : (string)reader["Diagnosis"];
                                vitalSigns_BP = reader["VitalSigns_BP"] == DBNull.Value ? "" : (string)reader["VitalSigns_BP"];

                                vitalSigns_Pulse = reader["VitalSigns_Pulse"] == DBNull.Value ? (int?)null : (int)reader["VitalSigns_Pulse"];
                                vitalSigns_Temp = reader["VitalSigns_Temp"] == DBNull.Value ? (decimal?)null : (decimal)reader["VitalSigns_Temp"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }
    }
}