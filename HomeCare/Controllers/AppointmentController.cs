using HomeCare.Models;
using HomeCare.ViewModel;
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
        [Route("api/appointment/Getappointment")]
        [HttpPost]
        public void Getappointment(DoctorViewmodel model)
        {
            var specialist = HomeHealthCareEntitie.Specialists.FirstOrDefault(p => p.DID == model.DID);
            var doctorName = HomeHealthCareEntitie.doctorNames.FirstOrDefault(p => p.ID== model.ID);

                using (HomeHealthCareEntitie)
                {
                    HomeHealthCareEntitie.Getappointments(model.ID, specialist.Specialist1, doctorName.DoctorName1, model.AppointmentDate);
                    HomeHealthCareEntitie.SaveChanges();
                }
            
        }
        [HttpGet]

        public IHttpActionResult AppointmentRecord()
        {
            List<AppointmentRecords_Result> appointmentRecords = new List<AppointmentRecords_Result>();
            appointmentRecords = HomeHealthCareEntitie.AppointmentRecords().ToList();
            return Json(appointmentRecords);
        }
        public IHttpActionResult Getspecialist()
        {
            List<SpecialistList_Result> specialistRecords = new List<SpecialistList_Result>();
            specialistRecords = HomeHealthCareEntitie.SpecialistList().ToList();
            return Json(specialistRecords);

        }
        public IHttpActionResult Getdoctornamelist()
        {
            List<DoctorNameList_Result> doctornamelist = new List<DoctorNameList_Result>();
            doctornamelist = HomeHealthCareEntitie.DoctorNameList().ToList();
            return Json(doctornamelist);

        }

    }
}


