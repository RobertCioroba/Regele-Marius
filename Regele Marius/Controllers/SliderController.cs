using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            return RedirectToAction("Index");
        }

        // GET: Slider
        public ActionResult Index()
        {
            var slidere = _context.Sliders.ToList();
            return View(slidere);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var slider = _context.Sliders.SingleOrDefault(c => c.Id == id);

            if (slider == null)
                return HttpNotFound();

            return View(slider);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var slider = _context.Sliders.SingleOrDefault(c => c.Id == id);
            if (slider == null)
                return HttpNotFound();

            return View("Create", slider);
        }
    }
}