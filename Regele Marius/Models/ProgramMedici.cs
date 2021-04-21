using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class ProgramMedici
    {
        public int Id { get; set; }
        public int[] Luni { get; set; }
        public int[] Marti { get; set; }
        public int[] Miercuri { get; set; }
        public int[] Joi { get; set; }
        public int[] Vineri { get; set; }
        public int IdMedic { get; set; }
    }
}