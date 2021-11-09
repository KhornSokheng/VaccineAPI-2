using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VaccineAPI2.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public int Population { get; set; }
        public int ContinentID { get; set; }
        public Continent Continent { get; set; }
    }
    public class CountryDBContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
    }
}