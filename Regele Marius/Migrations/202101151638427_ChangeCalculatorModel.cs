namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCalculatorModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calculators", "Greutate", c => c.Int(nullable: false));
            AlterColumn("dbo.Calculators", "Gen", c => c.Int(nullable: false));
            DropColumn("dbo.Calculators", "Gat");
            DropColumn("dbo.Calculators", "Talie");
            DropColumn("dbo.Calculators", "Sold");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Calculators", "Sold", c => c.Int());
            AddColumn("dbo.Calculators", "Talie", c => c.Int(nullable: false));
            AddColumn("dbo.Calculators", "Gat", c => c.Int(nullable: false));
            AlterColumn("dbo.Calculators", "Gen", c => c.Int());
            DropColumn("dbo.Calculators", "Greutate");
        }
    }
}
