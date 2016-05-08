using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net;
using Android.App;
using Android.Widget;
using Android.OS;
using System.Json;
using System.Net.Http;
using Android.Content;
using drphischel_mobile_android.Models;
using Newtonsoft.Json;
using Stream = System.IO.Stream;

namespace drphischel_mobile_android
{
    [Activity(Label = "drphischel_mobile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static LoggedUserData User = null;

        EditText _userIDInput;
        EditText _userPassInput;
        RadioButton _patientLogin;
        RadioButton _medicLogin;

        Button _LoginButton;

        Button _buttonPrev;
        Button _buttonNext;
        TextView _textTitle;
        ImageView _imageApp;

        /// <summary>
        /// this method creates the elements described in the axml file, and binds them to functionality defined here
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            _userIDInput = FindViewById<EditText>(Resource.Id.userIdInput);
            _userPassInput = FindViewById<EditText>(Resource.Id.userPassInput);

            _patientLogin = FindViewById<RadioButton>(Resource.Id.patient_login);
            _medicLogin = FindViewById<RadioButton>(Resource.Id.medic_login);

            _LoginButton = FindViewById<Button>(Resource.Id.loginButton);

            _LoginButton.Click += async (sender, e) =>
            {
                string url = "drphischel-login-uri";
                string loginResult = await getLoginResult(url);
                dealwithLogin(loginResult);
            };
        }

        void dealwithLogin(string loggedInUserData)
        {
            if (!loggedInUserData.Equals("crap"))
            {
                User = JsonConvert.DeserializeObject<LoggedUserData>(loggedInUserData);
                var intent = new Intent();
                intent.Extras.PutString("UserId",User.IdNumber);
                StartActivity(typeof(PatientActivity));
            }
            else
            {
                //INSERT LOGIN UNSUCCESFUL CODE HERE
            }
        }

        async Task<string> getLoginResult(string url)
        {
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var item = new LoginData
            {
                IdNumber = _userIDInput.Text,
                Pass = _userPassInput.Text
            };

            if (_medicLogin.Activated)
            {
                item.Role = "2";
            }
            if (_patientLogin.Activated)
            {
                item.Role = "1";
            }

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var loggedUserData = await response.Content.ReadAsStringAsync();
                    return loggedUserData;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return "crap";
        }
        

        /// <summary>
        /// this method updates the text and the image that the Next button is supposed to do
        /// </summary>
        /// <param name="json"></param>
        private void ParseAndDisplay(JsonValue json)
        {
            JsonValue weatherResults = json["weatherObservation"];
            double temp = weatherResults["temperature"];

            //_textTitle = FindViewById<TextView>(Resource.Id.textTitle);
            _textTitle.Text = temp.ToString();
            _imageApp.SetImageResource(Resource.Drawable.is_it_worth_the_time);
        }

        /// <summary>
        /// this method gets the json from the REST WEB API
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<JsonValue> FetchWeatherAsync(string url)
        {
            // Create an HTTP web request using the URL:
            Uri theuri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(theuri);
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonValue.Load(stream));
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

                    // Return the JSON document:
                    return jsonDoc;
                }
            }
        }

        /// <summary>
        /// this method implements the previous button functionality of the main activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void buttonPrev_Click(object sender, EventArgs e)
        {
            _textTitle.Text = "Prev Clicked";
            _imageApp.SetImageResource(Resource.Drawable.Icon);
        }
    }
}