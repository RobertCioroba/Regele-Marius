namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pacients", "Id", "dbo.Users");
            DropForeignKey("dbo.Medics", "Id", "dbo.Users");
            DropForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics");
            DropIndex("dbo.Medics", new[] { "Id" });
            DropIndex("dbo.Pacients", new[] { "Id" });
            DropPrimaryKey("dbo.Medics");
            DropPrimaryKey("dbo.Pacients");
            AlterColumn("dbo.Medics", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Pacients", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Medics", "Id");
            AddPrimaryKey("dbo.Pacients", "Id");
            AddForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics");
            DropPrimaryKey("dbo.Pacients");
            DropPrimaryKey("dbo.Medics");
            AlterColumn("dbo.Pacients", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Medics", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Pacients", "Id");
            AddPrimaryKey("dbo.Medics", "Id");
            CreateIndex("dbo.Pacients", "Id");
            CreateIndex("dbo.Medics", "Id");
            AddForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Medics", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Pacients", "Id", "dbo.Users", "Id");
        }
    }
}
