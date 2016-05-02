using System;
using System.Configuration;
using System.Web.Configuration;


namespace mdphischel.DAL
{
    public class DBConfigurator
    {
        public static string ConnectionString

        {

            get

            {
                var mySetting = WebConfigurationManager.ConnectionStrings;
                if (mySetting == null || string.IsNullOrEmpty(mySetting["DrPhischel"].ConnectionString))
                    throw new Exception("Fatal error: missing connecting string in web.config file");
                var conString = mySetting["DrPhischel"].ConnectionString;
                return conString;
            }

        }

    }
}