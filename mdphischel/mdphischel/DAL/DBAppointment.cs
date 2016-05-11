using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using mdphischel.DAL.Models;

namespace mdphischel.DAL
{
    public class DBAppointment
    {
        /// <summary>
        /// Function whose purpose is to create an appointment.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="doctorId"></param>
        /// <param name="appointmentTime"></param>
        /// <returns>Result codes indicating whether the operation was successful or not.</returns>
        public int[] CreateAppointment(int userId, string doctorId, string appointmentTime)
        {
            int[] resultCodes = new int[2];

            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspAddNewAppointment", connection))
            {
                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter userIdParameter = cmd.Parameters.Add("@UserId", SqlDbType.Int);
                userIdParameter.Direction = ParameterDirection.Input;
                userIdParameter.Value = userId;

                SqlParameter doctorIdParameter = cmd.Parameters.Add("@DoctorId", SqlDbType.NVarChar);
                doctorIdParameter.Direction = ParameterDirection.Input;
                doctorIdParameter.Value = doctorId;

                SqlParameter appointmentTimeParameter = cmd.Parameters.Add("@AppointmentDateTime", SqlDbType.DateTime);
                appointmentTimeParameter.Direction = ParameterDirection.Input;
                appointmentTimeParameter.Value = appointmentTime;

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


        //uspUpdateAppointment @UserId int, @DoctorId nvarchar(15), @OldAppointment DATETIME, @NewAppointment DATETIME
        /// <summary>
        /// Function in charge of updating an appointment.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="doctorId"></param>
        /// <param name="oldAppointment"></param>
        /// <param name="newAppointment"></param>
        /// <returns>Result codes indicating whether the operation was successful or not.</returns>
        public int[] UpdateAppointment(int userId, string doctorId, string oldAppointment, string newAppointment)
        {
            int[] resultCodes = new int[2];

            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspUpdateAppointment", connection))
            {
                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter userIdParameter = cmd.Parameters.Add("@UserId", SqlDbType.Int);
                userIdParameter.Direction = ParameterDirection.Input;
                userIdParameter.Value = userId;

                SqlParameter doctorIdParameter = cmd.Parameters.Add("@DoctorId", SqlDbType.NVarChar);
                doctorIdParameter.Direction = ParameterDirection.Input;
                doctorIdParameter.Value = doctorId;

                SqlParameter oldAppointmentParameter = cmd.Parameters.Add("@OldAppointment", SqlDbType.DateTime);
                oldAppointmentParameter.Direction = ParameterDirection.Input;
                oldAppointmentParameter.Value = oldAppointment;

                SqlParameter newAppointmentParameter = cmd.Parameters.Add("@NewAppointment", SqlDbType.DateTime);
                newAppointmentParameter.Direction = ParameterDirection.Input;
                newAppointmentParameter.Value = newAppointment;

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
        /// Function in charge of deleting an appointment.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="doctorId"></param>
        /// <param name="appointmentDate"></param>
        /// <returns>Result codes indicating whether the operation was successful or not.</returns>
        public int[] DeleteAppointment(int userId, string doctorId, string appointmentDate)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspDeleteAppointment", connection))
            {
                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter userIdParameter = cmd.Parameters.Add("@UserId", SqlDbType.Int);
                userIdParameter.Direction = ParameterDirection.Input;
                userIdParameter.Value = userId;

                SqlParameter doctorIdParameter = cmd.Parameters.Add("@DoctorId", SqlDbType.NVarChar);
                doctorIdParameter.Direction = ParameterDirection.Input;
                doctorIdParameter.Value = doctorId;

                SqlParameter appointmentDateParameter = cmd.Parameters.Add("@AppointmentDate", SqlDbType.DateTime);
                appointmentDateParameter.Direction = ParameterDirection.Input;
                appointmentDateParameter.Value = appointmentDate;

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
        /// Obtains all appointments by doctor.
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns>Result codes indicating whether the operation was successful or not.</returns>
        public List<Appointment> GetAppointmentsByDoctor(string doctorId)
        {
            List<Appointment> appointmentList = new List<Appointment>();
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspGetAppointmentsByDoctor", connection))
            {
                SqlParameter doctorIdParameter = cmd.Parameters.Add("DoctorId", SqlDbType.NVarChar);
                doctorIdParameter.Direction = ParameterDirection.Input;
                doctorIdParameter.Value = doctorId;

                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Appointment newAppointment = new Appointment();
                        newAppointment.DoctorId = reader[0].ToString();
                        newAppointment.UserId = (int)reader[1];
                        newAppointment.AppointmentDate = reader[2].ToString();
                        appointmentList.Add(newAppointment);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return appointmentList;
        }
    }
}