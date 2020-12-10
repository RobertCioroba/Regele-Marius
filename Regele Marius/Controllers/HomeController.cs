using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}