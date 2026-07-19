using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSData
{
    public class clsInvoicesData
    {
        public static int AddNewInvoice(int? visitID, int? appointmentID, DateTime invoiceDate,
            decimal totalAmount, decimal insuranceCoverAmount, decimal patientShareAmount, string paymentStatus)
        {
            int invoiceID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@VisitID", (object)visitID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AppointmentID", (object)appointmentID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@InvoiceDate", invoiceDate);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@InsuranceCoverAmount", insuranceCoverAmount);
                    command.Parameters.AddWithValue("@PatientShareAmount", patientShareAmount);
                    command.Parameters.AddWithValue("@PaymentStatus", paymentStatus);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            invoiceID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return invoiceID;
        }

        public static bool UpdateInvoice(int invoiceID, int? visitID, int? appointmentID, DateTime invoiceDate,
            decimal totalAmount, decimal insuranceCoverAmount, decimal patientShareAmount, string paymentStatus)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    command.Parameters.AddWithValue("@VisitID", (object)visitID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AppointmentID", (object)appointmentID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@InvoiceDate", invoiceDate);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@InsuranceCoverAmount", insuranceCoverAmount);
                    command.Parameters.AddWithValue("@PatientShareAmount", patientShareAmount);
                    command.Parameters.AddWithValue("@PaymentStatus", paymentStatus);

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

        public static bool GetInvoiceByID(int invoiceID, ref int? visitID, ref int? appointmentID, ref DateTime invoiceDate,
            ref decimal totalAmount, ref decimal insuranceCoverAmount, ref decimal patientShareAmount, ref string paymentStatus)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetInvoiceByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InvoiceID", invoiceID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                visitID = reader["VisitID"] != DBNull.Value ? (int?)reader["VisitID"] : null;
                                appointmentID = reader["AppointmentID"] != DBNull.Value ? (int?)reader["AppointmentID"] : null;
                                invoiceDate = (DateTime)reader["InvoiceDate"];
                                totalAmount = (decimal)reader["TotalAmount"];
                                insuranceCoverAmount = (decimal)reader["InsuranceCoverAmount"];
                                patientShareAmount = (decimal)reader["PatientShareAmount"];
                                paymentStatus = reader["PaymentStatus"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static DataTable GetAllInvoices()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllInvoices", connection))
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
                        throw new Exception(ex.Message);
                    }
                }
            }

            return dt;
        }

        public static bool DeleteInvoice(int invoiceID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InvoiceID", invoiceID);

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

        public static bool GetInvoiceByAppointmentID(int appointmentID, ref int invoiceID, ref int? visitID, ref DateTime invoiceDate, ref decimal totalAmount, ref decimal insuranceCoverAmount, ref decimal patientShareAmount, ref string paymentStatus)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Invoices WHERE AppointmentID = @AppointmentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentID", appointmentID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                invoiceID = (int)reader["InvoiceID"];
                                visitID = reader["VisitID"] != DBNull.Value ? (int?)reader["VisitID"] : null;
                                invoiceDate = (DateTime)reader["InvoiceDate"];
                                totalAmount = (decimal)reader["TotalAmount"];
                                insuranceCoverAmount = (decimal)reader["InsuranceCoveredAmount"];
                                patientShareAmount = (decimal)reader["PatientShareAmount"];
                                paymentStatus = reader["PaymentStatus"].ToString();
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            return isFound;
        }
    }
}

