namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeOraType1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Analizas", "Durata");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Analizas", "Durata", c => c.DateTime());
        }
    }
}
