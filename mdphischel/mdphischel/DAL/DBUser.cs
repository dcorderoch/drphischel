using System;
using System.Data;
using System.Data.SqlClient;
using mdphischel.DAL.Models;

namespace mdphischel.DAL
{
    public class DBUser
    {
        /// <summary>
        /// Method in charge of validating the user login.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns>User, if exists.</returns>
        public User AcceptLogin(int userId, string password, int role)
        {
            //uspUserLogin @IdNumber char(9), @Pass nvarchar(30), @RoleId int
            //SystemUser.UserId, SystemUser.IdNumber, SystemUser.Name, SystemUser.LastName1, SystemUser.LastName2, SystemUser.BirthDate
            User user = new User();
            using (SqlConnection connection = new SqlConnection(DBConfigurator.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("uspUserLogin", connection))
            {
                SqlParameter userIdParameter = cmd.Parameters.Add("@IdNumber", SqlDbType.Int);
                userIdParameter.Direction = ParameterDirection.Input;
                userIdParameter.Value = userId;

                SqlParameter passwordParameter = cmd.Parameters.Add("Pass", SqlDbType.NVarChar);
                passwordParameter.Direction = ParameterDirection.Input;
                passwordParameter.Value = password;

                SqlParameter roleParameter = cmd.Parameters.Add("@RoleId", SqlDbType.Int);
                roleParameter.Direction = ParameterDirection.Input;
                roleParameter.Value = role;

                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.UserId = (int)reader[0];
                        user.IdNumber = reader[1].ToString();
                        user.Name = reader[2].ToString();
                        user.LastName1 = reader[3].ToString();
                        user.LastName2 = reader[4].ToString();
                        user.BirthDate = reader[5].ToString();
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return user;
        }
    }
}