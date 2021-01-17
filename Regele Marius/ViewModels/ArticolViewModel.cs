using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regele_Marius.ViewModels
{
    public class ArticolViewModel
    {
        public IEnumerable<Articol> Articole { get; set; }
        public IEnumerable<Slider> Slidere { get; set; }
    }
}