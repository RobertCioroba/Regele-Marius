namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSpecializareFieldToAnalizaModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Analizas", "SpecializareId", c => c.Int());
            CreateIndex("dbo.Analizas", "SpecializareId");
            AddForeignKey("dbo.Analizas", "SpecializareId", "dbo.Specializares", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Analizas", "SpecializareId", "dbo.Specializares");
            DropIndex("dbo.Analizas", new[] { "SpecializareId" });
            DropColumn("dbo.Analizas", "SpecializareId");
        }
    }
}
