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
			List<DataPoint> dataPointsFete = new List<DataPoint>();
			List<DataPoint> dataPointsBaieti = new List<DataPoint>();
			List<DataPoint> dataPointsObezitate = new List<DataPoint>();

			List<Calculator> statistici = _context.Calculatoare.ToList();

			int fata1 = 0, fata2 = 0, fata3 = 0, fata4 = 0, fata5 = 0, totalfete = 0;
			int greutate1 = 0, greutate2 = 0, greutate3 = 0, greutate4 = 0, greutate5 = 0;
			int baiat1 = 0, baiat2 = 0, baiat3 = 0, baiat4 = 0, baiat5 = 0, totalBaieti = 0;
			int greutateb1 = 0, greutateb2 = 0, greutateb3 = 0, greutateb4 = 0, greutateb5 = 0;
			int rezultat1 = 0, rezultat2 = 0, rezultat3 = 0, rezultat4 = 0, totalStatistici = statistici.Count();

			foreach (var element in statistici)
            {
				if (element.Rezultat == "Sportiv")
					rezultat1++;
				else if (element.Rezultat == "Fitness")
					rezultat2++;
				else if (element.Rezultat == "Greutate medie")
					rezultat3++;
				else
					rezultat4++;

				if(element.Gen == Sex.Feminin)
                {
					totalfete++;
					if (element.Varsta < 14)
                    {
						fata1++;
						greutate1 += element.Greutate;
					}
					else if (element.Varsta > 15 && element.Varsta <= 30)
                    {
						fata2++;
						greutate2 += element.Greutate;
					}
					else if (element.Varsta > 31 && element.Varsta <= 45)
                    {
						fata3++;
						greutate3 += element.Greutate;
					}
					else if (element.Varsta > 46 && element.Varsta <= 65)
                    {
						fata4++;
						greutate4 += element.Greutate;
					}
					else
                    {
						fata5++;
						greutate5 += element.Greutate;
					}
                }
				else
                {
					totalBaieti++;
					if (element.Varsta <= 14)
                    {
						baiat1++;
						greutateb1 += element.Greutate;
					}
					else if (element.Varsta > 15 && element.Varsta <= 30)
                    {
						baiat2++;
						greutateb2 += element.Greutate;
					}
					else if (element.Varsta > 31 && element.Varsta <= 45)
                    {
						baiat3++;
						greutateb3 += element.Greutate;
					}
					else if (element.Varsta > 46 && element.Varsta <= 65)
                    {
						baiat4++;
						greutateb4 += element.Greutate;
					}
					else
                    {
						baiat5++;
						greutateb5 += element.Greutate;
					}
				}
            }
			if(fata1 != 0)
				fata1 = greutate1 / fata1;
			if(fata2 != 0)
				fata2 = greutate2 / fata2;
			if(fata3 != 0)
				fata3 = greutate3 / fata3;
			if(fata4 != 0)
				fata4 = greutate4 / fata4 * 100;
			if(fata5 != 0)
				fata5 = greutate5 / fata5 * 100;
			dataPointsFete.Add(new DataPoint("<14 ani", fata1));
			dataPointsFete.Add(new DataPoint("15-30 ani", fata2));
			dataPointsFete.Add(new DataPoint("31-45 ani", fata3));
			dataPointsFete.Add(new DataPoint("46-65 ani", fata4));
			dataPointsFete.Add(new DataPoint(">65 ani", fata5));
			ViewBag.StatisticiFete = JsonConvert.SerializeObject(dataPointsFete);

			if (baiat1 != 0)
				baiat1 = greutateb1 / baiat1; 
			if(baiat2 != 0)
				baiat2 = greutateb2 / baiat2; 
			if(baiat3 != 0)
				baiat3 = greutateb3 / baiat3; 
			if(baiat4 != 0)
				baiat4 = greutateb4 / baiat4; 
			if(baiat5 != 0)
				baiat5 = greutateb5 / baiat5;
			dataPointsBaieti.Add(new DataPoint("<14 ani", baiat1));
			dataPointsBaieti.Add(new DataPoint("15-30 ani", baiat2));
			dataPointsBaieti.Add(new DataPoint("31-45 ani", baiat3));
			dataPointsBaieti.Add(new DataPoint("46-65 ani", baiat4));
			dataPointsBaieti.Add(new DataPoint(">65 ani", baiat5));
			ViewBag.StatisticiBaieti = JsonConvert.SerializeObject(dataPointsBaieti);

			rezultat1 = (rezultat1 * 100) / totalStatistici;
			rezultat2 = (rezultat2 * 100) / totalStatistici;
			rezultat3 = (rezultat3 * 100) / totalStatistici;
			rezultat4 = (rezultat4 * 100) / totalStatistici;
			dataPointsObezitate.Add(new DataPoint("Sportiv", rezultat1));
			dataPointsObezitate.Add(new DataPoint("Fitness", rezultat2));
			dataPointsObezitate.Add(new DataPoint("Greutate medie", rezultat3));
			dataPointsObezitate.Add(new DataPoint("Obezitate", rezultat4));
			ViewBag.StatisticiObezitate = JsonConvert.SerializeObject(dataPointsObezitate);

			List<DataPoint2> dataPoints = new List<DataPoint2>();
			var aux = new Random();
			DateTime dt2 = new DateTime(2021, 06, 16);

			for (int i = 1; i <= 14; i++)
            {
				long today = (long)dt2.AddDays(i - 1).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
				dataPoints.Add(new DataPoint2(today, aux.Next(i*2, 55)));
			}

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}
	}
}