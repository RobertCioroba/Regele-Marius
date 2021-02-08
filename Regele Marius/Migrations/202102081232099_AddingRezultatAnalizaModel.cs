namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRezultatAnalizaModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RezultatAnalizas",
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
                        Glicemie = c.Int(nullable: false),
                        NumarLeucocite = c.Int(nullable: false),
                        NumarEritrocite = c.Int(nullable: false),
                        Hemoglobina = c.Int(nullable: false),
                        Hematrocit = c.Int(nullable: false),
                        VolumEritrocitarMediu = c.Int(nullable: false),
                        ConcentratieMedie = c.Int(nullable: false),
                        Trombocite = c.Int(nullable: false),
                        VolumMediuTrombocitar = c.Int(nullable: false),
                        Plachetocrit = c.Int(nullable: false),
                        Monocite = c.Int(nullable: false),
                        Neutrofile = c.Int(nullable: false),
                        Eozinofile = c.Int(nullable: false),
                        Bazofile = c.Int(nullable: false),
                        Limfocite = c.Int(nullable: false),
                        Colesterol = c.Int(nullable: false),
                        Trigliceride = c.Int(nullable: false),
                        Uree = c.Int(nullable: false),
                        Creatinina = c.Int(nullable: false),
                        Calciu = c.Int(nullable: false),
                        Fier = c.Int(nullable: false),
                        Magneziu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Analizas", t => t.AnalizaId, cascadeDelete: true)
                .ForeignKey("dbo.Medics", t => t.MedicId, cascadeDelete: true)
                .ForeignKey("dbo.Pacients", t => t.PacientId, cascadeDelete: true)
                .Index(t => t.MedicId)
                .Index(t => t.PacientId)
                .Index(t => t.AnalizaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RezultatAnalizas", "PacientId", "dbo.Pacients");
            DropForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatAnalizas", "AnalizaId", "dbo.Analizas");
            DropIndex("dbo.RezultatAnalizas", new[] { "AnalizaId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "PacientId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "MedicId" });
            DropTable("dbo.RezultatAnalizas");
        }
    }
}
