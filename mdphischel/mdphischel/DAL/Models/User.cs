using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mdphischel.DAL.Models
{
    public class User
    {
        /// <summary>
        /// Members of class definition.
        /// </summary>
        public int UserId { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string BirthDate { get; set; }

        public User()
        {

        }
    }
}