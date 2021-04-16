namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRezultatAnalizaModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RezultatAnalizas", "NumePacient", c => c.String());
            AddColumn("dbo.RezultatAnalizas", "PrenumePacient", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RezultatAnalizas", "PrenumePacient");
            DropColumn("dbo.RezultatAnalizas", "NumePacient");
        }
    }
}
