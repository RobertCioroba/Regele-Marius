using Regele_Marius.Models;
using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.Controllers
{
    public class RezultatInterventieController : Controller
    {
        private ContextClinica _context;

        public RezultatInterventieController()
        {
            _context = new ContextClinica();
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}