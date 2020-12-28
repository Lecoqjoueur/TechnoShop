namespace TechnoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        IDClient = c.Int(nullable: false, identity: true),
                        pseudo = c.String(),
                        adresse = c.String(),
                        email = c.String(),
                        mdp = c.String(),
                        Secret = c.String(),
                    })
                .PrimaryKey(t => t.IDClient);
            
            CreateTable(
                "dbo.Commande",
                c => new
                    {
                        IDCommande = c.Int(nullable: false, identity: true),
                        IDClient = c.Int(nullable: false),
                        IDProduit = c.Int(nullable: false),
                        quantite = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.IDCommande)
                .ForeignKey("dbo.Client", t => t.IDClient, cascadeDelete: true)
                .ForeignKey("dbo.Produit", t => t.IDProduit, cascadeDelete: true)
                .Index(t => t.IDClient)
                .Index(t => t.IDProduit);
            
            CreateTable(
                "dbo.Produit",
                c => new
                    {
                        IDProduit = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        marque = c.String(),
                        detail = c.String(),
                        prix = c.Double(nullable: false),
                        Secret = c.String(),
                    })
                .PrimaryKey(t => t.IDProduit);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commande", "IDProduit", "dbo.Produit");
            DropForeignKey("dbo.Commande", "IDClient", "dbo.Client");
            DropIndex("dbo.Commande", new[] { "IDProduit" });
            DropIndex("dbo.Commande", new[] { "IDClient" });
            DropTable("dbo.Produit");
            DropTable("dbo.Commande");
            DropTable("dbo.Client");
        }
    }
}
