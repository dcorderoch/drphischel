using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using mdphischel.BLL;
using mdphischel.DAL.Models;

namespace mdphischel.Controllers
{
    public class BranchOfficeController : ApiController
    {
        [HttpGet]
        public JsonResult<List<BranchOffice>> GetAll()
        {
            var bomng = new BranchOfficeManager();
            return Json(bomng.GetAllBranchOffices());
        }
    }
}
