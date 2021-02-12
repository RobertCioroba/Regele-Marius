using Regele_Marius.Models;
using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Regele_Marius.Controllers
{
    public class RezultatInterventieController : Controller
    {
        private ContextClinica _context;

        public RezultatInterventieController()
        {
            _context = new ContextClinica();
        }

        public ActionResult GeneratePDF(int id)
        {
            var report = new Rotativa.ActionAsPdf("Details", new { id = id });
            return report;
        }

        public ActionResult Create()
        {
            var _pacienti = _context.Pacienti.ToList();
            var _interventii = _context.Interventii.ToList();
            var _medici = _context.Medici.ToList();
            var _rezultateInterventie = _context.RezultateInterventie.ToList();

            var viewModel = new RezultatInterventieViewModel
            {
                RezultatInterventie = new RezultatInterventie(),
                Interventii = _interventii,
                Medici = _medici,
                Pacienti = _pacienti
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(RezultatInterventie rezultatInterventie)
        {
            _context.RezultateInterventie.Add(rezultatInterventie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var _rezultatInterventie = _context.RezultateInterventie.SingleOrDefault(p => p.Id == id);
            if (_rezultatInterventie == null)
                return HttpNotFound();

            var viewModel = new RezultatInterventieViewModel
            {
                RezultatInterventie = new RezultatInterventie(),
                Interventii = _context.Interventii.ToList(),
                Medici = _context.Medici.ToList(),
                Pacienti = _context.Pacienti.ToList()
            };

            return View("Create", viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RezultatInterventie rezultatInterventie = _context.RezultateInterventie.Find(id);
            if (rezultatInterventie == null)
            {
                return HttpNotFound();
            }
            return View(rezultatInterventie);
        }

        public ActionResult Index()
        {
            var rezultatInterventie = _context.RezultateInterventie.Include(c => c.Pacient).ToList();
            return View(rezultatInterventie);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var rezultatInterventie = _context.RezultateInterventie.SingleOrDefault(c => c.Id == id);

            if (rezultatInterventie == null)
                return HttpNotFound();
            _context.RezultateInterventie.Remove(rezultatInterventie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}