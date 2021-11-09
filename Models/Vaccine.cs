using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VaccineAPI2.Models
{
    public class Vaccine
    {
        public int VaccineID { get; set; }
        public string VaccineName { get; set; }
        public string OriginCountry { get; set; }
        public Country Country { get; set; }
        public string Description { get; set; }
    }
    public class VaccineDBContext : DbContext
    {
        public DbSet<Vaccine> Vaccines { get; set; }
    }
}