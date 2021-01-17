namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Calculators", "Inaltime", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Calculators", "Inaltime", c => c.Int(nullable: false));
        }
    }
}
