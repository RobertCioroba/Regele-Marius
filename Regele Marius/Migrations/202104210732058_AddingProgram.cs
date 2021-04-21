namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProgram : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Luni = c.String(),
                        Marti = c.String(),
                        Miercuri = c.String(),
                        Joi = c.String(),
                        Vineri = c.String(),
                        IdMedic = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Programs");
        }
    }
}
