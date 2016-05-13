﻿using System;
using System.Web.Http;
using System.Web.Http.Results;
using mdphischel.BLL;
using mdphischel.Models;

namespace mdphischel.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public JsonResult<LoginSession> Login(LoginInfo pUserInfo)
        {
            var accmanager = new AccountManager();
            var loginSession = new LoginSession();
            var resultfrombll = accmanager.AuthorizeLogin(Int32.Parse(pUserInfo.IdNumber), pUserInfo.Pass, Int32.Parse(pUserInfo.Role));
            if (resultfrombll.Count < 7)
            {
                loginSession.UserId = "";
                loginSession.Name = "";
                loginSession.LastName1 = "";
                loginSession.LastName2 = "";
                loginSession.BirthDate = "";
            }
            else
            {
                resultfrombll.RemoveAt(0);
                var strings = resultfrombll.ToArray();

                loginSession.UserId = strings[0];
                loginSession.Name = strings[1];
                loginSession.LastName1 = strings[2];
                loginSession.LastName2 = strings[3];
                loginSession.BirthDate = strings[4];
            }
            return Json(loginSession);
        }
    }
}