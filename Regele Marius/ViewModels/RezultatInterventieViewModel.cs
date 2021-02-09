using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regele_Marius.ViewModels
{
    public class RezultatInterventieViewModel
    {
        public RezultatInterventie RezultatInterventie { get; set; }
        public IEnumerable<Medic> Medici { get; set; }
        public IEnumerable<Interventie> Interventii { get; set; }
        public IEnumerable<Pacient> Pacienti { get; set; }
    }
}