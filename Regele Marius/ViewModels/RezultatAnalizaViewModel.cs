using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.ViewModels
{
    public class RezultatAnalizaViewModel
    {
        public RezultatAnaliza RezultatAnaliza { get; set; }
        public IEnumerable<Medic> Medici { get; set; }
        public IEnumerable<Analiza> Analize { get; set; }
        public IEnumerable<Pacient> Pacienti { get; set; }
    }
} 