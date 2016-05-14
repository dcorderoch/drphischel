using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using mdphischel.DAL.Models;

namespace mdphischel.DAL
{
    public class DBBranchOffice
    {

        /// This method calls a stored procedure to get all the branchoffices
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public List<BranchOffice> GetPrescriptionByDoctor(string doctorId)
        {
            List<BranchOffice> branchOfficeList = new List<BranchOffice>();
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_getBranchOffices", connection))
            {
                SqlParameter doctorIdParameter = cmd.Parameters.Add("@doctorId", SqlDbType.NVarChar);
                doctorIdParameter.Direction =ParameterDirection.Input;
                doctorIdParameter.Value = doctorId;
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BranchOffice BO = new BranchOffice();
                        BO.BranchOfficeId = (string) reader[0].ToString();
                        BO.Name = (string) reader[1].ToString();
                        BO.PhoneNum = (string) reader[2].ToString();
                        BO.BOLocation = (string) reader[3].ToString();
                        branchOfficeList.Add(BO);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return branchOfficeList;
        }
    }
}