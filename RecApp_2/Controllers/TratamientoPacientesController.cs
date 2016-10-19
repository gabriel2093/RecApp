﻿using System;
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
            tratamientoPaciente.ListTratamiento = db1.Tratamiento_valor.ToList();
            return View();
        }

        // POST: TratamientoPacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdTratamiento,IdPaciente,IdDiente,Cara,Observaciones")] TratamientoPaciente tratamientoPaciente)
        {
            if (ModelState.IsValid)
            {
                db.TratamientoPacientes.Add(tratamientoPaciente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tratamientoPaciente);
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
            return View(tratamientoPaciente);
        }

        // POST: TratamientoPacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdTratamiento,IdPaciente,IdDiente,Cara,Observaciones")] TratamientoPaciente tratamientoPaciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tratamientoPaciente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
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
