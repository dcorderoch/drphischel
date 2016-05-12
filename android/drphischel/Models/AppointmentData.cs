using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace drphischel.Models
{
    class AppointmentData
    {
        public string UserId { get; set; }
        public string DoctorId { get; set; }
        public string AppointmentDate { get; set; }
    }
}