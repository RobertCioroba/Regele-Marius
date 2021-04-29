namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCalculator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calculators", "Rezultat", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calculators", "Rezultat");
        }
    }
}
