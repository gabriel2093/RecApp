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
    public class CivilStatusController : Controller
    {
        private CivilStatContext db = new CivilStatContext();

        // GET: CivilStatus
        public async Task<ActionResult> Index()
        {
            return View(await db.CivilStatus.ToListAsync());
        }

        // GET: CivilStatus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CivilStatus civilStatus = await db.CivilStatus.FindAsync(id);
            if (civilStatus == null)
            {
                return HttpNotFound();
            }
            return View(civilStatus);
        }

        // GET: CivilStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CivilStatus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descripcion")] CivilStatus civilStatus)
        {
            if (ModelState.IsValid)
            {
                db.CivilStatus.Add(civilStatus);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(civilStatus);
        }

        // GET: CivilStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CivilStatus civilStatus = await db.CivilStatus.FindAsync(id);
            if (civilStatus == null)
            {
                return HttpNotFound();
            }
            return View(civilStatus);
        }

        // POST: CivilStatus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descripcion")] CivilStatus civilStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(civilStatus).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(civilStatus);
        }

        // GET: CivilStatus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CivilStatus civilStatus = await db.CivilStatus.FindAsync(id);
            if (civilStatus == null)
            {
                return HttpNotFound();
            }
            return View(civilStatus);
        }

        // POST: CivilStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CivilStatus civilStatus = await db.CivilStatus.FindAsync(id);
            db.CivilStatus.Remove(civilStatus);
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
