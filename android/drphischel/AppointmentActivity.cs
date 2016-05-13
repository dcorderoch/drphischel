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
using drphischel.Models;
using Newtonsoft.Json;

namespace drphischel
{
    [Activity(Label = "Appointment")]
    public class AppointmentActivity : Activity, DatePickerDialog.IOnDateSetListener, TimePickerDialog.IOnTimeSetListener
    {
        private TextView _dateDisplay;
        private Button _pickDate;
        private DateTime _date;

        private TextView _timeDisplay;
        private Button _pickTime;
        private int _hours;
        private int _minutes;

        private Button _makeAppointmentButton;

        private string _currentUserId;
        private string _currentDoctorId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            _currentUserId = base.Intent.GetStringExtra("CurrentUserId");
            _currentDoctorId = base.Intent.GetStringExtra("MedicIdForAppointment");
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Appointment);

            _dateDisplay = FindViewById<TextView>(Resource.Id.dateDisplay);
            _pickDate = FindViewById<Button>(Resource.Id.picDate);

            _timeDisplay = FindViewById<TextView>(Resource.Id.timeDisplay);
            _pickTime = FindViewById<Button>(Resource.Id.pickTime);

            _makeAppointmentButton = FindViewById<Button>(Resource.Id.makeAppointmentBtn);

            _makeAppointmentButton.Click += async (sender, e) =>
            {
                //1914-12-20 08:00
                string appointmentResult =
                    await
                        ApiClient.ApiMakeAppointment(_currentUserId, _currentDoctorId,
                            _dateDisplay.Text + " " + _timeDisplay.Text);

                var status = JsonConvert.DeserializeObject<ReturnStatus>(appointmentResult);
                string displayMesssage;
                displayMesssage = status.StatusCode == 1 ? "Listo!" : "Hora Ocupada";

                Toast.MakeText(this, displayMesssage, ToastLength.Short).Show();

                if (status.StatusCode == 1)
                {
                    Finish();
                }
            };

            // add a click event handler to the button
            _pickTime.Click += delegate { ShowTimePickerDialog(); };

            // get the current date
            _hours = 2;
            _minutes = 37;

            // display the current date (this method is below)
            UpdateDisplayTime(_hours, _minutes);

            // add a click event handler to the button
            _pickDate.Click += delegate { ShowDatePickerDialog(); };

            // get the current date
            _date = DateTime.Today;

            // display the current date (this method is below)
            UpdateDisplay(_date);
        }
        void ShowTimePickerDialog()
        {
            var dialog = new TimePickerFragment(this, _hours, _minutes, this);
            dialog.Show(FragmentManager, null);
        }

        public void OnTimeSet(TimePicker view, int hourOfDay, int minute)
        {
            UpdateDisplayTime(hourOfDay, minute);
        }

        void UpdateDisplayTime(int selectedHours, int selectedMinutes)
        {
            _timeDisplay.Text = selectedHours + ":" + selectedMinutes;
        }
        void ShowDatePickerDialog()
        {
            var dialog = new DatePickerFragment(this, DateTime.Now, this);
            dialog.Show(FragmentManager, null);
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            var newDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            UpdateDisplay(newDate);
        }

        void UpdateDisplay(DateTime selectedDate)
        {
            _dateDisplay.Text = selectedDate.ToString("yyyy-MM-dd");
        }
    }
}