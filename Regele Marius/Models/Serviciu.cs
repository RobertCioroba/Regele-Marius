using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Serviciu
    {
        public int Id { get; set; }
        [Required]
        public string Denumire { get; set; }
        [Required]
        public string Descriere { get; set; }
        [Required]
        public int Pret { get; set; }
    }
}