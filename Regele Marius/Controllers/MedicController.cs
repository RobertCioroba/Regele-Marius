using Regele_Marius.Models;
using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace Regele_Marius.Controllers
{
    public class MedicController : Controller
    {
        private ContextClinica _context;

        public MedicController()
        {
            _context = new ContextClinica();
        }

        public ActionResult Create()
        {
            var _specializari = _context.Specializari.ToList();

            var viewModel = new MedicFormViewModel
            {
                Medic = new Medic(),
                Specializari = _specializari
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Medic medic)
        {
            _context.Medici.Add(medic);
            _context.SaveChanges();

            return Content("Medic salvat!");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var _medic = _context.Medici.SingleOrDefault(p => p.Id == id);
            if (_medic == null)
                return HttpNotFound();

            var viewModel = new MedicFormViewModel
            {
                Medic = _medic,
                Specializari = _context.Specializari.ToList()
            };

            return View("Create",viewModel);
        }

        // GET: Medic
        public ActionResult Index()
        {
            var medici = _context.Medici.Include(c => c.Specializare).ToList();
            return View(medici);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}