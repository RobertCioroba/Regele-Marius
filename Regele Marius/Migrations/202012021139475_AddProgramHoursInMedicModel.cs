namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgramHoursInMedicModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizators", "LuniInceput", c => c.String());
            AddColumn("dbo.Utilizators", "LuniFinal", c => c.String());
            AddColumn("dbo.Utilizators", "MartiInceput", c => c.String());
            AddColumn("dbo.Utilizators", "MartiFinal", c => c.String());
            AddColumn("dbo.Utilizators", "MiercuriInceput", c => c.String());
            AddColumn("dbo.Utilizators", "MiercuriFinal", c => c.String());
            AddColumn("dbo.Utilizators", "JoiInceput", c => c.String());
            AddColumn("dbo.Utilizators", "JoiFinal", c => c.String());
            AddColumn("dbo.Utilizators", "VineriInceput", c => c.String());
            AddColumn("dbo.Utilizators", "VineriFinal", c => c.String());
            DropColumn("dbo.Utilizators", "ProgramId");
            DropTable("dbo.Programs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Utilizators", "ProgramId", c => c.Int());
            DropColumn("dbo.Utilizators", "VineriFinal");
            DropColumn("dbo.Utilizators", "VineriInceput");
            DropColumn("dbo.Utilizators", "JoiFinal");
            DropColumn("dbo.Utilizators", "JoiInceput");
            DropColumn("dbo.Utilizators", "MiercuriFinal");
            DropColumn("dbo.Utilizators", "MiercuriInceput");
            DropColumn("dbo.Utilizators", "MartiFinal");
            DropColumn("dbo.Utilizators", "MartiInceput");
            DropColumn("dbo.Utilizators", "LuniFinal");
            DropColumn("dbo.Utilizators", "LuniInceput");
        }
    }
}
