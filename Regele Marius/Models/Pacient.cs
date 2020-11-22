using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Pacient : Utilizator
    {
        [DataType(DataType.Date)]
        public DateTime DataNastere { get; set; }
        public int NrTelefon { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Sex { get; set; }
    }
}