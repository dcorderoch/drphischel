using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mdphischel.Test.DAL
{
    public class DALTest
    {
        public void test()
        {
            DoctorDBTest doctest=new DoctorDBTest();
            doctest.PreRegistrationDoctorTest();
        }
    }
}