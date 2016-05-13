using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace mdphischel.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public JsonResult<string> Nalga()
        {
            string retVal = "nalga, haha";
            return Json(retVal);
        }
    }
}
