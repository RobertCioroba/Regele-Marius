namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingValidators : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medics", "SpecializareId", "dbo.Specializares");
            DropIndex("dbo.Medics", new[] { "SpecializareId" });
            AlterColumn("dbo.Analizas", "Denumire", c => c.String(nullable: false));
            AlterColumn("dbo.Analizas", "Descriere", c => c.String(nullable: false));
            AlterColumn("dbo.ProgramareAnalizas", "Nume", c => c.String(nullable: false));
            AlterColumn("dbo.ProgramareAnalizas", "Prenume", c => c.String(nullable: false));
            AlterColumn("dbo.Medics", "SpecializareId", c => c.Int(nullable: false));
            AlterColumn("dbo.Medics", "Nume", c => c.String(nullable: false));
            AlterColumn("dbo.Medics", "Prenume", c => c.String(nullable: false));
            AlterColumn("dbo.Interventies", "Echipament", c => c.String(nullable: false));
            AlterColumn("dbo.Interventies", "Denumire", c => c.String(nullable: false));
            AlterColumn("dbo.Interventies", "Descriere", c => c.String(nullable: false));
            AlterColumn("dbo.Pacients", "Nume", c => c.String(nullable: false));
            AlterColumn("dbo.Pacients", "Prenume", c => c.String(nullable: false));
            AlterColumn("dbo.Specializares", "Nume", c => c.String(nullable: false));
            AlterColumn("dbo.Articols", "Nume", c => c.String(nullable: false));
            AlterColumn("dbo.Articols", "Titlu", c => c.String(nullable: false));
            AlterColumn("dbo.Articols", "Imagine", c => c.String(nullable: false));
            AlterColumn("dbo.Articols", "Descriere", c => c.String(nullable: false));
            CreateIndex("dbo.Medics", "SpecializareId");
            AddForeignKey("dbo.Medics", "SpecializareId", "dbo.Specializares", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medics", "SpecializareId", "dbo.Specializares");
            DropIndex("dbo.Medics", new[] { "SpecializareId" });
            AlterColumn("dbo.Articols", "Descriere", c => c.String());
            AlterColumn("dbo.Articols", "Imagine", c => c.String());
            AlterColumn("dbo.Articols", "Titlu", c => c.String());
            AlterColumn("dbo.Articols", "Nume", c => c.String());
            AlterColumn("dbo.Specializares", "Nume", c => c.String());
            AlterColumn("dbo.Pacients", "Prenume", c => c.String());
            AlterColumn("dbo.Pacients", "Nume", c => c.String());
            AlterColumn("dbo.Interventies", "Descriere", c => c.String());
            AlterColumn("dbo.Interventies", "Denumire", c => c.String());
            AlterColumn("dbo.Interventies", "Echipament", c => c.String());
            AlterColumn("dbo.Medics", "Prenume", c => c.String());
            AlterColumn("dbo.Medics", "Nume", c => c.String());
            AlterColumn("dbo.Medics", "SpecializareId", c => c.Int());
            AlterColumn("dbo.ProgramareAnalizas", "Prenume", c => c.String());
            AlterColumn("dbo.ProgramareAnalizas", "Nume", c => c.String());
            AlterColumn("dbo.Analizas", "Descriere", c => c.String());
            AlterColumn("dbo.Analizas", "Denumire", c => c.String());
            CreateIndex("dbo.Medics", "SpecializareId");
            AddForeignKey("dbo.Medics", "SpecializareId", "dbo.Specializares", "Id");
        }
    }
}
