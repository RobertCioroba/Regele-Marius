using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Interventie : Serviciu
    {
        public string Echipament { get; set; }

        public virtual ICollection<ProgramareInterventie> ProgramariInterventie { get; set; }
    }
}