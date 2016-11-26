using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecApp_2.Models;
using System.Globalization;
using System.Collections;
using System.Data.Entity.Validation;

namespace RecApp_2.Controllers
{
    public class RecordsController : Controller
    {
        //Instancia del Contexto para acceso a datos 
        private RecordsContext db = new RecordsContext();

        // GET: Records
        public async Task<ActionResult> Index(string search)
        {
            return View(await db.Records.Where(x => x.Nombre.StartsWith(search) || x.Apellido1.StartsWith(search) || x.Apellido2.StartsWith(search) || x.Cedula.ToString() == search || search == null).ToListAsync());
        }

        // GET: Records/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = await db.Records.FindAsync(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            ViewBag.CivilStatus = db.Civil_Status.SingleOrDefault(cs => cs.Id.Equals(record.IdEstadoCivil)).Descripcion;
            record.Edad = CalculateAge(record.FechaNacimiento);
            record.MenorEdad = CalculateAdult(record.Edad);
            return View(record);
        }


        // GET: Records/Create
        public ActionResult Create()
        {
            var model = new Record();
            {
                model.ListCivilStatus = db.Civil_Status.ToList();
            }
            return View(model);

        }

        // POST: Records/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Nombre,Apellido1,Apellido2,Cedula,FechaNacimiento,Edad,MenorEdad,NombreEncargado,Apellido1Encargado,Apellido2Encargado,IdEstadoCivil,Domicilio,Telefono1,Telefono2,Profesion,Email,ContactoEmergencia,TratamientoMedico,Medicamento,Diabetes,Artritis,EnfermedadCardiaca,Hepatitis,FiebreReumatica,Ulcera,PresionAlta,PresionBaja,EnfermedadesNerviosas,OtrasEnfermedades,SangradoProlongado,Desmayos,IntervencionQuirurgica,Aspirina,Sulfas,Penicilina,AnomaliasAnestesia,Embarazo,Lactancia,Otros")] Record record)
        {
            if (IsUserExistsBool(record.Cedula))
            {
                ModelState.AddModelError("Cedula", "El número de cédula ya se encuentra registrado.");
            }

            if (ModelState.IsValid)
            {

                db.Records.Add(record);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            record.ListCivilStatus = db.Civil_Status.ToList();

            return View(record);
        }


        [CustomAuthorize(Roles = "Administrador")]
        // GET: Records/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = await db.Records.FindAsync(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            if (TempData["AgregoTratamiento"] == null)
            {
                TempData["AgregoTratamiento"] = "false";
            }

            if (TempData["MensajeErrorAgregarTratamiento"] == null)
            {
                TempData["MensajeErrorAgregarTratamiento"] = "false";
            }
            if (TempData["tratamientoEditando"] == null)
            {
                TempData["tratamientoEditando"] = "false";
            }

            record.ListCivilStatus = db.Civil_Status.ToList();

            ViewBag.CivilStatus = db.Civil_Status.SingleOrDefault(cs => cs.Id.Equals(record.IdEstadoCivil)).Descripcion;
            TempData["MensajeErrorEditarExpediente"] = "true";
            record.Edad = CalculateAge(record.FechaNacimiento);
            record.ListTratamientoPaciente = from tP in
                                           db.TratamientoPaciente.ToList()
                                             where tP.IdPaciente.Equals(id)
                                             select tP;


            TratamientoPaciente tratamientoPaciente = new TratamientoPaciente();
            tratamientoPaciente.ListTratamiento = db.Tratamiento.ToList();
            List<String> ListaIdDientes = new List<string>(); 
            var tratamientosPorPaciente = db.TratamientoPaciente.ToList().Where(tp => tp.IdPaciente.Equals(record.id));
            foreach (var item in tratamientosPorPaciente)
            {
                item.Tratamiento = db.Tratamiento.ToList().SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).Nombre;
                item.NombrePaciente = record.Nombre + " " + record.Apellido1;
                ListaIdDientes.Add(item.IdDiente.ToString());
            }

            //Lista de dientes para cambiar el background
            ViewBag.ListaIdDientes = ListaIdDientes;

            foreach (var item in tratamientoPaciente.ListTratamiento)
            {
                item.NombreCompuesto = item.Nombre + " | Precio base: " + String.Format("{0:C}", item.PrecioBase);
            }
            record.ListPayment = db.Payments.ToList().Where(p => p.IdRecord.Equals(record.id)).OrderBy(e => e.Estado);          

