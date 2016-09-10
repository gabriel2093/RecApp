using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization; // << dont forget to add this for converting dates to localtime
using RecApp_2;
using System.ComponentModel.DataAnnotations;

namespace Rec_App_2.Models
{
    public class DiaryEvent
    {

        public int id;

        [Required(ErrorMessage = "Campo requerido*")]
        //[DataType(DataType.Text, ErrorMessage = "Ingrese un nombre válido.")]
        //[StringLength(50, ErrorMessage = "No puede exceder los 50 caracteres")]
        //[RegularExpression(@"^[a-zA-Z- ]+$", ErrorMessage = "Caracteres inválidos. A-Z  o a-z, '-' y ' ' son permitidos.")]
        [Display(Name = "Paciente")]
        public string title { set; get; }

        public int SomeImportantKeyID;

        [Required(ErrorMessage = "Campo requerido*")]
        [DataType(DataType.Duration, ErrorMessage = "Ingrese una duración válida.")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        [Display(Name = "Duración")]
        public int AppointmentLength { get; set; }

       
        [Required(ErrorMessage = "Campo requerido*")]
        [DataType(DataType.Time, ErrorMessage = "Ingrese una hora válida.")]       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        [Display(Name = "Hora")]
        public TimeSpan Hour { get; set; }

       
        [Required(ErrorMessage = "Campo requerido*")]
        //[DataType(DataType.DateTime, ErrorMessage = "Ingrese una fecha válida."), DisplayFormat(DataFormatString = "{0:dd.MM.yy}") ]
        [DataType(DataType.DateTime, ErrorMessage = "Ingrese una fecha vàlida.")]
        [Display(Name = "Fecha")]
        public string start { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [DataType(DataType.Date, ErrorMessage = "Ingrese una fecha válida.")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha final")]
        public string end { get; set; }

        public string StatusString;
        public string color;
        public string className;


        public static List<DiaryEvent> LoadAllAppointmentsInDateRange(DateTime start, DateTime end)
        {
            var fromDate = start;
            var toDate = end;
            using (DiaryContainer ent = new DiaryContainer())
            {
                var rslt = ent.AppointmentDiary.Where(s => s.DateTimeScheduled >= fromDate && System.Data.Entity.DbFunctions.AddMinutes(s.DateTimeScheduled, s.AppointmentLength) <= toDate);

                List<DiaryEvent> result = new List<DiaryEvent>();
                foreach (var item in rslt)
                {
                    DiaryEvent rec = new DiaryEvent();
                    rec.id = item.ID;
                    rec.SomeImportantKeyID = item.SomeImportantKey;
                    rec.start = item.DateTimeScheduled.ToString("s"); // "s" is a preset format that outputs as: "2009-02-27T12:12:22"
                    rec.end = item.DateTimeScheduled.AddMinutes(item.AppointmentLength).ToString("s"); // field AppointmentLength is in minutes
                    rec.title = item.Title + " | " + item.AppointmentLength.ToString() + " minutos";
                    rec.StatusString = Enums.GetName<AppointmentStatus>((AppointmentStatus)item.StatusENUM);
                    rec.color = Enums.GetEnumDescription<AppointmentStatus>(rec.StatusString);
                    string ColorCode = rec.color.Substring(0, rec.color.IndexOf(":"));
                    rec.className = rec.color.Substring(rec.color.IndexOf(":") + 1, rec.color.Length - ColorCode.Length - 1);
                    rec.color = ColorCode;
                    result.Add(rec);
                }

                return result;
            }

        }


        public static List<DiaryEvent> LoadAppointmentSummaryInDateRange(DateTime start, DateTime end)
        {
            try
            {


                var fromDate = start;
                var toDate = end;
                using (DiaryContainer ent = new DiaryContainer())
                {
                    var rslt = ent.AppointmentDiary.Where(s => s.DateTimeScheduled >= fromDate && System.Data.Entity.DbFunctions.AddMinutes(s.DateTimeScheduled, s.AppointmentLength) <= toDate)
                                                            .GroupBy(s => System.Data.Entity.DbFunctions.TruncateTime(s.DateTimeScheduled))
                                                            .Select(x => new { DateTimeScheduled = x.Key, Count = x.Count() });

                    List<DiaryEvent> result = new List<DiaryEvent>();
                    int i = 0;
                    foreach (var item in rslt)
                    {
                        DiaryEvent rec = new DiaryEvent();
                        rec.id = i; //we dont link this back to anything as its a group summary but the fullcalendar needs unique IDs for each event item (unless its a repeating event)
                        rec.SomeImportantKeyID = -1;
                        string StringDate = string.Format("{0:yyyy-MM-dd}", item.DateTimeScheduled);
                       // rec.start = StringDate + "T00:00:00"; //ISO 8601 format
                        //rec.end = StringDate + "T23:59:59";
                        rec.title = "Booked: " + item.Count.ToString();
                        result.Add(rec);
                        i++;
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public static void UpdateDiaryEvent(int id, string NewEventStart, string NewEventEnd)
        {
            // EventStart comes ISO 8601 format, eg:  "2000-01-10T10:00:00Z" - need to convert to DateTime
            using (DiaryContainer ent = new DiaryContainer())
            {
                var rec = ent.AppointmentDiary.FirstOrDefault(s => s.ID == id);
                if (rec != null)
                {
                    DateTime DateTimeStart = DateTime.Parse(NewEventStart, null, DateTimeStyles.RoundtripKind); // and convert offset to localtime
                    rec.DateTimeScheduled = DateTimeStart;
                    if (!String.IsNullOrEmpty(NewEventEnd))
                    {
                        TimeSpan span = DateTime.Parse(NewEventEnd, null, DateTimeStyles.RoundtripKind) - DateTimeStart;
                        rec.AppointmentLength = Convert.ToInt32(span.TotalMinutes);
                    }
                    ent.SaveChanges();
                }
            }

        }


        public static string DeleteDiaryEvent(int id)
        {
            // EventStart comes ISO 8601 format, eg:  "2000-01-10T10:00:00Z" - need to convert to DateTime
            using (DiaryContainer ent = new DiaryContainer())
            {
                var rec = ent.AppointmentDiary.FirstOrDefault(s => s.ID == id);
                if (rec != null)
                {
                    ent.AppointmentDiary.Remove(rec);
                    ent.SaveChanges();
                    return "Cita eliminada";
                }
                else
                {
                    return "Error al eliminar la cita";
                }
            }

        }


        public static bool CreateNewEvent(string Title, string NewEventDate, string NewEventTime, int NewEventDuration)
        {
            try
            {           
                DiaryContainer ent = new DiaryContainer();
                AppointmentDiary rec = new AppointmentDiary();
                rec.Title = Title;
                rec.DateTimeScheduled = DateTime.ParseExact(NewEventDate + " " + NewEventTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                rec.AppointmentLength = NewEventDuration;
                ent.AppointmentDiary.Add(rec);
                ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}