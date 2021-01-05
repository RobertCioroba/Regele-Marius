using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.Controllers
{
    public class AnalizaController : Controller
    {
        private ContextClinica _context;

        public AnalizaController()
        {
            _context = new ContextClinica();
        }

        // GET: Analiza
        public ActionResult Index()
        {
            var analize = _context.Analize.ToList();
            return View(analize);
        }

        public ActionResult Create()
        {
            return View(new Analiza { Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(Analiza _analiza)
        {
            if (!ModelState.IsValid)
                return View("Create", _analiza);

            if (_analiza.Id > 0)
                _context.Entry(_analiza).State = System.Data.Entity.EntityState.Modified;
            else
                _context.Analize.Add(_analiza);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var analiza = _context.Analize.SingleOrDefault(c => c.Id == id);

            if (analiza == null)
                return HttpNotFound();
            _context.Analize.Remove(analiza);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var analiza = _context.Analize.SingleOrDefault(c => c.Id == id);
            if (analiza == null)
                return HttpNotFound();

            return View("Create", analiza);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}