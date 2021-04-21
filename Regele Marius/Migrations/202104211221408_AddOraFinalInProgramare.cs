namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOraFinalInProgramare : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProgramareAnalizas", "OraFinal", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProgramareAnalizas", "OraFinal");
        }
    }
}
