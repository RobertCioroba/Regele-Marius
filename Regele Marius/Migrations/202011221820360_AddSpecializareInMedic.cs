namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecializareInMedic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specializares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Utilizators", "SpecializareId", c => c.Int());
            CreateIndex("dbo.Utilizators", "SpecializareId");
            AddForeignKey("dbo.Utilizators", "SpecializareId", "dbo.Specializares", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Utilizators", "SpecializareId", "dbo.Specializares");
            DropIndex("dbo.Utilizators", new[] { "SpecializareId" });
            DropColumn("dbo.Utilizators", "SpecializareId");
            DropTable("dbo.Specializares");
        }
    }
}
