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
    public class PaymentDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PaymentDetails
        public async Task<ActionResult> Index()
        {
            return View(await db.PaymentDetails.ToListAsync());
        }

        // GET: PaymentDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentDetails paymentDetails = await db.PaymentDetails.FindAsync(id);
            if (paymentDetails == null)
            {
                return HttpNotFound();
            }
            return View(paymentDetails);
        }

        // GET: PaymentDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentDetails/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdPayment,FechaAbono,Abono")] PaymentDetails paymentDetails)
        {
            if (ModelState.IsValid)
            {
                db.PaymentDetails.Add(paymentDetails);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(paymentDetails);
        }

        // GET: PaymentDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentDetails paymentDetails = await db.PaymentDetails.FindAsync(id);
            if (paymentDetails == null)
            {
                return HttpNotFound();
            }
            return View(paymentDetails);
        }

        // POST: PaymentDetails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdPayment,FechaAbono,Abono")] PaymentDetails paymentDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentDetails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paymentDetails);
        }

        // GET: PaymentDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentDetails paymentDetails = await db.PaymentDetails.FindAsync(id);
            if (paymentDetails == null)
            {
                return HttpNotFound();
            }
            return View(paymentDetails);
        }

        // POST: PaymentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PaymentDetails paymentDetails = await db.PaymentDetails.FindAsync(id);
            db.PaymentDetails.Remove(paymentDetails);
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
