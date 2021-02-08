namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToOneMedicUser1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Id", "dbo.Pacients");
            DropForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics");
            DropIndex("dbo.Users", new[] { "Id" });
            DropPrimaryKey("dbo.Medics");
            DropPrimaryKey("dbo.Pacients");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Medics", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Pacients", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Medics", "Id");
            AddPrimaryKey("dbo.Pacients", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Medics", "Id");
            CreateIndex("dbo.Pacients", "Id");
            AddForeignKey("dbo.Pacients", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Medics", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics");
            DropForeignKey("dbo.Medics", "Id", "dbo.Users");
            DropForeignKey("dbo.Pacients", "Id", "dbo.Users");
            DropIndex("dbo.Pacients", new[] { "Id" });
            DropIndex("dbo.Medics", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Pacients");
            DropPrimaryKey("dbo.Medics");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Pacients", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Medics", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Pacients", "Id");
            AddPrimaryKey("dbo.Medics", "Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.ProgramareInterventies", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramareAnalizas", "MedicId", "dbo.Medics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Id", "dbo.Pacients", "Id");
        }
    }
}
