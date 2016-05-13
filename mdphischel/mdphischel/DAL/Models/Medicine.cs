namespace mdphischel.DAL.Models
{
    public class Medicine
    {
        /// <summary>
        /// Members of class definition.
        /// </summary>
        public string BranchOfficeId { get; set; }
        public string MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public int Sales { get; set; }
        public string Price { get; set; }

        public Medicine() { }
    }
}