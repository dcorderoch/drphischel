using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mdphischel.DAL.Models
{
    public class Doctor
    {
        /// <summary>
        /// Members of class definition.
        /// </summary>
        public string DoctorId { get; set; }
        public int UserId { get; set; }
        public string OfficeAddress { get; set; }
        public bool IsActive { get; set; }
        public string CreditCardNumber { get; set; }
    }
}