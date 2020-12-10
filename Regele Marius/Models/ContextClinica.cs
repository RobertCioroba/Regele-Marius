using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class ContextClinica : DbContext
    {
        public DbSet<Utilizator>Utilizatori { get; set; }
        public DbSet<Medic>Medici { get; set; }
        public DbSet<Pacient>Pacienti { get; set; }
        public DbSet<Specializare>Specializari { get; set; }
        public DbSet<Role> Roluri { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}


