namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRezultatAnalizaModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RezultatAnalizas", "Denumire", c => c.String());
            AddColumn("dbo.RezultatAnalizas", "Descriere", c => c.String());
            AddColumn("dbo.RezultatAnalizas", "Pret", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RezultatAnalizas", "Pret");
            DropColumn("dbo.RezultatAnalizas", "Descriere");
            DropColumn("dbo.RezultatAnalizas", "Denumire");
        }
    }
}
