namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRezultatAnalizaModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RezultatAnalizas", "Id", "dbo.Analizas");
            DropForeignKey("dbo.RezultatAnalizas", "Id", "dbo.Pacients");
            DropForeignKey("dbo.RezultatAnalizas", "Id", "dbo.ProgramareAnalizas");
            DropIndex("dbo.RezultatAnalizas", new[] { "Id" });
            DropTable("dbo.RezultatAnalizas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RezultatAnalizas",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PacientId = c.Int(nullable: false),
                        AnalizaId = c.Int(nullable: false),
                        ProgramareAnalizaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.RezultatAnalizas", "Id");
            AddForeignKey("dbo.RezultatAnalizas", "Id", "dbo.ProgramareAnalizas", "Id");
            AddForeignKey("dbo.RezultatAnalizas", "Id", "dbo.Pacients", "Id");
            AddForeignKey("dbo.RezultatAnalizas", "Id", "dbo.Analizas", "Id");
        }
    }
}
