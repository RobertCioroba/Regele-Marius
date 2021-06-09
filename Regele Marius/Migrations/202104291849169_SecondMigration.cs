namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramareAnalizas", "AnalizaId", "dbo.Analizas");
            DropForeignKey("dbo.RezultatAnalizas", "AnalizaId", "dbo.Analizas");
            DropForeignKey("dbo.ProgramareInterventies", "InterventieId", "dbo.Interventies");
            DropForeignKey("dbo.RezultatInterventies", "InterventieId", "dbo.Interventies");
            DropForeignKey("dbo.RezultatInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatAnalizas", "PacientId", "dbo.Pacients");
            DropForeignKey("dbo.RezultatInterventies", "PacientId", "dbo.Pacients");
            DropForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.Medics", "SpecializareId", "dbo.Specializares");
            DropForeignKey("dbo.Analizas", "SpecializareId", "dbo.Specializares");
            DropIndex("dbo.Analizas", new[] { "SpecializareId" });
            DropIndex("dbo.ProgramareAnalizas", new[] { "AnalizaId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "MedicId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "PacientId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "AnalizaId" });
            DropIndex("dbo.Medics", new[] { "SpecializareId" });
            DropIndex("dbo.ProgramareInterventies", new[] { "MedicId" });
            DropIndex("dbo.ProgramareInterventies", new[] { "InterventieId" });
            DropIndex("dbo.RezultatInterventies", new[] { "MedicId" });
            DropIndex("dbo.RezultatInterventies", new[] { "PacientId" });
            DropIndex("dbo.RezultatInterventies", new[] { "InterventieId" });
            DropTable("dbo.Analizas");
            DropTable("dbo.ProgramareAnalizas");
            DropTable("dbo.RezultatAnalizas");
            DropTable("dbo.ProgramareInterventies");
            DropTable("dbo.Interventies");
            DropTable("dbo.RezultatInterventies");
            DropTable("dbo.Pacients");
            DropTable("dbo.Specializares");
            DropTable("dbo.Articols");
            DropTable("dbo.Calculators");
            DropTable("dbo.Roles");
            DropTable("dbo.Sliders");
        }
        
        public override void Down()
        {
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
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
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
                "dbo.Specializares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.RezultatInterventies", "InterventieId");
            CreateIndex("dbo.RezultatInterventies", "PacientId");
            CreateIndex("dbo.RezultatInterventies", "MedicId");
            CreateIndex("dbo.ProgramareInterventies", "InterventieId");
            CreateIndex("dbo.ProgramareInterventies", "MedicId");
            CreateIndex("dbo.Medics", "SpecializareId");
            CreateIndex("dbo.RezultatAnalizas", "AnalizaId");
            CreateIndex("dbo.RezultatAnalizas", "PacientId");
            CreateIndex("dbo.RezultatAnalizas", "MedicId");
            CreateIndex("dbo.ProgramareAnalizas", "AnalizaId");
            CreateIndex("dbo.Analizas", "SpecializareId");
            AddForeignKey("dbo.Analizas", "SpecializareId", "dbo.Specializares", "Id");
            AddForeignKey("dbo.Medics", "SpecializareId", "dbo.Specializares", "Id");
            AddForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics", "Id");
            AddForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RezultatInterventies", "PacientId", "dbo.Pacients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RezultatAnalizas", "PacientId", "dbo.Pacients", "Id");
            AddForeignKey("dbo.RezultatInterventies", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RezultatInterventies", "InterventieId", "dbo.Interventies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramareInterventies", "InterventieId", "dbo.Interventies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RezultatAnalizas", "AnalizaId", "dbo.Analizas", "Id");
            AddForeignKey("dbo.ProgramareAnalizas", "AnalizaId", "dbo.Analizas", "Id", cascadeDelete: true);
        }
    }
}
