namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDayNewLife : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.Medics", new[] { "GetProgramareAnaliza_Id" });
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
            AlterColumn("dbo.ProgramareAnalizas", "OraInceput", c => c.String());
            AlterColumn("dbo.ProgramareAnalizas", "OraFinal", c => c.String());
            DropColumn("dbo.Analizas", "ProgramareAnaliza_Id");
            DropColumn("dbo.ProgramareAnalizas", "Medic_Id");
            DropColumn("dbo.ProgramareAnalizas", "Pacient_Id");
            DropColumn("dbo.ProgramareAnalizas", "Analiza_Id");
            DropColumn("dbo.Medics", "GetProgramareAnaliza_Id");
            DropColumn("dbo.Pacients", "ProgramareAnaliza_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pacients", "ProgramareAnaliza_Id", c => c.Int());
            AddColumn("dbo.Medics", "GetProgramareAnaliza_Id", c => c.Int());
            AddColumn("dbo.ProgramareAnalizas", "Analiza_Id", c => c.Int());
            AddColumn("dbo.ProgramareAnalizas", "Pacient_Id", c => c.Int());
            AddColumn("dbo.ProgramareAnalizas", "Medic_Id", c => c.Int());
            AddColumn("dbo.Analizas", "ProgramareAnaliza_Id", c => c.Int());
            AlterColumn("dbo.ProgramareAnalizas", "OraFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProgramareAnalizas", "OraInceput", c => c.DateTime(nullable: false));
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
            CreateIndex("dbo.Medics", "GetProgramareAnaliza_Id");
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
        }
    }
}
