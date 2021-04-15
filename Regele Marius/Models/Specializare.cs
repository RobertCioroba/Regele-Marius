using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Specializare
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Specializare")]
        public string Nume { get; set; }

    }
}