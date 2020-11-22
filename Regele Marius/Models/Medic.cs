using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Medic : Utilizator
    {
        public int SpecializareId { get; set; }
        public Specializare Specializare { get; set; }
        public int ProgramId { get; set; }
    }
}