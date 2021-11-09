namespace VaccineAPI2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vaccines",
                c => new
                    {
                        VaccineID = c.Int(nullable: false, identity: true),
                        VaccineName = c.String(),
                        OriginCountry = c.String(),
                        Description = c.String(),
                        Country_CountryID = c.Int(),
                    })
                .PrimaryKey(t => t.VaccineID)
                .ForeignKey("dbo.Countries", t => t.Country_CountryID)
                .Index(t => t.Country_CountryID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        Population = c.Int(nullable: false),
                        ContinentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryID)
                .ForeignKey("dbo.Continents", t => t.ContinentID, cascadeDelete: true)
                .Index(t => t.ContinentID);
            
            CreateTable(
                "dbo.Continents",
                c => new
                    {
                        ContinentID = c.Int(nullable: false, identity: true),
                        ContinentName = c.String(),
                    })
                .PrimaryKey(t => t.ContinentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vaccines", "Country_CountryID", "dbo.Countries");
            DropForeignKey("dbo.Countries", "ContinentID", "dbo.Continents");
            DropIndex("dbo.Countries", new[] { "ContinentID" });
            DropIndex("dbo.Vaccines", new[] { "Country_CountryID" });
            DropTable("dbo.Continents");
            DropTable("dbo.Countries");
            DropTable("dbo.Vaccines");
        }
    }
}
