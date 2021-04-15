using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regele_Marius.ViewModels
{
    public class AnalizaFormViewModel
    {
        public Analiza Analiza { get; set; }
        public IEnumerable<Specializare> Specializari { get; set; }
    }
}