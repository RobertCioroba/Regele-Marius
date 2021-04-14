namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProgramareAnalizas", "Adresa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProgramareAnalizas", "Adresa", c => c.String());
        }
    }
}
