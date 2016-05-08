using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using drphischel_mobile_android.Models;
using Newtonsoft.Json;

namespace drphischel_mobile_android
{
    [Activity(Label = "Patient")]
    public class PatientActivity : Activity
    {
        public static List<MedicListItem> Medics = new List<MedicListItem>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //var PatientsMedics = await getMedics();
            //base.Intent.Extras.GetString("somekey", "somedefaultvalue");
            //Medics.AddRange(thedoctors);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Patient);
            // Create your application here
            var medRecsButton = FindViewById<Button>(Resource.Id.medRecordsBtn);
            var appointmentsButton = FindViewById<Button>(Resource.Id.AppointmentBtn);

            medRecsButton.Click += async (sender, e) =>
            {
                
            };
            appointmentsButton.Click += LoadMedics;
        }

        public async Task<List<MedicListItem>> getPatientsMedics()
        {
            string url = "getmedicsbypatientURI";
            //var retval = null;
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            //login model will be the item here that will be serialized



            var json = base.Intent.GetStringExtra("UserId");//JsonConvert.SerializeObject(item);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var loggedUserData = await response.Content.ReadAsStringAsync();
                    //JsonConvert.DeserializeObject<LoggedUserData>(loggedInUserData);
                    var retval = JsonConvert.DeserializeObject<List<MedicListItem>>(loggedUserData);

                    return retval;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            //return retval;
        }

        void LoadMedics(object sender, EventArgs e)
        {


            var intent = new Intent(this, typeof(PatientsMedicsActivity));
            StartActivity(intent);
        }

        void LoadMedRecords(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MedRecsActivity));
            StartActivity(intent);
        }
    }
}