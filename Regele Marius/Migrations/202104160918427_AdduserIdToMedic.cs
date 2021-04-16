namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdduserIdToMedic : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medics", "Id", "dbo.User1");
            DropForeignKey("dbo.RezultatInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics");
            DropIndex("dbo.Medics", new[] { "Id" });
            DropPrimaryKey("dbo.Medics");
            AddColumn("dbo.Medics", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Medics", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Medics", "Id");
            AddForeignKey("dbo.RezultatInterventies", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatInterventies", "MedicId", "dbo.Medics");
            DropPrimaryKey("dbo.Medics");
            AlterColumn("dbo.Medics", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Medics", "UserId");
            AddPrimaryKey("dbo.Medics", "Id");
            CreateIndex("dbo.Medics", "Id");
            AddForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics", "Id");
            AddForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RezultatInterventies", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Medics", "Id", "dbo.User1", "Id");
        }
    }
}
