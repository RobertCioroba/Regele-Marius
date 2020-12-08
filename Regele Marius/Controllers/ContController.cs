using Regele_Marius.Models;
using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Inregistrare(User user)
        {
            if (!ModelState.IsValid)
                return View("Inregistrare",user);

            if(_context.Users.Where(u => u.Email == user.Email || u.NumeUtilizator == user.NumeUtilizator).Any())
            {
                ModelState.AddModelError("Email", "Adresa de email sau numele de utilizator sunt deja inregistrate!");
                return View("Inregistrare",user);
            }
            _context.Users.Add(user);
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

            var loginUser = _context.Users.Where(u => u.NumeUtilizator == user.NumeUtilizator && u.Parola == user.Parola && u.Activ == true).FirstOrDefault();
            if(loginUser == null)
            {
                ModelState.AddModelError("NumeUtilizator","Nume utilizator sau parola incorecta!");
                return View("Logare", user);
            }
            else
            {
                Session["NumeUtilizator"] = loginUser.NumeUtilizator;
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult Deconectare()
        {
            Session.Abandon();
            return RedirectToAction("Logare");
        }
            
    }
}