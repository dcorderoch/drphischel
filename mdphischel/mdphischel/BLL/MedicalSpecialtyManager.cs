using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mdphischel.DAL;

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
    }



}