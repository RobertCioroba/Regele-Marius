namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDurataToAnalizaModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Analizas", "Durata", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Analizas", "Durata");
        }
    }
}
