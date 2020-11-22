namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPacientUserType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizators", "DataNastere", c => c.DateTime());
            AddColumn("dbo.Utilizators", "NrTelefon", c => c.Int());
            AddColumn("dbo.Utilizators", "Email", c => c.String());
            AddColumn("dbo.Utilizators", "Adresa", c => c.String());
            AddColumn("dbo.Utilizators", "Sex", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilizators", "Sex");
            DropColumn("dbo.Utilizators", "Adresa");
            DropColumn("dbo.Utilizators", "Email");
            DropColumn("dbo.Utilizators", "NrTelefon");
            DropColumn("dbo.Utilizators", "DataNastere");
        }
    }
}
