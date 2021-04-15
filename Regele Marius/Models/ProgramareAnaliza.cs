using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public enum Status
    {
        Derulare,
        Finalizat
    }

    public class ProgramareAnaliza
    {
        public enum Sex4
        {
            Masculin, Feminin
        }
        public int Id { get; set; }

        [Required]
        [Display(Name =  "Analiza")]
        public int AnalizaId { get; set; }
        [Required]
        public string Nume { get; set; }
        [Required]
        public string Prenume { get; set; }
        public Status Status { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNastere { get; set; }
        [Required]
        public int NrTelefon { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public Sex4 Gen { get; set; }
        public DateTime? DataProgramare { get; set; }
        [DataType(DataType.Time)]
        public DateTime? OraInceput { get; set; }
        public int RezultatId { get; set; }
        public virtual Analiza Analiza { get; set; }
    }
}