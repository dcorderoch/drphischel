using System.Collections.Generic;

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