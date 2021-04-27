using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regele_Marius.ViewModels
{
    public class ContMedicViewModel
    {
        public Medic Medic { get; set; }
        public User1 User { get; set; }
        public Specializare Specializare { get; set; }
    }
}