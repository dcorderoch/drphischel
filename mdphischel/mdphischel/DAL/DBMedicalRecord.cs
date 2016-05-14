using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using mdphischel.DAL.Models;

namespace mdphischel.DAL
{
    public class DBMedicalRecord
    {


        /// <summary>
        /// This method adds and entry into an user's medical record
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public int[] AddMedicalRecordEntry(int userId, int appointmentId, string description, string diagnosis, string prescriptionId)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_AddMedRecordEntry", connection))
            {

                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter resultCodeParameter = cmd.Parameters.Add("@resultCode", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter userIdParameter = cmd.Parameters.Add("@userId", SqlDbType.Int);
                userIdParameter.Direction = ParameterDirection.Input;
                userIdParameter.Value = userId;
                SqlParameter appointmentIdParameter = cmd.Parameters.Add("@appointmentId", SqlDbType.Int);
                appointmentIdParameter.Direction = ParameterDirection.Input;
                appointmentIdParameter.Value = appointmentId;
                SqlParameter descriptionParameter = cmd.Parameters.Add("@description", SqlDbType.VarChar);
                descriptionParameter.Direction = ParameterDirection.Input;
                descriptionParameter.Value = description;
                SqlParameter diagnosisParameter = cmd.Parameters.Add("@diagnosis", SqlDbType.VarChar);
                diagnosisParameter.Direction = ParameterDirection.Input;
                diagnosisParameter.Value = diagnosis;
                SqlParameter prescriptionIdParameter = cmd.Parameters.Add("@prescriptionId", SqlDbType.UniqueIdentifier);
                prescriptionIdParameter.Direction = ParameterDirection.Input;
                prescriptionIdParameter.Value = prescriptionId;

                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                cmd.ExecuteNonQuery();

                var resultCode = resultCodeParameter.Value;
                var errorNumCode = errorCodeParameter.Value;
                if (resultCode != DBNull.Value)
                {
                    resultCodes[0] = int.Parse(resultCode.ToString());
                    if (errorNumCode == DBNull.Value)
                    {
                        resultCodes[1] = 0;
                    }
                    else
                    {
                        resultCodes[1] = int.Parse(errorNumCode.ToString());
                    }

                }
                else
                {
                    resultCodes[0] = 0;
                    resultCodes[1] = 0;
                }

                connection.Close();
            }
            return resultCodes;
        }


        /// <summary>
        /// This method updates and entry in user's medical record
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public int[] UpdateMedicalRecordEntry(int medicalRecordId, int appointmentId, string description, string diagnosis, string prescriptionId)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_updateMedRecordEntry", connection))
            {

                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter resultCodeParameter = cmd.Parameters.Add("@resultcode", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter medicalRecordIdParameter = cmd.Parameters.Add("@medicalRecordId", SqlDbType.Int);
                medicalRecordIdParameter.Direction = ParameterDirection.Input;
                medicalRecordIdParameter.Value = medicalRecordId;
                SqlParameter appointmentIdParameter = cmd.Parameters.Add("@appointmentId", SqlDbType.Int);
                appointmentIdParameter.Direction = ParameterDirection.Input;
                appointmentIdParameter.Value = appointmentId;
                SqlParameter descriptionParameter = cmd.Parameters.Add("@description", SqlDbType.VarChar);
                descriptionParameter.Direction = ParameterDirection.Input;
                descriptionParameter.Value = description;
                SqlParameter diagnosisParameter = cmd.Parameters.Add("@diagnosis", SqlDbType.VarChar);
                diagnosisParameter.Direction = ParameterDirection.Input;
                diagnosisParameter.Value = diagnosis;
                SqlParameter prescriptionIdParameter = cmd.Parameters.Add("@prescriptionId", SqlDbType.UniqueIdentifier);
                prescriptionIdParameter.Direction = ParameterDirection.Input;
                prescriptionIdParameter.Value = prescriptionId;


                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                cmd.ExecuteNonQuery();

                var resultCode = resultCodeParameter.Value;
                var errorNumCode = errorCodeParameter.Value;
                if (resultCode != DBNull.Value)
                {
                    resultCodes[0] = int.Parse(resultCode.ToString());
                    if (errorNumCode == DBNull.Value)
                    {
                        resultCodes[1] = 0;
                    }
                    else
                    {
                        resultCodes[1] = int.Parse(errorNumCode.ToString());
                    }

                }
                else
                {
                    resultCodes[0] = 0;
                    resultCodes[1] = 0;
                }

                connection.Close();
            }
            return resultCodes;
        }


        /// <summary>
        /// Retrieves a list of patients for the given doctorId
        /// </summary>
        /// <returns>List of doctors</returns>
        public List<MedicalRecord> GetMedicalRecords(int patientId)
        {
            List<MedicalRecord> patientMedRecords = new List<MedicalRecord>();

            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_getPatientMedRecord", connection))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter userIdParameter = cmd.Parameters.Add("@userId", SqlDbType.Int);
                userIdParameter.Direction = ParameterDirection.Input;
                userIdParameter.Value = patientId;

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MedicalRecord medRecord = new MedicalRecord();
                        medRecord.MedicalRecordId = (int) Int32.Parse(reader[0].ToString());
                        medRecord.DoctorId = (string) reader[1].ToString();
                        medRecord.AppointmentDate = (string) reader[2].ToString();
                        medRecord.Description = (string) reader[3].ToString();
                        medRecord.Diagnosis = (string) reader[4].ToString();
                        medRecord.PrescriptionId = (string) reader[5].ToString();
                        patientMedRecords.Add(medRecord);
                    }
                    reader.Close();
                }

                connection.Close();
            }
            return patientMedRecords;
        }





    }
}