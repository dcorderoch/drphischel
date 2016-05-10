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
        /// <param name="role"></param>
        /// <returns>User, if exists.</returns>
        public User AcceptLogin(int userId, int role)
        {
            
        }
    }
}