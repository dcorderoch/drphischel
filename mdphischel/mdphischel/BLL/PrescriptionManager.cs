using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mdphischel.DAL;

namespace mdphischel.BLL
{
    public class PrescriptionManager
    {

        /// <summary>
        /// This method calls DAL to add a medicine into prescription
        /// </summary>
        /// <param name="medicineId"></param>
        /// <param name="prescriptionId"></param>
        /// <returns></returns>
        public int AddMedicineIntoPrescription(string medicineId, string prescriptionId)
        {
            DBPrescription prescriptionDAL= new DBPrescription();
            int[] result = prescriptionDAL.AddMedicineIntoPrescription(medicineId, prescriptionId);
            return result[0];
        }
    }
}