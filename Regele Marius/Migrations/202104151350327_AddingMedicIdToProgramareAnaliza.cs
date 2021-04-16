namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMedicIdToProgramareAnaliza : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProgramareAnalizas", "MedicId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProgramareAnalizas", "MedicId");
        }
    }
}
