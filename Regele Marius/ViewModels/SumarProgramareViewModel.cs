﻿using Regele_Marius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regele_Marius.ViewModels
{
    public class SumarProgramareViewModel
    {
        public ProgramareAnaliza ProgramareAnaliza { get; set; }
        public Medic Medic { get; set; }
        public Analiza Analiza { get; set; }
    }
}