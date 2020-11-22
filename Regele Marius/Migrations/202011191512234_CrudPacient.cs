namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrudPacient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programs", "IdMedic", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Programs", "IdMedic");
        }
    }
}
