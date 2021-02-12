namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDiagramaModelInContext : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Diagramas");
        }
    }
}
