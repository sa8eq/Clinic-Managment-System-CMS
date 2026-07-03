using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSData
{
    public static class clsPersonsData
    {
        public static bool GetPersonByID(int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName,
                                         ref string LastName, ref byte Gender, ref DateTime DateOfBirth,
                                         ref string Phone, ref string Email, ref string Address, ref DateTime? CreatedAt)
        {
            bool isFound = false;

            // clsDataAccessSettings.ConnectionString تأكد من مطابقة اسم كلاس الاتصال المتواجد عندك
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetPersonByID", connection))
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
                                isFound = true;

                                FirstName = (string)reader["FirstName"];
                                LastName = (string)reader["LastName"];
                                Gender = (byte)(reader["Gender"]);
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Phone = (string)reader["Phone"];
                                Email = (string)reader["Email"];
                                Address = (string)reader["Address"];

                                // معالجة الحقول التي تقبل القيمة الفارغة (Null)
                                SecondName = reader["SecondName"] == DBNull.Value ? "" : (string)reader["SecondName"];
                                ThirdName = reader["ThirdName"] == DBNull.Value ? "" : (string)reader["ThirdName"];
                                CreatedAt = reader["CreatedAt"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["CreatedAt"];
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

        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName,
                                         short Gender, DateTime DateOfBirth, string Phone, string Email, string Address)
        {
            int PersonID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewPerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Address", Address);

                    // معالجة الحقول الاختيارية عند الإرسال لقاعدة البيانات
                    command.Parameters.AddWithValue("@SecondName", string.IsNullOrEmpty(SecondName) ? (object)DBNull.Value : SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName);

                    // افترضنا هنا أن الـ Stored Procedure يعيد المعرف الجديد عبر SCOPE_IDENTITY أو نفذت كود جلب القيمة
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            PersonID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message); ;
                    }
                }
            }

            return PersonID;
        }
        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName,
                                         short Gender, DateTime DateOfBirth, string Phone, string Email, string Address)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdatePerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Address", Address);

                    command.Parameters.AddWithValue("@SecondName", string.IsNullOrEmpty(SecondName) ? (object)DBNull.Value : SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName);

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
        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeletePerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

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
        public static DataTable GetAllPersons()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllPersons", connection))
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
        public static bool GetPersonByEmail(string Email, ref int PersonID, ref string FirstName,
                                         ref string SecondName, ref string ThirdName,
                                         ref string LastName, ref byte Gender,
                                         ref DateTime DateOfBirth, ref string Phone,
                                         ref string Address, ref DateTime? CreatedAt)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetPersonByEmail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", Email);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                PersonID = (int)reader["PersonID"];
                                FirstName = (string)reader["FirstName"];
                                LastName = (string)reader["LastName"];
                                Gender = (byte)(reader["Gender"]);
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Phone = (string)reader["Phone"];
                                Address = (string)reader["Address"];

                                SecondName = reader["SecondName"] == DBNull.Value ? "" : (string)reader["SecondName"];
                                ThirdName = reader["ThirdName"] == DBNull.Value ? "" : (string)reader["ThirdName"];
                                CreatedAt = reader["CreatedAt"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["CreatedAt"];
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
        public static bool IsPersonExistsByEmail(string Email)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_IsPersonExistsByEmail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", Email);

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
        public static bool IsPersonExistsByPhone(string Phone)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_IsPersonExistsByPhone", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Phone", Phone);

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