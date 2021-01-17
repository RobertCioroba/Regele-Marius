namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCalculatorEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calculators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gen = c.Int(),
                        Varsta = c.Int(nullable: false),
                        Inaltime = c.Int(nullable: false),
                        Gat = c.Int(nullable: false),
                        Talie = c.Int(nullable: false),
                        Sold = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Calculators");
        }
    }
}
