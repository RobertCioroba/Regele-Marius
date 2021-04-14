namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProgramareAnalizaModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics");
            DropIndex("dbo.ProgramareAnalizas", new[] { "MedicId" });
            AddColumn("dbo.ProgramareAnalizas", "Nume", c => c.String());
            AddColumn("dbo.ProgramareAnalizas", "Prenume", c => c.String());
            AddColumn("dbo.ProgramareAnalizas", "DataNastere", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "NrTelefon", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "Email", c => c.String());
            AddColumn("dbo.ProgramareAnalizas", "Adresa", c => c.String());
            AddColumn("dbo.ProgramareAnalizas", "Gen", c => c.Int(nullable: false));
            AlterColumn("dbo.ProgramareAnalizas", "DataProgramare", c => c.DateTime());
            AlterColumn("dbo.ProgramareAnalizas", "OraInceput", c => c.DateTime());
            DropColumn("dbo.ProgramareAnalizas", "MedicId");
            DropColumn("dbo.ProgramareAnalizas", "PacientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProgramareAnalizas", "PacientId", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramareAnalizas", "MedicId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProgramareAnalizas", "OraInceput", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProgramareAnalizas", "DataProgramare", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProgramareAnalizas", "Gen");
            DropColumn("dbo.ProgramareAnalizas", "Adresa");
            DropColumn("dbo.ProgramareAnalizas", "Email");
            DropColumn("dbo.ProgramareAnalizas", "NrTelefon");
            DropColumn("dbo.ProgramareAnalizas", "DataNastere");
            DropColumn("dbo.ProgramareAnalizas", "Prenume");
            DropColumn("dbo.ProgramareAnalizas", "Nume");
            CreateIndex("dbo.ProgramareAnalizas", "MedicId");
            AddForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
        }
    }
}
