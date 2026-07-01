using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSData
{
    public static class clsInsuranceCompaniesData
    {
        // 1. جلب بيانات شركة تأمين بواسطة المعرف
        public static bool GetInsuranceCompanyByID(int InsuranceCompanyID, ref string CompanyName,
                                                   ref string ContactPhone, ref string ContactEmail, ref decimal CoveragePercentage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetInsuranceCompanyByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InsuranceCompanyID", InsuranceCompanyID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                CompanyName = (string)reader["CompanyName"];
                                ContactPhone = (string)reader["ContactPhone"];
                                ContactEmail = (string)reader["ContactEmail"];
                                CoveragePercentage = (decimal)reader["CoveragePercentage"];
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
        // 2. إضافة شركة جديدة
        public static int AddNewInsuranceCompany(string CompanyName, string ContactPhone, string ContactEmail, decimal CoveragePercentage)
        {
            int InsuranceCompanyID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewInsuranceCompany", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CompanyName", CompanyName);
                    command.Parameters.AddWithValue("@ContactPhone", ContactPhone);
                    command.Parameters.AddWithValue("@ContactEmail", ContactEmail);
                    command.Parameters.AddWithValue("@CoveragePercentage", CoveragePercentage);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            InsuranceCompanyID = insertedID;
                        }
                    }
                    catch (Exception ex) { }
                }
            }

            return InsuranceCompanyID;
        }

        // 3. تعديل شركة
        public static bool UpdateInsuranceCompany(int InsuranceCompanyID, string CompanyName, string ContactPhone, string ContactEmail, decimal CoveragePercentage)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateInsuranceCompany", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InsuranceCompanyID", InsuranceCompanyID);
                    command.Parameters.AddWithValue("@CompanyName", CompanyName);
                    command.Parameters.AddWithValue("@ContactPhone", ContactPhone);
                    command.Parameters.AddWithValue("@ContactEmail", ContactEmail);
                    command.Parameters.AddWithValue("@CoveragePercentage", CoveragePercentage);

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

        // 4. حذف شركة
        public static bool DeleteInsuranceCompany(int InsuranceCompanyID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteInsuranceCompany", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InsuranceCompanyID", InsuranceCompanyID);

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

        // 5. جلب كل الشركات من الفيو
        public static DataTable GetAllInsuranceCompanies()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllInsuranceCompanies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
                        }
                    }
                    catch (Exception ex) { }
                }
            }

            return dt;
        }

        public static bool IsInsuranceCompanyExistsByName(string CompanyName)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_IsInsuranceCompanyExistsByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CompanyName", CompanyName);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null)
                            IsFound = Convert.ToBoolean(Result);
                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }

        public static bool GetInsuranceCompanyByName(string CompanyName,
                                             ref int InsuranceCompanyID,
                                             ref string ContactPhone,
                                             ref string ContactEmail,
                                             ref decimal CoveragePercentage)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetInsuranceCompanyByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CompanyName", CompanyName);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                InsuranceCompanyID = (int)reader["InsuranceCompanyID"];
                                ContactPhone = (string)reader["ContactPhone"];
                                ContactEmail = (string)reader["ContactEmail"];
                                CoveragePercentage = (decimal)reader["CoveragePercentage"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }
    }
}
