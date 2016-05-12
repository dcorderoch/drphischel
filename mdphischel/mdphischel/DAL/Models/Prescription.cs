using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mdphischel.DAL.Models
{
    public class Prescription
    {

        public string PrescriptionId { get; set; }
        public string DoctorId { get; set; }
        public int UserId { get; set; }
    }
}