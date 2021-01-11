namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMedicModelDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Utilizators", "LuniInceput", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "LuniFinal", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "MartiInceput", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "MartiFinal", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "MiercuriInceput", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "MiercuriFinal", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "JoiInceput", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "JoiFinal", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "VineriInceput", c => c.DateTime());
            AlterColumn("dbo.Utilizators", "VineriFinal", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Utilizators", "VineriFinal", c => c.String());
            AlterColumn("dbo.Utilizators", "VineriInceput", c => c.String());
            AlterColumn("dbo.Utilizators", "JoiFinal", c => c.String());
            AlterColumn("dbo.Utilizators", "JoiInceput", c => c.String());
            AlterColumn("dbo.Utilizators", "MiercuriFinal", c => c.String());
            AlterColumn("dbo.Utilizators", "MiercuriInceput", c => c.String());
            AlterColumn("dbo.Utilizators", "MartiFinal", c => c.String());
            AlterColumn("dbo.Utilizators", "MartiInceput", c => c.String());
            AlterColumn("dbo.Utilizators", "LuniFinal", c => c.String());
            AlterColumn("dbo.Utilizators", "LuniInceput", c => c.String());
        }
    }
}
