﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EnDataBase
{
    public class ThreatLevelMidnightEntertainmentDBContext : DbContext
    {
        public DbSet<Genero> Generos { get; set; }

        public ThreatLevelMidnightEntertainmentDBContext() : base("ThreatLevelMidnightEntertainmentDB")
        {
        }
    }
}