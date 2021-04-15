namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAnalizaModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Analizas", "Glicemie", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "NumarLeucocite", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "NumarEritrocite", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Hemoglobina", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Hematrocit", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "VolumEritrocitarMediu", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "ConcentratieMedie", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Trombocite", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "VolumMediuTrombocitar", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Plachetocrit", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Monocite", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Neutrofile", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Eozinofile", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Bazofile", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Limfocite", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Colesterol", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Trigliceride", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Uree", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Creatinina", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Calciu", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Fier", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Analizas", "Magneziu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Analizas", "Magneziu", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Fier", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Calciu", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Creatinina", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Uree", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Trigliceride", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Colesterol", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Limfocite", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Bazofile", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Eozinofile", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Neutrofile", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Monocite", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Plachetocrit", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "VolumMediuTrombocitar", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Trombocite", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "ConcentratieMedie", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "VolumEritrocitarMediu", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Hematrocit", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Hemoglobina", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "NumarEritrocite", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "NumarLeucocite", c => c.Int(nullable: false));
            AlterColumn("dbo.Analizas", "Glicemie", c => c.Int(nullable: false));
        }
    }
}
