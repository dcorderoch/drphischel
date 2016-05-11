using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mdphischel.DAL;

namespace mdphischel.BLL
{
    /// <summary>
    /// Class whose purpose is to verify the appointments' business rules in order to complete each CRUD operation successfully.  
    /// </summary>
    public class AppointmentManager
    {
        /// <summary>
        /// Creates an appointment if business rules conditions are met.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="doctorId"></param>
        /// <param name="appointmentTime"></param>
        /// <returns>Result code indicating whether operation was successful or not.</returns>
        public int CreateAppointment(int userId, string doctorId, string appointmentTime)
        {   
            int result;
            try
            {
                DBAppointment appointmentInstance = new DBAppointment();
                var operationResult = appointmentInstance.CreateAppointment(userId, doctorId, appointmentTime);
                if (operationResult[0].Equals(Constants.SUCCESS))
                {
                    result = Constants.SUCCESS;
                }
                else
                {
                    result = Constants.ERROR;
                }
            }
            catch (Exception)
            {
                result = Constants.ERROR;
            }
            return result;
        }

        /// <summary>
        /// Updates an appointment if business rules conditions are met.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="doctorId"></param>
        /// <param name="oldAppointment"></param>
        /// <param name="newAppointment"></param>
        /// <returns>Result code indicating whether operation was successful or not.</returns>
        public int UpdateAppointment(int userId, string doctorId, string oldAppointment, string newAppointment)
        {
            int result;
            try
            {
                DBAppointment appointmentInstance = new DBAppointment();
                var operationResult = appointmentInstance.UpdateAppointment(userId, doctorId, oldAppointment, newAppointment);
                if (operationResult[0].Equals(Constants.SUCCESS))
                {
                    result = Constants.SUCCESS;
                }
                else
                {
                    result = Constants.ERROR;
                }
            }
            catch (Exception)
            {
                result = Constants.ERROR;
            }
            return result;
        }

        /// <summary>
        /// Deletes an appointment if business rules conditions are met.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="doctorId"></param>
        /// <param name="appointmentDate"></param>
        /// <returns>Result code indicating whether operation was successful or not.</returns>
        public int DeleteAppointment(int userId, string doctorId, string appointmentDate)
        {
            int result;
            try
            {
                DBAppointment appointmentInstance = new DBAppointment();
                var operationResult = appointmentInstance.DeleteAppointment(userId, doctorId, appointmentDate);
                if (operationResult[0].Equals(Constants.SUCCESS))
                {
                    result = Constants.SUCCESS;
                }
                else
                {
                    result = Constants.ERROR;
                }
            }
            catch (Exception)
            {
                result = Constants.ERROR;
            }
            return result;
        }

    }
}