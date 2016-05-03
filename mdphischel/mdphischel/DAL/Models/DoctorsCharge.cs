using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mdphischel.DAL.Models
{
    /// <summary>
    /// Model to represent an element of the DoctorsCharges list
    /// </summary>
    public class DoctorsCharge
    {
        public string UserId { get; set; }
        public string AppointmentDate { get; set; }
    }
}