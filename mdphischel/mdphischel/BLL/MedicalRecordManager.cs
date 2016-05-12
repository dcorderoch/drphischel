using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mdphischel.DAL;

namespace mdphischel.BLL
{
    public class MedicalRecordManager
    {

        /// <summary>
        /// This method calls DAL to insert new medicalrecord entry
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="appointmentId"></param>
        /// <param name="description"></param>
        /// <param name="diagnosis"></param>
        /// <param name="prescriptionId"></param>
        /// <returns>1 if success, 0 if found an error</returns>
        public int AddMedicalRecordEntry(int userId, int appointmentId, string description, string diagnosis, string prescriptionId)
        {
            DBMedicalRecord medicalRecordDAL = new DBMedicalRecord();
            int[] result = medicalRecordDAL.AddMedicalRecordEntry(userId, appointmentId, description, diagnosis,
                prescriptionId);
            return result[0];
        }

        
    }
}