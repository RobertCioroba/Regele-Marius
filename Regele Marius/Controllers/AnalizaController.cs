using Regele_Marius.Models;
using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
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

        public ActionResult Create()
        {
            var _specializari = _context.Specializari.ToList();

            var viewModel = new AnalizaFormViewModel
            {
                Analiza = new Analiza(),
                Specializari = _specializari
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Analiza analiza)
        {
            if(ModelState.IsValid)
            {
                int numarParametrii = 0;

/*                foreach(PropertyInfo prop in analiza.GetType().GetProperties())
                {
                    if(prop.PropertyType == typeof(bool))
                    {
                        var valoare = prop.GetValue(analiza);
                        if (valoare == true)
                            numarParametrii++;
                    }
                }*/

                analiza.Pret = numarParametrii * 15;
                _context.Analize.Add(analiza);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var analiza = _context.Analize.SingleOrDefault(c => c.Id == id);

            if (analiza == null)
                return HttpNotFound();

            return View(analiza);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Analiza analiza = _context.Analize.Find(id);
            _context.Analize.Remove(analiza);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var _analiza = _context.Analize.SingleOrDefault(p => p.Id == id);
            if (_analiza == null)
                return HttpNotFound();

            var viewModel = new AnalizaFormViewModel
            {
                Analiza = _analiza,
                Specializari = _context.Specializari.ToList()
            };

            return View("Create", viewModel);
        }

        public ActionResult Index()
        {
            var analize = _context.Analize.ToList();
            return View(analize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}