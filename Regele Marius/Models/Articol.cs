using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Articol
    {
        public int Id { get; set; }
        [Required]
        public string Nume { get; set; }
        [Required]
        public string Titlu { get; set; }
        [Required]
        public string Imagine { get; set; }
        [Required]
        public string Descriere { get; set; }
    }
}