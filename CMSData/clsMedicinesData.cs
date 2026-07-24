using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSData
{
    public class clsMedicinesData
    {
        public static int AddNewMedicine(string medicineName, string activeIngredient, string form)
        {
            int medicineID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewMedicine", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MedicineName", medicineName);
                    command.Parameters.AddWithValue("@ActiveIngredient", string.IsNullOrEmpty(activeIngredient) ? (object)DBNull.Value : activeIngredient);
                    command.Parameters.AddWithValue("@Form", string.IsNullOrEmpty(form) ? (object)DBNull.Value : form);

                    SqlParameter outputIdParam = new SqlParameter("@MedicineID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        medicineID = Convert.ToInt32(outputIdParam.Value);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            return medicineID;
        }
        public static bool UpdateMedicine(int medicineID, string medicineName, string activeIngredient, string form)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateMedicine", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MedicineID", medicineID);
                    command.Parameters.AddWithValue("@MedicineName", medicineName);
                    command.Parameters.AddWithValue("@ActiveIngredient", string.IsNullOrEmpty(activeIngredient) ? (object)DBNull.Value : activeIngredient);
                    command.Parameters.AddWithValue("@Form", string.IsNullOrEmpty(form) ? (object)DBNull.Value : form);

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
            return rowsAffected > 0;
        }
        public static bool DeleteMedicine(int medicineID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteMedicine", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MedicineID", medicineID);

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
            return rowsAffected > 0;
        }
        public static bool GetMedicineInfoByID(int medicineID, ref string medicineName, ref string activeIngredient, ref string form)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetMedicineByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MedicineID", medicineID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                medicineName = reader["MedicineName"].ToString();
                                activeIngredient = reader["ActiveIngredient"] != DBNull.Value ? reader["ActiveIngredient"].ToString() : string.Empty;
                                form = reader["Form"] != DBNull.Value ? reader["Form"].ToString() : string.Empty;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        throw new Exception(ex.Message);
                    }
                }
            }
            return isFound;
        }
        public static DataTable GetAllMedicines()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllMedicines", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
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
    }
}