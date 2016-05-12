using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BranchOffice BO = new BranchOffice();
                        BO.BranchOfficeId = (string) reader[0];
                        BO.Name = (string) reader[1];
                        BO.PhoneNum = (string) reader[2];
                        BO.BOLocation = (string) reader[3];
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