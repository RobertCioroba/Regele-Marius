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
    public class RezultatAnalizaController : Controller
    {
        private ContextClinica _context;

        public RezultatAnalizaController()
        {
            _context = new ContextClinica();
        }

        public ActionResult Create()
        {
            var _pacienti = _context.Pacienti.ToList();
            var _analize = _context.Analize.ToList();
            var _medici = _context.Medici.ToList();
            var _rezultatAnaliza = _context.RezultateAnaliza.ToList();

            var viewModel = new RezultatAnalizaViewModel
            {
                RezultatAnaliza = new RezultatAnaliza(),
                Analize = _analize,
                Medici = _medici,
                Pacienti = _pacienti
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(RezultatAnaliza rezultatAnaliza)
        {
            _context.RezultateAnaliza.Add(rezultatAnaliza);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var _rezultatAnaliza = _context.RezultateAnaliza.SingleOrDefault(p => p.Id == id);
            if (_rezultatAnaliza == null)
                return HttpNotFound();

            var viewModel = new RezultatAnalizaViewModel
            {
                RezultatAnaliza = _rezultatAnaliza,
                Medici = _context.Medici.ToList(),
                Analize = _context.Analize.ToList(),
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

            RezultatAnaliza rezultatAnaliza = _context.RezultateAnaliza.Find(id);
            if (rezultatAnaliza == null)
            {
                return HttpNotFound();
            }
            return View(rezultatAnaliza);
        }

        public ActionResult Index()
        {
            var rezultateAnaliza = _context.RezultateAnaliza.Include(c => c.Pacient).ToList();
            return View(rezultateAnaliza);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var rezultatAnaliza = _context.RezultateAnaliza.SingleOrDefault(c => c.Id == id);

            if (rezultatAnaliza == null)
                return HttpNotFound();
            _context.RezultateAnaliza.Remove(rezultatAnaliza);
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