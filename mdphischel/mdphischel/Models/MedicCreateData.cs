using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mdphischel.Models
{
    public class MedicCreateData
    {

        public string DoctorId { get; set; }
        public string UserId { get; set; }
        public string Pass { get; set; }
        public string OfficeAddress { get; set; }
        public string CreditCardNumber { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string PlaceResidence { get; set; }
        public string BirthDate { get; set; }
    }
}