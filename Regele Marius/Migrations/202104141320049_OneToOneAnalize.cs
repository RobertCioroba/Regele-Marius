namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToOneAnalize : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RezultatAnalizas");
            AlterColumn("dbo.RezultatAnalizas", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RezultatAnalizas", "Id");
            CreateIndex("dbo.RezultatAnalizas", "Id");
            AddForeignKey("dbo.RezultatAnalizas", "Id", "dbo.ProgramareAnalizas", "Id");
            DropColumn("dbo.RezultatAnalizas", "ProgramareId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RezultatAnalizas", "ProgramareId", c => c.Int());
            DropForeignKey("dbo.RezultatAnalizas", "Id", "dbo.ProgramareAnalizas");
            DropIndex("dbo.RezultatAnalizas", new[] { "Id" });
            DropPrimaryKey("dbo.RezultatAnalizas");
            AlterColumn("dbo.RezultatAnalizas", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RezultatAnalizas", "Id");
        }
    }
}
