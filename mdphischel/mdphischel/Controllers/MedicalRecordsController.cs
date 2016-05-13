using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using mdphischel.BLL;
using mdphischel.DAL.Models;
using mdphischel.Models;

namespace mdphischel.Controllers
{
    public class MedicalRecordsController : ApiController
    {
        [HttpPost]
        public JsonResult<List<MedicalRecord>> ViewAllByPatient(PatientIdData pData)
        {
            var medrecsmanager = new MedicalRecordManager();
            return Json(medrecsmanager.GetMedicalRecords(Int32.Parse(pData.UserId)));
        }

        //public int AddMedicalRecordEntry(int userId, int appointmentId, string description, string diagnosis, string prescriptionId)
        //int userId, int appointmentId, string description, string diagnosis, string prescriptionId
        [HttpPost]
        public JsonResult<ReturnStatus> Create(MedRecCreateData pData)
        {
            var medrecsmanager = new MedicalRecordManager();
            return
                Json(new ReturnStatus()
                {
                    StatusCode =
                        medrecsmanager.AddMedicalRecordEntry(Int32.Parse(pData.UserId), Int32.Parse(pData.AppointMentId), pData.Description,
                            pData.Diagnosis, pData.PrescriptionId)
                });
        }
    }
}
