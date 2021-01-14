namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordAgain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Parola", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Parola", c => c.Int(nullable: false));
        }
    }
}
