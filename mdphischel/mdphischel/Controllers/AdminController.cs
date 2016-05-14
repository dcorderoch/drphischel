using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using drphischel.Models;
using mdphischel.BLL;
using mdphischel.Models;

namespace mdphischel.Controllers
{
    public class AdminController : ApiController
    {
        [HttpPost]
        public JsonResult<ReturnStatus> AddNewSpecialty(NewSpecialty pData)
        {
            var medspecmanager = new MedicalSpecialtyManager();
            return Json(new ReturnStatus() {StatusCode = medspecmanager.CreateMedicalSpecialty(pData.specName)});
        }

        [HttpGet]
        public JsonResult<List<MedicBill>> Charges()
        {
            var retval = new List<MedicBill>();
            var docmanager = new DoctorManager();
            //var resultfrombll = docmanager.GetMonthlyCharges()

            return Json(retval);
        }
    }
}
