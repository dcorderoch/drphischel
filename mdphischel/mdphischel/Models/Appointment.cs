using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mdphischel.Models
{
    public class Appointment
    {
        public string DoctorId { get; set; }
        public string UserId { get; set; }
        public string AppointmentDate { get; set; }
    }
}