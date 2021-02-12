using Newtonsoft.Json;
using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.Controllers
{
    public class DiagramaController : Controller
    {
        private ContextClinica _context;

        public DiagramaController()
        {
            _context = new ContextClinica();
        }

        public ActionResult Index()
        {
            var numarPacientiFemei = 0;
            numarPacientiFemei = _context.Pacienti.Count();
            Console.WriteLine(numarPacientiFemei);
            List<Diagrama> intrari = new List<Diagrama>();

            intrari.Add(new Diagrama("NXP", 14));
            intrari.Add(new Diagrama("Infineon", 10));
            intrari.Add(new Diagrama("Renesas", 9));
            intrari.Add(new Diagrama("STMicroelectronics", 8));
            intrari.Add(new Diagrama("Texas Instruments", 7));
 

            ViewBag.Diagrame = JsonConvert.SerializeObject(intrari);
            return View();
        }
    }
}