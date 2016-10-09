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

namespace RecApp_2.Controllers
{
    public class RecordsController : Controller
    {
        private RecordsContext db = new RecordsContext();

        // GET: Records
        public async Task<ActionResult> Index()
        {
            return View(await db.Records.ToListAsync());
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
            if (ModelState.IsValid)
            {
                db.Records.Add(record);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            record.ListCivilStatus = db.Civil_Status.ToList();

            return View(record);
        }

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
            record.ListCivilStatus = db.Civil_Status.ToList();                        
                         
            return View(record);
        }

        // POST: Records/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Nombre,Apellido1,Apellido2,Cedula,FechaNacimiento,Edad,MenorEdad,NombreEncargado,Apellido1Encargado,Apellido2Encargado,IdEstadoCivil,Domicilio,Telefono1,Telefono2,Profesion,Email,ContactoEmergencia,TratamientoMedico,Medicamento,Diabetes,Artritis,EnfermedadCardiaca,Hepatitis,FiebreReumatica,Ulcera,PresionAlta,PresionBaja,EnfermedadesNerviosas,OtrasEnfermedades,SangradoProlongado,Desmayos,IntervencionQuirurgica,Aspirina,Sulfas,Penicilina,AnomaliasAnestesia,Embarazo,Lactancia,Otros")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            record.ListCivilStatus = db.Civil_Status.ToList();
            return View(record);
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
