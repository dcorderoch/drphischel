using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;


namespace mdphischel.DAL
{
    public class DBPatient
    {
        /// <summary>
        /// Method in charge of creating a new patient (Unlinked to doctor).
        /// </summary>
        /// <param name="idNumber"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="lastName1"></param>
        /// <param name="lastName2"></param>
        /// <param name="residence"></param>
        /// <param name="birthDate"></param>
        /// <returns>ResultCodes indicating whether operation was successful or not.</returns>
        public int[] CreatePatient(String idNumber, String password, String name, String lastName1, String lastName2,
            String residence, String birthDate)
        {
            // Initializing resultCodes array.
            int[] resultCodes = new int[2];
            // Using temporary connection and command objects.
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspCreatePatient", connection))
            {
                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter idNumberParameter = cmd.Parameters.Add("@IdNumber", SqlDbType.Char);
                idNumberParameter.Direction = ParameterDirection.Input;
                idNumberParameter.Value = idNumber;

                SqlParameter passwordParameter = cmd.Parameters.Add("@Pass", SqlDbType.NVarChar);
                passwordParameter.Direction = ParameterDirection.Input;
                passwordParameter.Value = password;

                SqlParameter nameParameter = cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                nameParameter.Direction = ParameterDirection.Input;
                nameParameter.Value = name;

                SqlParameter lastName1Parameter = cmd.Parameters.Add("@LastName1", SqlDbType.NVarChar);
                lastName1Parameter.Direction = ParameterDirection.Input;
                lastName1Parameter.Value = lastName1;

                SqlParameter lastName2Parameter = cmd.Parameters.Add("@LastName2", SqlDbType.NVarChar);
                lastName2Parameter.Direction = ParameterDirection.Input;
                lastName2Parameter.Value = lastName2;

                SqlParameter residenceParameter = cmd.Parameters.Add("@Residence", SqlDbType.NVarChar);
                residenceParameter.Direction =ParameterDirection.Input;
                residenceParameter.Value = residence;

                SqlParameter birthDateParameter = cmd.Parameters.Add("@BirthDate", SqlDbType.Date);
                birthDateParameter.Direction = ParameterDirection.Input;
                birthDateParameter.Value = birthDate;

                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                cmd.ExecuteNonQuery();

                var resultCode = resultCodeParameter.Value;
                var errorNum = errorCodeParameter.Value;
                if (resultCode != DBNull.Value)
                {
                    resultCodes[0] = int.Parse(resultCode.ToString());
                    if (errorNum == DBNull.Value)
                    {
                        resultCodes[1] = 0;
                    }
                    else
                    {
                        resultCodes[1] = int.Parse(errorNum.ToString());
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
    }
}