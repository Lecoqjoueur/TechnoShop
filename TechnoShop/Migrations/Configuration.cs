namespace TechnoShop.Migrations
{
    using TechnoShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TechnoShop.DAL.MagasinContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TechnoShop.DAL.MagasinContext context)
        {
            var clients = new List<Client>
            {
                new Client{IDClient=1,pseudo="Carson",adresse="Tournai",email="client@mail.fr",mdp="1234"},
                new Client{IDClient=2,pseudo="Philippe",adresse="Mons",email="client2@mail.fr",mdp="12345"}
            };
            clients.ForEach(s => context.Clients.AddOrUpdate(p => p.pseudo, s));
            context.SaveChanges();

            var produits = new List<Produit>
            {
                new Produit{IDProduit=201,nom="Iphone 12",marque="Apple",detail="iphone de la marque Apple",prix=900.00},
                new Produit{IDProduit=202,nom="Samsung Galaxy S20",marque="Samsung",detail="Écran (pouces):6.2  pouces |Mémoire (Go):128  GB",prix=789.00}
            };
            produits.ForEach(s => context.Produits.AddOrUpdate(p => p.nom, s));
            context.SaveChanges();
            var commandes = new List<Commande>
            {
                new Commande{
                    IDClient = clients.Single(s => s.pseudo == "Alexander").IDClient,
                    IDProduit = produits.Single(c => c.nom == "Iphone" ).IDProduit,
                    Grade = Grade.A
                },
                new Commande{
                    IDClient = clients.Single(s => s.pseudo == "Alexander2").IDClient,
                    IDProduit = produits.Single(c => c.nom == "Iphone2" ).IDProduit,
                    Grade = Grade.B
                },
                new Commande{
                    IDClient = clients.Single(s => s.pseudo == "Alexander3").IDClient,
                    IDProduit = produits.Single(c => c.nom == "Iphone3" ).IDProduit,
                    Grade = Grade.C
                },
            };
            foreach (Commande e in commandes)
            {
                var enrollmentInDataBase = context.Commandes.Where(
                    s =>
                         s.Clients.IDClient == e.IDClient &&
                         s.Produits.IDProduit == e.IDProduit).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Commandes.Add(e);
                }
            }
            context.SaveChanges();
        }
    }

    }
