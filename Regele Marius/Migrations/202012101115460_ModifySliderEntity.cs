namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifySliderEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "Imagine", c => c.String());
            DropColumn("dbo.Sliders", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sliders", "Path", c => c.String());
            DropColumn("dbo.Sliders", "Imagine");
        }
    }
}
