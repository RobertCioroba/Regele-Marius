namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAnalizaModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Analizas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Glicemie = c.Int(nullable: true),
                        NumarLeucocite = c.Int(nullable: true),
                        NumarEritrocite = c.Int(nullable: true),
                        Hemoglobina = c.Int(nullable: true),
                        Hematrocit = c.Int(nullable: true),
                        VolumEritrocitarMediu = c.Int(nullable: true),
                        ConcentratieMedie = c.Int(nullable: true),
                        Trombocite = c.Int(nullable: true),
                        VolumMediuTrombocitar = c.Int(nullable: true),
                        Plachetocrit = c.Int(nullable: true),
                        Monocite = c.Int(nullable: true),
                        Neutrofile = c.Int(nullable: true),
                        Eozinofile = c.Int(nullable: true),
                        Bazofile = c.Int(nullable: true),
                        Limfocite = c.Int(nullable: true),
                        Colesterol = c.Int(nullable: true),
                        Trigliceride = c.Int(nullable: true),
                        Uree = c.Int(nullable: true),
                        Creatinina = c.Int(nullable: true),
                        Calciu = c.Int(nullable: true),
                        Fier = c.Int(nullable: true),
                        Magneziu = c.Int(nullable: true),
                        Denumire = c.String(),
                        Descriere = c.String(),
                        Pret = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Analizas");
        }
    }
}
