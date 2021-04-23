namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZileDinBoolInInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jois", "Ora08", c => c.Int());
            AlterColumn("dbo.Jois", "Ora09", c => c.Int());
            AlterColumn("dbo.Jois", "Ora10", c => c.Int());
            AlterColumn("dbo.Jois", "Ora11", c => c.Int());
            AlterColumn("dbo.Jois", "Ora12", c => c.Int());
            AlterColumn("dbo.Jois", "Ora13", c => c.Int());
            AlterColumn("dbo.Jois", "Ora14", c => c.Int());
            AlterColumn("dbo.Jois", "Ora15", c => c.Int());
            AlterColumn("dbo.Jois", "Ora16", c => c.Int());
            AlterColumn("dbo.Jois", "Ora17", c => c.Int());
            AlterColumn("dbo.Jois", "Ora18", c => c.Int());
            AlterColumn("dbo.Jois", "Ora19", c => c.Int());
            AlterColumn("dbo.Jois", "Ora20", c => c.Int());
            AlterColumn("dbo.Jois", "Ora21", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora08", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora09", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora10", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora11", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora12", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora13", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora14", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora15", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora16", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora17", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora18", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora19", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora20", c => c.Int());
            AlterColumn("dbo.Lunis", "Ora21", c => c.Int());
            AlterColumn("dbo.Martis", "Ora08", c => c.Int());
            AlterColumn("dbo.Martis", "Ora09", c => c.Int());
            AlterColumn("dbo.Martis", "Ora10", c => c.Int());
            AlterColumn("dbo.Martis", "Ora11", c => c.Int());
            AlterColumn("dbo.Martis", "Ora12", c => c.Int());
            AlterColumn("dbo.Martis", "Ora13", c => c.Int());
            AlterColumn("dbo.Martis", "Ora14", c => c.Int());
            AlterColumn("dbo.Martis", "Ora15", c => c.Int());
            AlterColumn("dbo.Martis", "Ora16", c => c.Int());
            AlterColumn("dbo.Martis", "Ora17", c => c.Int());
            AlterColumn("dbo.Martis", "Ora18", c => c.Int());
            AlterColumn("dbo.Martis", "Ora19", c => c.Int());
            AlterColumn("dbo.Martis", "Ora20", c => c.Int());
            AlterColumn("dbo.Martis", "Ora21", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora08", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora09", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora10", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora11", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora12", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora13", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora14", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora15", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora16", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora17", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora18", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora19", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora20", c => c.Int());
            AlterColumn("dbo.Miercuris", "Ora21", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora08", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora09", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora10", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora11", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora12", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora13", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora14", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora15", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora16", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora17", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora18", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora19", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora20", c => c.Int());
            AlterColumn("dbo.Vineris", "Ora21", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vineris", "Ora21", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora20", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora19", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora18", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora17", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora16", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora15", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora14", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora13", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora12", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora11", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora10", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora09", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Vineris", "Ora08", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora21", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora20", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora19", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora18", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora17", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora16", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora15", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora14", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora13", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora12", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora11", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora10", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora09", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Miercuris", "Ora08", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora21", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora20", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora19", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora18", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora17", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora16", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora15", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora14", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora13", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora12", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora11", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora10", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora09", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Martis", "Ora08", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora21", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora20", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora19", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora18", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora17", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora16", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora15", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora14", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora13", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora12", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora11", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora10", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora09", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lunis", "Ora08", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora21", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora20", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora19", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora18", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora17", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora16", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora15", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora14", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora13", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora12", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora11", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora10", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora09", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jois", "Ora08", c => c.Boolean(nullable: false));
        }
    }
}
