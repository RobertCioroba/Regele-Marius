using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string TipAnaliza { get; set; }

        [DataType(DataType.Date)]
        public DateTime OraInceput { get; set; }
        [DataType(DataType.Date)]
        public DateTime OraFinal { get; set; }
    }
}