namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPathForArticleImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articols", "Nume", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articols", "Nume");
        }
    }
}
