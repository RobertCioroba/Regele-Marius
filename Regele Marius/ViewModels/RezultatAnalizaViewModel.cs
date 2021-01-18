using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regele_Marius.ViewModels
{
    public class RezultatAnalizaViewModel
    {
        public virtual Medic Medic { get; set; }
        public virtual Pacient Pacient { get; set; }
        public virtual Analiza Analiza { get; set; }
        public virtual ProgramareAnaliza ProgramareAnaliza { get; set; }
    }
} 