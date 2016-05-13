using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using mdphischel.BLL;
using mdphischel.Models;

namespace mdphischel.Controllers
{
    public class SpecialtiesController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Specialty>> GetAll()
        {
            var specmanager = new MedicalSpecialtyManager();
            var retVal = new List<Specialty>();

            var bllresult = specmanager.GetAllSpecialties();

            for (int i = 0; i < bllresult.Count / 2; i++)
            {
                retVal.Add(new Specialty() {MedicalSpecialtyId = bllresult.ToArray()[0],Name = bllresult.ToArray()[1]});
                bllresult.RemoveAt(0);
                bllresult.RemoveAt(0);
            }

            return Json(retVal);
        }
    }
}