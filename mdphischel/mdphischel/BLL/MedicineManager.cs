using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mdphischel.DAL;

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
    }
}