using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Web;
using mdphischel.DAL;

namespace mdphischel.BLL
{
    /// <summary>
    /// Class whose intention is to validate a user's log in.
    /// </summary>
    public class AccountManager
    {
        /// <summary>
        /// Method that returns to the REST API the corresponding user's information if and only if the parameters given match a user in the DB.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns>User information.</returns>
        public List<string> AuthorizeLogin(int userId, string password, int role)
        {
            List<string> retVal = new List<string>();
            DBUser dbUserInstance = new DBUser();
            try
            {
                var user = dbUserInstance.AcceptLogin(userId, password, role);

                retVal.Add(Constants.SUCCESS.ToString());
                retVal.Add(user.UserId.ToString());
                retVal.Add(user.IdNumber);
                retVal.Add(user.Name);
                retVal.Add(user.LastName1);
                retVal.Add(user.LastName2);
                retVal.Add(user.BirthDate);

            }
            catch (Exception)
            {
                retVal.Add(Constants.ERROR.ToString());
            }
            return retVal;
        }
    }
}