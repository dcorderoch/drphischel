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

namespace drphischel_mobile_android.Models
{
    public class LoggedUserData
    {
        public string UserId { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string BirthDate { get; set; }
    }
}