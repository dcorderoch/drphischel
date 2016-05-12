using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using drphischel.Models;
using drphischel_mobile_android.Models;
using Newtonsoft.Json;

namespace drphischel
{
    class ApiClient
    {
        private static string _baseUrl = "http://drphischel-env.us-west-2.elasticbeanstalk.com/";
        private static string _apiMedicsByPatient = "api/doctor/getbypatient";
        private static string _apiLogin = "api/User/Login";
        private static string _apiMakeAppointment = "api/appointment/create";

        public static async Task<string> ApiMakeAppointment(string pUserId, string pDoctorId, string pDate)
        {
            var url = _baseUrl + _apiMakeAppointment;
            var appointment = new AppointmentData()
            {
                UserId = pUserId,
                DoctorId = pDoctorId,
                AppointmentDate = pDate
            };
            var data = JsonConvert.SerializeObject(appointment);
            return await APiPostCalls(url, data);
        }

        public static async Task<string> ApiMedicbyPatientId(string pPatientId)
        {
            string url = _baseUrl + _apiMedicsByPatient;
            var patient = new UserInfo()
            {
                UserId = pPatientId
            };
            var data = JsonConvert.SerializeObject(patient);

            return await APiPostCalls(url, data);
        }
        public static async Task<string> ApiLogin(string pIdNumber, string pPassword, string pRole)
        {
            string url = _baseUrl + _apiLogin;
            var item = new LoginData
            {
                IdNumber = pIdNumber,
                Pass = pPassword,
                Role = pRole
            };
            var data = JsonConvert.SerializeObject(item);

            return await APiPostCalls(url, data);
        }
        public static async Task<string> APiPostCalls(string pUrl, string pData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pUrl);
            request.ContentType = "application/json";
            request.Method = "POST";

            var stream = await request.GetRequestStreamAsync();
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(pData);
                writer.Flush();
                writer.Dispose();
            }
            var response = await request.GetResponseAsync();
            var respStream = response.GetResponseStream();

            using (StreamReader sr = new StreamReader(respStream))
            {
                //Need to return this response 
                return sr.ReadToEnd();
            }
        }
        
    }
}