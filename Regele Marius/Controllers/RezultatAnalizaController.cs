using Regele_Marius.Models;
using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var _programareAnaliza = _context.ProgramariAnaliza.ToList();
            var viewModel = new RezultatAnalizaViewModel
            {
                Pacient = new Pacient(),
                Analiza = new Analiza(),
                ProgramareAnaliza = new ProgramareAnaliza()
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}