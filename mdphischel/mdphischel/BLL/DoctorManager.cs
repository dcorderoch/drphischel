using System;
using System.Collections.Generic;
using mdphischel.DAL;
using mdphischel.DAL.Models;

namespace mdphischel.BLL
{
    public class DoctorManager
    {
        /// <summary>
        /// This method calls DAL to preregister a new doctor. 
        /// </summary>
        /// <param name="docCode"></param>
        /// <param name="pass"></param>
        /// <param name="idNumber"></param>
        /// <param name="name"></param>
        /// <param name="lastName1"></param>
        /// <param name="lastName2"></param>
        /// <param name="residencePlace"></param>
        /// <param name="birthdate"></param>
        /// <param name="officeAddres"></param>
        /// <param name="creditCardNum"></param>
        /// <returns>1 if succes, 0 if found any errors</returns>
        public int PreregisterDoctor(String docCode,
            String pass, String idNumber, String name,
            String lastName1, String lastName2, String residencePlace,
            String birthdate, String officeAddres, String creditCardNum)
        {
            DBDoctor doctorDAL= new DBDoctor();
            int[] result=doctorDAL.PreRegistation(docCode, pass, idNumber, name, lastName1, lastName2, residencePlace, birthdate,
                officeAddres, creditCardNum);
            return result[0];
        }


        /// <summary>
        /// This method calls DAL to accept a pre registed doctor
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns>1 if succes, 0 if found errors</returns>
        public int AcceptDoctor(string docId)
        {
            DBDoctor doctorDAL = new DBDoctor();
            int[] result = doctorDAL.AcceptDoctor(docId);
            return result[0];
        }

        /// <summary>
        /// This method calls DAL to reject a pre registed doctor
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public int RejectDoctor(string doctorId)
        {
            DBDoctor doctorDAL = new DBDoctor();
            int[] result = doctorDAL.RejectDoctor(doctorId);
            return result[0];
        }

        /// <summary>
        /// This method calls DAL to retrieve information about doctors' charges
        /// </summary>
        /// <param name="year">Must be a string in YYYY format</param>
        /// <param name="month">Must be a string in MM format</param>
        /// <returns></returns>
        public List<DoctorsCharge> GetMonthlyCharges()
        {
            DBDoctor doctorDAL = new DBDoctor();
            MonthlyDocCharges docCharges = doctorDAL.GetMonthlyCharges();
            return docCharges.ChargesList;
        }

        /// <summary>
        /// Get pending doctors
        /// </summary>
        /// <returns></returns>
        public List<Doctor> GetPendingDoctors()
        {
            DBDoctor doctorDAL = new DBDoctor();
            return doctorDAL.GetPendingDoctors();
        }

        /// <summary>
        /// Get patients by doctor id
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public List<User> GetPatientsByDoctorId(string doctorId)
        {
            DBDoctor doctorDAL = new DBDoctor();
            return doctorDAL.GetPatientsByDoctorId(doctorId);
        } 
    }
}