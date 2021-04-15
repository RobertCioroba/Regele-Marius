using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Interventie : Serviciu
    {
        [Required]
        public string Echipament { get; set; }

        public virtual ICollection<ProgramareInterventie> ProgramariInterventie { get; set; }
        public virtual ICollection<RezultatInterventie> RezultateInterventie { get; set; }
    }
}