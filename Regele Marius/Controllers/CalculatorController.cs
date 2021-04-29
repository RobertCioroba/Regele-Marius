using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Regele_Marius.Models;

namespace Regele_Marius.Controllers
{
    public class CalculatorController : Controller
    {
        private ContextClinica _context;

        public CalculatorController()
        {
            _context = new ContextClinica();
        }

        public ActionResult Create()
        {
            return View(new Calculator { Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(Calculator _calculator)
        {
            double rezultat = 0;
            var gen = _calculator.Gen;
            if (gen == 0)
                if (_calculator.Varsta > 14)
                    rezultat = 1.2 * (_calculator.Greutate) / (_calculator.Inaltime * _calculator.Inaltime) + 0.23 * _calculator.Varsta - 16.2;
                else
                    rezultat = 1.51 * (_calculator.Greutate) / (_calculator.Inaltime * _calculator.Inaltime) - 0.7 * _calculator.Varsta - 2.2;
            else
                if (_calculator.Varsta > 14)
                rezultat = 1.2 * (_calculator.Greutate) / (_calculator.Inaltime * _calculator.Inaltime) + 0.23 * _calculator.Varsta - 5.4;
            else
                rezultat = 1.51 * (_calculator.Greutate) / (_calculator.Inaltime * _calculator.Inaltime) - 0.7 * _calculator.Varsta + 1.4;

            if (!ModelState.IsValid)
                return View("Create", _calculator);

            if (_calculator.Id > 0)
                _context.Entry(_calculator).State = System.Data.Entity.EntityState.Modified;
            else
                _context.Calculatoare.Add(_calculator);


            var BMI = (_calculator.Greutate) / (_calculator.Inaltime * _calculator.Inaltime);
            var rezultatText = "";
            if (gen == 0)
            {
                if (rezultat <= 13.00)
                    rezultatText = "Sportiv";
                else
                    if (rezultat > 13.00 && rezultat <= 17.00)
                    rezultatText = "Fitness";
                else
                    if (rezultat > 17.00 && rezultat <= 24.00)
                    rezultatText = "Greutate medie";
                else
                    if (rezultat > 24)
                    rezultatText = "Obezitate";
            }
            else
            {
                if (rezultat <= 20.00)
                    rezultatText = "Sportiv";
                else
                    if (rezultat > 20.00 && rezultat <= 24.00)
                    rezultatText = "Fitness";
                else
                    if (rezultat > 24.00 && rezultat <= 31.00)
                    rezultatText = "Greutate medie";
                else
                    if (rezultat > 31)
                    rezultatText = "Obezitate";
            }

            _calculator.Rezultat = rezultatText;
            _context.SaveChanges();
            ViewBag.Message1 = String.Format("{0:0.00}", rezultat); 
            ViewBag.Message2 = String.Format("{0:0.00}", BMI);
            ViewBag.Message3 = rezultatText;
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
