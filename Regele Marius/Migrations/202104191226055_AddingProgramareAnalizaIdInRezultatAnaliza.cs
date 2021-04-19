namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProgramareAnalizaIdInRezultatAnaliza : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RezultatAnalizas", "ProgramareAnalizaId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RezultatAnalizas", "ProgramareAnalizaId");
        }
    }
}
