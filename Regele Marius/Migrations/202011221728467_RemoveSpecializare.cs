namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSpecializare : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Utilizators", "Specializare");
            DropColumn("dbo.Programs", "IdMedic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Programs", "IdMedic", c => c.Int(nullable: false));
            AddColumn("dbo.Utilizators", "Specializare", c => c.String());
        }
    }
}
