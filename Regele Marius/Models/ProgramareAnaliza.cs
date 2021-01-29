using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class ProgramareAnaliza
    {
        public int Id { get; set; }
        [Display(Name =  "Nume Medic")]
        public int MedicId { get; set; }
        public int PacientId { get; set; }
        [Display(Name =  "Analiza")]
        public int AnalizaId { get; set; }
        public DateTime DataProgramare { get; set; }
        [DataType(DataType.Time)]
        public DateTime OraInceput { get; set; }

        public Medic Medic { get; set; }
        public Analiza Analiza { get; set; }
    }
}