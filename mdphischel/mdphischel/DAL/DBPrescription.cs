using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mdphischel.DAL
{
    public class DBPrescription
    {



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




    }
}