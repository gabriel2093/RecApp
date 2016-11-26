using Rec_App_2.Models;
using RecApp_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecApp_2.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadEvents(DateTime start, DateTime end)
        {
            var ApptListForDate = DiaryEvent.LoadAllAppointmentsInDateRange(start, end);
            var eventList = from e in ApptListForDate
                            select new
                            {
                                id = e.id,
                                title = e.title,
                                start = e.start,
                                end = e.end,
                                color = e.color,
                                className = e.className,
                                someKey = e.SomeImportantKeyID,
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public string Init()
        {
            bool rslt = Utils.InitialiseDiary();
            return rslt.ToString();
        }

        public void UpdateEvent(int id, string NewEventStart, string NewEventEnd)
        {
            DiaryEvent.UpdateDiaryEvent(id, NewEventStart, NewEventEnd);
        }

        public bool SaveEvent(string Title, string NewEventDate, string NewEventTime, int NewEventDuration)
        {
            return DiaryEvent.CreateNewEvent(Title, NewEventDate, NewEventTime, NewEventDuration);
        }

        public string DeleteEvent(int id)
        {
            return DiaryEvent.DeleteDiaryEvent(id);
        }

        public JsonResult GetDiarySummary(DateTime start, DateTime end)
        {

            var ApptListForDate = DiaryEvent.LoadAppointmentSummaryInDateRange(start, end);
            var eventList = from e in ApptListForDate
                            select new
                            {
                                id = e.id,
                                title = e.title,
                                start = e.start,
                                end = e.end,
                                someKey = e.SomeImportantKeyID,
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDiaryEvents(DateTime start, DateTime end)
        {
            var ApptListForDate = DiaryEvent.LoadAllAppointmentsInDateRange(start, end);
            var eventList = from e in ApptListForDate
                            select new
                            {
                                id = e.id,
                                title = e.title,
                                start = e.start,
                                end = e.end,
                                color = e.color,
                                className = e.className,
                                someKey = e.SomeImportantKeyID,
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }



      

        [HttpPost]
        public JsonResult SearchPatient(string Prefix)
        {
            //Note : you can bind same list from database  
            List<PatientModel> ObjList = new List<PatientModel>()
            {

                new PatientModel {Id=1,Name="Latur" },
                new PatientModel {Id=2,Name="Mumbai" },
                new PatientModel {Id=3,Name="Pune" },
                new PatientModel {Id=4,Name="Delhi" },
                new PatientModel {Id=5,Name="Dehradun" },
                new PatientModel {Id=6,Name="Noida" },
                new PatientModel {Id=7,Name="New Delhi" }

        };
            //Searching records from list using LINQ query  
            var Name = (from N in ObjList
                            where N.Name.StartsWith(Prefix)
                            select new { N.Name });
            return Json(Name, JsonRequestBehavior.AllowGet);
        }




    }
}
