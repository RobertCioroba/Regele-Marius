namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Analizas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        Denumire = c.String(),
                        Descriere = c.String(),
                        Pret = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProgramareAnalizas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicId = c.Int(nullable: false),
                        PacientId = c.Int(nullable: false),
                        AnalizaId = c.Int(nullable: false),
                        DataProgramare = c.DateTime(nullable: false),
                        OraInceput = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Analizas", t => t.AnalizaId, cascadeDelete: true)
                .ForeignKey("dbo.Medics", t => t.MedicId, cascadeDelete: true)
                .Index(t => t.MedicId)
                .Index(t => t.AnalizaId);
            
            CreateTable(
                "dbo.Medics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpecializareId = c.Int(),
                        LuniInceput = c.DateTime(),
                        LuniFinal = c.DateTime(),
                        MartiInceput = c.DateTime(),
                        MartiFinal = c.DateTime(),
                        MiercuriInceput = c.DateTime(),
                        MiercuriFinal = c.DateTime(),
                        JoiInceput = c.DateTime(),
                        JoiFinal = c.DateTime(),
                        VineriInceput = c.DateTime(),
                        VineriFinal = c.DateTime(),
                        Nume = c.String(),
                        Prenume = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specializares", t => t.SpecializareId)
                .Index(t => t.SpecializareId);
            
            CreateTable(
                "dbo.ProgramareInterventies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicId = c.Int(nullable: false),
                        PacientId = c.Int(nullable: false),
                        InterventieId = c.Int(nullable: false),
                        DataProgramare = c.DateTime(nullable: false),
                        OraInceput = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Interventies", t => t.InterventieId, cascadeDelete: true)
                .ForeignKey("dbo.Medics", t => t.MedicId, cascadeDelete: true)
                .Index(t => t.MedicId)
                .Index(t => t.InterventieId);
            
            CreateTable(
                "dbo.Interventies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Echipament = c.String(),
                        Denumire = c.String(),
                        Descriere = c.String(),
                        Pret = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RezultatInterventies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicId = c.Int(nullable: false),
                        PacientId = c.Int(nullable: false),
                        InterventieId = c.Int(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Interventies", t => t.InterventieId, cascadeDelete: true)
                .ForeignKey("dbo.Medics", t => t.MedicId, cascadeDelete: true)
                .ForeignKey("dbo.Pacients", t => t.PacientId, cascadeDelete: true)
                .Index(t => t.MedicId)
                .Index(t => t.PacientId)
                .Index(t => t.InterventieId);
            
            CreateTable(
                "dbo.Pacients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataNastere = c.DateTime(nullable: false),
                        NrTelefon = c.Int(nullable: false),
                        Email = c.String(),
                        Adresa = c.String(),
                        Gen = c.Int(nullable: false),
                        Nume = c.String(),
                        Prenume = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Denumire = c.String(),
                        Descriere = c.String(),
                        Pret = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.Specializares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        Titlu = c.String(),
                        Imagine = c.String(),
                        Descriere = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Calculators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gen = c.Int(nullable: false),
                        Greutate = c.Int(nullable: false),
                        Inaltime = c.Double(nullable: false),
                        Varsta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Diagramas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        Titlu = c.String(),
                        Imagine = c.String(),
                        Descriere = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        NumeUtilizator = c.String(nullable: false, maxLength: 50),
                        Parola = c.String(nullable: false, maxLength: 20),
                        Activ = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medics", "SpecializareId", "dbo.Specializares");
            DropForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatInterventies", "PacientId", "dbo.Pacients");
            DropForeignKey("dbo.RezultatAnalizas", "PacientId", "dbo.Pacients");
            DropForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatAnalizas", "AnalizaId", "dbo.Analizas");
            DropForeignKey("dbo.RezultatInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatInterventies", "InterventieId", "dbo.Interventies");
            DropForeignKey("dbo.ProgramareInterventies", "InterventieId", "dbo.Interventies");
            DropForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.ProgramareAnalizas", "AnalizaId", "dbo.Analizas");
            DropIndex("dbo.RezultatAnalizas", new[] { "AnalizaId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "PacientId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "MedicId" });
            DropIndex("dbo.RezultatInterventies", new[] { "InterventieId" });
            DropIndex("dbo.RezultatInterventies", new[] { "PacientId" });
            DropIndex("dbo.RezultatInterventies", new[] { "MedicId" });
            DropIndex("dbo.ProgramareInterventies", new[] { "InterventieId" });
            DropIndex("dbo.ProgramareInterventies", new[] { "MedicId" });
            DropIndex("dbo.Medics", new[] { "SpecializareId" });
            DropIndex("dbo.ProgramareAnalizas", new[] { "AnalizaId" });
            DropIndex("dbo.ProgramareAnalizas", new[] { "MedicId" });
            DropTable("dbo.User1");
            DropTable("dbo.Sliders");
            DropTable("dbo.Roles");
            DropTable("dbo.Diagramas");
            DropTable("dbo.Calculators");
            DropTable("dbo.Articols");
            DropTable("dbo.Specializares");
            DropTable("dbo.RezultatAnalizas");
            DropTable("dbo.Pacients");
            DropTable("dbo.RezultatInterventies");
            DropTable("dbo.Interventies");
            DropTable("dbo.ProgramareInterventies");
            DropTable("dbo.Medics");
            DropTable("dbo.ProgramareAnalizas");
            DropTable("dbo.Analizas");
        }
    }
}
