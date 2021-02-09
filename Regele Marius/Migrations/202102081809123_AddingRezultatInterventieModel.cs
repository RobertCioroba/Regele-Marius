namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRezultatInterventieModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RezultatInterventies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicId = c.Int(nullable: false),
                        PacientId = c.Int(nullable: false),
                        AnalizaId = c.Int(nullable: false),
                        DataNastere = c.DateTime(nullable: false),
                        NrTelefon = c.Int(nullable: false),
                        Email = c.String(),
                        Adresa = c.String(),
                        Gen = c.Int(nullable: false),
                        Denumire = c.String(),
                        Descriere = c.String(),
                        Pret = c.Int(nullable: false),
                        Echipament = c.String(),
                        Durata = c.String(),
                        Succes = c.Boolean(nullable: false),
                        Interventie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Interventies", t => t.Interventie_Id)
                .ForeignKey("dbo.Medics", t => t.MedicId, cascadeDelete: true)
                .ForeignKey("dbo.Pacients", t => t.PacientId, cascadeDelete: true)
                .Index(t => t.MedicId)
                .Index(t => t.PacientId)
                .Index(t => t.Interventie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RezultatInterventies", "PacientId", "dbo.Pacients");
            DropForeignKey("dbo.RezultatInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatInterventies", "Interventie_Id", "dbo.Interventies");
            DropIndex("dbo.RezultatInterventies", new[] { "Interventie_Id" });
            DropIndex("dbo.RezultatInterventies", new[] { "PacientId" });
            DropIndex("dbo.RezultatInterventies", new[] { "MedicId" });
            DropTable("dbo.RezultatInterventies");
        }
    }
}
