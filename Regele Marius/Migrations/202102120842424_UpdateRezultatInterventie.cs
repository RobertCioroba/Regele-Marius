namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRezultatInterventie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RezultatInterventies", "Interventie_Id", "dbo.Interventies");
            DropIndex("dbo.RezultatInterventies", new[] { "Interventie_Id" });
            RenameColumn(table: "dbo.RezultatInterventies", name: "Interventie_Id", newName: "InterventieId");
            AlterColumn("dbo.RezultatInterventies", "InterventieId", c => c.Int(nullable: false));
            CreateIndex("dbo.RezultatInterventies", "InterventieId");
            AddForeignKey("dbo.RezultatInterventies", "InterventieId", "dbo.Interventies", "Id", cascadeDelete: true);
            DropColumn("dbo.RezultatInterventies", "AnalizaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RezultatInterventies", "AnalizaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RezultatInterventies", "InterventieId", "dbo.Interventies");
            DropIndex("dbo.RezultatInterventies", new[] { "InterventieId" });
            AlterColumn("dbo.RezultatInterventies", "InterventieId", c => c.Int());
            RenameColumn(table: "dbo.RezultatInterventies", name: "InterventieId", newName: "Interventie_Id");
            CreateIndex("dbo.RezultatInterventies", "Interventie_Id");
            AddForeignKey("dbo.RezultatInterventies", "Interventie_Id", "dbo.Interventies", "Id");
        }
    }
}
