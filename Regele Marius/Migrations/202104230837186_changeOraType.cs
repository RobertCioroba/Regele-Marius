namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeOraType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProgramareAnalizas", "OraInceput", c => c.String());
            AlterColumn("dbo.ProgramareAnalizas", "OraFinal", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProgramareAnalizas", "OraFinal", c => c.DateTime());
            AlterColumn("dbo.ProgramareAnalizas", "OraInceput", c => c.DateTime());
        }
    }
}
