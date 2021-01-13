namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallChangesMedicModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Medics", "LuniInceput", c => c.DateTime());
            AlterColumn("dbo.Medics", "LuniFinal", c => c.DateTime());
            AlterColumn("dbo.Medics", "MartiInceput", c => c.DateTime());
            AlterColumn("dbo.Medics", "MartiFinal", c => c.DateTime());
            AlterColumn("dbo.Medics", "MiercuriInceput", c => c.DateTime());
            AlterColumn("dbo.Medics", "MiercuriFinal", c => c.DateTime());
            AlterColumn("dbo.Medics", "JoiInceput", c => c.DateTime());
            AlterColumn("dbo.Medics", "JoiFinal", c => c.DateTime());
            AlterColumn("dbo.Medics", "VineriInceput", c => c.DateTime());
            AlterColumn("dbo.Medics", "VineriFinal", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Medics", "VineriFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Medics", "VineriInceput", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Medics", "JoiFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Medics", "JoiInceput", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Medics", "MiercuriFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Medics", "MiercuriInceput", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Medics", "MartiFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Medics", "MartiInceput", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Medics", "LuniFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Medics", "LuniInceput", c => c.DateTime(nullable: false));
        }
    }
}
