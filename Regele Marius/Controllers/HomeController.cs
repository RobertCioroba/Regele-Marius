using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;

namespace Regele_Marius.Controllers
{
    public class HomeController : Controller
    {
        private ContextClinica _context;

        public HomeController()
        {
            _context = new ContextClinica();
        }

        public ActionResult Index()
        {
            var slider = _context.Sliders.ToList();
            ViewBag.Slider = slider;

            return View();
        }

        public ActionResult About()
        {
            var analize = new List<string>();
            analize.Add("1");
            analize.Add("2");
            analize.Add("3");
            analize.Add("4");
            analize.Add("5");
            analize.Add("6");
            analize.Add("7");
            analize.Add("8");

            ViewBag.Analize = analize;
            return View();
        }
    }
}