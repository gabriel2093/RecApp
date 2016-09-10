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



        public JsonResult getData(string term)
        {
            // We can get a list of MicrosoftProduct from the database, but
            // for this example, I will populate a list with values.
            List<string> MicrosoftProduct = new List<string>();
            MicrosoftProduct.Add("Office");
            MicrosoftProduct.Add(".NET");
            MicrosoftProduct.Add("VS");
            MicrosoftProduct.Add("sql server");
            MicrosoftProduct.Add("Windows7");
            MicrosoftProduct.Add("Window8");

            // Select the tags that match the query, and get the
            // number or tags specified by the limit.

            List<string> getValues = MicrosoftProduct.Where(item => item.ToLower().StartsWith(term.ToLower())).ToList();

            // Return the result set as JSON
            return Json(getValues, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SearchCustomer(string Prefix)
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
