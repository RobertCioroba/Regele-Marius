using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.Controllers
{
    public class SliderController : Controller
    {
        private ContextClinica _context;

        public SliderController()
        {
            _context = new ContextClinica();
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Slider slider, HttpPostedFileBase picture)
        {
            string numeImagine = (picture == null) ? null : System.IO.Path.GetFileName(picture.FileName);

            string imagePath = "~/Uploads/Slider/" + numeImagine;

            picture.SaveAs(Server.MapPath(imagePath));
            slider.Nume = numeImagine;
            slider.Imagine = imagePath;

            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return Content("Imagine salvata cu succes!");
        }

        // GET: Slider
        public ActionResult Index()
        {
            return View();
        }
    }
}