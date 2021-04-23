namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStructureForMedic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jois",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedic = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Ora08 = c.Boolean(nullable: false),
                        Ora09 = c.Boolean(nullable: false),
                        Ora10 = c.Boolean(nullable: false),
                        Ora11 = c.Boolean(nullable: false),
                        Ora12 = c.Boolean(nullable: false),
                        Ora13 = c.Boolean(nullable: false),
                        Ora14 = c.Boolean(nullable: false),
                        Ora15 = c.Boolean(nullable: false),
                        Ora16 = c.Boolean(nullable: false),
                        Ora17 = c.Boolean(nullable: false),
                        Ora18 = c.Boolean(nullable: false),
                        Ora19 = c.Boolean(nullable: false),
                        Ora20 = c.Boolean(nullable: false),
                        Ora21 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lunis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedic = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Ora08 = c.Boolean(nullable: false),
                        Ora09 = c.Boolean(nullable: false),
                        Ora10 = c.Boolean(nullable: false),
                        Ora11 = c.Boolean(nullable: false),
                        Ora12 = c.Boolean(nullable: false),
                        Ora13 = c.Boolean(nullable: false),
                        Ora14 = c.Boolean(nullable: false),
                        Ora15 = c.Boolean(nullable: false),
                        Ora16 = c.Boolean(nullable: false),
                        Ora17 = c.Boolean(nullable: false),
                        Ora18 = c.Boolean(nullable: false),
                        Ora19 = c.Boolean(nullable: false),
                        Ora20 = c.Boolean(nullable: false),
                        Ora21 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Martis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedic = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Ora08 = c.Boolean(nullable: false),
                        Ora09 = c.Boolean(nullable: false),
                        Ora10 = c.Boolean(nullable: false),
                        Ora11 = c.Boolean(nullable: false),
                        Ora12 = c.Boolean(nullable: false),
                        Ora13 = c.Boolean(nullable: false),
                        Ora14 = c.Boolean(nullable: false),
                        Ora15 = c.Boolean(nullable: false),
                        Ora16 = c.Boolean(nullable: false),
                        Ora17 = c.Boolean(nullable: false),
                        Ora18 = c.Boolean(nullable: false),
                        Ora19 = c.Boolean(nullable: false),
                        Ora20 = c.Boolean(nullable: false),
                        Ora21 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Miercuris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedic = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Ora08 = c.Boolean(nullable: false),
                        Ora09 = c.Boolean(nullable: false),
                        Ora10 = c.Boolean(nullable: false),
                        Ora11 = c.Boolean(nullable: false),
                        Ora12 = c.Boolean(nullable: false),
                        Ora13 = c.Boolean(nullable: false),
                        Ora14 = c.Boolean(nullable: false),
                        Ora15 = c.Boolean(nullable: false),
                        Ora16 = c.Boolean(nullable: false),
                        Ora17 = c.Boolean(nullable: false),
                        Ora18 = c.Boolean(nullable: false),
                        Ora19 = c.Boolean(nullable: false),
                        Ora20 = c.Boolean(nullable: false),
                        Ora21 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vineris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedic = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Ora08 = c.Boolean(nullable: false),
                        Ora09 = c.Boolean(nullable: false),
                        Ora10 = c.Boolean(nullable: false),
                        Ora11 = c.Boolean(nullable: false),
                        Ora12 = c.Boolean(nullable: false),
                        Ora13 = c.Boolean(nullable: false),
                        Ora14 = c.Boolean(nullable: false),
                        Ora15 = c.Boolean(nullable: false),
                        Ora16 = c.Boolean(nullable: false),
                        Ora17 = c.Boolean(nullable: false),
                        Ora18 = c.Boolean(nullable: false),
                        Ora19 = c.Boolean(nullable: false),
                        Ora20 = c.Boolean(nullable: false),
                        Ora21 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Medics", "Schimb", c => c.Int(nullable: false));
            DropColumn("dbo.Medics", "LuniInceput");
            DropColumn("dbo.Medics", "LuniFinal");
            DropColumn("dbo.Medics", "MartiInceput");
            DropColumn("dbo.Medics", "MartiFinal");
            DropColumn("dbo.Medics", "MiercuriInceput");
            DropColumn("dbo.Medics", "MiercuriFinal");
            DropColumn("dbo.Medics", "JoiInceput");
            DropColumn("dbo.Medics", "JoiFinal");
            DropColumn("dbo.Medics", "VineriInceput");
            DropColumn("dbo.Medics", "VineriFinal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medics", "VineriFinal", c => c.DateTime());
            AddColumn("dbo.Medics", "VineriInceput", c => c.DateTime());
            AddColumn("dbo.Medics", "JoiFinal", c => c.DateTime());
            AddColumn("dbo.Medics", "JoiInceput", c => c.DateTime());
            AddColumn("dbo.Medics", "MiercuriFinal", c => c.DateTime());
            AddColumn("dbo.Medics", "MiercuriInceput", c => c.DateTime());
            AddColumn("dbo.Medics", "MartiFinal", c => c.DateTime());
            AddColumn("dbo.Medics", "MartiInceput", c => c.DateTime());
            AddColumn("dbo.Medics", "LuniFinal", c => c.DateTime());
            AddColumn("dbo.Medics", "LuniInceput", c => c.DateTime());
            DropColumn("dbo.Medics", "Schimb");
            DropTable("dbo.Vineris");
            DropTable("dbo.Miercuris");
            DropTable("dbo.Martis");
            DropTable("dbo.Lunis");
            DropTable("dbo.Jois");
        }
    }
}
