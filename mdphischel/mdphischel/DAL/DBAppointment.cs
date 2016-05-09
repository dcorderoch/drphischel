using System;
using System.Data;
using System.Data.SqlClient;

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
                doctorIdParameter.Direction =ParameterDirection.Input;
                doctorIdParameter.Value = doctorId;

                SqlParameter appointmentTimeParameter= cmd.Parameters.Add("@AppointmentDateTime", SqlDbType.DateTime);
                appointmentTimeParameter.Direction= ParameterDirection.Input;
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









    }
}