using System;
using System.Collections.Generic;
using mdphischel.DAL;
using mdphischel.DAL.Models;

namespace mdphischel.BLL
{
    /// <summary>
    /// Class in charge of managing business rules concerning to Medicines and its operations.
    /// </summary>
    public class MedicineManager
    {
       /// <summary>
       /// Inserts specific medicine into given branch office.
       /// </summary>
       /// <param name="branchOfficeId"></param>
       /// <param name="medicineId"></param>
       /// <param name="quantity"></param>
       /// <param name="sales"></param>
       /// <param name="price"></param>
       /// <returns>Integer indicating whether operation was successful or not.</returns>
        public int InsertMedicineIntoBranchOffice(string branchOfficeId, string medicineId, int quantity, int sales,
            string price)
        {
            int result;
            try
            {
                DBMedicine medicineInstance = new DBMedicine();
                var operationResult = medicineInstance.InsertMedicineIntoBranchOffice(branchOfficeId,medicineId,quantity,sales,price);
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
        /// Method in charge of synchronizing the given medicine information into local medicine table.
        /// </summary>
        /// <param name="branchOfficeId"></param>
        /// <param name="medicineId"></param>
        /// <param name="quantity"></param>
        /// <param name="sales"></param>
        /// <returns>Integer indicating whether operation was successful or not.</returns>
        public int SynchronizeMedicine(string branchOfficeId, string medicineId, int quantity, int sales)
        {
            int result;
            try
            {
                DBMedicine medicineInstance = new DBMedicine();
                var operationResult = medicineInstance.SynchronizeMedicine(branchOfficeId, medicineId, quantity, sales);
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
        /// Gets all medicines by given branch office Id.
        /// </summary>
        /// <param name="branchOffice"></param>
        /// <returns></returns>
        public List<string> GetAllMedicines(string branchOffice)
        {
            List<string> retVal = new List<string>();

            try
            {
                DBMedicine medicineInstance = new DBMedicine();
                var medicineList = medicineInstance.GetAllMedicines(branchOffice);
                retVal.Add(Constants.SUCCESS.ToString());
                foreach (Medicine t in medicineList)
                {
                    retVal.Add(t.BranchOfficeId);
                    retVal.Add(t.MedicineId);
                    retVal.Add(t.Quantity.ToString());
                    retVal.Add(t.Sales.ToString());
                    retVal.Add(t.Price);
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