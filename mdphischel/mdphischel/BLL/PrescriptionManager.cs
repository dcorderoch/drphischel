﻿using System.Collections.Generic;
using mdphischel.DAL;
using mdphischel.DAL.Models;

namespace mdphischel.BLL
{
    public class PrescriptionManager
    {


        /// <summary>
        /// This method calls DAL to create a prescription
        /// </summary>
        /// <param name="medicineId"></param>
        /// <param name="prescriptionId"></param>
        /// <returns></returns>
        public int[] CreatePrescription(string doctorId, int patientId)
        {
            DBPrescription prescriptionDAL = new DBPrescription();
            int[] result = prescriptionDAL.CreatePrescription(doctorId, patientId);
            return result;
        }

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

        /// <summary>
        /// This method calls DAL to update an existing prescription
        /// </summary>
        /// <param name="oldMedicineId"></param>
        /// <param name="prescriptionId"></param>
        /// <param name="doctorcode"></param>
        /// <param name="patientId"></param>
        /// <param name="NewMedicineId"></param>
        /// <returns></returns>
        public int UpdatePrescription(string oldMedicineId, string prescriptionId, string doctorcode, int patientId, string NewMedicineId)
        {
            DBPrescription prescriptionDAL = new DBPrescription();
            int[] result=prescriptionDAL.UpdatePrescription(oldMedicineId, prescriptionId, doctorcode, patientId, NewMedicineId);
            return result[0];
        }

        /// <summary>
        /// This method calls DAL to delete an existing prescription
        /// </summary>
        /// <param name="prescriptionId"></param>
        /// <returns>1 if success, 0 if found errors</returns>
        public int DeletePrescription(string prescriptionId)
        {
            DBPrescription prescriptionDB= new DBPrescription();
            int[] result = prescriptionDB.DeletePrescription(prescriptionId);
            return result[0];
        }

        /// <summary>
        /// This method calls DAL to get prescripted medicines from prescription
        /// </summary>
        /// <param name="prescriptionId"></param>
        /// <returns></returns>
        public List<Medicine> GetPrescriptionMedicines(string prescriptionId)
        {
            DBPrescription prescriptionDAL=new DBPrescription();
            return prescriptionDAL.GetPrescriptionMedicines(prescriptionId);

        }

        /// <summary>
        /// This method calls DAL to get prescriptions prescripted (by the way) by a doctor
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public List<Prescription> GetPrescriptionByDoctor(string doctorId)
        {
            var retVal = new List<Prescription>();
            try
            {
                DBPrescription prescriptionDAL = new DBPrescription();
                return prescriptionDAL.GetPrescriptionByDoctor(doctorId);
            }
            catch (KeyNotFoundException e)
            {
                retVal.Add(new Prescription() {DoctorId = e.Message, PrescriptionId = e.Source, UserId = 0});
                return retVal;
            }
        } 
    }
}