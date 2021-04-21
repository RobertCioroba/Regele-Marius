using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class ContextClinica : DbContext
    {
        public DbSet<Medic>Medici { get; set; }
        public DbSet<Pacient>Pacienti { get; set; }
        public DbSet<Specializare>Specializari { get; set; }
        public DbSet<Role> Roluri { get; set; }
        public DbSet<User1> Users1 { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Analiza> Analize { get; set; }
        public DbSet<Interventie> Interventii { get; set; }
        public DbSet<Articol> Articole { get; set; }
        public DbSet<ProgramareAnaliza> ProgramariAnaliza { get; set; }
        public DbSet<ProgramareInterventie> ProgramariInterventie { get; set; }
        public DbSet<Calculator> Calculatoare { get; set; }
        public DbSet<RezultatAnaliza> RezultateAnaliza { get; set; }
        public DbSet<RezultatInterventie> RezultateInterventie { get; set; }
        public DbSet<ProgramMedici> ProgramMedicis { get; set; }
        public DbSet<DoamneAjuta> DoamneAjutas { get; set; }
    }
}


