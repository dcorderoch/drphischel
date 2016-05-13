using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace drphischel
{
    [Activity(Label = "Patient")]
    public class PatientActivity : Activity
    {
        public static string CurrentUserId = null;
        /// <summary>
        /// this method creates the elements described in the axml file, and binds them to functionality defined here
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            CurrentUserId = base.Intent.GetStringExtra("CurrentUserId");
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Patient);

            var medRecsButton = FindViewById<Button>(Resource.Id.medRecordsBtn);
            var appointmentsButton = FindViewById<Button>(Resource.Id.AppointmentBtn);
            var logOutButton = FindViewById<Button>(Resource.Id.LogOutBtn);

            appointmentsButton.Click += MakeAppointMent;
            medRecsButton.Click += ViewMedicalRecords;
            logOutButton.Click += LogOut;
        }

        private void LogOut(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity) );
            intent.SetFlags(ActivityFlags.ClearTop);
            StartActivity(intent);
        }

        void MakeAppointMent(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MedicListActivity));
            intent.PutExtra("CurrentUserId", CurrentUserId);
            StartActivity(intent);
        }

        void ViewMedicalRecords(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof (MedicalRecordsActivity));
            intent.PutExtra("CurrentUserId", CurrentUserId);
            StartActivity(intent);
        }
    }
}