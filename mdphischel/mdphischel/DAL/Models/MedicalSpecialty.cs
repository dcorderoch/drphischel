using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mdphischel.DAL.Models
{
    public class MedicalSpecialty
    {
        /// <summary>
        /// Members of class definition.
        /// </summary>
        public int MedicalSpecialtyId { get; set; }
        public string Name { get; set; }

        public MedicalSpecialty()
        {
        }
    }
}