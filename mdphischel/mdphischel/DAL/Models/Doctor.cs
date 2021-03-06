﻿namespace mdphischel.DAL.Models
{
    public class Doctor
    {
        /// <summary>
        /// Members of class definition.
        /// </summary>
        public string DoctorId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string PlaceResidence { get; set; }
        public string BirthDate { get; set; }
        public string OfficeAddress { get; set; }
        public bool IsActive { get; set; }
        public string CreditCardNumber { get; set; }
    }
}