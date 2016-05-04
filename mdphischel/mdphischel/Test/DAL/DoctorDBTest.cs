using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mdphischel.DAL;

namespace mdphischel.Test.DAL
{
    public class DoctorDBTest
    {
        public void PreRegistrationDoctorTest()
        {
            DoctorDBManager doctorDb = new DoctorDBManager();
            var result=doctorDb.PreRegistation("DOC222", "eeewwwsss", "123454322", "Mauricio", "Huertas", "Gutierrez",
                "San Jose", "19700615", "San Jose", "3456987098767654");
            var result2 = doctorDb.AcceptDoctor("DOC22");
            var result3 = doctorDb.GetMonthlyCharges("DOC222","20160601");
        }
    }
}