using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mdphischel.DAL
{
    public class DoctorDBManager
    {

        public int[] PreRegistation(String docCode, String pass, String idNumber, String name, String lastName1, String lastName2, String residencePlace, String birthdate, String officeAddres, String creditCardNum)
        {
            int[] resultCodes = new int[2];
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_preregistDoc",connection))
            {
                
                SqlParameter errorCodeParameter = cmd.Parameters.Add("@errorNum", SqlDbType.Int);
                errorCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter resultCodeParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultCodeParameter.Direction = ParameterDirection.Output;
                SqlParameter docCodeParameter = cmd.Parameters.Add("@docCode", SqlDbType.NVarChar);
                docCodeParameter.Direction = ParameterDirection.Input;
                docCodeParameter.Value = docCode;
                SqlParameter passwordParameter = cmd.Parameters.Add("@pass", SqlDbType.NVarChar);
                passwordParameter.Direction = ParameterDirection.Input;
                passwordParameter.Value = pass;
                SqlParameter idNumberParameter = cmd.Parameters.Add("@idNumber", SqlDbType.Char);
                idNumberParameter.Direction = ParameterDirection.Input;
                idNumberParameter.Value = idNumber;
                SqlParameter nameParameter = cmd.Parameters.Add("@name", SqlDbType.NVarChar);
                nameParameter.Direction = ParameterDirection.Input;
                nameParameter.Value = name;
                SqlParameter lastName1Parameter = cmd.Parameters.Add("@lastName1", SqlDbType.NVarChar);
                lastName1Parameter.Direction = ParameterDirection.Input;
                lastName1Parameter.Value = lastName1;
                SqlParameter lastName2Parameter = cmd.Parameters.Add("@lastName2", SqlDbType.NVarChar);
                lastName2Parameter.Direction = ParameterDirection.Input;
                lastName2Parameter.Value = lastName2;
                SqlParameter residencePlaceParameter = cmd.Parameters.Add("@residencePlace", SqlDbType.NVarChar);
                residencePlaceParameter.Direction = ParameterDirection.Input;
                residencePlaceParameter.Value = residencePlace;
                SqlParameter birthDateParameter = cmd.Parameters.Add("@birthDate", SqlDbType.NVarChar);
                birthDateParameter.Direction = ParameterDirection.Input;
                birthDateParameter.Value = birthdate;
                SqlParameter officeAddressParameter = cmd.Parameters.Add("@officeAddress", SqlDbType.NVarChar);
                officeAddressParameter.Direction = ParameterDirection.Input;
                officeAddressParameter.Value = officeAddres;
                SqlParameter creditCardNumParameter = cmd.Parameters.Add("@creditCardNum", SqlDbType.NVarChar);
                creditCardNumParameter.Direction = ParameterDirection.Input;
                creditCardNumParameter.Value = creditCardNum;

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
                        resultCodes[1]=int.Parse(errorNumCode.ToString());
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