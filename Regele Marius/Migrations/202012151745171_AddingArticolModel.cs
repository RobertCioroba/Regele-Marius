namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingArticolModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imagine = c.String(),
                        Titlu = c.String(),
                        Descriere = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Articols");
        }
    }
}
