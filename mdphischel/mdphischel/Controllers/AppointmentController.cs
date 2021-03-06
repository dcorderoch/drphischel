﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using mdphischel.BLL;
using mdphischel.Models;

namespace mdphischel.Controllers
{
    public class AppointmentController : ApiController
    {
        [HttpPost]
        public JsonResult<ReturnStatus> Create(AppointmentCreateData pData)
        {
            var appointmentmng = new AppointmentManager();
            return Json(new ReturnStatus()
                {
                    StatusCode = appointmentmng.CreateAppointment(Int32.Parse(pData.UserId), pData.DoctorId, pData.AppointmentDate)
                });
        }

        [HttpPost]
        public JsonResult<ReturnStatus> Update(UpdateAppointmentData pData)
        {
            var appointmentmng = new AppointmentManager();
            return Json(new ReturnStatus()
            {
                StatusCode = appointmentmng.UpdateAppointment(Int32.Parse(pData.UserId), pData.DoctorId, pData.OldAppointmentDate, pData.NewAppointmentDate)
            });
        }

        [HttpPost]
        public JsonResult<ReturnStatus> Delete(AppointmentCreateData pData)
        {
            var appointmentmng = new AppointmentManager();
            return Json(new ReturnStatus()
            {
                StatusCode = appointmentmng.DeleteAppointment(Int32.Parse(pData.UserId), pData.DoctorId, pData.AppointmentDate)
            });
        }

        [HttpPost]
        public JsonResult<List<Appointment>> GetbyDoctorId(MedicIdData pData)
        {
            var retVal = new List<Appointment>();
            var appointmentmng = new AppointmentManager();
            var resultfrombll = appointmentmng.GetAppointmentsByDoctor(pData.DoctorId);
            if (resultfrombll.Count > 2)
            {
                resultfrombll.RemoveAt(0);
                while (resultfrombll.Count > 0)
                {
                    Appointment tmp = new Appointment();
                    tmp.title = resultfrombll.ToArray()[0];
                    tmp.UserId = resultfrombll.ToArray()[1];
                    tmp.start = resultfrombll.ToArray()[2];

                    resultfrombll.RemoveAt(0);
                    resultfrombll.RemoveAt(0);
                    resultfrombll.RemoveAt(0);

                    retVal.Add(tmp);
                }
            }
            return Json(retVal);
        }
    }
}
