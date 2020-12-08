using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.ViewModels
{
    public class LoginFormViewModel
    {
        [Required(ErrorMessage = "Nume de utilizator invalid!")]
        [Display(Name = "Nume utilizator")]
        [StringLength(50)]
        [MaxLength(50)]
        public string NumeUtilizator { get; set; }

        [Required(ErrorMessage = "Parola invalida!")]
        [Display(Name = "Parola")]
        [StringLength(20)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Parola { get; set; }
    }
}