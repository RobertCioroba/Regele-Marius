namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Analizas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Glicemie = c.Boolean(nullable: false),
                        NumarLeucocite = c.Boolean(nullable: false),
                        NumarEritrocite = c.Boolean(nullable: false),
                        Hemoglobina = c.Boolean(nullable: false),
                        Hematrocit = c.Boolean(nullable: false),
                        VolumEritrocitarMediu = c.Boolean(nullable: false),
                        ConcentratieMedie = c.Boolean(nullable: false),
                        Trombocite = c.Boolean(nullable: false),
                        VolumMediuTrombocitar = c.Boolean(nullable: false),
                        Plachetocrit = c.Boolean(nullable: false),
                        Monocite = c.Boolean(nullable: false),
                        Neutrofile = c.Boolean(nullable: false),
                        Eozinofile = c.Boolean(nullable: false),
                        Bazofile = c.Boolean(nullable: false),
                        Limfocite = c.Boolean(nullable: false),
                        Colesterol = c.Boolean(nullable: false),
                        Trigliceride = c.Boolean(nullable: false),
                        Uree = c.Boolean(nullable: false),
                        Creatinina = c.Boolean(nullable: false),
                        Calciu = c.Boolean(nullable: false),
                        Fier = c.Boolean(nullable: false),
                        Magneziu = c.Boolean(nullable: false),
                        SpecializareId = c.Int(),
                        Durata = c.Int(nullable: false),
                        Denumire = c.String(nullable: false),
                        Descriere = c.String(nullable: false),
                        Pret = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specializares", t => t.SpecializareId)
                .Index(t => t.SpecializareId);
            
            CreateTable(
                "dbo.ProgramareAnalizas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnalizaId = c.Int(nullable: false),
                        Nume = c.String(nullable: false),
                        Prenume = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        DataNastere = c.DateTime(nullable: false),
                        NrTelefon = c.Int(nullable: false),
                        Email = c.String(),
                        Gen = c.Int(nullable: false),
                        DataProgramare = c.DateTime(),
                        OraInceput = c.String(),
                        OraFinal = c.String(),
                        RezultatId = c.Int(nullable: false),
                        RezultatGuid = c.String(),
                        MedicId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Analizas", t => t.AnalizaId, cascadeDelete: true)
                .Index(t => t.AnalizaId);
            
            CreateTable(
                "dbo.RezultatAnalizas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicId = c.Int(),
                        PacientId = c.Int(),
                        AnalizaId = c.Int(),
                        DataNastere = c.DateTime(),
                        NrTelefon = c.Int(),
                        Email = c.String(),
                        Adresa = c.String(),
                        Gen = c.Int(nullable: false),
                        NumePacient = c.String(),
                        PrenumePacient = c.String(),
                        Denumire = c.String(),
                        Descriere = c.String(),
                        Pret = c.Int(),
                        ProgramareAnalizaId = c.Int(),
                        RezultatGuid = c.String(),
                        Glicemie = c.Int(),
                        NumarLeucocite = c.Int(),
                        NumarEritrocite = c.Int(),
                        Hemoglobina = c.Int(),
                        Hematrocit = c.Int(),
                        VolumEritrocitarMediu = c.Int(),
                        ConcentratieMedie = c.Int(),
                        Trombocite = c.Int(),
                        VolumMediuTrombocitar = c.Int(),
                        Plachetocrit = c.Int(),
                        Monocite = c.Int(),
                        Neutrofile = c.Int(),
                        Eozinofile = c.Int(),
                        Bazofile = c.Int(),
                        Limfocite = c.Int(),
                        Colesterol = c.Int(),
                        Trigliceride = c.Int(),
                        Uree = c.Int(),
                        Creatinina = c.Int(),
                        Calciu = c.Int(),
                        Fier = c.Int(),
                        Magneziu = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Analizas", t => t.AnalizaId)
                .ForeignKey("dbo.Pacients", t => t.PacientId)
                .ForeignKey("dbo.Medics", t => t.MedicId)
                .Index(t => t.MedicId)
                .Index(t => t.PacientId)
                .Index(t => t.AnalizaId);
            
            CreateTable(
                "dbo.Medics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(nullable: false),
                        Prenume = c.String(nullable: false),
                        SpecializareId = c.Int(),
                        Schimb = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
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
                        Echipament = c.String(nullable: false),
                        Denumire = c.String(nullable: false),
                        Descriere = c.String(nullable: false),
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
                        Nume = c.String(nullable: false),
                        Prenume = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specializares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(nullable: false),
                        Titlu = c.String(nullable: false),
                        Imagine = c.String(nullable: false),
                        Descriere = c.String(nullable: false),
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
                        Rezultat = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Luni = c.String(),
                        Marti = c.String(),
                        Miercuri = c.String(),
                        Joi = c.String(),
                        Vineri = c.String(),
                        IdMedic = c.Int(nullable: false),
                        Data = c.DateTime(),
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
                        IdMedic = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Analizas", "SpecializareId", "dbo.Specializares");
            DropForeignKey("dbo.Medics", "SpecializareId", "dbo.Specializares");
            DropForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatInterventies", "PacientId", "dbo.Pacients");
            DropForeignKey("dbo.RezultatAnalizas", "PacientId", "dbo.Pacients");
            DropForeignKey("dbo.RezultatInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatInterventies", "InterventieId", "dbo.Interventies");
            DropForeignKey("dbo.ProgramareInterventies", "InterventieId", "dbo.Interventies");
            DropForeignKey("dbo.RezultatAnalizas", "AnalizaId", "dbo.Analizas");
            DropForeignKey("dbo.ProgramareAnalizas", "AnalizaId", "dbo.Analizas");
            DropIndex("dbo.RezultatInterventies", new[] { "InterventieId" });
            DropIndex("dbo.RezultatInterventies", new[] { "PacientId" });
            DropIndex("dbo.RezultatInterventies", new[] { "MedicId" });
            DropIndex("dbo.ProgramareInterventies", new[] { "InterventieId" });
            DropIndex("dbo.ProgramareInterventies", new[] { "MedicId" });
            DropIndex("dbo.Medics", new[] { "SpecializareId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "AnalizaId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "PacientId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "MedicId" });
            DropIndex("dbo.ProgramareAnalizas", new[] { "AnalizaId" });
            DropIndex("dbo.Analizas", new[] { "SpecializareId" });
            DropTable("dbo.User1");
            DropTable("dbo.Sliders");
            DropTable("dbo.Roles");
            DropTable("dbo.Programs");
            DropTable("dbo.Calculators");
            DropTable("dbo.Articols");
            DropTable("dbo.Specializares");
            DropTable("dbo.Pacients");
            DropTable("dbo.RezultatInterventies");
            DropTable("dbo.Interventies");
            DropTable("dbo.ProgramareInterventies");
            DropTable("dbo.Medics");
            DropTable("dbo.RezultatAnalizas");
            DropTable("dbo.ProgramareAnalizas");
            DropTable("dbo.Analizas");
        }
    }
}
