namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDayAtWork : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Medics", newName: "Utilizators");
            DropForeignKey("dbo.ProgramareAnalizas", "AnalizaId", "dbo.Analizas");
            DropForeignKey("dbo.Medics", "GetProgramareAnaliza_Id", "dbo.ProgramareAnalizas");
            DropForeignKey("dbo.ProgramareAnalizas", "Medic_Id", "dbo.Medics");
            DropForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.Pacients", "ProgramareAnaliza_Id", "dbo.ProgramareAnalizas");
            DropForeignKey("dbo.ProgramareAnalizas", "Pacient_Id", "dbo.Pacients");
            DropForeignKey("dbo.ProgramareAnalizas", "PacientId", "dbo.Pacients");
            DropForeignKey("dbo.Analizas", "ProgramareAnaliza_Id", "dbo.ProgramareAnalizas");
            DropForeignKey("dbo.ProgramareAnalizas", "Analiza_Id", "dbo.Analizas");
            DropIndex("dbo.Analizas", new[] { "ProgramareAnaliza_Id" });
            DropIndex("dbo.ProgramareAnalizas", new[] { "AnalizaId" });
            DropIndex("dbo.ProgramareAnalizas", new[] { "PacientId" });
            DropIndex("dbo.ProgramareAnalizas", new[] { "MedicId" });
            DropIndex("dbo.ProgramareAnalizas", new[] { "Medic_Id" });
            DropIndex("dbo.ProgramareAnalizas", new[] { "Pacient_Id" });
            DropIndex("dbo.ProgramareAnalizas", new[] { "Analiza_Id" });
            DropIndex("dbo.Utilizators", new[] { "SpecializareId" });
            DropIndex("dbo.Utilizators", new[] { "GetProgramareAnaliza_Id" });
            DropIndex("dbo.Pacients", new[] { "ProgramareAnaliza_Id" });
            AddColumn("dbo.ProgramareAnalizas", "Glicemie", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "NumarLeucocite", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "NumarEritrocite", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Hemoglobina", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Hematrocit", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "VolumEritrocitarMediu", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "ConcentratieMedie", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Trombocite", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "VolumMediuTrombocitar", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Plachetocrit", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Monocite", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Neutrofile", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Eozinofile", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Bazofile", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Limfocite", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Colesterol", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Trigliceride", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Uree", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Creatinina", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Calciu", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Fier", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Magneziu", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilizators", "DataNastere", c => c.DateTime());
            AddColumn("dbo.Utilizators", "NrTelefon", c => c.Int());
            AddColumn("dbo.Utilizators", "Email", c => c.String());
            AddColumn("dbo.Utilizators", "Adresa", c => c.String());
            AddColumn("dbo.Utilizators", "Sex", c => c.String());
            AddColumn("dbo.Utilizators", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ProgramareAnalizas", "OraInceput", c => c.String());
            AlterColumn("dbo.ProgramareAnalizas", "OraFinal", c => c.String());
            AlterColumn("dbo.Utilizators", "SpecializareId", c => c.Int());
            AlterColumn("dbo.Utilizators", "LuniInceput", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "LuniFinal", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "MartiInceput", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "MartiFinal", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "MiercuriInceput", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "MiercuriFinal", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "JoiInceput", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "JoiFinal", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "VineriInceput", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "VineriFinal", c => c.DateTime());
            CreateIndex("dbo.Utilizators", "SpecializareId");
            DropColumn("dbo.Analizas", "ProgramareAnaliza_Id");
            DropColumn("dbo.ProgramareAnalizas", "Medic_Id");
            DropColumn("dbo.ProgramareAnalizas", "Pacient_Id");
            DropColumn("dbo.ProgramareAnalizas", "Analiza_Id");
            DropColumn("dbo.Utilizators", "GetProgramareAnaliza_Id");
            DropTable("dbo.Pacients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pacients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataNastere = c.DateTime(nullable: false),
                        NrTelefon = c.Int(nullable: false),
                        Email = c.String(),
                        Adresa = c.String(),
                        Sex = c.String(),
                        Nume = c.String(),
                        Prenume = c.String(),
                        ProgramareAnaliza_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Utilizators", "GetProgramareAnaliza_Id", c => c.Int());
            AddColumn("dbo.ProgramareAnalizas", "Analiza_Id", c => c.Int());
            AddColumn("dbo.ProgramareAnalizas", "Pacient_Id", c => c.Int());
            AddColumn("dbo.ProgramareAnalizas", "Medic_Id", c => c.Int());
            AddColumn("dbo.Analizas", "ProgramareAnaliza_Id", c => c.Int());
            DropIndex("dbo.Utilizators", new[] { "SpecializareId" });
            AlterColumn("dbo.Utilizators", "VineriFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Utilizators", "VineriInceput", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Utilizators", "JoiFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Utilizators", "JoiInceput", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Utilizators", "MiercuriFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Utilizators", "MiercuriInceput", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Utilizators", "MartiFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Utilizators", "MartiInceput", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Utilizators", "LuniFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Utilizators", "LuniInceput", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Utilizators", "SpecializareId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProgramareAnalizas", "OraFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProgramareAnalizas", "OraInceput", c => c.DateTime(nullable: false));
            DropColumn("dbo.Utilizators", "Discriminator");
            DropColumn("dbo.Utilizators", "Sex");
            DropColumn("dbo.Utilizators", "Adresa");
            DropColumn("dbo.Utilizators", "Email");
            DropColumn("dbo.Utilizators", "NrTelefon");
            DropColumn("dbo.Utilizators", "DataNastere");
            DropColumn("dbo.ProgramareAnalizas", "Magneziu");
            DropColumn("dbo.ProgramareAnalizas", "Fier");
            DropColumn("dbo.ProgramareAnalizas", "Calciu");
            DropColumn("dbo.ProgramareAnalizas", "Creatinina");
            DropColumn("dbo.ProgramareAnalizas", "Uree");
            DropColumn("dbo.ProgramareAnalizas", "Trigliceride");
            DropColumn("dbo.ProgramareAnalizas", "Colesterol");
            DropColumn("dbo.ProgramareAnalizas", "Limfocite");
            DropColumn("dbo.ProgramareAnalizas", "Bazofile");
            DropColumn("dbo.ProgramareAnalizas", "Eozinofile");
            DropColumn("dbo.ProgramareAnalizas", "Neutrofile");
            DropColumn("dbo.ProgramareAnalizas", "Monocite");
            DropColumn("dbo.ProgramareAnalizas", "Plachetocrit");
            DropColumn("dbo.ProgramareAnalizas", "VolumMediuTrombocitar");
            DropColumn("dbo.ProgramareAnalizas", "Trombocite");
            DropColumn("dbo.ProgramareAnalizas", "ConcentratieMedie");
            DropColumn("dbo.ProgramareAnalizas", "VolumEritrocitarMediu");
            DropColumn("dbo.ProgramareAnalizas", "Hematrocit");
            DropColumn("dbo.ProgramareAnalizas", "Hemoglobina");
            DropColumn("dbo.ProgramareAnalizas", "NumarEritrocite");
            DropColumn("dbo.ProgramareAnalizas", "NumarLeucocite");
            DropColumn("dbo.ProgramareAnalizas", "Glicemie");
            CreateIndex("dbo.Pacients", "ProgramareAnaliza_Id");
            CreateIndex("dbo.Utilizators", "GetProgramareAnaliza_Id");
            CreateIndex("dbo.Utilizators", "SpecializareId");
            CreateIndex("dbo.ProgramareAnalizas", "Analiza_Id");
            CreateIndex("dbo.ProgramareAnalizas", "Pacient_Id");
            CreateIndex("dbo.ProgramareAnalizas", "Medic_Id");
            CreateIndex("dbo.ProgramareAnalizas", "MedicId");
            CreateIndex("dbo.ProgramareAnalizas", "PacientId");
            CreateIndex("dbo.ProgramareAnalizas", "AnalizaId");
            CreateIndex("dbo.Analizas", "ProgramareAnaliza_Id");
            AddForeignKey("dbo.ProgramareAnalizas", "Analiza_Id", "dbo.Analizas", "Id");
            AddForeignKey("dbo.Analizas", "ProgramareAnaliza_Id", "dbo.ProgramareAnalizas", "Id");
            AddForeignKey("dbo.ProgramareAnalizas", "PacientId", "dbo.Pacients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramareAnalizas", "Pacient_Id", "dbo.Pacients", "Id");
            AddForeignKey("dbo.Pacients", "ProgramareAnaliza_Id", "dbo.ProgramareAnalizas", "Id");
            AddForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramareAnalizas", "Medic_Id", "dbo.Medics", "Id");
            AddForeignKey("dbo.Medics", "GetProgramareAnaliza_Id", "dbo.ProgramareAnalizas", "Id");
            AddForeignKey("dbo.ProgramareAnalizas", "AnalizaId", "dbo.Analizas", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Utilizators", newName: "Medics");
        }
    }
}
