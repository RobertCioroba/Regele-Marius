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
    public class PacientsController : Controller
    {
        private ContextClinica db = new ContextClinica();

        // GET: Pacients
        public ActionResult Index()
        {
            return View(db.Pacienti.ToList());
        }

        // GET: Pacients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacient pacient = db.Pacienti.Find(id);
            if (pacient == null)
            {
                return HttpNotFound();
            }
            return View(pacient);
        }

        // GET: Pacients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataNastere,NrTelefon,Email,Adresa,Gen,Nume,Prenume")] Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                db.Pacienti.Add(pacient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pacient);
        }

        // GET: Pacients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacient pacient = db.Pacienti.Find(id);
            if (pacient == null)
            {
                return HttpNotFound();
            }
            return View(pacient);
        }

        // POST: Pacients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataNastere,NrTelefon,Email,Adresa,Gen,Nume,Prenume")] Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pacient);
        }

        // GET: Pacients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacient pacient = db.Pacienti.Find(id);
            if (pacient == null)
            {
                return HttpNotFound();
            }
            return View(pacient);
        }

        // POST: Pacients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pacient pacient = db.Pacienti.Find(id);
            db.Pacienti.Remove(pacient);
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
