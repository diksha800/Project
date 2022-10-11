using HomeCare.Models;
using HomeCare.ViewModel;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;

namespace HomeCare.Controllers
{
   
    public class HomeController : Controller
    {      
        HttpClient hc = new HttpClient();



    public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    
        public async Task<JsonResult> Appointment()
        {
            List<Specialist> specialists= new List<Specialist>();

            hc.BaseAddress = new Uri("https://localhost:44386/");


            HttpResponseMessage message = await hc.GetAsync("api/Appointment/GetSpecialist/");


            if (message.IsSuccessStatusCode)
            {
                var display = message.Content.ReadAsAsync<List<Specialist>>();
                specialists = display.Result;
            }
            return Json(specialists, JsonRequestBehavior.AllowGet);
        }
 
        HomeHealthCareEntities entities = new HomeHealthCareEntities();
        public ActionResult GetSpecialist()
        {
            List<Specialist> specialists = entities.Specialists.ToList();
            ViewBag.speciaList = new SelectList(specialists, "DID", "Specialist");
            return View();
        }

        public JsonResult GetDoctorList(int DID)
        {
            entities.Configuration.ProxyCreationEnabled = false;
            List<doctorName> doctorNames = entities.doctorNames.Where(x => x.DID == DID).ToList();
            return Json(doctorNames, JsonRequestBehavior.AllowGet);

        }
        public async Task<JsonResult> AppointmentRecord([DataSourceRequest] DataSourceRequest request)
        {
            List<AppointmentRecords_Result> appointmentRecords = new List<AppointmentRecords_Result>();

            hc.BaseAddress = new Uri("https://localhost:44386/");


            HttpResponseMessage message = await hc.GetAsync("api/appointment/AppointmentRecord/");


            if (message.IsSuccessStatusCode)
            {
                var display = message.Content.ReadAsAsync<List<AppointmentRecords_Result>>();
              appointmentRecords  = display.Result;
            }
            return Json(appointmentRecords.ToDataSourceResult(request));
        }
        public async Task<JsonResult> GetSpecialistList()
        {
            List<SpecialistList_Result> Specialist = new List<SpecialistList_Result>();



            hc.BaseAddress = new Uri("https://localhost:44386/");



            HttpResponseMessage message = await hc.GetAsync("api/appointment/Getspecialist/");



            if (message.IsSuccessStatusCode)
            {
                var display = message.Content.ReadAsAsync<List<SpecialistList_Result>>();
                Specialist = display.Result;
            }
            return Json(Specialist, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetDoctorNameList()
        {
            List<DoctorNameList_Result> doctornamelist = new List<DoctorNameList_Result>();



            hc.BaseAddress = new Uri("https://localhost:44386/");



            HttpResponseMessage message = await hc.GetAsync("api/appointment/Getdoctornamelist/");



            if (message.IsSuccessStatusCode)
            {
                var display = message.Content.ReadAsAsync<List<DoctorNameList_Result>>();
                doctornamelist = display.Result;
            }
            return Json(doctornamelist, JsonRequestBehavior.AllowGet);
        }

    }
}
       
    

