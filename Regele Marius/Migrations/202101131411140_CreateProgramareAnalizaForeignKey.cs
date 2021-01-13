namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProgramareAnalizaForeignKey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProgramareAnalizas", "OraInceput", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProgramareAnalizas", "OraFinal", c => c.DateTime(nullable: false));
            CreateIndex("dbo.ProgramareAnalizas", "MedicId");
            CreateIndex("dbo.ProgramareAnalizas", "PacientId");
            CreateIndex("dbo.ProgramareAnalizas", "AnalizaId");
            AddForeignKey("dbo.ProgramareAnalizas", "AnalizaId", "dbo.Analizas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramareAnalizas", "PacientId", "dbo.Pacients", "Id", cascadeDelete: true);
            DropColumn("dbo.ProgramareAnalizas", "Glicemie");
            DropColumn("dbo.ProgramareAnalizas", "NumarLeucocite");
            DropColumn("dbo.ProgramareAnalizas", "NumarEritrocite");
            DropColumn("dbo.ProgramareAnalizas", "Hemoglobina");
            DropColumn("dbo.ProgramareAnalizas", "Hematrocit");
            DropColumn("dbo.ProgramareAnalizas", "VolumEritrocitarMediu");
            DropColumn("dbo.ProgramareAnalizas", "ConcentratieMedie");
            DropColumn("dbo.ProgramareAnalizas", "Trombocite");
            DropColumn("dbo.ProgramareAnalizas", "VolumMediuTrombocitar");
            DropColumn("dbo.ProgramareAnalizas", "Plachetocrit");
            DropColumn("dbo.ProgramareAnalizas", "Monocite");
            DropColumn("dbo.ProgramareAnalizas", "Neutrofile");
            DropColumn("dbo.ProgramareAnalizas", "Eozinofile");
            DropColumn("dbo.ProgramareAnalizas", "Bazofile");
            DropColumn("dbo.ProgramareAnalizas", "Limfocite");
            DropColumn("dbo.ProgramareAnalizas", "Colesterol");
            DropColumn("dbo.ProgramareAnalizas", "Trigliceride");
            DropColumn("dbo.ProgramareAnalizas", "Uree");
            DropColumn("dbo.ProgramareAnalizas", "Creatinina");
            DropColumn("dbo.ProgramareAnalizas", "Calciu");
            DropColumn("dbo.ProgramareAnalizas", "Fier");
            DropColumn("dbo.ProgramareAnalizas", "Magneziu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProgramareAnalizas", "Magneziu", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Fier", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Calciu", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Creatinina", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Uree", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Trigliceride", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Colesterol", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Limfocite", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Bazofile", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Eozinofile", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Neutrofile", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Monocite", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Plachetocrit", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "VolumMediuTrombocitar", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Trombocite", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "ConcentratieMedie", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "VolumEritrocitarMediu", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Hematrocit", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Hemoglobina", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "NumarEritrocite", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "NumarLeucocite", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Glicemie", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ProgramareAnalizas", "PacientId", "dbo.Pacients");
            DropForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.ProgramareAnalizas", "AnalizaId", "dbo.Analizas");
            DropIndex("dbo.ProgramareAnalizas", new[] { "AnalizaId" });
            DropIndex("dbo.ProgramareAnalizas", new[] { "PacientId" });
            DropIndex("dbo.ProgramareAnalizas", new[] { "MedicId" });
            AlterColumn("dbo.ProgramareAnalizas", "OraFinal", c => c.String());
            AlterColumn("dbo.ProgramareAnalizas", "OraInceput", c => c.String());
        }
    }
}
