using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSData
{
    public static class clsPatientsData
    {
        public static bool GetPatientByID(int PatientID, ref int PersonID, ref string BloodType,
                                          ref int? InsuranceCompanyID, ref string InsurancePolicyNumber, ref string EmergencyContactPhone)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetPatientByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PatientID", PatientID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                PersonID = (int)reader["PersonID"];

                                BloodType = reader["BloodType"] == DBNull.Value ? "" : (string)reader["BloodType"];
                                InsuranceCompanyID = reader["InsuranceCompanyID"] == DBNull.Value ? (int?)null : (int)reader["InsuranceCompanyID"];
                                InsurancePolicyNumber = reader["InsurancePolicyNumber"] == DBNull.Value ? "" : (string)reader["InsurancePolicyNumber"];
                                EmergencyContactPhone = reader["EmergencyContactPhone"] == DBNull.Value ? "" : (string)reader["EmergencyContactPhone"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message); ;
                    }
                }
            }

            return isFound;
        }

        public static int AddNewPatient(int PersonID, string BloodType, int? InsuranceCompanyID, string InsurancePolicyNumber, string EmergencyContactPhone)
        {
            int PatientID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewPatient", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    command.Parameters.AddWithValue("@BloodType", string.IsNullOrEmpty(BloodType) ? (object)DBNull.Value : BloodType);
                    command.Parameters.AddWithValue("@InsuranceCompanyID", InsuranceCompanyID.HasValue ? (object)InsuranceCompanyID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@InsurancePolicyNumber", string.IsNullOrEmpty(InsurancePolicyNumber) ? (object)DBNull.Value : InsurancePolicyNumber);
                    command.Parameters.AddWithValue("@EmergencyContactPhone", string.IsNullOrEmpty(EmergencyContactPhone) ? (object)DBNull.Value : EmergencyContactPhone);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            PatientID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message); ;
                    }
                }
            }

            return PatientID;
        }

        public static bool UpdatePatient(int PatientID, int PersonID, string BloodType, int? InsuranceCompanyID, string InsurancePolicyNumber, string EmergencyContactPhone)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdatePatient", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PatientID", PatientID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    command.Parameters.AddWithValue("@BloodType", string.IsNullOrEmpty(BloodType) ? (object)DBNull.Value : BloodType);
                    command.Parameters.AddWithValue("@InsuranceCompanyID", InsuranceCompanyID.HasValue ? (object)InsuranceCompanyID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@InsurancePolicyNumber", string.IsNullOrEmpty(InsurancePolicyNumber) ? (object)DBNull.Value : InsurancePolicyNumber);
                    command.Parameters.AddWithValue("@EmergencyContactPhone", string.IsNullOrEmpty(EmergencyContactPhone) ? (object)DBNull.Value : EmergencyContactPhone);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message); ;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool DeletePatient(int PatientID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeletePatient", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PatientID", PatientID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message); ;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllPatients()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllPatients", connection))
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
                        throw new Exception(ex.Message); ;
                    }
                }
            }

            return dt;
        }

        public static bool GetPatientByPersonID(int PersonID,
                                        ref int PatientID,
                                        ref string BloodType,
                                        ref int? InsuranceCompanyID,
                                        ref string InsurancePolicyNumber,
                                        ref string EmergencyContactPhone)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetPatientByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                PatientID = (int)reader["PatientID"];
                                BloodType = reader["BloodType"] == DBNull.Value ? "" : (string)reader["BloodType"];
                                InsuranceCompanyID = reader["InsuranceCompanyID"] == DBNull.Value ? (int?)null : (int)reader["InsuranceCompanyID"];
                                InsurancePolicyNumber = reader["InsurancePolicyNumber"] == DBNull.Value ? "" : (string)reader["InsurancePolicyNumber"];
                                EmergencyContactPhone = reader["EmergencyContactPhone"] == DBNull.Value ? "" : (string)reader["EmergencyContactPhone"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message); ;
                    }
                }
            }

            return IsFound;
        }

        public static bool GetPatientByInsurancePolicyNumber(string InsurancePolicyNumber,
                                                     ref int PatientID,
                                                     ref int PersonID,
                                                     ref string BloodType,
                                                     ref int? InsuranceCompanyID,
                                                     ref string EmergencyContactPhone)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetPatientByInsurancePolicyNumber", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InsurancePolicyNumber", InsurancePolicyNumber);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                PatientID = (int)reader["PatientID"];
                                PersonID = (int)reader["PersonID"];
                                BloodType = reader["BloodType"] == DBNull.Value ? "" : (string)reader["BloodType"];
                                InsuranceCompanyID = reader["InsuranceCompanyID"] == DBNull.Value ? (int?)null : (int)reader["InsuranceCompanyID"];
                                EmergencyContactPhone = reader["EmergencyContactPhone"] == DBNull.Value ? "" : (string)reader["EmergencyContactPhone"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message); ;
                    }
                }
            }

            return IsFound;
        }

        public static bool IsPatientExistsByPersonID(int PersonID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_IsPatientExistsByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null)
                            IsFound = Convert.ToBoolean(Result);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message); ;
                    }
                }
            }

            return IsFound;
        }

        public static bool IsPatientExistsByInsurancePolicyNumber(string InsurancePolicyNumber)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_IsPatientExistsByInsurancePolicyNumber", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InsurancePolicyNumber", InsurancePolicyNumber);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null)
                            IsFound = Convert.ToBoolean(Result);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message); ;
                    }
                }
            }

            return IsFound;
        }
    }
}