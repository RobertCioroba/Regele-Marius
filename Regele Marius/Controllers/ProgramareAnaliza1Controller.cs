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

        //convert din string in vector
        public int[] SetareVector(string programPeZi)
        {
            int[] zi = new int[49];
            int i = 0;
            foreach(char c in programPeZi)
            {
                zi[i] = Convert.ToInt32(c);
                i++;
            }
            return zi;
        }

        public DateTime inceput = new DateTime(1, 1, 1, 0, 0, 0);
        public DateTime final = new DateTime(1, 1, 1, 0, 0, 0);
        //incerc sa introduc programarea in programul medicului
        public int[] VerificareZi(int[] ziPentruVerificare,int durataAnaliza)
        {
            int i = 0, gasit = 0, startInterval = 0, finalInterval = 0, lungimeInterval = 0;
            while(i < (ziPentruVerificare.Length - 2) && gasit == 0)
            {
                if(ziPentruVerificare[i] == 1)
                {
                    if(lungimeInterval == 0)
                    {
                        startInterval = i;
                        i++;
                        lungimeInterval++;
                    }
                    else
                    {
                        lungimeInterval++;
                        i++;
                    }
                    if (lungimeInterval == durataAnaliza)
                    {
                        gasit = 1;
                        finalInterval = i - 1;
                    }
                }
                else
                {
                    i++;
                }
            }

            if (gasit == 1)
            {
                for (i = startInterval; i < finalInterval; i++)
                    ziPentruVerificare[1] = 2;
                ziPentruVerificare[48] = 5;
                inceput.AddHours(startInterval / 2);
                if (startInterval % 2 != 0)
                    inceput.AddMinutes(30);

                final.AddHours(finalInterval / 2);
                if (finalInterval % 2 != 0)
                    final.AddMinutes(30);
            }

            return ziPentruVerificare;
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
                    List<Medic> mediciEligibili = new List<Medic>();
                    List<Analiza> analize = _context.Analize.ToList();
                    List<Program> programs = _context.Programs.ToList();

                    var analiza = _context.Analize.SingleOrDefault(c => c.Id == programareAnaliza.AnalizaId);
                    var specializareAnaliza = _context.Specializari.SingleOrDefault(c => c.Id == analiza.SpecializareId);
                    //caut doar medicii care pot efectua setul cautat de analize
                    foreach (var medic in medici)
                    {
                        var specializareMedic = _context.Specializari.SingleOrDefault(c => c.Id == medic.SpecializareId);
                        
                        if (specializareMedic == specializareAnaliza)
                            mediciEligibili.Add(medic);
                    }

                    int[] luni, marti, miercuri, joi, vineri;
                    luni = new int[49];
                    marti = new int[49];
                    miercuri = new int[49];
                    joi = new int[49];
                    vineri = new int[49];

                    var durataAnaliza = analiza.Durata;
                    int durata = durataAnaliza.Value.Hour * 2;
                    if (durataAnaliza.Value.Minute > 30)
                        durata++;

                    foreach(var medic in mediciEligibili)
                    {
                        Program program = _context.Programs.SingleOrDefault(c => c.Id == medic.ProgramId);
                        luni = SetareVector(program.Luni);
                        luni = VerificareZi(luni, durata);
                        if (luni[48] == 5)
                        {
                            programareAnaliza.MedicId = medic.Id;
                            programareAnaliza.OraInceput = inceput;
                            programareAnaliza.OraFinal = final;
                            break;
                        }
                        else
                        {
                            marti = SetareVector(program.Marti);
                            marti = VerificareZi(marti, durata);
                            if (marti[48] == 5)
                            {
                                programareAnaliza.MedicId = medic.Id;
                                programareAnaliza.OraInceput = inceput;
                                programareAnaliza.OraFinal = final;
                                break;
                            }
                            else
                            {
                                miercuri = SetareVector(program.Miercuri);
                                miercuri = VerificareZi(miercuri, durata);
                                if (miercuri[48] == 5)
                                {
                                    programareAnaliza.MedicId = medic.Id;
                                    programareAnaliza.OraInceput = inceput;
                                    programareAnaliza.OraFinal = final;
                                    break;
                                }
                                else
                                {
                                    joi = SetareVector(program.Joi);
                                    joi = VerificareZi(joi, durata);
                                    if (joi[48] == 5)
                                    {
                                        programareAnaliza.MedicId = medic.Id;
                                        programareAnaliza.OraInceput = inceput;
                                        programareAnaliza.OraFinal = final;
                                        break;
                                    }
                                    else
                                    {
                                        vineri = SetareVector(program.Vineri);
                                        vineri = VerificareZi(vineri, durata);
                                        if(vineri[48] == 5)
                                        {
                                            programareAnaliza.MedicId = medic.Id;
                                            programareAnaliza.OraInceput = inceput;
                                            programareAnaliza.OraFinal = final;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                   
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