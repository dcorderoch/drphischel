using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
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
    }
}
