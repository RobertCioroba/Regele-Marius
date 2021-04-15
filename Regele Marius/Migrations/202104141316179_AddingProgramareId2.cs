namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProgramareId2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RezultatAnalizas", "ProgramareId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RezultatAnalizas", "ProgramareId", c => c.Int(nullable: false));
        }
    }
}
