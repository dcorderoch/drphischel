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
    public class PrescriptionController : ApiController
    {
        //public int AddMedicineIntoPrescription(string medicineId, string prescriptionId)
        public JsonResult<ReturnStatus> Addmedicinetoprescription(NewMedInPrescription pNewMed)
        {
            var prescManager = new PrescriptionManager();
            var retVal = new ReturnStatus();
            retVal.StatusCode = prescManager.AddMedicineIntoPrescription(pNewMed.MedicineId, pNewMed.PrescriptionId);
            return Json(retVal);
        }

        public JsonResult<ReturnStatus> Create(NewPrescriptionInfo pPresc)
        {
            var prescmanager = new PrescriptionManager();
            var retVal = new ReturnStatus();

            //int prelim = prescManager.AddMedicineIntoPrescription(pPresc., pNewMed.PrescriptionId);

            retVal.StatusCode = prescmanager.CreatePrescription(pPresc.DoctorId, Int32.Parse(pPresc.UserId));

            List<PrescriptionMedicine> medicines = new List<PrescriptionMedicine>();
            medicines.AddRange(pPresc.Medicines);

            // get prescriptionID
            var presc = new Prescription();

            /*
            foreach (var med in medicines)
            {
                prescmanager.AddMedicineIntoPrescription(med.MedicineId,pPresc.)
            }
            */

            return Json(retVal);
        }
    }
}
