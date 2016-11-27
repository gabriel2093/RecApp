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
using System.Data.Entity.Validation;

namespace RecApp_2.Controllers
{
    public class TratamientoPacientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RecordsContext db1 = new RecordsContext();


        // GET: TratamientoPacientes
        public async Task<ActionResult> Index()
        {
            return View(await db.TratamientoPacientes.ToListAsync());
        }

        // GET: TratamientoPacientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TratamientoPaciente tratamientoPaciente = await db.TratamientoPacientes.FindAsync(id);
            if (tratamientoPaciente == null)
            {
                return HttpNotFound();
            }
            return View(tratamientoPaciente);
        }

        // GET: TratamientoPacientes/Create
        public ActionResult Create()
        {
            TratamientoPaciente tratamientoPaciente = new TratamientoPaciente();
            tratamientoPaciente.ListTratamiento = db1.Tratamiento.ToList();
            return View();
        }

        // POST: TratamientoPacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Prefix = "Item2", Include = "Id,IdPayment,IdTratamiento,IdPaciente,IdDiente,Cara,Observaciones")] TratamientoPaciente tratamientoPaciente)
        {
            try
            {
                tratamientoPaciente.MontoAdicional = 0.00m;
                if (ModelState.IsValid)
                {
                    var _Payment = db1.Payments.ToList().SingleOrDefault(p => p.IdRecord.Equals(tratamientoPaciente.IdPaciente) && p.Estado.Equals(1));

                    if (_Payment == null)
                    {
                        Payment newPayment = new Payment();
                        newPayment.Estado = 1;
                        newPayment.FechaRegistro = DateTime.Now;
                        newPayment.IdRecord = tratamientoPaciente.IdPaciente;
                        newPayment.MontoAdicional = 0.00m;                                            
                        var tratamientoActual = db1.Tratamiento.ToList().SingleOrDefault(t => t.id.Equals(tratamientoPaciente.IdTratamiento));

                        var costoTratamientoActual = ((Tratamiento)tratamientoActual).PrecioBase;
                        newPayment.TotalPagar = decimal.Round(newPayment.MontoAdicional + (decimal)costoTratamientoActual, 2, MidpointRounding.AwayFromZero);
                        newPayment.Saldo = newPayment.TotalPagar;
                        db1.Payments.Add(newPayment);
                        await db1.SaveChangesAsync();
                        tratamientoPaciente.IdPayment = newPayment.Id;

                    }
                    else {

                        var tratamientoActual = db1.Tratamiento.ToList().SingleOrDefault(t => t.id.Equals(tratamientoPaciente.IdTratamiento));
                        var costoTratamientoActual = ((Tratamiento)tratamientoActual).PrecioBase;
                       
                        _Payment.TotalPagar = _Payment.TotalPagar + (decimal)costoTratamientoActual;  
                        _Payment.MontoAdicional = 0.00m;
                        _Payment.TotalPagar = decimal.Round(_Payment.TotalPagar, 2, MidpointRounding.AwayFromZero);
                        _Payment.Saldo = decimal.Round(_Payment.Saldo+ (decimal)costoTratamientoActual, 2, MidpointRounding.AwayFromZero);
                        db1.Entry(_Payment).State = EntityState.Modified;
                        db1.SaveChanges();
                        tratamientoPaciente.IdPayment = _Payment.Id;

                    }
                    db.TratamientoPacientes.Add(tratamientoPaciente);
                    await db.SaveChangesAsync();
                    TempData["AgregoTratamiento"] = "true";
                    TempData["MensajeErrorAgregarTratamiento"] = "true";
                    return RedirectToAction("Edit/" + tratamientoPaciente.IdPaciente, "Records");
                }

                TempData["MensajeErrorAgregarTratamiento"] = "Ocurrió un error, intente agregando el tratamiento nuevamente.";
                return RedirectToAction("Edit/" + tratamientoPaciente.IdPaciente, "Records");
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
                return RedirectToAction("Edit/" + tratamientoPaciente.IdPaciente, "Records");
            }
        }

        // GET: TratamientoPacientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TratamientoPaciente tratamientoPaciente = await db.TratamientoPacientes.FindAsync(id);
            if (tratamientoPaciente == null)
            {
                return HttpNotFound();
            }
            Record record1 = new Record();
            record1 = await db1.Records.FindAsync(tratamientoPaciente.IdPaciente);

            tratamientoPaciente.NombrePaciente = record1.Nombre + " " + record1.Apellido1 + " " + record1.Apellido2;
            tratamientoPaciente.ListTratamiento = db1.Tratamiento.ToList();
            tratamientoPaciente.Tratamiento = db.Tratamientoes.ToList().SingleOrDefault(t => t.id.Equals(tratamientoPaciente.IdTratamiento)).Nombre;
            return View(tratamientoPaciente);
        }

        // POST: TratamientoPacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdTratamiento,IdPaciente,IdPayment,IdDiente,Cara,Observaciones")] TratamientoPaciente tratamientoPaciente)
        {

            if (ModelState.IsValid)
            {
                db.Entry(tratamientoPaciente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["tratamientoEditando"] = "true";
                return RedirectToAction("Edit", "Records", new { id = tratamientoPaciente.IdPaciente });
            }
            return View(tratamientoPaciente);
        }

        // GET: TratamientoPacientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TratamientoPaciente tratamientoPaciente = await db.TratamientoPacientes.FindAsync(id);
            if (tratamientoPaciente == null)
            {
                return HttpNotFound();
            }
            return View(tratamientoPaciente);
        }

        // POST: TratamientoPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TratamientoPaciente tratamientoPaciente = await db.TratamientoPacientes.FindAsync(id);
            db.TratamientoPacientes.Remove(tratamientoPaciente);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
