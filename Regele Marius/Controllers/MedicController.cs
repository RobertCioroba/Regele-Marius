using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.Controllers
{
    public class MedicController : Controller
    {
        private ContextClinica _context;

        public MedicController()
        {
            _context = new ContextClinica();
        }

        // GET: Medic
        public ActionResult Index()
        {
            var medici = _context.Medici.ToList();
            return View(medici);
        }
    }
}