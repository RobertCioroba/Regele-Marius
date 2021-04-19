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
using PagedList;

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

            return View(programareAnaliza);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgramareAnaliza programare = _context.ProgramariAnaliza.Find(id);
            _context.ProgramariAnaliza.Remove(programare);
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

        public ActionResult Index(string sortOrder, string currentFilter2, string searchString2, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.DateSortParm2 = sortOrder == "Date2" ? "date_desc2" : "Date2";
            ViewBag.DateSortParm3 = sortOrder == "Date3" ? "date_desc3" : "Date3";
            if (searchString2 != null)
            {
                page = 1;
            }
            else
            {
                searchString2 = currentFilter2;
            }

            ViewBag.CurrentFilter2 = searchString2;

            var programari = _context.ProgramariAnaliza.Include(t => t.Analiza);

            if (!String.IsNullOrEmpty(searchString2))
            {
                programari = programari.Where(s => s.Nume.Contains(searchString2) ||
                             s.Prenume.Contains(searchString2));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    programari = programari.OrderByDescending(s => s.Analiza.Denumire);
                    break;
                case "Date":
                    programari = programari.OrderBy(s => s.Nume);
                    break;
                case "date_desc":
                    programari = programari.OrderByDescending(s => s.Nume);
                    break;
                case "Date2":
                    programari = programari.OrderBy(s => s.Prenume);
                    break;
                case "date_desc2":
                    programari = programari.OrderByDescending(s => s.Prenume);
                    break;
                case "Date3":
                    programari = programari.OrderBy(s => s.Status);
                    break;
                case "date_desc3":
                    programari = programari.OrderByDescending(s => s.Status);
                    break;
                default:
                    programari = programari.OrderBy(s => s.Analiza.Denumire);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(programari.ToPagedList(pageNumber, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}