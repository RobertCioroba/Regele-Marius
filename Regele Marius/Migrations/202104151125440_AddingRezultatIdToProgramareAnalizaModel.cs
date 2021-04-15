namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRezultatIdToProgramareAnalizaModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RezultatAnalizas", "Id", "dbo.ProgramareAnalizas");
            DropIndex("dbo.RezultatAnalizas", new[] { "Id" });
            DropPrimaryKey("dbo.RezultatAnalizas");
            AddColumn("dbo.ProgramareAnalizas", "RezultatId", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RezultatAnalizas", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RezultatAnalizas");
            AlterColumn("dbo.RezultatAnalizas", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.ProgramareAnalizas", "RezultatId");
            AddPrimaryKey("dbo.RezultatAnalizas", "Id");
            CreateIndex("dbo.RezultatAnalizas", "Id");
            AddForeignKey("dbo.RezultatAnalizas", "Id", "dbo.ProgramareAnalizas", "Id");
        }
    }
}