            if (TempData["mayorEdad"] == null)
            {
                if (record.Edad >= 18)
                {
                    TempData["mayorEdad"] = "true";
                }
                else
                {
                    TempData["mayorEdad"] = "false";
                }


            }
            var tuple = new Tuple<Record, TratamientoPaciente>(record, tratamientoPaciente);
            return View(tuple);
        }

        // POST: Records/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Prefix = "Item1", Include = "id,Nombre,Apellido1,Apellido2,Cedula,FechaNacimiento,Edad,MenorEdad,NombreEncargado,Apellido1Encargado,Apellido2Encargado,IdEstadoCivil,Domicilio,Telefono1,Telefono2,Profesion,Email,ContactoEmergencia,TratamientoMedico,Medicamento,Diabetes,Artritis,EnfermedadCardiaca,Hepatitis,FiebreReumatica,Ulcera,PresionAlta,PresionBaja,EnfermedadesNerviosas,OtrasEnfermedades,SangradoProlongado,Desmayos,IntervencionQuirurgica,Aspirina,Sulfas,Penicilina,AnomaliasAnestesia,Embarazo,Lactancia,Otros")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["MessageRegistroModificado"] = "El Expediente fue modificado  correctamente.";
                return RedirectToAction("Edit", "Records", new { id = record.id });
            }

            ViewBag.MessageErrorEdit = "Debe verificar los datos del Expediente.";
            if (TempData["AgregoTratamiento"] == null)
            {
                TempData["AgregoTratamiento"] = "false";
            }

            if (TempData["MensajeErrorAgregarTratamiento"] == null)
            {
                TempData["MensajeErrorAgregarTratamiento"] = "false";
            }
            record.ListCivilStatus = db.Civil_Status.ToList();
            // ViewBag.CivilStatus = db.Civil_Status.SingleOrDefault(cs => cs.Id.Equals(record.IdEstadoCivil)).Descripcion;
            TempData["MensajeErrorEditarExpediente"] = "true";
            record.Edad = CalculateAge(record.FechaNacimiento);
            record.ListTratamientoPaciente = from tP in
                                           db.TratamientoPaciente.ToList()
                                             where tP.IdPaciente.Equals(record.id)
                                             select tP;

            TratamientoPaciente tratamientoPaciente = new TratamientoPaciente();
            tratamientoPaciente.ListTratamiento = db.Tratamiento.ToList();
            foreach (var item in db.TratamientoPaciente.ToList())
            {
                item.Tratamiento = tratamientoPaciente.ListTratamiento.ToList().SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).Nombre;
                item.NombrePaciente = record.Nombre + " " + record.Apellido1;
            }

            // var tuple = new Tuple<Record, TratamientoPaciente>(record, null);
            var tuple = new Tuple<Record, TratamientoPaciente>(record, tratamientoPaciente);
            //return View(tuple);
            return PartialView(tuple);
        }

        // GET: Records/Edit/5
        [HttpGet]
        public ActionResult GetTratamientosDiente(int? idDiente, int? idPaciente_1)
        {

            if (idDiente == null || idPaciente_1 == null)
            {
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);

            }

            var tratamientos = (from t in db.TratamientoPaciente.ToList()
                                where (t.IdDiente.Equals(idDiente) &&
                                t.IdPaciente.Equals(idPaciente_1))
                                select t).ToList();
            if (tratamientos.Count.Equals(0))
            {
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { success = true, responseText = "Your message successfuly sent!" }, JsonRequestBehavior.AllowGet);

            //  return View(record);
        }

        // GET: Records/Tratamiento Factura Vista Parcial
        [HttpGet]
        public PartialViewResult PartialViewTratamientoPacienteFactura(int id_Payment, int id_Paciente)
        {

            var tratamientos = (from t in db.TratamientoPaciente.ToList()
                                where t.IdPayment.Equals(id_Payment)
                                select t).ToList();
            var listaTratamientos = db.Tratamiento.ToList();
            foreach (var item in tratamientos)
            {
                if (listaTratamientos != null)
                {
                    item.Costo = listaTratamientos.SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).PrecioBase;
                    item.Total += item.Costo;
                    item.Tratamiento = listaTratamientos.SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).Nombre;
                }
            }

            Payment _Payment = db.Payments.ToList().SingleOrDefault(p => p.Id.Equals(id_Payment));
            tratamientos.ToList()[tratamientos.ToList().Count - 1].Total = _Payment.TotalPagar;
            tratamientos.ToList()[tratamientos.ToList().Count - 1].MontoAdicional = _Payment.MontoAdicional;
            return PartialView(tratamientos);
        }


        // GET: Records/FiltrarTratamientos/5
        [HttpGet]
        public ActionResult FiltrarTratamientosPorDiente(int idDiente, int idPaciente_1)
        {

            Record record = db.Records.Find(idPaciente_1);
            record.ListCivilStatus = db.Civil_Status.ToList();
            record.Edad = CalculateAge(record.FechaNacimiento);
            record.ListTratamientoPaciente = from tP in
                                           db.TratamientoPaciente.ToList()
                                             where tP.IdPaciente.Equals(idPaciente_1) && tP.IdDiente.Equals(idDiente)
                                             select tP;

            //Devolver tupla de tipo TratamientoPaciente
            TratamientoPaciente tratamientoPaciente = new TratamientoPaciente();

            tratamientoPaciente.ListTratamiento = db.Tratamiento.ToList();
            foreach (var item in record.ListTratamientoPaciente)
            {
                item.Tratamiento = tratamientoPaciente.ListTratamiento.ToList().SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).Nombre;
                item.NombrePaciente = record.Nombre + " " + record.Apellido1;
            }


            return PartialView("PartialViewTratamientosPaciente", record.ListTratamientoPaciente);

        }


        // GET: Records/FiltrarTratamientosFecha/5
        [HttpGet]
        public ActionResult FiltrarTratamientosPorFecha(String fechaInicio, String fechaFin, int idPaciente_1)
        {

            DateTime fechaInicioD = DateTime.ParseExact(fechaInicio + " " + "00:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            DateTime fechaFinD = DateTime.ParseExact(fechaFin + " " + "00:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Record record = db.Records.Find(idPaciente_1);
            record.ListCivilStatus = db.Civil_Status.ToList();
            record.Edad = CalculateAge(record.FechaNacimiento);
            record.ListTratamientoPaciente = from tP in
                                           db.TratamientoPaciente.ToList()
                                             where (tP.FechaTratamiento.Date >= fechaInicioD.Date && tP.FechaTratamiento.Date <= fechaFinD) && tP.IdPaciente.Equals(idPaciente_1)
                                             select tP;

            //Devolver tupla de tipo TratamientoPaciente
            TratamientoPaciente tratamientoPaciente = new TratamientoPaciente();

            tratamientoPaciente.ListTratamiento = db.Tratamiento.ToList();
            foreach (var item in record.ListTratamientoPaciente)
            {
                item.Tratamiento = tratamientoPaciente.ListTratamiento.ToList().SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).Nombre;
                item.NombrePaciente = record.Nombre + " " + record.Apellido1;
            }


            return PartialView("PartialViewTratamientosPaciente", record.ListTratamientoPaciente);

        }


        // GET: Records/FiltrarTratamientosPorTratamiento/5
        [HttpGet]
        public ActionResult FiltrarTratamientosPorTratamiento(int idTratamiento_1, int idPaciente_1)
        {
            Record record = db.Records.Find(idPaciente_1);
            record.ListCivilStatus = db.Civil_Status.ToList();
            record.Edad = CalculateAge(record.FechaNacimiento);
            record.ListTratamientoPaciente = from tP in
                                           db.TratamientoPaciente.ToList()
                                             where (tP.IdTratamiento.Equals(idTratamiento_1)) && tP.IdPaciente.Equals(idPaciente_1)
                                             select tP;

            //Devolver tupla de tipo TratamientoPaciente
            TratamientoPaciente tratamientoPaciente = new TratamientoPaciente();

            tratamientoPaciente.ListTratamiento = db.Tratamiento.ToList();
            foreach (var item in record.ListTratamientoPaciente)
            {
                item.Tratamiento = tratamientoPaciente.ListTratamiento.ToList().SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).Nombre;
                item.NombrePaciente = record.Nombre + " " + record.Apellido1;
            }


            return PartialView("PartialViewTratamientosPaciente", record.ListTratamientoPaciente);

        }


        // GET: Records/FiltrarTratamientosPorCaraDiente/5
        [HttpGet]
        public ActionResult FiltrarTratamientosPorCaraDiente(string idCaraDiente_1, int idPaciente_1)
        {
            Record record = db.Records.Find(idPaciente_1);
            record.ListCivilStatus = db.Civil_Status.ToList();
            record.Edad = CalculateAge(record.FechaNacimiento);
            record.ListTratamientoPaciente = from tP in
                                           db.TratamientoPaciente.ToList()
                                             where (tP.Cara.Equals(idCaraDiente_1)) && tP.IdPaciente.Equals(idPaciente_1)
                                             select tP;

            //Devolver tupla de tipo TratamientoPaciente
            TratamientoPaciente tratamientoPaciente = new TratamientoPaciente();

            tratamientoPaciente.ListTratamiento = db.Tratamiento.ToList();
            foreach (var item in record.ListTratamientoPaciente)
            {
                item.Tratamiento = tratamientoPaciente.ListTratamiento.ToList().SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).Nombre;
                item.NombrePaciente = record.Nombre + " " + record.Apellido1;
            }


            return PartialView("PartialViewTratamientosPaciente", record.ListTratamientoPaciente);

        }

        // GET: Records/FiltrarTratamientos/5
        [HttpGet]
        public ActionResult FiltrarFacturaPorEstado(int id_Estado, int id_Paciente)
        {

            Record record = db.Records.Find(id_Paciente);
            record.ListCivilStatus = db.Civil_Status.ToList();
            record.Edad = CalculateAge(record.FechaNacimiento);
            record.ListPayment = from P in
                                            db.Payments.ToList()
                                 where P.IdRecord.Equals(id_Paciente) && P.Estado.Equals(id_Estado)
                                 select P;
            record.ListTratamientoPaciente = db.TratamientoPaciente.ToList().Where(tp => tp.IdPaciente.Equals(id_Paciente));
            //Devolver tupla de tipo TratamientoPaciente
            TratamientoPaciente tratamientoPaciente = new TratamientoPaciente();

            tratamientoPaciente.ListTratamiento = db.Tratamiento.ToList();
            foreach (var item in record.ListTratamientoPaciente)
            {
                item.Tratamiento = tratamientoPaciente.ListTratamiento.ToList().SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).Nombre;
                item.NombrePaciente = record.Nombre + " " + record.Apellido1;
            }


            return PartialView("PartialViewPayments", record.ListPayment);

        }

        // GET: Records/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = await db.Records.FindAsync(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Record record = await db.Records.FindAsync(id);
            db.Records.Remove(record);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Records/Odontogram
        public ActionResult Odontogram()
        {
            return View();

        }

        // GET: Records/PartialViewFacturar/
        [HttpGet]
        public PartialViewResult PartialViewFacturar(int id_Payment, int id_Paciente)
        {

            var _ListaTratamientosPacientes = (from t in db.TratamientoPaciente.ToList()
                                               where t.IdPayment.Equals(id_Payment)
                                               select t).ToList();
            var listaTratamientos = db.Tratamiento.ToList();
            foreach (var item in _ListaTratamientosPacientes)
            {
                if (listaTratamientos != null)
                {
                    item.Costo = listaTratamientos.SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).PrecioBase;
                    item.Total += item.Costo;
                    item.Tratamiento = listaTratamientos.SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).Nombre;
                }
            }

            Payment _Payment = db.Payments.ToList().SingleOrDefault(p => p.Id.Equals(id_Payment));
            _ListaTratamientosPacientes.ToList()[_ListaTratamientosPacientes.ToList().Count - 1].Total = _Payment.TotalPagar;
            _ListaTratamientosPacientes.ToList()[_ListaTratamientosPacientes.ToList().Count - 1].MontoAdicional = _Payment.MontoAdicional;
            _Payment.ListTratamientoXPaciente = _ListaTratamientosPacientes;

            //var tuple = new Tuple<Payment, List<TratamientoPaciente>>(_Payment, tratamientos);
            return PartialView(_Payment);
        }


        // GET: Records/PartialViewFacturar/
        [HttpGet]
        public PartialViewResult PartialViewCerrarFactura(int id_Paciente, decimal montoAdicional)
        {            
            try
            {
                Payment _Payment = db.Payments.ToList().SingleOrDefault(p => p.IdRecord.Equals(id_Paciente) && p.Estado.Equals(1));
                var _ListaTratamientosPacientes = (from t in db.TratamientoPaciente.ToList()
                                                   where t.IdPayment.Equals(_Payment.Id)
                                                   select t).ToList();
                var listaTratamientos = db.Tratamiento.ToList();
                foreach (var item in _ListaTratamientosPacientes)
                {
                    if (listaTratamientos != null)
                    {
                        item.Costo = decimal.Round(listaTratamientos.SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).PrecioBase, 2, MidpointRounding.AwayFromZero);
                        item.Total += decimal.Round(item.Costo, 2, MidpointRounding.AwayFromZero);
                        item.Tratamiento = listaTratamientos.SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).Nombre;
                    }
                }

                montoAdicional = montoAdicional == 0 ? 0.00m : montoAdicional;
                _ListaTratamientosPacientes.ToList()[_ListaTratamientosPacientes.ToList().Count - 1].Total = decimal.Round(_Payment.TotalPagar, 2, MidpointRounding.AwayFromZero);
                _ListaTratamientosPacientes.ToList()[_ListaTratamientosPacientes.ToList().Count - 1].MontoAdicional = decimal.Round(_Payment.MontoAdicional, 2, MidpointRounding.AwayFromZero);
                _Payment.ListTratamientoXPaciente = _ListaTratamientosPacientes;
                _Payment.MontoAdicional = decimal.Round(montoAdicional, 2, MidpointRounding.AwayFromZero);
                _Payment.TotalPagar = decimal.Round((_Payment.MontoAdicional + _Payment.TotalPagar), 2, MidpointRounding.AwayFromZero);
                _Payment.Estado = 2;
                db.Entry(_Payment).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView(_Payment);
            }
            catch (DbEntityValidationException ex)
            {
                string errores = "";
                foreach (var error in ex.EntityValidationErrors)
                {
                    errores += error.Entry.Entity.GetType().Name + error.Entry.State;
                    foreach (var item in error.ValidationErrors)
                    {
                        errores += item.PropertyName + "  " + item.ErrorMessage;
                    }
                }
                return PartialView();
            }
        }


        // GET: Records/PartialViewAbonar/
        [HttpGet]
        public PartialViewResult PartialViewAbonar(int id_Factura)
        {
            
            try
            {
                //Payment _Payment = db.Payments.ToList().SingleOrDefault(p => p.Id.Equals(id_Factura) && p.Estado.Equals(2));

                //var _ListaTratamientosPacientes = (from t in db.TratamientoPaciente.ToList()
                //                                   where t.IdPayment.Equals(_Payment.Id)
                //                                   select t).ToList();
                //var listaTratamientos = db.Tratamiento.ToList();
                //foreach (var item in _ListaTratamientosPacientes)
                //{
                //    if (listaTratamientos != null)
                //    {
                //        item.Costo = decimal.Round(listaTratamientos.SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).PrecioBase, 2, MidpointRounding.AwayFromZero);
                //        item.Total += decimal.Round(item.Costo, 2, MidpointRounding.AwayFromZero);
                //        item.Tratamiento = listaTratamientos.SingleOrDefault(t => t.id.Equals(item.IdTratamiento)).Nombre;
                //    }
                //}
                PaymentDetails _PaymentDetails = new PaymentDetails();
                _PaymentDetails.IdPayment = id_Factura;
                // montoAdicional = montoAdicional == 0 ? 0.00m : montoAdicional;
                //_ListaTratamientosPacientes.ToList()[_ListaTratamientosPacientes.ToList().Count - 1].Total = decimal.Round(_Payment.TotalPagar, 2, MidpointRounding.AwayFromZero);
                //_ListaTratamientosPacientes.ToList()[_ListaTratamientosPacientes.ToList().Count - 1].MontoAdicional = decimal.Round(_Payment.MontoAdicional, 2, MidpointRounding.AwayFromZero);
                //_Payment.ListTratamientoXPaciente = _ListaTratamientosPacientes;
                //_Payment.MontoAdicional = decimal.Round(montoAdicional, 2, MidpointRounding.AwayFromZero);
                //_Payment.TotalPagar = decimal.Round((_Payment.MontoAdicional + _Payment.TotalPagar), 2, MidpointRounding.AwayFromZero);
                //_Payment.Estado = 2;
                // db.Entry(_Payment).State = EntityState.Added;
                // db.SaveChanges();
               // System.Threading.Thread.Sleep(15000);
                return PartialView(_PaymentDetails);
            }
            catch (DbEntityValidationException ex)
            {
                string errores = "";
                foreach (var error in ex.EntityValidationErrors)
                {
                    errores += error.Entry.Entity.GetType().Name + error.Entry.State;
                    foreach (var item in error.ValidationErrors)
                    {
                        errores += item.PropertyName + "  " + item.ErrorMessage;
                    }
                }
                return PartialView();
            }
        }

        public JsonResult IsUserExists(int cedula)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return Json(!db.Records.Any(record => record.Cedula == cedula), JsonRequestBehavior.AllowGet);
        }

        public bool IsUserExistsBool(int cedula)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return db.Records.Any(record => record.Cedula == cedula);
        }

        private int CalculateAdult(int edad)
        {
            return edad >= 18 ? 1 : 0;
        }

        private int CalculateAge(DateTime fechaNacimiento)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - fechaNacimiento.Year;
            if (fechaNacimiento > now.AddYears(-age)) age--;
            return age;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
