using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.Controllers
{
    public class SpecializareController : Controller
    {
        private ContextClinica _context;

        public SpecializareController()
        {
            _context = new ContextClinica();
        }

        // GET: Specializare
        public ActionResult Index()
        {
            var specializari = _context.Specializari.ToList();
            return View(specializari);
        }

        public ActionResult Create()
        {
            return View(new Specializare {Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(Specializare _specializare)
        {
            if (!ModelState.IsValid)
                return View("Create", _specializare);

            if (_specializare.Id > 0)
                _context.Entry(_specializare).State = System.Data.Entity.EntityState.Modified;
            else
                _context.Specializari.Add(_specializare);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var specializare = _context.Specializari.SingleOrDefault(c => c.Id == id);

            if (specializare == null)
                return HttpNotFound();
            _context.Specializari.Remove(specializare);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var _specializare = _context.Specializari.SingleOrDefault(c => c.Id == id);
            if (_specializare == null)
                return HttpNotFound();

            return View("Create", _specializare);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}