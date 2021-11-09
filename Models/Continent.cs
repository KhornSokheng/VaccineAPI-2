using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VaccineAPI2.Models
{
    public class Continent
    {
        public int ContinentID { get; set; }
        public string ContinentName { get; set; }
    }
    public class ContinentDBContext : DbContext
    {
        public DbSet<Continent> Continents { get; set; }
    }
}