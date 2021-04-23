namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevenireLaPrimaVariantaDeProgram : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programs", "Data", c => c.DateTime());
            DropTable("dbo.Jois");
            DropTable("dbo.Lunis");
            DropTable("dbo.Martis");
            DropTable("dbo.Miercuris");
            DropTable("dbo.Vineris");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Vineris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedic = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Ora08 = c.Int(),
                        Ora09 = c.Int(),
                        Ora10 = c.Int(),
                        Ora11 = c.Int(),
                        Ora12 = c.Int(),
                        Ora13 = c.Int(),
                        Ora14 = c.Int(),
                        Ora15 = c.Int(),
                        Ora16 = c.Int(),
                        Ora17 = c.Int(),
                        Ora18 = c.Int(),
                        Ora19 = c.Int(),
                        Ora20 = c.Int(),
                        Ora21 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Miercuris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedic = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Ora08 = c.Int(),
                        Ora09 = c.Int(),
                        Ora10 = c.Int(),
                        Ora11 = c.Int(),
                        Ora12 = c.Int(),
                        Ora13 = c.Int(),
                        Ora14 = c.Int(),
                        Ora15 = c.Int(),
                        Ora16 = c.Int(),
                        Ora17 = c.Int(),
                        Ora18 = c.Int(),
                        Ora19 = c.Int(),
                        Ora20 = c.Int(),
                        Ora21 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Martis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedic = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Ora08 = c.Int(),
                        Ora09 = c.Int(),
                        Ora10 = c.Int(),
                        Ora11 = c.Int(),
                        Ora12 = c.Int(),
                        Ora13 = c.Int(),
                        Ora14 = c.Int(),
                        Ora15 = c.Int(),
                        Ora16 = c.Int(),
                        Ora17 = c.Int(),
                        Ora18 = c.Int(),
                        Ora19 = c.Int(),
                        Ora20 = c.Int(),
                        Ora21 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lunis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedic = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Ora08 = c.Int(),
                        Ora09 = c.Int(),
                        Ora10 = c.Int(),
                        Ora11 = c.Int(),
                        Ora12 = c.Int(),
                        Ora13 = c.Int(),
                        Ora14 = c.Int(),
                        Ora15 = c.Int(),
                        Ora16 = c.Int(),
                        Ora17 = c.Int(),
                        Ora18 = c.Int(),
                        Ora19 = c.Int(),
                        Ora20 = c.Int(),
                        Ora21 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jois",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedic = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Ora08 = c.Int(),
                        Ora09 = c.Int(),
                        Ora10 = c.Int(),
                        Ora11 = c.Int(),
                        Ora12 = c.Int(),
                        Ora13 = c.Int(),
                        Ora14 = c.Int(),
                        Ora15 = c.Int(),
                        Ora16 = c.Int(),
                        Ora17 = c.Int(),
                        Ora18 = c.Int(),
                        Ora19 = c.Int(),
                        Ora20 = c.Int(),
                        Ora21 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Programs", "Data");
        }
    }
}
