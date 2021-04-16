namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdMedicToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User1", "IdMedic", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User1", "IdMedic");
        }
    }
}
