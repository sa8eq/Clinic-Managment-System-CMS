using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CMSData
{
    public class clsSpecialtiesData
    {
        public static DataTable GetAllSpecialties()
        {
            DataTable _dt = new DataTable();
            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using(SqlCommand command = new SqlCommand("select * from v_SpecialtiesList", connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                _dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message); ;
                    }
                }
            }
            return _dt;
        }
        public static int AddNewSpecialty(string specialtyName, string description)
        {
            int newSpecialtyID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddSpecialty", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SpecialtyName", specialtyName);

                    if (!string.IsNullOrEmpty(description))
                        command.Parameters.AddWithValue("@Description", description);
                    else
                        command.Parameters.AddWithValue("@Description", DBNull.Value);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedId))
                        {
                            newSpecialtyID = insertedId;
                        }
                        else
                        {
                            newSpecialtyID = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            return newSpecialtyID;
        }
        public static bool UpdateSpecialty(int specialtyID, string specialtyName, string description)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateSpecialty", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SpecialtyID", specialtyID);
                    command.Parameters.AddWithValue("@SpecialtyName", specialtyName);

                    if (!string.IsNullOrEmpty(description))
                        command.Parameters.AddWithValue("@Description", description);
                    else
                        command.Parameters.AddWithValue("@Description", DBNull.Value);

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
        public static bool DeleteSpecialty(int specialtyID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteSpecialty", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SpecialtyID", specialtyID);

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
        public static bool GetSpecialtyByID(int specialtyID, ref string specialtyName, ref string description)
        {
            bool isFound = false;
            specialtyName = "";
            description = "";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetSpecialtyByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SpecialtyID", specialtyID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) 
                            {
                                isFound = true;
                                specialtyName = reader["SpecialtyName"].ToString();
                                if (reader["Description"] != DBNull.Value)
                                    description = reader["Description"].ToString();
                                else
                                    description = "";
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
    }
}
