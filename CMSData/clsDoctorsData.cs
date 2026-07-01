using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSData
{
    public static class clsDoctorsData
    {
        // 1. جلب بيانات طبيب بواسطة المعرف (FindByID)
        public static bool GetDoctorByID(int DoctorID, ref int PersonID, ref int SpecialtyID,
                                         ref string LicenseNumber, ref DateTime HireDate, ref bool IsActive)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetDoctorByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DoctorID", DoctorID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                PersonID = (int)reader["PersonID"];
                                SpecialtyID = (int)reader["SpecialtyID"];
                                LicenseNumber = (string)reader["LicenseNumber"];
                                HireDate = (DateTime)reader["HireDate"];
                                IsActive = (bool)reader["IsActive"];
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

        // 2. إضافة طبيب جديد (Insert) وإعادة الـ ID المولد
        public static int AddNewDoctor(int PersonID, int SpecialtyID, string LicenseNumber, DateTime HireDate, bool IsActive)
        {
            int DoctorID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewDoctor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@SpecialtyID", SpecialtyID);
                    command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);
                    command.Parameters.AddWithValue("@HireDate", HireDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            DoctorID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        // إدارة الخطأ هنا عند الحاجة
                    }
                }
            }

            return DoctorID;
        }

        // 3. تعديل بيانات طبيب (Update)
        public static bool UpdateDoctor(int DoctorID, int PersonID, int SpecialtyID, string LicenseNumber, DateTime HireDate, bool IsActive)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateDoctor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@DoctorID", DoctorID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@SpecialtyID", SpecialtyID);
                    command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);
                    command.Parameters.AddWithValue("@HireDate", HireDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

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

        // 4. حذف طبيب بواسطة المعرف (Delete)
        public static bool DeleteDoctor(int DoctorID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteDoctor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DoctorID", DoctorID);

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

        // 5. جلب جدول جميع الأطباء (والذي يقرأ داخلياً من الـ View الشاملة)
        public static DataTable GetAllDoctors()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllDoctors", connection))
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
                        // إدارة الخطأ
                    }
                }
            }

            return dt;
        }

        public static bool GetDoctorByLicenseNumber(string LicenseNumber, ref int DoctorID,
                                            ref int PersonID, ref int SpecialtyID,
                                            ref DateTime HireDate, ref bool IsActive)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetDoctorByLicenseNumber", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                DoctorID = (int)reader["DoctorID"];
                                PersonID = (int)reader["PersonID"];
                                SpecialtyID = (int)reader["SpecialtyID"];
                                HireDate = (DateTime)reader["HireDate"];
                                IsActive = (bool)reader["IsActive"];
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

        public static bool IsDoctorExistsByLicenseNumber(string LicenseNumber)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_IsDoctorExistsByLicenseNumber", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);

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
    }
}