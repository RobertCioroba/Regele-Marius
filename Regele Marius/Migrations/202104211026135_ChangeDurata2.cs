namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDurata2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Analizas", "Durata", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Analizas", "Durata");
        }
    }
}
