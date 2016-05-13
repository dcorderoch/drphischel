using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mdphischel.Models
{
    public class NewPatientByAdmin
    {
        public string IdNumber { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string ResidencePlace { get; set; }
        public string BirthDate { get; set; }
    }
}