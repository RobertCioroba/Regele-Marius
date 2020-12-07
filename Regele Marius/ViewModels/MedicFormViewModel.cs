using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Regele_Marius.ViewModels
{
    public class MedicFormViewModel
    {
        public Medic Medic { get; set; }
        public IEnumerable<Specializare> Specializari { get; set; }

      
    }
}