using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using mdphischel.DAL.Models;

namespace mdphischel.DAL
{
    public class DBMedicalSpecialty
    {
        /// <summary>
        /// Function whose purpose is create a new medical specialty (Only if it does not already exist).
        /// </summary>
        /// <returns>Result codes indicating whether the operation was successful or not.</returns>
        public int[] CreateMedicalSpecialty(string medicalSpecialty)
        {
            int[] resultCodes = new int[2];

            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspAddMedicalSpecialty", connection))
            {
                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter medicalSpecialtyParameter = cmd.Parameters.Add("@MedicalSpecialtyName", SqlDbType.NVarChar);
                medicalSpecialtyParameter.Direction = ParameterDirection.Input;
                medicalSpecialtyParameter.Value = medicalSpecialty;

                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                cmd.ExecuteNonQuery();

                var resultCode = resultCodeParameter.Value;
                var errorNumCode = errorCodeParameter.Value;
                if (resultCode != DBNull.Value)
                {
                    resultCodes[0] = int.Parse(resultCode.ToString());
                    if (errorNumCode == DBNull.Value)
                    {
                        resultCodes[1] = 0;
                    }
                    else
                    {
                        resultCodes[1] = int.Parse(errorNumCode.ToString());
                    }
                }
                else
                {
                    resultCodes[0] = 0;
                    resultCodes[1] = 0;
                }

                connection.Close();
            }
            return resultCodes;
        }

        /// <summary>
        /// Gets all medical specialties.
        /// </summary>
        public List<MedicalSpecialty> GetAllSpecialties()
        {
            List<MedicalSpecialty> medicalSpecialties = new List<MedicalSpecialty>();
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspGetAllSpecialties", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MedicalSpecialty newMedicalSpecialty = new MedicalSpecialty();
                        newMedicalSpecialty.MedicalSpecialtyId = (int)reader[0];
                        var name = reader[1].ToString();
                        newMedicalSpecialty.Name = name.ToString();
                        medicalSpecialties.Add(newMedicalSpecialty);
          
                    }
                    reader.Close();
                    connection.Close();
            }
                return medicalSpecialties;
        }
    }
}