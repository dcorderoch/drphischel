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
    class LoginData
    {
        public string IdNumber { get; set; }
        public string Pass { get; set; }
        public string Role { get; set; }
    }
}