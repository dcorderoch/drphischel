using System.IO;
using System.Net;
using System.Threading.Tasks;
using drphischel.Models;
using Newtonsoft.Json;

namespace drphischel
{
    class ApiClient
    {
        private static string _baseUrl = "http://drphischel-env.us-west-2.elasticbeanstalk.com/";

        private static string _apiUserLogin = "api/user/login";
        private static string _apiPatientsByMedic = "api/patient/getbymedic";
        private static string _apiMedicsByPatient = "api/doctor/getbypatient";
        private static string _apiAddPatientByMedic = "api/patient/createbymedic";



        private static string _apiMedRecsByPatient = "api/medicalrecords/viewallbypatient";
        private static string _apiAppointmentsbyMedic = "api/appointment/getbyDoctorId";
        private static string _apiAddAppointment = "api/appointment/create";

        public static async Task<string> ApiAddPatientByMedic(string pUserId, string pPass, string pName, string pLastName1, string pLastName2, string pResidencePlace, string pBirthDate, string pDoctorID)
        {
            string url = _baseUrl + _apiPatientsByMedic;
            var newPatient = new NewPatient()
            {
                UserId = pUserId,
                Pass = pPass,
                Name = pName,
                LastName1 = pLastName1,
                LastName2 = pLastName2,
                ResidencePlace = pResidencePlace,
                BirthDate = pBirthDate,
                DoctorID = pDoctorID
            };
            var data = JsonConvert.SerializeObject(newPatient);

            return await APiPostCalls(url, data);
        }

        public static async Task<string> ApiPatientsByMedicId(string pMedicId)
        {
            string url = _baseUrl + _apiPatientsByMedic;
            var medic = new UserInfo()
            {
                UserId = pMedicId
            };
            var data = JsonConvert.SerializeObject(medic);

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
            string url = _baseUrl + _apiUserLogin;
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