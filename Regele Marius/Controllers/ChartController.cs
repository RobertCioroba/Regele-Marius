using Newtonsoft.Json;
using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.Controllers
{
    public class ChartController : Controller
    {
		private ContextClinica _context;

		public ChartController()
		{
			_context = new ContextClinica();
		}
		// GET: Chart
		public ActionResult Index()
        {
			List<DataPoint> dataPoints = new List<DataPoint>();

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

			dataPoints.Add(new DataPoint("In derulare", derulare));
			dataPoints.Add(new DataPoint("Finalizare", finalizat));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}
    }
}