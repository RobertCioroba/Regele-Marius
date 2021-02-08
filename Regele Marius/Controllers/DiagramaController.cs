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
        // GET: Diagrama
        public ActionResult Index()
        {

            List<Diagrama> dataPoints = new List<Diagrama>();

            dataPoints.Add(new Diagrama("NXP", 14));
            dataPoints.Add(new Diagrama("Infineon", 10));
            dataPoints.Add(new Diagrama("Renesas", 9));
            dataPoints.Add(new Diagrama("STMicroelectronics", 8));
            dataPoints.Add(new Diagrama("Texas Instruments", 7));
            dataPoints.Add(new Diagrama("Bosch", 5));
            dataPoints.Add(new Diagrama("ON Semiconductor", 4));
            dataPoints.Add(new Diagrama("Toshiba", 3));
            dataPoints.Add(new Diagrama("Micron", 3));
            dataPoints.Add(new Diagrama("Osram", 2));
            dataPoints.Add(new Diagrama("Others", 35));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }
    }
}