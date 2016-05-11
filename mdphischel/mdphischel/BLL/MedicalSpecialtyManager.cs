using System;
using System.Collections.Generic;
using mdphischel.DAL;
using mdphischel.DAL.Models;

namespace mdphischel.BLL
{
    /// <summary>
    /// Class in charge of validating business rules relative to medical specialties.
    /// </summary>
    public class MedicalSpecialtyManager
    {
        /// <summary>
        /// Creates a new medical specialty.
        /// </summary>
        /// <param name="medicalSpecialty"></param>
        /// <returns>Integer indicating whether or not the operation was successful.</returns>
        public int CreateMedicalSpecialty(string medicalSpecialty)
        {
            int result;
            try
            {
                DBMedicalSpecialty specialtyInstance = new DBMedicalSpecialty();
                var operationResult = specialtyInstance.CreateMedicalSpecialty(medicalSpecialty);
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
        /// Gets all existing medical specialties in the database.
        /// </summary>
        /// <returns>List of strings with all the specialty information.</returns>
        public List<string> GetAllSpecialties()
        {
            List<string> retVal = new List<string>();

            try
            {
                DBMedicalSpecialty specialtyInstance = new DBMedicalSpecialty();
                var specialtyList = specialtyInstance.GetAllSpecialties();
                retVal.Add(Constants.SUCCESS.ToString());
                foreach (MedicalSpecialty t in specialtyList)
                {
                    retVal.Add(t.MedicalSpecialtyId.ToString());
                    retVal.Add(t.Name);
                }
            }
            catch (Exception)
            {
                retVal.Add(Constants.ERROR.ToString());
            }
            return retVal;
        }
    }
}


