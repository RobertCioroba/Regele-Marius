namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingRolesData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Roles (Nume) VALUES('Administrator')");
            Sql("INSERT INTO Roles (Nume) VALUES('Pacient')");
            Sql("INSERT INTO Roles (Nume) VALUES('Medic')");
            Sql("INSERT INTO Roles (Nume) VALUES('Laborant')");
        }
        
        public override void Down()
        {
        }
    }
}
