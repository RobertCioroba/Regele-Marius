namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingStatusFieldToProgramareAnalizaModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProgramareAnalizas", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProgramareAnalizas", "Status");
        }
    }
}
