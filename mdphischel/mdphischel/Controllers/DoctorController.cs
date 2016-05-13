using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using drphischel.Models;
using mdphischel.BLL;
using mdphischel.DAL.Models;
using mdphischel.Models;
using Newtonsoft.Json;

namespace mdphischel.Controllers
{
    public class DoctorController : ApiController
    {
        [HttpPost]
        public JsonResult<ReturnStatus> LoadPatients()
        {
            //var
            var retVal = new ReturnStatus();

            //retVal.StatusCode

            return Json(retVal);
        }
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

            var bllresult = patmanager.GetDoctorsByPatient(Int32.Parse(pPatient.UserId));

            if (bllresult.Count > 1)
            {
                bllresult.RemoveAt(0);
                int upperlimit = bllresult.Count;
                for (int i = 0; i < upperlimit / 2; i++)
                {
                    medics.Add(new MedicByPatient() {DoctorId = bllresult.ToArray()[0],Name = bllresult.ToArray()[1]});
                    bllresult.RemoveAt(0);
                    bllresult.RemoveAt(0);
                }
            }
            //medics.AddRange(patmanager.GetDoctorsByPatient());

            return Json(medics);
        }

        [HttpPost]
        public JsonResult<UnapprovedMedic> GetMedicIdentifier(PatientIdData pUser)
        {
            var retVal = new UnapprovedMedic();
            var patManager = new PatientManager();

            var result = patManager.GetDoctor(Int32.Parse(pUser.UserId));

            if (Int32.Parse(result.ToArray()[0]) == 1)
            {
                retVal.DoctorId = result.ToArray()[1];
            }
            else
            {
                retVal.DoctorId = "-1";
            }

            return Json(retVal);
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
