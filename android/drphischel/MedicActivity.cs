using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace drphischel
{
    [Activity(Label = "MedicActivity")]
    public class MedicActivity : Activity
    {
        public static string CurrentUserId = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            CurrentUserId = base.Intent.GetStringExtra("CurrentUserId");
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Medic);

            var logOutBtn = FindViewById<Button>(Resource.Id.MedicLogOutBtn);
            var viewCalendarBtn = FindViewById<Button>(Resource.Id.MedicViewCalendarBtn);
            var viewPatientsBtn = FindViewById<Button>(Resource.Id.MedicViewPatientsBtn);
            var addPatientBtn = FindViewById<Button>(Resource.Id.MedicAddPatientBtn);

            logOutBtn.Click += LogOut;
            viewCalendarBtn.Click += ViewCalendar;
            viewPatientsBtn.Click += ViewPatients;
            addPatientBtn.Click += AddPatient;
        }

        private void AddPatient(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddPatientActivity));
            intent.PutExtra("MedicUserId", CurrentUserId);
            StartActivity(intent);
        }

        private void ViewPatients(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ViewPatientsActivity));
            intent.PutExtra("MedicUserId", CurrentUserId);
            StartActivity(intent);
        }

        private void ViewCalendar(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ViewCalendarActivity));
            intent.PutExtra("MedicUserId", CurrentUserId);
            StartActivity(intent);
        }

        private void LogOut(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTop);
            StartActivity(intent);
        }
    }
}