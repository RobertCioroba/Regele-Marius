using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Regele_Marius.Models;

namespace Regele_Marius.Controllers
{
    public class SpecializaresController : Controller
    {
        private ContextClinica db = new ContextClinica();

        // GET: Specializares
        public ActionResult Index()
        {
            return View(db.Specializari.ToList());
        }

        // GET: Specializares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specializare specializare = db.Specializari.Find(id);
            if (specializare == null)
            {
                return HttpNotFound();
            }
            return View(specializare);
        }

        // GET: Specializares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specializares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nume")] Specializare specializare)
        {
            if (ModelState.IsValid)
            {
                if (db.Specializari.Any(x => x.Nume == specializare.Nume))
                    ModelState.AddModelError("Nume", "Specializare existenta");
                else
                {
                    db.Specializari.Add(specializare);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(specializare);
        }

        // GET: Specializares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specializare specializare = db.Specializari.Find(id);
            if (specializare == null)
            {
                return HttpNotFound();
            }
            return View(specializare);
        }

        // POST: Specializares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nume")] Specializare specializare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specializare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specializare);
        }

        // GET: Specializares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specializare specializare = db.Specializari.Find(id);
            if (specializare == null)
            {
                return HttpNotFound();
            }
            return View(specializare);
        }

        // POST: Specializares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specializare specializare = db.Specializari.Find(id);
            db.Specializari.Remove(specializare);
            db.SaveChanges();
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
