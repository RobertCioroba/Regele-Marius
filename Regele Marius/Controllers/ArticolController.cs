using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            articol.Titlu = numeImagine;
            articol.Imagine = imagePath;

            _context.Articole.Add(articol);
            _context.SaveChanges();

            return Content("Imagine salvata cu succes!");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}