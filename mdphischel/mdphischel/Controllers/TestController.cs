using System.Web.Http;
using System.Web.Http.Results;

namespace mdphischel.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public JsonResult<string> Nalga()
        {
            string retVal = "nalga, haha wahaha";
            return Json(retVal);
        }
    }
}
