using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using drphischel_mobile_android.Models;
using Newtonsoft.Json;

namespace drphischel
{
    [Activity(Label = "drphischel", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static LoggedUserData User = null;

        Button _loginButton;
        RadioButton _patientRadioButton;
        RadioButton _medicRadioButton;

        EditText _userIdText;
        EditText _PassText;

        /// <summary>
        /// this method creates the elements described in the axml file, and binds them to functionality defined here
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            _userIdText = FindViewById<EditText>(Resource.Id.userIdInput);
            _PassText = FindViewById<EditText>(Resource.Id.userPassInput);

            _patientRadioButton = FindViewById<RadioButton>(Resource.Id.patient_login);
            _medicRadioButton = FindViewById<RadioButton>(Resource.Id.medic_login);

            _loginButton = FindViewById<Button>(Resource.Id.loginButton);

            _loginButton.Click += async (sender, e) =>
            {
                string loginResult = await ApiClient.ApiLogin(_userIdText.Text, _PassText.Text);
                DealwithLogin(loginResult);
            };
        }

        void DealwithLogin(string loggedInUserData)
        {
            User = JsonConvert.DeserializeObject<LoggedUserData>(loggedInUserData);
            _loginButton = FindViewById<Button>(Resource.Id.loginButton);

            var intent = new Intent(this, typeof (PatientActivity));
            intent.PutExtra("UserId", User.UserId);//.Extras.PutString("CurrentUserId", User.CurrentUserId);
            StartActivity(intent);
        }
    }
}