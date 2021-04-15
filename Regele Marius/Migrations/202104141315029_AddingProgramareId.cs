namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProgramareId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RezultatAnalizas", "ProgramareId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RezultatAnalizas", "ProgramareId");
        }
    }
}
