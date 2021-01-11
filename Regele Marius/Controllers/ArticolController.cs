using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.Controllers
{
    public class ArticolController : Controller
    {
        private ContextClinica _context;

        public ArticolController()
        {
            _context = new ContextClinica();
        }

        // GET: Articol
        public ActionResult Index()
        {
            var articole = _context.Articole.ToList();
            return View(articole);
        }

        public ActionResult Create()
        {
            return View(new Articol { Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(Articol articol, HttpPostedFileBase picture)
        {
            string numeImagine = (picture == null) ? null : System.IO.Path.GetFileName(picture.FileName);

            string imagePath = "~/Uploads/Articole/" + numeImagine;

            picture.SaveAs(Server.MapPath(imagePath));
            articol.Nume = numeImagine;
            articol.Imagine = imagePath;

            _context.Articole.Add(articol);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var articol = _context.Articole.SingleOrDefault(c => c.Id == id);

            if (articol == null)
                return HttpNotFound();
            _context.Articole.Remove(articol);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var articol = _context.Articole.SingleOrDefault(c => c.Id == id);
            if (articol == null)
                return HttpNotFound();

            return View("Create", articol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}