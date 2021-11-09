using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VaccineAPI2.Models
{
    public class Vaccination
    {
        public int VaccinationID { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
        public int VaccineID { get; set; }
        public Vaccine Vaccine { get; set; }
        public int FirstDose { get; set; }
        public int SecondDose { get; set; }
        public double Percentage { get; set; }

    }
    public class VaccinationDBContext : DbContext
    {
        public DbSet<Vaccination> Vaccination { get; set; }
    }
}