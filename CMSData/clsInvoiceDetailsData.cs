using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSData
{
    public class clsInvoiceDetailsData
    {
        public static int AddNewInvoiceDetail(int invoiceID, int serviceID, int quantity, decimal price)
        {
            int invoiceDetailID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewInvoiceDetail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    command.Parameters.AddWithValue("@ServiceID", serviceID);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            invoiceDetailID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                    }
                }
            }

            return invoiceDetailID;
        }

        public static bool UpdateInvoiceDetail(int invoiceDetailID, int invoiceID, int serviceID, int quantity, decimal price)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateInvoiceDetail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@InvoiceDetailID", invoiceDetailID);
                    command.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    command.Parameters.AddWithValue("@ServiceID", serviceID);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetInvoiceDetailsByInvoiceID(int invoiceID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetInvoiceDetailsByInvoiceID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InvoiceID", invoiceID);

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
                        // Handle exception
                    }
                }
            }

            return dt;
        }

        public static bool DeleteInvoiceDetail(int invoiceDetailID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteInvoiceDetail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InvoiceDetailID", invoiceDetailID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }
    }
}
