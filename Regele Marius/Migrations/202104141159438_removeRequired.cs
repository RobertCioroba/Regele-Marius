namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medics", "SpecializareId", "dbo.Specializares");
            DropIndex("dbo.Medics", new[] { "SpecializareId" });
            AlterColumn("dbo.Medics", "SpecializareId", c => c.Int());
            CreateIndex("dbo.Medics", "SpecializareId");
            AddForeignKey("dbo.Medics", "SpecializareId", "dbo.Specializares", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medics", "SpecializareId", "dbo.Specializares");
            DropIndex("dbo.Medics", new[] { "SpecializareId" });
            AlterColumn("dbo.Medics", "SpecializareId", c => c.Int(nullable: false));
            CreateIndex("dbo.Medics", "SpecializareId");
            AddForeignKey("dbo.Medics", "SpecializareId", "dbo.Specializares", "Id", cascadeDelete: true);
        }
    }
}
