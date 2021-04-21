namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.DoamneAjutas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DoamneAjutas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
