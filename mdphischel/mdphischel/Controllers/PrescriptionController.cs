using System.Web.Http;
using System.Web.Http.Results;
using mdphischel.BLL;
using mdphischel.Models;

namespace mdphischel.Controllers
{
    public class PrescriptionController : ApiController
    {
        //public int AddMedicineIntoPrescription(string medicineId, string prescriptionId)
        public JsonResult<ReturnStatus> addmedicinetoprescription(NewMedInPrescription pNewMed)
        {
            var prescManager = new PrescriptionManager();
            var retVal = new ReturnStatus();
            retVal.StatusCode = prescManager.AddMedicineIntoPrescription(pNewMed.MedicineId, pNewMed.PrescriptionId);
            return Json(retVal);
        }
    }
}
