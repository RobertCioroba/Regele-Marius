namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProgramareAnalizaModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgramareAnalizas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicId = c.Int(nullable: false),
                        PacientId = c.Int(nullable: false),
                        AnalizaId = c.Int(nullable: false),
                        DataProgramare = c.DateTime(nullable: false),
                        OraInceput = c.String(),
                        OraFinal = c.String(),
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProgramareAnalizas");
        }
    }
}
