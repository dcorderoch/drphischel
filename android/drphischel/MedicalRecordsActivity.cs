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

namespace drphischel
{
    [Activity(Label = "MedicalRecordsActivity")]
    public class MedicalRecordsActivity : Activity
    {
        private ListView _medicalrecords;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MedicalRecords);

            _medicalrecords = FindViewById<ListView>(Resource.Id.MedRecordsList);
        }
    }
}