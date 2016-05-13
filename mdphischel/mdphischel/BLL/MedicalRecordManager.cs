using System.Collections.Generic;
using mdphischel.DAL;
using mdphischel.DAL.Models;

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

        /// <summary>
        /// This method calls DAL to update an existing medicalrecordentry
        /// </summary>
        /// <param name="medicalRecordId"></param>
        /// <param name="appointmentId"></param>
        /// <param name="description"></param>
        /// <param name="diagnosis"></param>
        /// <param name="prescriptionId"></param>
        /// <returns>1 if success, 0 if error</returns>
        public int UpdateMedicalRecordEntry(int medicalRecordId, int appointmentId, string description, string diagnosis, string prescriptionId)
        {
            DBMedicalRecord medicalRecordDAL=new DBMedicalRecord();
            int[] result = medicalRecordDAL.UpdateMedicalRecordEntry(medicalRecordId, appointmentId, description,
                diagnosis, prescriptionId);
            return result[0];
        }

        /// <summary>
        /// This method gets all the records for the given patient id
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public List<MedicalRecord> GetMedicalRecords(int patientId)
        {
            DBMedicalRecord medicalRecordDAL=new DBMedicalRecord();
            return medicalRecordDAL.GetMedicalRecords(patientId);
        } 
    }
}