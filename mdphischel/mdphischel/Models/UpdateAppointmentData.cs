namespace mdphischel.Models
{
    public class UpdateAppointmentData
    {
        public string UserId { get; set; }
        public string DoctorId { get; set; }
        public string OldAppointmentDate { get; set; }
        public string NewAppointmentDate { get; set; }
    }
}