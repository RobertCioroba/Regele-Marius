namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RezultatAnalizas", "AnalizaId", "dbo.Analizas");
            DropForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatAnalizas", "PacientId", "dbo.Pacients");
            DropIndex("dbo.RezultatAnalizas", new[] { "MedicId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "PacientId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "AnalizaId" });
            AlterColumn("dbo.RezultatAnalizas", "MedicId", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "PacientId", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "AnalizaId", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "DataNastere", c => c.DateTime());
            AlterColumn("dbo.RezultatAnalizas", "NrTelefon", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Pret", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Glicemie", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "NumarLeucocite", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "NumarEritrocite", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Hemoglobina", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Hematrocit", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "VolumEritrocitarMediu", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "ConcentratieMedie", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Trombocite", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "VolumMediuTrombocitar", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Plachetocrit", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Monocite", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Neutrofile", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Eozinofile", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Bazofile", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Limfocite", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Colesterol", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Trigliceride", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Uree", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Creatinina", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Calciu", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Fier", c => c.Int());
            AlterColumn("dbo.RezultatAnalizas", "Magneziu", c => c.Int());
            CreateIndex("dbo.RezultatAnalizas", "MedicId");
            CreateIndex("dbo.RezultatAnalizas", "PacientId");
            CreateIndex("dbo.RezultatAnalizas", "AnalizaId");
            AddForeignKey("dbo.RezultatAnalizas", "AnalizaId", "dbo.Analizas", "Id");
            AddForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics", "Id");
            AddForeignKey("dbo.RezultatAnalizas", "PacientId", "dbo.Pacients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RezultatAnalizas", "PacientId", "dbo.Pacients");
            DropForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.RezultatAnalizas", "AnalizaId", "dbo.Analizas");
            DropIndex("dbo.RezultatAnalizas", new[] { "AnalizaId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "PacientId" });
            DropIndex("dbo.RezultatAnalizas", new[] { "MedicId" });
            AlterColumn("dbo.RezultatAnalizas", "Magneziu", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Fier", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Calciu", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Creatinina", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Uree", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Trigliceride", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Colesterol", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Limfocite", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Bazofile", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Eozinofile", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Neutrofile", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Monocite", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Plachetocrit", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "VolumMediuTrombocitar", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Trombocite", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "ConcentratieMedie", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "VolumEritrocitarMediu", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Hematrocit", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Hemoglobina", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "NumarEritrocite", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "NumarLeucocite", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Glicemie", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "Pret", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "NrTelefon", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "DataNastere", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "AnalizaId", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "PacientId", c => c.Int(nullable: false));
            AlterColumn("dbo.RezultatAnalizas", "MedicId", c => c.Int(nullable: false));
            CreateIndex("dbo.RezultatAnalizas", "AnalizaId");
            CreateIndex("dbo.RezultatAnalizas", "PacientId");
            CreateIndex("dbo.RezultatAnalizas", "MedicId");
            AddForeignKey("dbo.RezultatAnalizas", "PacientId", "dbo.Pacients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RezultatAnalizas", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RezultatAnalizas", "AnalizaId", "dbo.Analizas", "Id", cascadeDelete: true);
        }
    }
}
