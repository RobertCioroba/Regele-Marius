﻿using Regele_Marius.Models;
using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Diagnostics;
using System.Reflection;
using System.Text;

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

        public void CreateProgram(object zi, int idMedic,bool schimb)
        {
            int numarOre = 0;
            if (schimb == true)
                foreach (PropertyInfo prop in zi.GetType().GetProperties())
                {
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    if (type == typeof(int))
                    {
                        var proprietate = prop.GetValue(zi, null);
                        //zi(prop) = 1;
                        //zi.
                    }
                }
        }

        [HttpPost]
        public ActionResult Create(Medic medic)
        {
            if(ModelState.IsValid)
            {
                var idUser = TempData["idUser"].ToString();
                var userId = Convert.ToInt32(idUser);
                medic.UserId = userId;
                User1 user = _context.Users1.Find(userId);

                Program program = new Program();
                string[] Luni, Marti, Miercuri, Joi, Vineri;
                Luni = new string[25];
                Marti = new string[25];
                Miercuri = new string[25];
                Joi = new string[25];
                Vineri = new string[25];

                //Marchez programul de lucru pentru fiecare zi
                if (medic.Schimb == Schimb.Unu)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        Luni[i] = "job";
                        Marti[i] = "job";
                        Miercuri[i] = "job";
                        Joi[i] = "job";
                        Vineri[i] = "job";
                    }
                }
                else
                {
                    for (int i = 12; i < 24; i++)
                    {
                        Luni[i] = "job";
                        Marti[i] = "job";
                        Miercuri[i] = "job";
                        Joi[i] = "job";
                        Vineri[i] = "job";
                    }
                }


                for (var i = 0; i < 25; i++)
                {
                    program.Luni += Luni[i] + ',';
                    program.Marti += Marti[i] + ',';
                    program.Miercuri += Miercuri[i] + ',';
                    program.Joi += Joi[i] + ',';
                    program.Vineri += Vineri[i] + ',';
                }
                DateTime data = DateTime.Today;
                while (data.DayOfWeek != DayOfWeek.Monday)
                    data = data.AddDays(1);
                program.Data = data;
                _context.Programs.Add(program);
                _context.Medici.Add(medic);
                _context.SaveChanges();

                program.IdMedic = medic.Id;
                user.IdMedic = medic.Id;
                medic.ProgramId = program.Id;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Programari(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Medic medic = _context.Medici.Find(id);
            int totalProgramariAzi = 0, programariFinalizateAzi = 0;
            List<ProgramareAnaliza> programari = _context.ProgramariAnaliza.ToList();
            List<ProgramareAnaliza> programariCautate = new List<ProgramareAnaliza>();

            foreach (var programare in programari)
                if (programare.MedicId == medic.Id)
                {
                    DateTime date = (DateTime)programare.DataProgramare;
                    programare.DataProgramare = date.Date;
                    programariCautate.Add(programare);
                    if (programare.Status == Status.Finalizat)
                        programariFinalizateAzi++;
                }
            totalProgramariAzi = programariCautate.Count();
            ViewBag.totalProgramariAzi = totalProgramariAzi;
            ViewBag.programariFinalizateAzi = programariFinalizateAzi;
            var dataCurenta = DateTime.Today;
            ViewBag.dataCurenta = dataCurenta.ToShortDateString();
            return View(programariCautate);
        }

        public ActionResult Programarii(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Medic medic = _context.Medici.Find(id);
            int totalProgramariAzi = 0, programariFinalizateAzi = 0;
            List<ProgramareAnaliza> programari = _context.ProgramariAnaliza.ToList();
            List<ProgramareAnaliza> programariCautate = new List<ProgramareAnaliza>();

            foreach (var programare in programari)
            {
                if (programare.MedicId == medic.Id && programare.Status == Status.Derulare)
                {
                    DateTime date = (DateTime)programare.DataProgramare;
                    programare.DataProgramare = date.Date;
                    programariCautate.Add(programare);
                }
                if (programare.MedicId == medic.Id && programare.Status == Status.Finalizat)
                    programariFinalizateAzi++;
                if (programare.MedicId == medic.Id)
                    totalProgramariAzi++;
            }
            ViewBag.totalProgramariAzi = totalProgramariAzi;
            ViewBag.programariFinalizateAzi = programariFinalizateAzi;
            var dataCurenta = DateTime.Today;
            ViewBag.dataCurenta = dataCurenta.ToShortDateString();
            return View(programariCautate);
        }

        public ActionResult Program(int? idMedic)
        {
            TempData["idMedic"] = idMedic;
            return View();
        }

        public JsonResult GetEvents()
        {
            string idMedic = null;
            if (TempData.ContainsKey("idMedic"))
                idMedic = TempData["idMedic"].ToString();
            int medicId = Convert.ToInt32(idMedic);

            List<ProgramareAnaliza> programari = _context.ProgramariAnaliza.Where(x => x.MedicId == medicId).ToList();
            List<Events> events = new List<Events>();
            while (programari.Any())
            {
                var programare = programari.First();
                DateTime inceput = Convert.ToDateTime(programare.OraInceput);
                DateTime final = Convert.ToDateTime(programare.OraFinal);

                var tipAnaliza = _context.Analize.First(x => x.Id == programare.AnalizaId);
                events.Add(new Events()
                {
                    Nume = programari.First().NumeComplet,
                    TipAnaliza = tipAnaliza.Denumire,
                    OraInceput = inceput,
                    OraFinal = final
                });
                programari.Remove(programari.First());
            }
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Medic medic = _context.Medici.Find(id);
            User1 user = _context.Users1.Find(medic.UserId);
            Specializare specializare = _context.Specializari.Find(medic.SpecializareId);
            if (medic == null)
                return HttpNotFound();

            /*            Specializare specializare = _context.Specializari.Find(medic.SpecializareId);
                        ViewBag.Specializare = specializare;*/
            var viewModel = new ContMedicViewModel
            {
                Medic = medic,
                User = user,
                Specializare = specializare
            };

            return View(viewModel);
        }

        public ActionResult _Specializare(int id)
        {
            Specializare specializare = _context.Specializari.Find(id);
            return PartialView(specializare);
        }


        [HttpGet]
        public JsonResult getSpecializare(int id)
        {
            if (_context.Specializari.Any(x => x.Id == id))
            {
                var specialiare = _context.Specializari.Find(id);
                var numeSpecializare = specialiare.Nume;
                Debug.WriteLine(numeSpecializare);
                return Json(numeSpecializare, JsonRequestBehavior.AllowGet);
            }

            return Json("eroare");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var medic = _context.Medici.SingleOrDefault(c => c.Id == id);

            if (medic == null)
                return HttpNotFound();

            return View(medic);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medic medic = _context.Medici.Find(id);
            _context.Medici.Remove(medic);
            _context.SaveChanges();
            return RedirectToAction("Index");
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