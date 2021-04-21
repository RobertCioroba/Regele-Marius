namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ceva : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagramas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.ProgramareAnalizas", "RezultatGuid");
            DropColumn("dbo.RezultatAnalizas", "RezultatGuid");
            DropColumn("dbo.Medics", "ProgramId");
            DropTable("dbo.ProgramMedicis");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProgramMedicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedic = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Medics", "ProgramId", c => c.Int(nullable: false));
            AddColumn("dbo.RezultatAnalizas", "RezultatGuid", c => c.String());
            AddColumn("dbo.ProgramareAnalizas", "RezultatGuid", c => c.String());
            DropTable("dbo.Diagramas");
        }
    }
}
