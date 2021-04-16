using Regele_Marius.Models;
using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Reflection;
using System.Diagnostics;

namespace Regele_Marius.Controllers
{
    public class RezultatAnalizaController : Controller
    {
        private ContextClinica _context;

        public RezultatAnalizaController()
        {
            _context = new ContextClinica();
        }

        public ActionResult GeneratePDF(int id)
        {
            var report = new Rotativa.ActionAsPdf("Details", new { id = id });
            return report;
        }


        public ActionResult Create(int id)
        {
            ProgramareAnaliza programare = _context.ProgramariAnaliza.Find(id);
            Analiza analiza = _context.Analize.Find(programare.AnalizaId);
            RezultatAnaliza rezultat = new RezultatAnaliza();
            rezultat.AnalizaId = programare.AnalizaId;
            rezultat.DataNastere = programare.DataNastere;
            rezultat.Denumire = analiza.Denumire;
            rezultat.Descriere = analiza.Descriere;
            rezultat.Email = programare.Email;
            rezultat.MedicId = programare.MedicId;
            rezultat.NrTelefon = programare.NrTelefon;
            rezultat.Pret = analiza.Pret;
            rezultat.Gen = programare.Gen;
            rezultat.NumePacient = programare.Nume;
            rezultat.PrenumePacient = programare.Prenume;

            PropertyInfo[] props = typeof(Analiza).GetProperties();

            var justBools = new List<string>();

            foreach(PropertyInfo prop in props)
            {
                if (prop.PropertyType.ToString() == "System.Boolean")
                {
                    justBools.Add(prop.Name);
                }
            }

            foreach (var boolulet in justBools)
            {
                Debug.WriteLine(boolulet);
            }



            return View(rezultat);
        }

        [HttpPost]
        public ActionResult Create(RezultatAnaliza rezultatAnaliza,ProgramareAnaliza programareAnaliza)
        {
           // rezultatAnaliza.ProgramareAnaliza = programareAnaliza.Id;

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