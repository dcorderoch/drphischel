﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace mdphischel.DAL
{
    public class DBMedicine
    {
        /// <summary>
        /// Inserts the given medicine into the specified branch office.
        /// </summary>
        /// <param name="branchOfficeId"></param>
        /// <param name="medicineId"></param>
        /// <param name="quantity"></param>
        /// <param name="sales"></param>
        /// <param name="price"></param>
        /// <returns>Result codes indicating whether the operation was successful or not.</returns>
        public int[] InsertMedicineIntoBranchOffice(string branchOfficeId, string medicineId, int quantity, int sales, string price)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspInsertMedicineIntoBranchOffice", connection))
            {
                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter branchOfficeIdParameter = cmd.Parameters.Add("@BranchOfficeId", SqlDbType.NVarChar);
                branchOfficeIdParameter.Direction = ParameterDirection.Input;
                branchOfficeIdParameter.Value = branchOfficeId;

                SqlParameter medicineIdParameter = cmd.Parameters.Add("@MedicineId", SqlDbType.NVarChar);
                medicineIdParameter.Direction = ParameterDirection.Input;
                medicineIdParameter.Value = medicineId;

                SqlParameter quantityParameter = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
                quantityParameter.Direction = ParameterDirection.Input;
                quantityParameter.Value = quantity;

                SqlParameter salesParameter = cmd.Parameters.Add("@Sales", SqlDbType.Int);
                salesParameter.Direction = ParameterDirection.Input;
                salesParameter.Value = sales;

                SqlParameter priceParameter = cmd.Parameters.Add("@Price", SqlDbType.NVarChar);
                priceParameter.Direction = ParameterDirection.Input;
                priceParameter.Value = price;

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
                //Closing connection
                connection.Close();
            }
            return resultCodes;
        }

        //uspSynchronizeMedicinesPerBranchOffice @BranchOfficeId uniqueidentifier, @MedicineId uniqueidentifier, @Quantity int, @Sales int
        /// <summary>
        /// Synchronizes quantity and sales information from a medicine located in a specific branch office.
        /// </summary>
        /// <param name="branchOfficeId"></param>
        /// <param name="medicineId"></param>
        /// <param name="quantity"></param>
        /// <param name="sales"></param>
        /// <returns>Result codes indicating whether the operation was successful or not.</returns>
        public int[] SynchronizeMedicine(string branchOfficeId, string medicineId, int quantity, int sales)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspSynchronizeMedicinesPerBranchOffice", connection))
            {
                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;

                SqlParameter branchOfficeIdParameter = cmd.Parameters.Add("@BranchOfficeId", SqlDbType.NVarChar);
                branchOfficeIdParameter.Direction = ParameterDirection.Input;
                branchOfficeIdParameter.Value = branchOfficeId;

                SqlParameter medicineIdParameter = cmd.Parameters.Add("@MedicineId", SqlDbType.NVarChar);
                medicineIdParameter.Direction = ParameterDirection.Input;
                medicineIdParameter.Value = medicineId;

                SqlParameter quantityParameter = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
                quantityParameter.Direction = ParameterDirection.Input;
                quantityParameter.Value = quantity;

                SqlParameter salesParameter = cmd.Parameters.Add("@Sales", SqlDbType.Int);
                salesParameter.Direction = ParameterDirection.Input;
                salesParameter.Value = sales;
                
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

                //Closing connection
                connection.Close();
            }
            return resultCodes;
        }
    }
}