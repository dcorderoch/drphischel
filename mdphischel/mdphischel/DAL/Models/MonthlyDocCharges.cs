using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mdphischel.DAL.Models
{
    /// <summary>
    /// Model object to represent doctor's monthly charges list
    /// </summary>
    public class MonthlyDocCharges
    {
        //pos 0 is the resut code (1= success, 0=fail) , pos 1 is the errorcode (sql error code num).
        public int[] ResultCodes { get; set; }
        public List<DoctorsCharge> ChargesList { get; set; }


        public MonthlyDocCharges()
        {
            ResultCodes = new int[2];
            ChargesList = new List<DoctorsCharge>();
            
        }

        public void AddCharge(DoctorsCharge newCharge)
        {
            ChargesList.Add(newCharge);
        }
    }
}