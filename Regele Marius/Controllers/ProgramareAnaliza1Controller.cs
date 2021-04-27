using Regele_Marius.Models;
using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using CaptchaMvc.HtmlHelpers;
using PagedList;
using System.Net.Mail;
using Regele_Marius.Resources;
using System.Threading.Tasks;

namespace Regele_Marius.Controllers
{
    public class ProgramareAnaliza1Controller : Controller
    {
        private ContextClinica _context;

        public ProgramareAnaliza1Controller()
        {
            _context = new ContextClinica();
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


        public ActionResult Create()
        {
            var _analize = _context.Analize.ToList();
            var _medici = _context.Medici.ToList();


            var viewModel = new ProgramareAnalizaViewModel
            {
                ProgramareAnaliza = new ProgramareAnaliza(),
                Analize = _analize,
                Medici = _medici
            };

            return View(viewModel);
        }

        //verific daca in ziua data este suficient loc pentru noua programare
        public string[] VerificareZi(string[] ziPentruVerificare, int durataAnaliza,int idPacient)
        {
            int i = 0, gasit = 0, startInterval = 0, finalInterval = 0, lungimeInterval = 0;
            while (i < (ziPentruVerificare.Length - 2) && gasit == 0)
            {
                if (ziPentruVerificare[i] == "job")
                {
                    if (lungimeInterval == 0)
                    {
                        startInterval = i;
                        i++;
                        lungimeInterval++;
                    }
                    else
                    {
                        lungimeInterval++;
                        i++;
                    }
                    if (lungimeInterval == durataAnaliza)
                    {
                        gasit = 1;
                        finalInterval = i - 1;
                    }
                }
                else
                {
                    lungimeInterval = 0;
                    i++;
                }
            }

            if (gasit == 1)
            {
                for (i = startInterval; i <= finalInterval; i++)
                    ziPentruVerificare[i] = idPacient.ToString();
                ziPentruVerificare[25] = "gasit";
            }
            return ziPentruVerificare;
        }

        public string TransformareDinVectorInString(string[] vector)
        {
            string sir = null;
            vector[25] = null;
            for(int i = 0; i <= 25; i++)
                sir = sir + vector[i] + ",";
      
            return sir;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Create(ProgramareAnaliza programareAnaliza)
        {
            if(ModelState.IsValid)
                if (this.IsCaptchaValid("Captcha is not valid"))
                {
                    RezultatAnaliza rezultat = new RezultatAnaliza();
                    _context.RezultateAnaliza.Add(rezultat);
                    _context.SaveChanges();
                    programareAnaliza.RezultatId = rezultat.Id;

                    List<Medic> medici = _context.Medici.ToList();
                    List<Medic> mediciEligibili = new List<Medic>();
                    List<Analiza> analize = _context.Analize.ToList();
                    List<Program> programs = _context.Programs.ToList();

                    var analiza = _context.Analize.SingleOrDefault(c => c.Id == programareAnaliza.AnalizaId);
                    var specializareAnaliza = _context.Specializari.SingleOrDefault(c => c.Id == analiza.SpecializareId);

                    //caut medicii care au specializarea analizei cerute
                    foreach (var medic in medici)
                    {
                        var specializareMedic = _context.Specializari.SingleOrDefault(c => c.Id == medic.SpecializareId);

                        if (specializareMedic == specializareAnaliza)
                            mediciEligibili.Add(medic);
                    }

                    //preiau lungimea programarii
                    var durataAnaliza = analiza.Durata;
                    int durata = 0;
                    switch(analiza.Durata)
                    {
                        case Durata.JumatateDeOra:
                            durata = 1;
                            break;
                        case Durata.Ora:
                            durata = 2;
                            break;
                        case Durata.Ora30:
                            durata = 3;
                            break;
                        case Durata.DouaOre:
                            durata = 4;
                            break;
                        default:
                            break;
                    }


                    string[] sirAuxiliar = null;
                    bool gasit = false;

                    _context.ProgramariAnaliza.Add(programareAnaliza);
                    _context.SaveChanges();

                    while (gasit == false)
                    {
                        foreach (var medic in mediciEligibili)
                        {
                            Program program = _context.Programs.SingleOrDefault(c => c.Id == medic.ProgramId);
                            string[] programLuni = program.Luni.Split(',');
                            sirAuxiliar = VerificareZi(programLuni, durata, programareAnaliza.Id);
                            if (sirAuxiliar[25] == "gasit")
                            {
                                program.Luni = TransformareDinVectorInString(sirAuxiliar);
                                programareAnaliza.DataProgramare = program.Data;
                                programareAnaliza.MedicId = medic.Id;
                                gasit = true;
                                break;
                            }
                        }

                        if(gasit == false)
                        {
                            foreach (var medic in mediciEligibili)
                            {
                                Program program = _context.Programs.SingleOrDefault(c => c.Id == medic.ProgramId);
                                string[] programMarti = program.Marti.Split(',');
                                sirAuxiliar = VerificareZi(programMarti, durata, programareAnaliza.Id);
                                if (sirAuxiliar[25] == "gasit")
                                {
                                    program.Marti = TransformareDinVectorInString(sirAuxiliar);
                                    programareAnaliza.MedicId = medic.Id;
                                    DateTime data = program.Data.Value;
                                    data = data.AddDays(1);
                                    programareAnaliza.DataProgramare = data;
                                    gasit = true;
                                    break;
                                }
                            }
                        }

                        if(gasit == false)
                        {
                            foreach (var medic in mediciEligibili)
                            {
                                Program program = _context.Programs.SingleOrDefault(c => c.Id == medic.ProgramId);
                                string[] programMiercuri = program.Luni.Split(',');
                                sirAuxiliar = VerificareZi(programMiercuri, durata, programareAnaliza.Id);
                                if (sirAuxiliar[25] == "gasit")
                                {
                                    program.Miercuri = TransformareDinVectorInString(sirAuxiliar);
                                    programareAnaliza.MedicId = medic.Id;
                                    DateTime data = program.Data.Value;
                                    data = data.AddDays(2);
                                    programareAnaliza.DataProgramare = data;
                                    gasit = true;
                                    break;
                                }
                            }
                        }

                        if(gasit == false)
                        {
                            foreach (var medic in mediciEligibili)
                            {
                                Program program = _context.Programs.SingleOrDefault(c => c.Id == medic.ProgramId);
                                string[] programJoi = program.Joi.Split(',');
                                sirAuxiliar = VerificareZi(programJoi, durata, programareAnaliza.Id);
                                if (sirAuxiliar[25] == "gasit")
                                {
                                    program.Joi = TransformareDinVectorInString(sirAuxiliar);
                                    programareAnaliza.MedicId = medic.Id;
                                    DateTime data = program.Data.Value;
                                    data = data.AddDays(3);
                                    programareAnaliza.DataProgramare = data;
                                    gasit = true;
                                    break;
                                }
                            }
                        }

                        if(gasit == false)
                        {
                            foreach (var medic in mediciEligibili)
                            {
                                Program program = _context.Programs.SingleOrDefault(c => c.Id == medic.ProgramId);
                                string[] programVineri = program.Vineri.Split(',');
                                sirAuxiliar = VerificareZi(programVineri, durata, programareAnaliza.Id);
                                if (sirAuxiliar[25] == "gasit")
                                {
                                    program.Vineri = TransformareDinVectorInString(sirAuxiliar);
                                    programareAnaliza.MedicId = medic.Id;
                                    DateTime data = program.Data.Value;
                                    data = data.AddDays(4);
                                    programareAnaliza.DataProgramare = data;
                                    gasit = true;
                                    break;
                                }
                            }
                        }
                    }
                    int oraInceput = -1, oraFinal = -1;
                    for (int i = 0; i < 24; i++)
                    {
                        if (sirAuxiliar[i] == programareAnaliza.Id.ToString())
                        {
                            if (oraInceput == -1)
                            {
                                oraInceput = i;
                                oraFinal = i;
                            }
                            else
                                oraFinal++;
                        }
                    }
                    oraFinal++;
                    programareAnaliza.OraInceput = ((oraInceput / 2) + 8).ToString();
                    programareAnaliza.OraFinal = ((oraFinal / 2) + 8).ToString();
                    if (oraInceput % 2 == 0)
                        programareAnaliza.OraInceput += ":00";
                    else
                        programareAnaliza.OraInceput += ":30";

                    if (oraFinal % 2 == 0)
                        programareAnaliza.OraFinal += ":00";
                    else
                        programareAnaliza.OraFinal += ":30";

                    programareAnaliza.Status = Status.Derulare;
                    _context.SaveChanges();
                    string emailMsg = "Salut, <br /><br /> Ai finalizat cu succes programarea la clinica noastra! Te asteptam " + " alaturi de actul tau de identitate. </b> <br /><br /> O zi frumoasa! <br />Echipa Regele Marius";
                    string emailSubject = EmailInfo.EMAIL_SUBJECT_DEFAULT + " Programare";

                    await this.SendEmailAsync(programareAnaliza.Email, emailMsg, emailSubject);
                    return RedirectToAction("Details",new { id = programareAnaliza.Id });
                }
            ViewBag.ErrMessage = "Error: captcha is not valid.";
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ProgramareAnaliza programare = _context.ProgramariAnaliza.Find(id);
            Medic medic = _context.Medici.Find(programare.MedicId);
            Analiza analiza = _context.Analize.Find(programare.AnalizaId);

            if (programare == null)
                return HttpNotFound();
            var viewModel = new SumarProgramareViewModel
            {
                ProgramareAnaliza = programare,
                Medic = medic,
                Analiza = analiza

            };

            return View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var programareAnaliza = _context.ProgramariAnaliza.SingleOrDefault(c => c.Id == id);

            if (programareAnaliza == null)
                return HttpNotFound();

            return View(programareAnaliza);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgramareAnaliza programare = _context.ProgramariAnaliza.Find(id);
            _context.ProgramariAnaliza.Remove(programare);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var _programareAnaliza = _context.ProgramariAnaliza.SingleOrDefault(p => p.Id == id);
            if (_programareAnaliza == null)
                return HttpNotFound();

            var viewModel = new ProgramareAnalizaViewModel
            {
                ProgramareAnaliza = _programareAnaliza,
                Medici = _context.Medici.ToList(),
                Analize = _context.Analize.ToList()
            };

            return View("Create", viewModel);
        }

        public ActionResult Index(string sortOrder, string currentFilter2, string searchString2, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.DateSortParm2 = sortOrder == "Date2" ? "date_desc2" : "Date2";
            ViewBag.DateSortParm3 = sortOrder == "Date3" ? "date_desc3" : "Date3";
            if (searchString2 != null)
            {
                page = 1;
            }
            else
            {
                searchString2 = currentFilter2;
            }

            ViewBag.CurrentFilter2 = searchString2;

            var programari = _context.ProgramariAnaliza.Include(t => t.Analiza);

            if (!String.IsNullOrEmpty(searchString2))
            {
                programari = programari.Where(s => s.Nume.Contains(searchString2) ||
                             s.Prenume.Contains(searchString2));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    programari = programari.OrderByDescending(s => s.Analiza.Denumire);
                    break;
                case "Date":
                    programari = programari.OrderBy(s => s.Nume);
                    break;
                case "date_desc":
                    programari = programari.OrderByDescending(s => s.Nume);
                    break;
                case "Date2":
                    programari = programari.OrderBy(s => s.Prenume);
                    break;
                case "date_desc2":
                    programari = programari.OrderByDescending(s => s.Prenume);
                    break;
                case "Date3":
                    programari = programari.OrderBy(s => s.Status);
                    break;
                case "date_desc3":
                    programari = programari.OrderByDescending(s => s.Status);
                    break;
                default:
                    programari = programari.OrderBy(s => s.Analiza.Denumire);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(programari.ToPagedList(pageNumber, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}