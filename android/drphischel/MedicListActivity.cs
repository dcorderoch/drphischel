using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using drphischel.Models;
using Newtonsoft.Json;

namespace drphischel
{
    [Activity(Label = "MedicList")]
    public class MedicListActivity : ListActivity
    {
        string _currentUserId;
        List<MedicListItem> _medics;
        List<string> _medicNames ;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MedicList);

            _medics = new List<MedicListItem>();

            _currentUserId = base.Intent.GetStringExtra("CurrentUserId");

            string medicsJson = await ApiClient.ApiMedicbyPatientId(_currentUserId);

            _medics = JsonConvert.DeserializeObject<List<MedicListItem>>(medicsJson);

            _medicNames = new List<string>();

            foreach (var medic in _medics)
            {
                _medicNames.Add(medic.Name + " " + medic.LastName1 + " " + medic.LastName2);
            }

            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _medicNames);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var medicId = _medics.ToArray()[position].DoctorId;
            var intent = new Intent(this, typeof(AppointmentActivity));
            intent.PutExtra("CurrentUserId", _currentUserId);
            intent.PutExtra("MedicIdForAppointment", medicId);
            StartActivity(intent);
        }
    }
}