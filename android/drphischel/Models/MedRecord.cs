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
    class MedRecord
    {
        public string AppointmentDate { get; set; }
        public string MRDescription { get; set; }
        public string MRDiagnosis { get; set; }
        public List<Medicine> Medicines { get; set; }
    }
}