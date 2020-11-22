using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.Controllers
{
    public class SpecializareController : Controller
    {
        private ContextClinica _context;

        public SpecializareController()
        {
            _context = new ContextClinica();
        }

        // GET: Specializare
        public ActionResult Index()
        {
            var specializari = _context.Specializari.ToList();
            return View(specializari);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}