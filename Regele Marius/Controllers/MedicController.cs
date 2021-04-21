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

        public int[] SetInterval(DateTime? inceput, DateTime? final)
        {
            int oraInceput = 0, oraFinal = 0;
            oraInceput = inceput.Value.Hour * 2 + 1;
            //verific daca sunt in prima sau in a 2-a jumatate a unei ore
            if (inceput.Value.Minute > 30)
                oraInceput++;

            oraFinal = final.Value.Hour * 2;
            if (final.Value.Minute > 30)
                oraFinal++;
            int[] interval = { oraInceput, oraFinal };
            return interval;
        }

        [HttpPost]
        public ActionResult Create(Medic medic)
        {
            var idUser = TempData["idUser"].ToString();
            var userId = Convert.ToInt32(idUser);
            medic.UserId = userId;
            User1 user = _context.Users1.Find(userId);
            Program program = new Program();
            int[] Luni,Marti,Miercuri,Joi,Vineri;
            Luni = new int[49];
            Marti = new int[49];
            Miercuri = new int[49];
            Joi = new int[49];
            Vineri = new int[49];

            for (var i = 0; i < 48; i++)
            {
                Luni[i] = 0;
                Marti[i] = 0;
                Miercuri[i] = 0;
                Joi[i] = 0;
                Vineri[i] = 0;
            }

            //Marchez programul de lucru pentru fiecare zi
            int[] interval = SetInterval(medic.LuniInceput, medic.LuniFinal);
            for (int i = interval[0]; i < interval[1]; i++)
                Luni[i] = 1;

            interval = SetInterval(medic.MartiInceput, medic.MartiFinal);
            for (int i = interval[0]; i < interval[1]; i++)
                Marti[i] = 1;

            interval = SetInterval(medic.MiercuriInceput, medic.MiercuriFinal);
            for (int i = interval[0]; i < interval[1]; i++)
                Miercuri[i] = 1;

            interval = SetInterval(medic.JoiInceput, medic.JoiFinal);
            for (int i = interval[0]; i < interval[1]; i++)
                Joi[i] = 1;

            interval = SetInterval(medic.VineriInceput, medic.VineriFinal);
            for (int i = interval[0]; i < interval[1]; i++)
                Vineri[i] = 1;

            for(var i = 0; i < 48; i++)
            {
                program.Luni += Luni[i];
                program.Marti += Marti[i];
                program.Miercuri += Miercuri[i];
                program.Joi += Joi[i];
                program.Vineri += Vineri[i];
            }

            _context.Programs.Add(program);
            _context.Medici.Add(medic);
            _context.SaveChanges();

            program.IdMedic = medic.Id;
            user.IdMedic = medic.Id;
            medic.ProgramId = program.Id;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Medic medic = _context.Medici.Find(id);
            if (medic == null)
                return HttpNotFound();

            Specializare specializare = _context.Specializari.Find(medic.SpecializareId);
            ViewBag.Specializare = specializare;


            return View(medic);
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