using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class ProgramareAnaliza
    {
        public enum Sex4
        {
            Masculin, Feminin
        }
        public int Id { get; set; }

        [Display(Name =  "Analiza")]
        public int AnalizaId { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNastere { get; set; }
        public int NrTelefon { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public Sex4 Gen { get; set; }
        public DateTime? DataProgramare { get; set; }
        [DataType(DataType.Time)]
        public DateTime? OraInceput { get; set; }

        public virtual Analiza Analiza { get; set; }
    }
}