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
        [HttpGet]
        public JsonResult<List<Medicine>> GetAllByBranchOffice(BranchOfficeIdInfo pBOffice)
        {
            return Json(new MedicineManager().GetAllMedicines(pBOffice.BranchOfficeId));
        }
    }
}