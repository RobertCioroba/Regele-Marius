﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Utilizator
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

    }
}