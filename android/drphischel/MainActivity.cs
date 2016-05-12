using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Locations;
using Newtonsoft.Json;
using System;
using drphischel.Models;

namespace drphischel
{
    [Activity(Label = "drphischel", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static LoggedUserData User = null;
        public static int UserRole = 1;

        Button _loginButton;
        RadioButton _patientRadioButton;
        RadioButton _medicRadioButton;

        EditText _userIdText;
        EditText _passText;

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
            _passText = FindViewById<EditText>(Resource.Id.userPassInput);

            _patientRadioButton = FindViewById<RadioButton>(Resource.Id.patient_login);
            _medicRadioButton = FindViewById<RadioButton>(Resource.Id.medic_login);

            _patientRadioButton.Click += RoleSelection;
            _medicRadioButton.Click += RoleSelection;

            _loginButton = FindViewById<Button>(Resource.Id.loginButton);

            _loginButton.Click += async (sender, e) =>
            {
                string loginResult = await ApiClient.ApiLogin(_userIdText.Text, _passText.Text, UserRole.ToString());

                UserLogin(loginResult,(UserRole == 1));
            };
        }
        /// <summary>
        /// this method logs the user in and starts the corresponding 'Activity'
        /// </summary>
        /// <param name="pLoggedInUserData"></param>
        /// <param name="pPatient"></param>
        void UserLogin(string pLoggedInUserData, bool pPatient)
        {
            User = JsonConvert.DeserializeObject<LoggedUserData>(pLoggedInUserData);
            _loginButton = FindViewById<Button>(Resource.Id.loginButton);
            Intent intent;

            if (pPatient)
            {
                intent = new Intent(this, typeof(MedicActivity));
            }
            else
            {
                intent = new Intent(this, typeof(PatientActivity));
            }
            intent.PutExtra("CurrentUserId", User.UserId);
            StartActivity(intent);
        }
        /// <summary>
        /// this method receives a signal when the radiobuttons are selected,
        /// and changes the variable UserRole correspondingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void RoleSelection(object sender, EventArgs e)
        {
            var rb = (RadioButton) sender;
            if(rb.Text.Equals("medic"))
            {
                UserRole = 2;
            }

            if (rb.Text.Equals("patient"))
            {
                UserRole = 1;
            }
        }
    }
}