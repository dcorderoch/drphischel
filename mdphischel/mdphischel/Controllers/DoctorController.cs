using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using drphischel.Models;
using mdphischel.BLL;
using mdphischel.DAL.Models;
using mdphischel.Models;

namespace mdphischel.Controllers
{
    public class DoctorController : ApiController
    {
        [HttpPost]
        public JsonResult<ReturnStatus> Create(MedicCreateData pMedic)
        {
            var medicmanager = new DoctorManager();
            return Json(new ReturnStatus()
            {
                StatusCode = medicmanager.PreregisterDoctor(pMedic.DoctorId,
                pMedic.Pass, pMedic.UserId,pMedic.Name, pMedic.LastName1,
                pMedic.LastName2,pMedic.PlaceResidence, pMedic.BirthDate, pMedic.OfficeAddress, pMedic.CreditCardNumber)
            });
        }

        [HttpPost]
        public JsonResult<List<MedicByPatient>> GetByPatient(PatientIdData pPatient)
        {
            var patmanager = new PatientManager();
            //return Json(patmanager.GetDoctorsByPatient(Int32.Parse(pPatient.UserId)));

            var medics = new List<MedicByPatient>();



            return Json(medics);
        }

        [HttpPost]
        public JsonResult<ReturnStatus> Accept(UnapprovedMedic pMedic)
        {
            var medicmanager = new DoctorManager();
            return Json(new ReturnStatus() {StatusCode = medicmanager.AcceptDoctor(pMedic.DoctorId)});
        }

        [HttpPost]
        public JsonResult<ReturnStatus> Reject(UnapprovedMedic pMedic)
        {
            var medicmanager = new DoctorManager();
            return Json(new ReturnStatus() { StatusCode = medicmanager.RejectDoctor(pMedic.DoctorId) });
        }

        [HttpGet]
        public JsonResult<List<Doctor>> GetListOfPending()
        {
            var medicmanager = new DoctorManager();
            return Json(medicmanager.GetPendingDoctors());
        }
    }
}
