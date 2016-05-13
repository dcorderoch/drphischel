using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using mdphischel.BLL;
using mdphischel.DAL.Models;

namespace mdphischel.Controllers
{
    public class BranchOfficeController : ApiController
    {
        [HttpGet]
        public JsonResult<List<BranchOffice>> GetAllBranchOffices()
        {
            var bomng = new BranchOfficeManager();
            return Json(bomng.GetAllBranchOffices());
        }
    }
}
