using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using mdphischel.DAL.Models;

namespace mdphischel.DAL
{
    public class DBPrescription
    {
        /// <summary>
        /// This method calls a stored procedure to  create prescription
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public int[] CreatePrescription(string doctorCode, int patientId)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_createPrescription", connection))
            {

                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter resultCodeParameter = cmd.Parameters.Add("@resultcode", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter patientIdParameter = cmd.Parameters.Add("@patientId", SqlDbType.Int);
                patientIdParameter.Direction = ParameterDirection.Input;
                patientIdParameter.Value = patientId;
                SqlParameter doctorCodeParameter = cmd.Parameters.Add("@doctorCode", SqlDbType.NVarChar);
                doctorCodeParameter.Direction = ParameterDirection.Input;
                doctorCodeParameter.Value = doctorCode;

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
        /// This method calls a stored procedure to add a medicine into prescription
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public int[] AddMedicineIntoPrescription(String medicineId, string prescriptionId)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_AddMedicineIntoPrescription", connection))
            {

                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter resultCodeParameter = cmd.Parameters.Add("@resultcode", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter medicineIdParameter = cmd.Parameters.Add("@medicineId", SqlDbType.UniqueIdentifier);
                medicineIdParameter.Direction = ParameterDirection.Input;
                medicineIdParameter.Value = medicineId;
                SqlParameter prescriptionIdParameter = cmd.Parameters.Add("@medicineId", SqlDbType.UniqueIdentifier);
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
        /// This method calls a stored procedure to update an existing prescription
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public int[] UpdatePrescription(string oldMedicineId, string prescriptionId, string doctorcode, int patientId, string NewMedicineId)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_updatePrescription", connection))
            {

                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter resultCodeParameter = cmd.Parameters.Add("@resultcode", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter prescriptionIdParam = cmd.Parameters.Add("@prescriptionId", SqlDbType.UniqueIdentifier);
                prescriptionIdParam.Direction = ParameterDirection.Input;
                prescriptionIdParam.Value = prescriptionId;
                SqlParameter doctorCodeParam = cmd.Parameters.Add("@doctorCode", SqlDbType.NVarChar);
                doctorCodeParam.Direction = ParameterDirection.Input;
                doctorCodeParam.Value = doctorcode;
                SqlParameter patientIdParam = cmd.Parameters.Add("@patientId", SqlDbType.Int);
                patientIdParam.Direction = ParameterDirection.Input;
                patientIdParam.Value = patientId;
                SqlParameter oldMedicineIdParam = cmd.Parameters.Add("@OldMedicineId", SqlDbType.UniqueIdentifier);
                oldMedicineIdParam.Direction = ParameterDirection.Input;
                oldMedicineIdParam.Value = oldMedicineId;
                SqlParameter newMedicineIdParam = cmd.Parameters.Add("@NewMedicineId", SqlDbType.UniqueIdentifier);
                newMedicineIdParam.Direction = ParameterDirection.Input;
                newMedicineIdParam.Value = NewMedicineId;

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
        /// This method calls a stored procedure to delete an existing prescription
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public int[] DeletePrescription(string prescriptionId)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_deletePrescription", connection))
            {

                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter resultCodeParameter = cmd.Parameters.Add("@resultcode", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter prescriptionIdParam = cmd.Parameters.Add("@prescriptionId", SqlDbType.UniqueIdentifier);
                prescriptionIdParam.Direction = ParameterDirection.Input;
                prescriptionIdParam.Value = prescriptionId;

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
        /// This method calls a stored procedure to get medicines from prescription
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public List<Medicine> GetPrescriptionMedicines(string prescriptionId)
        {
            List<Medicine> medicines = new List<Medicine>();
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_getPrescriptionMedicines", connection))
            {

                SqlParameter prescriptionIdParam = cmd.Parameters.Add("@prescriptionId", SqlDbType.UniqueIdentifier);
                prescriptionIdParam.Direction = ParameterDirection.Input;
                prescriptionIdParam.Value = prescriptionId;

                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Medicine newMed = new Medicine();
                        newMed.MedicineId = (string) reader[0];
                        newMed.MedicineName = (string) reader[1];
                        medicines.Add(newMed);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return medicines;
        }


        /// This method calls a stored procedure to get prescriptions by doctorId
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public List<Prescription> GetPrescriptionByDoctor(string doctorId)
        {
            List<Prescription> prescriptionList = new List<Prescription>();
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_getPrescriptionByDoctor", connection))
            {
                SqlParameter prescriptionIdParam = cmd.Parameters.Add("@doctorId", SqlDbType.NVarChar);
                prescriptionIdParam.Direction = ParameterDirection.Input;
                prescriptionIdParam.Value = doctorId;

                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Prescription presc = new Prescription();
                        presc.PrescriptionId = (string)reader[0];
                        presc.DoctorId = (string)reader[1];
                        presc.UserId = (int) reader[2];
                        prescriptionList.Add(presc);
                    }
                    reader.Close();
                }


                connection.Close();
            }
            return prescriptionList;
        }

    }
}