using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Pacient : Utilizator
    {
        public enum Sex1
        {
            Masculin, Feminin
        }
        [DataType(DataType.Date)]
        public DateTime DataNastere { get; set; }
        public int NrTelefon { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public Sex1 Gen { get; set; }

        public virtual ICollection<RezultatAnaliza> RezultateAnaliza { get; set; }
        public virtual ICollection<RezultatInterventie> RezultateInterventie { get; set; }
    }
}