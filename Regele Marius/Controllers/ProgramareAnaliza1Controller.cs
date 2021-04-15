using Regele_Marius.Models;
using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using CaptchaMvc.HtmlHelpers;

namespace Regele_Marius.Controllers
{
    public class ProgramareAnaliza1Controller : Controller
    {
        private ContextClinica _context;

        public ProgramareAnaliza1Controller()
        {
            _context = new ContextClinica();
        }

  
        public ActionResult Create()
        {
            var _analize = _context.Analize.ToList();
            var _medici = _context.Medici.ToList();


            var viewModel = new ProgramareAnalizaViewModel
            {
                ProgramareAnaliza = new ProgramareAnaliza(),
                Analize = _analize,
                Medici = _medici
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ProgramareAnaliza programareAnaliza)
        {
            if(ModelState.IsValid)
                if (this.IsCaptchaValid("Captcha is not valid"))
                {
                    RezultatAnaliza rezultat = new RezultatAnaliza();
                    _context.RezultateAnaliza.Add(rezultat);
                    _context.SaveChanges();
                    programareAnaliza.RezultatId = rezultat.Id;
                    List<Medic> medici = _context.Medici.ToList();
                    programareAnaliza.Status = Status.Derulare;
                    _context.ProgramariAnaliza.Add(programareAnaliza);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            ViewBag.ErrMessage = "Error: captcha is not valid.";
            return View();
        }
        

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var programareAnaliza = _context.ProgramariAnaliza.SingleOrDefault(c => c.Id == id);

            if (programareAnaliza == null)
                return HttpNotFound();
            _context.ProgramariAnaliza.Remove(programareAnaliza);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var _programareAnaliza = _context.ProgramariAnaliza.SingleOrDefault(p => p.Id == id);
            if (_programareAnaliza == null)
                return HttpNotFound();

            var viewModel = new ProgramareAnalizaViewModel
            {
                ProgramareAnaliza = _programareAnaliza,
                Medici = _context.Medici.ToList(),
                Analize = _context.Analize.ToList()
            };

            return View("Create", viewModel);
        }
        public ActionResult Index()
        {
            var programariAnaliza = _context.ProgramariAnaliza.Include(c => c.Analiza).ToList();
            return View(programariAnaliza);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}