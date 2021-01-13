namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherChangeForProgramareAnaliza : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramareAnalizas", "PacientId", "dbo.Pacients");
            DropIndex("dbo.ProgramareAnalizas", new[] { "PacientId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.ProgramareAnalizas", "PacientId");
            AddForeignKey("dbo.ProgramareAnalizas", "PacientId", "dbo.Pacients", "Id", cascadeDelete: true);
        }
    }
}
