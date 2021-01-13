using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Regele_Marius.Models;

namespace Regele_Marius.ViewModels
{
    public class ProgramareAnalizaViewModel
    {
        public ProgramareAnaliza ProgramareAnaliza { get; set; }
        public IEnumerable<Medic> Medici { get; set; }
        public IEnumerable<Analiza> Analize { get; set; }
    }
}