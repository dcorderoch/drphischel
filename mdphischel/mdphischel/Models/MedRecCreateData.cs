﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mdphischel.Models
{
    public class MedRecCreateData
    {
        public string UserId { get; set; }
        public string AppointMentId { get; set; }
        public string Description { get; set; }
        public string Diagnosis { get; set; }
        public string PrescriptionId { get; set; }
    }
}