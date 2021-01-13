namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProgramareInterventieModel : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Interventies", t => t.InterventieId, cascadeDelete: true)
                .ForeignKey("dbo.Medics", t => t.MedicId, cascadeDelete: true)
                .Index(t => t.MedicId)
                .Index(t => t.InterventieId);
            
            DropColumn("dbo.ProgramareAnalizas", "OraFinal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProgramareAnalizas", "OraFinal", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.ProgramareInterventies", "InterventieId", "dbo.Interventies");
            DropIndex("dbo.ProgramareInterventies", new[] { "InterventieId" });
            DropIndex("dbo.ProgramareInterventies", new[] { "MedicId" });
            DropTable("dbo.ProgramareInterventies");
        }
    }
}
