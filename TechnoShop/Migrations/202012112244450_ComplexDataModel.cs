namespace TechnoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Client", "Pseudo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Client", "adresse", c => c.String(maxLength: 50));
            AlterColumn("dbo.Client", "email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Client", "mdp", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Client", "mdp", c => c.String());
            AlterColumn("dbo.Client", "email", c => c.String());
            AlterColumn("dbo.Client", "adresse", c => c.String());
            AlterColumn("dbo.Client", "Pseudo", c => c.String());
        }
    }
}
