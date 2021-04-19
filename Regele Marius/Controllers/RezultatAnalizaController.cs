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
            programare.Status = Status.Finalizat;
            var Rezultat = new RezultatAnalizaCreateViewModel
            {
                RezultatAnaliza = rezultat,
                ProgramareAnaliza = programare,
                Analiza = analiza
            };
            /*            PropertyInfo[] props = typeof(Analiza).GetProperties();

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
                        }*/
            return View(Rezultat);
        }

        [HttpPost]
        public ActionResult Create(RezultatAnaliza rezultatAnaliza)
        {
            // rezultatAnaliza.ProgramareAnaliza = programareAnaliza.Id;
            if(ModelState.IsValid)
            {
                string idProgramare = null;
                if (TempData.ContainsKey("idProgramare"))
                {
                    idProgramare = TempData["idProgramare"].ToString();
                    int programareId = Convert.ToInt32(idProgramare);
                    ProgramareAnaliza programare = _context.ProgramariAnaliza.Find(programareId);
                    Analiza analiza = _context.Analize.Find(programare.AnalizaId);
                    rezultatAnaliza.AnalizaId = programare.AnalizaId;
                    rezultatAnaliza.DataNastere = programare.DataNastere;
                    rezultatAnaliza.Denumire = analiza.Denumire;
                    rezultatAnaliza.Descriere = analiza.Descriere;
                    rezultatAnaliza.Email = programare.Email;
                    rezultatAnaliza.MedicId = programare.MedicId;
                    rezultatAnaliza.NrTelefon = programare.NrTelefon;
                    rezultatAnaliza.Pret = analiza.Pret;
                    rezultatAnaliza.Gen = programare.Gen;
                    rezultatAnaliza.NumePacient = programare.Nume;
                    rezultatAnaliza.PrenumePacient = programare.Prenume;
                    rezultatAnaliza.ProgramareAnalizaId = programareId;
                    programare.Status = Status.Finalizat;
                    _context.RezultateAnaliza.Add(rezultatAnaliza);
                    _context.SaveChanges();
                    programare.RezultatId = rezultatAnaliza.Id;
                    _context.SaveChanges();
                }
                return RedirectToAction("Index","ProgramareAnaliza1"); ;
            }
            return View();
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
            return View(rezultatAnaliza);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RezultatAnaliza rezultat = _context.RezultateAnaliza.Find(id);
            _context.RezultateAnaliza.Remove(rezultat);
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