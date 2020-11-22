namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgramForMedicUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Utilizators", "ProgramId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilizators", "ProgramId");
            DropTable("dbo.Programs");
        }
    }
}
