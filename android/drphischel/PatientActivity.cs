using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using drphischel_mobile_android.Models;

namespace drphischel
{
    [Activity(Label = "Patient")]
    public class PatientActivity : Activity
    {
        public static List<MedicListItem> Medics = new List<MedicListItem>();
        public static string CurrentUserId = "";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            CurrentUserId = base.Intent.GetStringExtra("UserId");//.Extras.GetString("CurrentUserId");
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Patient);

            var medRecsButton = FindViewById<Button>(Resource.Id.medRecordsBtn);
            var appointmentsButton = FindViewById<Button>(Resource.Id.AppointmentBtn);

            appointmentsButton.Click += Getthething;
        }

        void MakeAppointMent()
        {
            var intent = new Intent(this, typeof(MedicListActivity));
            intent.PutExtra("CurrentUserId", CurrentUserId);//.Extras.PutString("CurrentUserId", User.CurrentUserId);
            StartActivity(intent);
        }

        private void Getthething(object sender, EventArgs e)
        {
            try
            {
                var appointmentsButton = FindViewById<Button>(Resource.Id.AppointmentBtn);
                appointmentsButton.Text = CurrentUserId;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}