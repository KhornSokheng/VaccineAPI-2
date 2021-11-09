using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VaccineAPI2.Data
{
    public class VaccineAPI2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VaccineAPI2Context() : base("name=VaccineAPI2Context")
        {
        }

        public System.Data.Entity.DbSet<VaccineAPI2.Models.Vaccine> Vaccines { get; set; }

        public System.Data.Entity.DbSet<VaccineAPI2.Models.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<VaccineAPI2.Models.Continent> Continents { get; set; }

        public System.Data.Entity.DbSet<VaccineAPI2.Models.Vaccination> Vaccinations { get; set; }
    }
}
