using Regele_Marius.Models;
using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Mail;
using Regele_Marius.Resources;

namespace Regele_Marius.Controllers
{
    public class RezultatAnalizaController : Controller
    {
        private ContextClinica _context;

        public RezultatAnalizaController()
        {
            _context = new ContextClinica();
        }

        public ActionResult GeneratePDF(string id)
        {
            var report = new Rotativa.ActionAsPdf("Details", new { id = id });
            return report;
        }

        public async Task<bool> SendEmailAsync(string email, string msg, string subject = "")
        {
            bool isSend = false;

            try
            {
                var body = msg;
                var message = new MailMessage();

                message.To.Add(new MailAddress(email));
                message.From = new MailAddress(EmailInfo.FROM_EMAIL_ACCOUNT);
                message.Subject = !string.IsNullOrEmpty(subject) ? subject : EmailInfo.EMAIL_SUBJECT_DEFAULT;
                message.Body = body;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = EmailInfo.FROM_EMAIL_ACCOUNT,
                        Password = EmailInfo.FROM_EMAIL_PASSWORD
                    };
                    smtp.Credentials = credential;
                    smtp.Host = EmailInfo.SMTP_HOST_GMAIL;
                    smtp.Port = Convert.ToInt32(EmailInfo.SMTP_PORT_GMAIL);
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(message);

                    isSend = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSend;
        }


        public ActionResult Create(int id)
        {
            ProgramareAnaliza programare = _context.ProgramariAnaliza.Find(id);
            Analiza analiza = _context.Analize.Find(programare.AnalizaId);
            RezultatAnaliza rezultat = new RezultatAnaliza();
            rezultat.AnalizaId = programare.AnalizaId;
            rezultat.DataNastere = programare.DataNastere;
            rezultat.Denumire = analiza.Denumire;
            rezultat.Descriere = analiza.Descriere;
            rezultat.Email = programare.Email;
            rezultat.MedicId = programare.MedicId;
            rezultat.NrTelefon = programare.NrTelefon;
            rezultat.Pret = analiza.Pret;
            rezultat.Gen = programare.Gen;
            rezultat.NumePacient = programare.Nume;
            rezultat.PrenumePacient = programare.Prenume;
            programare.Status = Status.Finalizat;
            var Rezultat = new RezultatAnalizaCreateViewModel
            {
                RezultatAnaliza = rezultat,
                ProgramareAnaliza = programare,
                Analiza = analiza
            };
            /*            PropertyInfo[] props = typeof(Analiza).GetProperties();

                        var justBools = new List<string>();

                        foreach(PropertyInfo prop in props)
                        {
                            if (prop.PropertyType.ToString() == "System.Boolean")
                            {
                                justBools.Add(prop.Name);
                            }
                        }

                        foreach (var boolulet in justBools)
                        {
                            Debug.WriteLine(boolulet);
                        }*/
            return View(Rezultat);
        }

        [HttpPost]
        public async Task<ActionResult> Create(RezultatAnaliza rezultatAnaliza)
        {
            // rezultatAnaliza.ProgramareAnaliza = programareAnaliza.Id;
            if(ModelState.IsValid)
            {
                string idProgramare = null;
                if (TempData.ContainsKey("idProgramare"))
                {
                    idProgramare = TempData["idProgramare"].ToString();
                    int programareId = Convert.ToInt32(idProgramare);
                    ProgramareAnaliza programare = _context.ProgramariAnaliza.Find(programareId);
                    Analiza analiza = _context.Analize.Find(programare.AnalizaId);
                    rezultatAnaliza.AnalizaId = programare.AnalizaId;
                    rezultatAnaliza.DataNastere = programare.DataNastere;
                    rezultatAnaliza.Denumire = analiza.Denumire;
                    rezultatAnaliza.Descriere = analiza.Descriere;
                    rezultatAnaliza.Email = programare.Email;
                    rezultatAnaliza.MedicId = programare.MedicId;
                    rezultatAnaliza.NrTelefon = programare.NrTelefon;
                    rezultatAnaliza.Pret = analiza.Pret;
                    rezultatAnaliza.Gen = programare.Gen;
                    rezultatAnaliza.NumePacient = programare.Nume;
                    rezultatAnaliza.PrenumePacient = programare.Prenume;
                    rezultatAnaliza.ProgramareAnalizaId = programareId;
                    programare.Status = Status.Finalizat;
                    _context.RezultateAnaliza.Add(rezultatAnaliza);
                    _context.SaveChanges();
                    programare.RezultatId = rezultatAnaliza.Id;
                    Guid guidRezultat = Guid.NewGuid();
                    programare.RezultatGuid = guidRezultat.ToString();
                    rezultatAnaliza.RezultatGuid = guidRezultat.ToString();
                    _context.SaveChanges();

                    string emailMsg = "Salut, <br /><br /> Avem vesti bune! Analizele tale tocmai au fost finalizate. Poti vedea rezultatele accesand link-ul de mai jos: </br> http://localhost:63610/RezultatAnaliza/Details/" + rezultatAnaliza.RezultatGuid + " </b> <br /><br /> O zi frumoasa! <br />Echipa Regele Marius";
                    string emailSubject = EmailInfo.EMAIL_SUBJECT_DEFAULT + " Rezultate analize";

                    await this.SendEmailAsync(rezultatAnaliza.Email, emailMsg, emailSubject);
                }
                return RedirectToAction("Programari","Medic", new { id = rezultatAnaliza.MedicId}); 
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var _rezultatAnaliza = _context.RezultateAnaliza.SingleOrDefault(p => p.Id == id);
            if (_rezultatAnaliza == null)
                return HttpNotFound();

            var viewModel = new RezultatAnalizaViewModel
            {
                RezultatAnaliza = _rezultatAnaliza,
                Medici = _context.Medici.ToList(),
                Analize = _context.Analize.ToList(),
                Pacienti = _context.Pacienti.ToList()
            };

            return View("Create", viewModel);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RezultatAnaliza rezultatAnaliza = _context.RezultateAnaliza.First(x => x.RezultatGuid == id);
            Medic medic = _context.Medici.Find(rezultatAnaliza.MedicId);
            Analiza analiza = _context.Analize.Find(rezultatAnaliza.AnalizaId);
            if (rezultatAnaliza == null)
            {
                return HttpNotFound();
            }

            var viewModel = new RezultatViewModel
            {
                RezultatAnaliza = rezultatAnaliza,
                Medic = medic,
                Analiza = analiza
            };
            return View(viewModel);
        }

        public ActionResult Index()
        {
            var rezultateAnaliza = _context.RezultateAnaliza.Include(c => c.Pacient).ToList();
            return View(rezultateAnaliza);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var rezultatAnaliza = _context.RezultateAnaliza.SingleOrDefault(c => c.Id == id);

            if (rezultatAnaliza == null)
                return HttpNotFound();
            return View(rezultatAnaliza);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RezultatAnaliza rezultat = _context.RezultateAnaliza.Find(id);
            _context.RezultateAnaliza.Remove(rezultat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}