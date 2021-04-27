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
			//randare chart pentru taskuri
			List<Diagrama> dataPoints = new List<Diagrama>();
			List<ProgramareAnaliza> programari = _context.ProgramariAnaliza.ToList();
			int derulare = 0, finalizat = 0, total = programari.Count();
			foreach (var programare in programari)
			{
				switch (programare.Status)
				{
					case Status.Derulare:
						derulare++;
						break;
					default:
						finalizat++;
						break;
				}
			}

			derulare = (derulare * 100) / total;
			finalizat = (finalizat * 100) / total;

			dataPoints.Add(new Diagrama("In derulare", derulare));
			dataPoints.Add(new Diagrama("Finalizare", finalizat));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
			return View();
		}
	}
}