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
    public class ExRezultatAnalizasController : Controller
    {
        private ContextClinica db = new ContextClinica();

        // GET: ExRezultatAnalizas
        public ActionResult Index()
        {
            var rezultateAnaliza = db.RezultateAnaliza.Include(r => r.Analiza).Include(r => r.Medic).Include(r => r.Pacient);
            return View(rezultateAnaliza.ToList());
        }

        // GET: ExRezultatAnalizas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RezultatAnaliza rezultatAnaliza = db.RezultateAnaliza.Find(id);
            if (rezultatAnaliza == null)
            {
                return HttpNotFound();
            }
            return View(rezultatAnaliza);
        }

        // GET: ExRezultatAnalizas/Create
        public ActionResult Create()
        {
            ViewBag.AnalizaId = new SelectList(db.Analize, "Id", "Denumire");
            ViewBag.MedicId = new SelectList(db.Medici, "Id", "Nume");
            ViewBag.PacientId = new SelectList(db.Pacienti, "Id", "Email");
            return View();
        }

        // POST: ExRezultatAnalizas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MedicId,PacientId,AnalizaId,DataNastere,NrTelefon,Email,Adresa,Gen,Denumire,Descriere,Pret,Glicemie,NumarLeucocite,NumarEritrocite,Hemoglobina,Hematrocit,VolumEritrocitarMediu,ConcentratieMedie,Trombocite,VolumMediuTrombocitar,Plachetocrit,Monocite,Neutrofile,Eozinofile,Bazofile,Limfocite,Colesterol,Trigliceride,Uree,Creatinina,Calciu,Fier,Magneziu")] RezultatAnaliza rezultatAnaliza)
        {
            if (ModelState.IsValid)
            {
                db.RezultateAnaliza.Add(rezultatAnaliza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnalizaId = new SelectList(db.Analize, "Id", "Denumire", rezultatAnaliza.AnalizaId);
            ViewBag.MedicId = new SelectList(db.Medici, "Id", "Nume", rezultatAnaliza.MedicId);
            ViewBag.PacientId = new SelectList(db.Pacienti, "Id", "Email", rezultatAnaliza.PacientId);
            return View(rezultatAnaliza);
        }

        // GET: ExRezultatAnalizas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RezultatAnaliza rezultatAnaliza = db.RezultateAnaliza.Find(id);
            if (rezultatAnaliza == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnalizaId = new SelectList(db.Analize, "Id", "Denumire", rezultatAnaliza.AnalizaId);
            ViewBag.MedicId = new SelectList(db.Medici, "Id", "Nume", rezultatAnaliza.MedicId);
            ViewBag.PacientId = new SelectList(db.Pacienti, "Id", "Email", rezultatAnaliza.PacientId);
            return View(rezultatAnaliza);
        }

        // POST: ExRezultatAnalizas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MedicId,PacientId,AnalizaId,DataNastere,NrTelefon,Email,Adresa,Gen,Denumire,Descriere,Pret,Glicemie,NumarLeucocite,NumarEritrocite,Hemoglobina,Hematrocit,VolumEritrocitarMediu,ConcentratieMedie,Trombocite,VolumMediuTrombocitar,Plachetocrit,Monocite,Neutrofile,Eozinofile,Bazofile,Limfocite,Colesterol,Trigliceride,Uree,Creatinina,Calciu,Fier,Magneziu")] RezultatAnaliza rezultatAnaliza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezultatAnaliza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnalizaId = new SelectList(db.Analize, "Id", "Denumire", rezultatAnaliza.AnalizaId);
            ViewBag.MedicId = new SelectList(db.Medici, "Id", "Nume", rezultatAnaliza.MedicId);
            ViewBag.PacientId = new SelectList(db.Pacienti, "Id", "Email", rezultatAnaliza.PacientId);
            return View(rezultatAnaliza);
        }

        // GET: ExRezultatAnalizas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RezultatAnaliza rezultatAnaliza = db.RezultateAnaliza.Find(id);
            if (rezultatAnaliza == null)
            {
                return HttpNotFound();
            }
            return View(rezultatAnaliza);
        }

        // POST: ExRezultatAnalizas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RezultatAnaliza rezultatAnaliza = db.RezultateAnaliza.Find(id);
            db.RezultateAnaliza.Remove(rezultatAnaliza);
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
