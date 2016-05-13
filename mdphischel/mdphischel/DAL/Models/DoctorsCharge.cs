namespace mdphischel.DAL.Models
{
    /// <summary>
    /// Model to represent an element of the DoctorsCharges list
    /// </summary>
    public class DoctorsCharge
    {
        public string DoctorName{ get; set; }
        public string DoctorLastName1 { get; set; }
        public string DoctorLastName2 { get; set; }
        public string DoctorId { get; set; }
        public decimal Charge { get; set; }
    }
}