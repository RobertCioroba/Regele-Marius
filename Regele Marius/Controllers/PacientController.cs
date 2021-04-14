using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.Controllers
{
    public class PacientController : Controller
    {
        private ContextClinica _context;

        public PacientController()
        {
            _context = new ContextClinica();
        }

        // GET: Pacient
        public ActionResult Index()
        {
            var pacienti = _context.Pacienti.ToList();
            return View(pacienti);
        }

        public ActionResult Create()
        {
            return View(new Pacient {Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(Pacient _pacient)
        {
            if (!ModelState.IsValid)
                return View("Create", _pacient);

            if(_pacient.Id > 0)
                _context.Entry(_pacient).State = System.Data.Entity.EntityState.Modified;
            else
                _context.Pacienti.Add(_pacient);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pacient = _context.Pacienti.SingleOrDefault(c => c.Id == id);

            if (pacient == null)
                return HttpNotFound();

            return View(pacient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pacient pacient = _context.Pacienti.Find(id);
            _context.Pacienti.Remove(pacient);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pacient = _context.Pacienti.SingleOrDefault(c => c.Id == id);
            if (pacient == null)
                return HttpNotFound();

            return View("Create", pacient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}