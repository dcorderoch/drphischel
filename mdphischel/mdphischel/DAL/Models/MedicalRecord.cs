using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mdphischel.DAL.Models
{
    public class MedicalRecord
    {
        public  int MedicalRecordId { get; set; }
        public string DoctorId { get; set; }
        public string AppointmentDate { get; set; }
        public string Description { get; set; }
        public string Diagnosis { get; set; }
        public  string PrescriptionId { get; set; }
    }
}