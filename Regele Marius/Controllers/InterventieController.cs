using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.Controllers
{
    public class InterventieController : Controller
    {
        private ContextClinica _context;

        public InterventieController()
        {
            _context = new ContextClinica();
        }

        // GET: Interventie
        public ActionResult Index()
        {
            var interventii = _context.Interventii.ToList();
            return View(interventii);
        }

        public ActionResult Create()
        {
            return View(new Interventie { Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(Interventie _interventie)
        {
            if (!ModelState.IsValid)
                return View("Create", _interventie);

            if (_interventie.Id > 0)
                _context.Entry(_interventie).State = System.Data.Entity.EntityState.Modified;
            else
                _context.Interventii.Add(_interventie);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var interventie = _context.Interventii.SingleOrDefault(c => c.Id == id);

            if (interventie == null)
                return HttpNotFound();
            _context.Interventii.Remove(interventie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var interventie = _context.Interventii.SingleOrDefault(c => c.Id == id);
            if (interventie == null)
                return HttpNotFound();

            return View("Create", interventie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}