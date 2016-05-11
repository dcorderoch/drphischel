using System.IO;
using System.Net;
using System.Threading.Tasks;
using drphischel_mobile_android.Models;
using Newtonsoft.Json;

namespace drphischel
{
    class ApiClient
    {
        private static string _baseUrl = "http://drphischel-env.us-west-2.elasticbeanstalk.com/";
        private static string _apiMedicsByPatient = "api/doctor/getbypatient";
        private static string _apiLogin = "api/User/Login";
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
        //GOTTA CHANGE THIS TO INCLUDE A ROLE
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

            return await ApiClient.APiPostCalls(url, data);
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