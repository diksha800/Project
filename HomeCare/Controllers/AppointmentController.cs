using HomeCare.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeCare.Controllers
{
    public class AppointmentController : ApiController


    {
        private HomeHealthCareEntities HomeHealthCareEntitie;
        public readonly Logger logger = NLog.LogManager.GetCurrentClassLogger();


        public AppointmentController()
        {
            this.HomeHealthCareEntitie = new HomeHealthCareEntities();
        }
        public void Getappointment(Appointment model)
        {
            if (ModelState.IsValid)
            {
                using (HomeHealthCareEntitie)
                {
                    HomeHealthCareEntitie.Getappointments(model.ID, model.Specialist, model.DoctorName, model.AppointmentDate);
                    HomeHealthCareEntitie.SaveChanges();
                }
            }
        }

        public IHttpActionResult AppointmentRecord()
        {
            List<AppointmentRecords_Result> appointmentRecords = new List<AppointmentRecords_Result>();
            appointmentRecords = HomeHealthCareEntitie.AppointmentRecords().ToList();
            return Json(appointmentRecords);
        }

        //public HttpResponseMessage GetAppointments(Appointment model)
        //{
        //    logger.Info("Entering in the GetAppointments  method");
        //    try
        //    {
        //        HomeHealthCareEntitie.Getappointments(model.ID, model.Specialist, model.DoctorName, model.AppointmentDate);
        //        HomeHealthCareEntitie.SaveChanges();
        //        logger.Info("Exit the Add method.    Item Added successfully");
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch (Exception e)
        //    {
        //        logger.Error(" Exception during Adding item ");
        //        logger.Error(e);
        //        return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, e);
        //    }
        //}
    }
}


