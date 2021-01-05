namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingInterventieModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Interventies", "DenumireInterventie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Interventies", "DenumireInterventie", c => c.String());
        }
    }
}
