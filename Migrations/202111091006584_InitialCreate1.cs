namespace VaccineAPI2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vaccinations",
                c => new
                    {
                        VaccinationID = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(nullable: false),
                        VaccineID = c.Int(nullable: false),
                        FirstDose = c.Int(nullable: false),
                        SecondDose = c.Int(nullable: false),
                        Percentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.VaccinationID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .ForeignKey("dbo.Vaccines", t => t.VaccineID, cascadeDelete: true)
                .Index(t => t.CountryID)
                .Index(t => t.VaccineID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vaccinations", "VaccineID", "dbo.Vaccines");
            DropForeignKey("dbo.Vaccinations", "CountryID", "dbo.Countries");
            DropIndex("dbo.Vaccinations", new[] { "VaccineID" });
            DropIndex("dbo.Vaccinations", new[] { "CountryID" });
            DropTable("dbo.Vaccinations");
        }
    }
}
