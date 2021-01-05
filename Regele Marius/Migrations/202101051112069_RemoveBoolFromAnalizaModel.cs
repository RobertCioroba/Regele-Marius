namespace Regele_Marius.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBoolFromAnalizaModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Analizas", "GlicemieActiv");
            DropColumn("dbo.Analizas", "NumarLeucociteActiv");
            DropColumn("dbo.Analizas", "NumarEritrociteActiv");
            DropColumn("dbo.Analizas", "HemoglobinaActiv");
            DropColumn("dbo.Analizas", "HematrocitActiv");
            DropColumn("dbo.Analizas", "VolumEritrocitarMediuActiv");
            DropColumn("dbo.Analizas", "ConcentratieMedieActiv");
            DropColumn("dbo.Analizas", "TrombociteActiv");
            DropColumn("dbo.Analizas", "VolumMediuTrombocitarActiv");
            DropColumn("dbo.Analizas", "PlachetocritActiv");
            DropColumn("dbo.Analizas", "MonociteActiv");
            DropColumn("dbo.Analizas", "NeutrofileActiv");
            DropColumn("dbo.Analizas", "EozinofileActiv");
            DropColumn("dbo.Analizas", "BazofileActiv");
            DropColumn("dbo.Analizas", "LimfociteActiv");
            DropColumn("dbo.Analizas", "ColesterolActiv");
            DropColumn("dbo.Analizas", "TriglicerideActiv");
            DropColumn("dbo.Analizas", "UreeActiv");
            DropColumn("dbo.Analizas", "CreatininaActiv");
            DropColumn("dbo.Analizas", "CalciuActiv");
            DropColumn("dbo.Analizas", "FierActiv");
            DropColumn("dbo.Analizas", "MagneziuActiv");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Analizas", "MagneziuActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "FierActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "CalciuActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "CreatininaActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "UreeActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "TriglicerideActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "ColesterolActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "LimfociteActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "BazofileActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "EozinofileActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "NeutrofileActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "MonociteActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "PlachetocritActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "VolumMediuTrombocitarActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "TrombociteActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "ConcentratieMedieActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "VolumEritrocitarMediuActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "HematrocitActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "HemoglobinaActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "NumarEritrociteActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "NumarLeucociteActiv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analizas", "GlicemieActiv", c => c.Boolean(nullable: false));
        }
    }
}
