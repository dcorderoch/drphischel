using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using mdphischel.DAL.Models;


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
        public int[] CreatePatient(string idNumber, string password, string name, string lastName1, string lastName2,
            string residence, string birthDate)
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
                residenceParameter.Direction = ParameterDirection.Input;
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

        /// <summary>
        /// Function in charge of associating a patient to a specific doctor. 
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="patientIdNumber"></param>
        /// <returns>ResultCodes indicating whether operation was successful or not.</returns>
        public int[] LinkPatientToDoctor(string doctorId, string patientIdNumber)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspLinkToDoctor", connection))
            {
                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter resultParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultParameter.Direction = ParameterDirection.Output;
                SqlParameter doctorIdParameter = cmd.Parameters.Add("@doctorId", SqlDbType.NVarChar);
                doctorIdParameter.Direction = ParameterDirection.Input;
                doctorIdParameter.Value = doctorId;
                SqlParameter patientIdNumberParameter = cmd.Parameters.Add("@idNumber", SqlDbType.Char);
                patientIdNumberParameter.Direction = ParameterDirection.Input;
                patientIdNumberParameter.Value = patientIdNumber;

                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                cmd.ExecuteNonQuery();

                var resultCode = resultParameter.Value;
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

        //uspUpdatePatient @IdNumber char(9), @Pass nvarchar(30), @Name nvarchar(30),@LastName1 nvarchar(30), @LastName2 nvarchar(30), @Residence nvarchar(30), @BirthDate Date, @result int OUTPUT, @errorNum int OUTPUT
        /// <summary>
        /// Method in charge of updating patient information.
        /// </summary>
        /// <param name="idNumber"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="lastName1"></param>
        /// <param name="lastName2"></param>
        /// <param name="residence"></param>
        /// <param name="birthDate"></param>
        /// <returns>ResultCodes indicating whether operation was successful or not.</returns>
        public int[] UpdatePatient(string idNumber, string password, string name, string lastName1, string lastName2,
            string residence, string birthDate)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspUpdatePatient", connection))
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
                residenceParameter.Direction = ParameterDirection.Input;
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

        /// <summary>
        /// Function whose purpose is to delete a given patient.
        /// </summary>
        /// <param name="idNumber"></param>
        /// <returns>ResultCodes indicating whether operation was successful or not.</returns>
        public int[] UpdatePatient(string idNumber)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspDeletePatient", connection))
            {
                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter idNumberParameter = cmd.Parameters.Add("@IdNumber", SqlDbType.Char);
                idNumberParameter.Direction = ParameterDirection.Input;
                idNumberParameter.Value = idNumber;

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
                //Closing connection
                connection.Close();
            }
            return resultCodes;
        }

        /// <summary>
        /// Obtains all doctors from given patient.
        /// </summary>
        /// <param name="UserId"></param>
        public List<Doctor> GetDoctorsByPatient(int UserId)
        {
            List<Doctor> doctorList = new List<Doctor>();
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspGetDoctorsByPatient", connection))
            {
                SqlParameter UserIdParameter = cmd.Parameters.Add("@UserId", SqlDbType.Int);
                UserIdParameter.Direction = ParameterDirection.Input;
                UserIdParameter.Value = UserId;

                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Doctor newDoctor = new Doctor();
                        newDoctor.DoctorId = reader[0].ToString();
                        newDoctor.UserId = (int) reader[1];
                        newDoctor.OfficeAddress = reader[2].ToString();
                        newDoctor.IsActive = (bool) reader[3];
                        newDoctor.CreditCardNumber = reader[4].ToString();
                        doctorList.Add(newDoctor);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return doctorList;
        }

        /// <summary>
        /// Obtains doctor code by given userId. 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Doctor GetDoctor(int userId)
        {
            Doctor doctor = new Doctor();
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspGetDoctorCodeFromUserId", connection))
            {
                SqlParameter userIdParameter = cmd.Parameters.Add("@UserId", SqlDbType.Int);
                userIdParameter.Direction = ParameterDirection.Input;
                userIdParameter.Value = userId;

                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        doctor.DoctorId = reader[0].ToString();
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return doctor;
        }






    }
  
}