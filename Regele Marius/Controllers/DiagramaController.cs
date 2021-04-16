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

            List<Diagrama> dataPoints = new List<Diagrama>();

            dataPoints.Add(new Diagrama("Economics", 1));
            dataPoints.Add(new Diagrama("Physics", 2));
            dataPoints.Add(new Diagrama("Literature", 4));
            dataPoints.Add(new Diagrama("Chemistry", 4));
            dataPoints.Add(new Diagrama("Literature", 9));
            dataPoints.Add(new Diagrama("Physiology or Medicine", 11));
            dataPoints.Add(new Diagrama("Peace", 13));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
    }
}