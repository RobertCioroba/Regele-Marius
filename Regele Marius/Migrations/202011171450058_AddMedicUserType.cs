namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMedicUserType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizators", "Specializare", c => c.String());
            AddColumn("dbo.Utilizators", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilizators", "Discriminator");
            DropColumn("dbo.Utilizators", "Specializare");
        }
    }
}
