using Regele_Marius.Models;
using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.Controllers
{
    public class ContController : Controller
    {
        private ContextClinica _context;

        public ContController()
        {
            _context = new ContextClinica();
        }

        public ActionResult Inregistrare()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inregistrare(User1 user)
        {
            if (!ModelState.IsValid)
                return View("Inregistrare",user);

            if(_context.Users1.Where(u => u.Email == user.Email || u.NumeUtilizator == user.NumeUtilizator).Any())
            {
                ModelState.AddModelError("Email", "Adresa de email sau numele de utilizator sunt deja inregistrate!");
                return View("Inregistrare",user);
            }
            _context.Users1.Add(user);
            _context.SaveChanges();
            return Content("Utilizator salvat cu succes!");
        }

        public ActionResult Logare()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logare(LoginFormViewModel user)
        {
            if (!ModelState.IsValid)
                return View("Logare", user);

            var loginUser = _context.Users1.Where(u => u.NumeUtilizator == user.NumeUtilizator && u.Parola == user.Parola).FirstOrDefault();
            if(loginUser == null)
            {
                ModelState.AddModelError("NumeUtilizator","Nume utilizator sau parola incorecta!");
                return View("Logare", user);
            }
            else
            {
                Session["NumeUtilizator"] = loginUser.NumeUtilizator;
                Session["Activ"] = loginUser.Activ;
                Session["Id"] = loginUser.Id;
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult Index()
        {
            var utilizatori = _context.Users1.ToList();
            return View(utilizatori);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User1 user = _context.Users1.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User1 user = _context.Users1.Find(id);
            _context.Users1.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deconectare()
        {
            Session.Abandon();
            return RedirectToAction("Logare");
        }
            
    }
}