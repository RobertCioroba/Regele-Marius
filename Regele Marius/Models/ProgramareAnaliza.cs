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

    public enum Sex
    {
        Masculin, Feminin
    }

    public class ProgramareAnaliza
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Analiza")]
        public int AnalizaId { get; set; }
        [Required]
        public string Nume { get; set; }
        [Required]
        public string Prenume { get; set; }
        public Status Status { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Data nastere")]
        public DateTime DataNastere { get; set; }
        [Required]
        [Display(Name ="Numar telefon")]
        public int NrTelefon { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public Sex Gen { get; set; }
        public DateTime? DataProgramare { get; set; }
        [DataType(DataType.Time)]
        public DateTime? OraInceput { get; set; }
        public int RezultatId { get; set; }
        public string RezultatGuid { get; set; }
        public int? MedicId { get; set; }
        public virtual Analiza Analiza { get; set; }
    }
}