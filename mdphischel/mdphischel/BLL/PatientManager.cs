using System;
using System.Collections.Generic;
using mdphischel.DAL;
using mdphischel.DAL.Models;

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
                var operationResult = patientInstance.CreatePatient(idNumber, password, name, lastName1, lastName2, residence, birthDate);
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

        /// <summary>
        /// Updates patient information.
        /// </summary>
        /// <param name="idNumber"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="lastName1"></param>
        /// <param name="lastName2"></param>
        /// <param name="residence"></param>
        /// <param name="birthDate"></param>
        /// <returns>1 or 0 whether operation was successful or not.</returns>
        public int UpdatePatient(string idNumber, string password, string name, string lastName1, string lastName2,
            string residence, string birthDate)
        {
            int result;
            try
            {
                DBPatient patientInstance = new DBPatient();
                var operationResult = patientInstance.UpdatePatient(idNumber, password, name, lastName1, lastName2, residence, birthDate);
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
        /// Deletes the given patient. (Logically)
        /// </summary>
        /// <param name="idNumber"></param>
        /// <returns>1 or 0 whether operation was successful or not.</returns>
        public int DeletePatient(string idNumber)
        {
            int result;
            try
            {
                DBPatient patientInstance = new DBPatient();
                var operationResult = patientInstance.DeletePatient(idNumber);
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
        /// Get all doctors associated to given patient.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Doctor> GetDoctorsByPatient(int userId)
        {
            //List<string> retVal = new List<string>();

            try
            {
                DBPatient patientInstance = new DBPatient();
                //var doctorList = 
                return patientInstance.GetDoctorsByPatient(userId);
                /*
                retVal.Add(Constants.SUCCESS.ToString());
                foreach (Doctor t in doctorList)
                {
                    retVal.Add(t.UserId.ToString());
                    retVal.Add(t.DoctorId);
                    retVal.Add(t.OfficeAddress);

                }
            }
            catch (Exception)
            {
                retVal.Add(Constants.ERROR.ToString());
            }
            return retVal;
            */
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }

        /// <summary>
        /// Get doctor code from given userId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetDoctor(int userId)
        {
            List<string> retVal = new List<string>();

            try
            {
                DBPatient patientInstance = new DBPatient();
                var doctor = patientInstance.GetDoctor(userId);
                retVal.Add(Constants.SUCCESS.ToString());
                retVal.Add(doctor.DoctorId);
                
            }
            catch (Exception)
            {
                retVal.Add(Constants.ERROR.ToString());
            }
            return retVal;
        }
    }
}