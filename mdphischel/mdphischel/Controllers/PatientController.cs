using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using mdphischel.BLL;
using mdphischel.DAL.Models;
using mdphischel.Models;

namespace mdphischel.Controllers
{
    public class PatientController : ApiController
    {
        [HttpPost]
        public JsonResult<ReturnStatus> CreateByMedic(NewPatientByMedic pNewPatient)
        {
            var retVal = new ReturnStatus();
            var patmanager = new PatientManager();
            retVal.StatusCode = patmanager.CreatePatientByDoctor(pNewPatient.IdNumber, pNewPatient.Pass,
                pNewPatient.Name, pNewPatient.LastName1, pNewPatient.LastName2, pNewPatient.ResidencePlace,
                pNewPatient.BirthDate, pNewPatient.DoctorID);

            return Json(retVal);
        }
        //public int CreatePatientByAdmin(string idNumber, string password, string name, string lastName1, string lastName2, string residence, string birthDate)
        [HttpPost]
        public JsonResult<ReturnStatus> CreateByAdmin(NewPatientByAdmin pNewPatient)
        {
            var retVal = new ReturnStatus();
            var patmanager = new PatientManager();
            retVal.StatusCode = patmanager.CreatePatientByAdmin(pNewPatient.IdNumber, pNewPatient.Pass,
                pNewPatient.Name, pNewPatient.LastName1, pNewPatient.LastName2, pNewPatient.ResidencePlace,
                pNewPatient.BirthDate);

            return Json(retVal);
        }

        [HttpPost]
        public JsonResult<ReturnStatus> Update(NewPatientByAdmin pNewPatient)
        {
            var retVal = new ReturnStatus();
            var patmanager = new PatientManager();
            retVal.StatusCode = patmanager.UpdatePatient(pNewPatient.IdNumber, pNewPatient.Pass,
                pNewPatient.Name, pNewPatient.LastName1, pNewPatient.LastName2, pNewPatient.ResidencePlace,
                pNewPatient.BirthDate);

            return Json(retVal);
        }

        [HttpPost]
        public JsonResult<ReturnStatus> Delete(PatientIdData pData)
        {
            var retVal = new ReturnStatus();
            var patmanager = new PatientManager();
            retVal.StatusCode = patmanager.DeletePatient(pData.UserId);
            return Json(retVal);
        }

        [HttpPost]
        public JsonResult<List<User>> GetByMedic(UnapprovedMedic pMedic)
        {
            var medicManager = new DoctorManager();
            return Json(medicManager.GetPatientsByDoctorId(pMedic.DoctorId));
        }
    }
}
