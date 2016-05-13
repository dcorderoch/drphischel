using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace drphischel.Models
{
    public class NewPrescriptionInfo
    {
        public string UserId { get; set; }
        public string DoctorId { get; set; }
        public List<PrescriptionMedicine> Medicines { get; set; }
    }
}