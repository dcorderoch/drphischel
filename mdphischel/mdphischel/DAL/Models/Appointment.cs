namespace mdphischel.DAL.Models
{
    public class Appointment
    {
        /// <summary>
        /// Members of class definition.
        /// </summary>
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public string DoctorId { get; set; }
        public string AppointmentDate { get; set; }

        public Appointment()
        {
            
        }
    }
}