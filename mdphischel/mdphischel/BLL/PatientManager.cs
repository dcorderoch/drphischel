using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mdphischel.DAL;

namespace mdphischel.BLL
{
    /// <summary>
    /// Class in charge of managing business rules related to Patients issues.
    /// </summary>
    public class PatientManager
    {
        /// <summary>
        /// Creates a new patient and links it to doctor immediately after.
        /// </summary>
        /// <param name="idNumber"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="lastName1"></param>
        /// <param name="lastName2"></param>
        /// <param name="residence"></param>
        /// <param name="birthDate"></param>
        /// <param name="doctorId"></param>
        /// <returns>1 or 0 whether operation was successful or not.</returns>
        public int CreatePatientByDoctor(string idNumber, string password, string name, string lastName1, string lastName2,
            string residence, string birthDate, string doctorId)
        {
            int result;
            try
            {
                DBPatient patientInstance = new DBPatient();
                var operationResult = patientInstance.CreatePatient(idNumber,password,name,lastName1,lastName2,residence,birthDate);
                var operationResult2 = patientInstance.LinkPatientToDoctor(doctorId, idNumber);
                if (operationResult[0].Equals(Constants.SUCCESS) && operationResult2[0].Equals(Constants.SUCCESS))
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
        /// Creates a new patient (Unlinked to doctor).
        /// </summary>
        /// <param name="idNumber"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="lastName1"></param>
        /// <param name="lastName2"></param>
        /// <param name="residence"></param>
        /// <param name="birthDate"></param>
        /// <returns>1 or 0 whether operation was successful or not.</returns>
        public int CreatePatientByAdmin(string idNumber, string password, string name, string lastName1,
            string lastName2,
            string residence, string birthDate)
        {
            int result;
            try
            {
                DBPatient patientInstance = new DBPatient();
                var operationResult = patientInstance.CreatePatient(idNumber, password, name, lastName1, lastName2, residence, birthDate);
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