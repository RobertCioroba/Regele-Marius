using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.ViewModels
{
    public class EmailNotificareViewModel
    {
        [Required]
        [Display(Name ="Catre")]
        public string ToEmail { get; set; }
    }
}