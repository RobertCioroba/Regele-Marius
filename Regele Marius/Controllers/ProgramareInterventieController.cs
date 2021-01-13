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
    public class ProgramareInterventieController : Controller
    {
        private ContextClinica _context;

        public ProgramareInterventieController()
        {
            _context = new ContextClinica();
        }

        public ActionResult Create()
        {
            var _interventii = _context.Interventii.ToList();
            var _medici = _context.Medici.ToList();


            var viewModel = new ProgramareInterventieViewModel
            {
                ProgramareInterventie = new ProgramareInterventie(),
                Interventii = _interventii,
                Medici = _medici
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ProgramareInterventie programareInterventie)
        {
            _context.ProgramariInterventie.Add(programareInterventie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var programariInterventie = _context.ProgramariInterventie.Include(c => c.Interventie).ToList();
            return View(programariInterventie);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var programareInterventie = _context.ProgramariInterventie.SingleOrDefault(c => c.Id == id);

            if (programareInterventie == null)
                return HttpNotFound();
            _context.ProgramariInterventie.Remove(programareInterventie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var _programareInterventie = _context.ProgramariInterventie.SingleOrDefault(p => p.Id == id);
            if (_programareInterventie == null)
                return HttpNotFound();

            var viewModel = new ProgramareInterventieViewModel
            {
                ProgramareInterventie = _programareInterventie,
                Medici = _context.Medici.ToList(),
                Interventii = _context.Interventii.ToList()
            };

            return View("Create", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}