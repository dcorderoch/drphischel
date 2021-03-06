﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using mdphischel.DAL.Models;

namespace mdphischel.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class DBDoctor
    {

        /// <summary>
        /// This method calls a stored procedure to create a new doctor
        /// </summary>
        /// <param name="docCode"></param>
        /// <param name="pass"></param>
        /// <param name="idNumber"></param>
        /// <param name="name"></param>
        /// <param name="lastName1"></param>
        /// <param name="lastName2"></param>
        /// <param name="residencePlace"></param>
        /// <param name="birthdate"></param>
        /// <param name="officeAddres"></param>
        /// <param name="creditCardNum"></param>
        /// <returns></returns>
        public int[] PreRegistation(String docCode, String pass, String idNumber, String name, String lastName1, String lastName2, String residencePlace, String birthdate, String officeAddres, String creditCardNum)
        {
            //Initializing result code array. Pos 0 is the Result code (1= success, 0= fail) and pos 1 is the sql error code (if sp fails).
            int[] resultCodes = new int[2];
            //Using temp connection and command objects
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_preregistDoc",connection))
            {
                //Definning input and output parameters of the SP
                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter docCodeParameter = cmd.Parameters.Add("@docCode", SqlDbType.NVarChar);
                docCodeParameter.Direction = ParameterDirection.Input;
                docCodeParameter.Value = docCode;
                SqlParameter passwordParameter = cmd.Parameters.Add("@pass", SqlDbType.NVarChar);
                passwordParameter.Direction = ParameterDirection.Input;
                passwordParameter.Value = pass;
                SqlParameter idNumberParameter = cmd.Parameters.Add("@idNumber", SqlDbType.Char);
                idNumberParameter.Direction = ParameterDirection.Input;
                idNumberParameter.Value = idNumber;
                SqlParameter nameParameter = cmd.Parameters.Add("@name", SqlDbType.NVarChar);
                nameParameter.Direction = ParameterDirection.Input;
                nameParameter.Value = name;
                SqlParameter lastName1Parameter = cmd.Parameters.Add("@lastName1", SqlDbType.NVarChar);
                lastName1Parameter.Direction = ParameterDirection.Input;
                lastName1Parameter.Value = lastName1;
                SqlParameter lastName2Parameter = cmd.Parameters.Add("@lastName2", SqlDbType.NVarChar);
                lastName2Parameter.Direction = ParameterDirection.Input;
                lastName2Parameter.Value = lastName2;
                SqlParameter residencePlaceParameter = cmd.Parameters.Add("@residencePlace", SqlDbType.NVarChar);
                residencePlaceParameter.Direction = ParameterDirection.Input;
                residencePlaceParameter.Value = residencePlace;
                SqlParameter birthDateParameter = cmd.Parameters.Add("@birthDate", SqlDbType.NVarChar);
                birthDateParameter.Direction = ParameterDirection.Input;
                birthDateParameter.Value = birthdate;
                SqlParameter officeAddressParameter = cmd.Parameters.Add("@officeAddress", SqlDbType.NVarChar);
                officeAddressParameter.Direction = ParameterDirection.Input;
                officeAddressParameter.Value = officeAddres;
                SqlParameter creditCardNumParameter = cmd.Parameters.Add("@creditCardNum", SqlDbType.NVarChar);
                creditCardNumParameter.Direction = ParameterDirection.Input;
                creditCardNumParameter.Value = creditCardNum;

                //Definning command type
                cmd.CommandType = CommandType.StoredProcedure;

                //Open connection and then executes the SP
                connection.Open();
                cmd.ExecuteNonQuery();

                //Getting resultCodes and errorcodes
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
                        resultCodes[1]=int.Parse(errorNumCode.ToString());
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
        /// This method calls a stored procedure to accept a previously created doctor
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public int[] AcceptDoctor(String docCode)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_acceptDoc", connection))
            {

                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter docCodeParameter = cmd.Parameters.Add("@docCode", SqlDbType.NVarChar);
                docCodeParameter.Direction = ParameterDirection.Input;
                docCodeParameter.Value = docCode;

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
        /// This method calls a stored procedure to accept a previously created doctor
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public int[] RejectDoctor(String docCode)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_rejectDoc", connection))
            {

                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter docCodeParameter = cmd.Parameters.Add("@docCode", SqlDbType.NVarChar);
                docCodeParameter.Direction = ParameterDirection.Input;
                docCodeParameter.Value = docCode;

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
        /// Retrieves doctors appointments of the specified month and year
        /// </summary>
        /// <param name="docCode">doctor id</param>
        /// <param name="date"> desired year and month in the format YYYY-MM-01</param>
        /// <returns></returns>
        public MonthlyDocCharges GetMonthlyCharges()
        {
            MonthlyDocCharges chargesReport = new MonthlyDocCharges();

            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_doctorsCharges", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DoctorsCharge newcharge = new DoctorsCharge();
                        newcharge.DoctorName =  (string) reader[0].ToString();
                        newcharge.DoctorLastName1 = (string) reader[1].ToString();
                        newcharge.DoctorLastName2 = (string) reader[2].ToString();
                        newcharge.Value = (string) reader[3].ToString();
                        chargesReport.AddCharge(newcharge);

                    }
                    reader.Close();
                 }

                connection.Close();
            }
            return chargesReport;
        }




        /// <summary>
        /// Retrieves a list of pending doctors for approbation
        /// </summary>
        /// <returns>List of doctors</returns>
        public List<Doctor> GetPendingDoctors()
        {
            List<Doctor> docList = new List<Doctor>();

            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))

            {
                using (SqlCommand cmd = new SqlCommand("usp_getPendingDoctors", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Doctor newDoc = new Doctor();
                            newDoc.DoctorId = (string) reader[0].ToString();
                            newDoc.OfficeAddress = (string) reader[1].ToString();
                            newDoc.CreditCardNumber = (string) reader[2].ToString();
                            newDoc.Name = (string) reader[3].ToString();
                            newDoc.LastName1 = (string) reader[4].ToString();
                            newDoc.LastName2 = (string) reader[5].ToString();
                            newDoc.PlaceResidence = (string) reader[6].ToString();
                            newDoc.BirthDate = (string) reader[7].ToString();
                            docList.Add(newDoc);
                        }
                        reader.Close();
                    }

                    connection.Close();
                }
            }
            return docList;
        }

        /// <summary>
        /// Retrieves a list of patients for the given doctorId
        /// </summary>
        /// <returns>List of doctors</returns>
        public List<User> GetPatientsByDoctorId(string doctorId)
        {
            List<User> patientList = new List<User>();

            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_getPatientsByDoctor", connection))
            {
                SqlParameter doctorIdParameter = cmd.Parameters.Add("@doctorId", SqlDbType.NVarChar);
                doctorIdParameter.Direction = ParameterDirection.Input;
                doctorIdParameter.Value = doctorId;
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User newUser = new User();
                        newUser.UserId = (int) Int32.Parse(reader[0].ToString());
                        newUser.Name = (string) reader[1].ToString();
                        newUser.LastName1 = (string) reader[2].ToString();
                        newUser.LastName2 = (string) reader[3].ToString();
                        newUser.IdNumber = (string) reader[4].ToString();
                        newUser.PlaceResidence = (string) reader[5].ToString();
                        newUser.BirthDate = (string) reader[6].ToString();
                        patientList.Add(newUser);
                    }
                    reader.Close();
                }

                connection.Close();
            }
            return patientList;
        }


    }

    
}