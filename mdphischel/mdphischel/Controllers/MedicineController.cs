using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using mdphischel.BLL;
using mdphischel.DAL.Models;
using mdphischel.Models;

namespace mdphischel.Controllers
{
    public class MedicineController : ApiController
    {
        [HttpPost]
        public JsonResult<List<Medicine>> GetAllByBranchOffice(BranchOfficeIdInfo pBOffice)
        {
            var medManager = new MedicineManager();
            return Json(medManager.GetAllMedicines(pBOffice.BranchOfficeId));
        }
    }
}