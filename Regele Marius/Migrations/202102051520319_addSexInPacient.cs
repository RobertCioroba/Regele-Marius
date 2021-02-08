namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSexInPacient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacients", "Gen", c => c.Int(nullable: false));
            DropColumn("dbo.Pacients", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pacients", "Sex", c => c.String());
            DropColumn("dbo.Pacients", "Gen");
        }
    }
}
