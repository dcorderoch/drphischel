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
using drphischel_mobile_android.Models;

namespace drphischel_mobile_android
{
    [Activity(Label = "MedicsActivity")]
    public class PatientsMedicsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PatientsMedics);
            
            var lv = FindViewById<ListView>(Resource.Id.PatientsMedicsList);
            lv.Adapter = new ArrayAdapter<MedicListItem>(this,Android.Resource.Layout.SimpleListItem1,Android.Resource.Id.Text1,)











            //lv.Adapter = new ArrayAdapter<Item>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, MainActivity.Items);	
        }
    }
}