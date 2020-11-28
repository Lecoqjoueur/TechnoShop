using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TechnoShop.Models;

namespace TechnoShop.DAL
{
    public class MagasinInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MagasinContext>
    {
        protected override void Seed(MagasinContext context)
        {
            var clients = new List<Client>
            {
                new Client{IDClient=1,pseudo="Carson",adresse="Tournai",email="client@mail.fr",mdp="1234"},
                new Client{IDClient=2,pseudo="Philippe",adresse="Mons",email="client2@mail.fr",mdp="12345"}
            };
            clients.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();

            var produits = new List<Produit>
            {
                new Produit{IDProduit=201,nom="Iphone 12",marque="Apple",detail="iphone de la marque Apple",prix=900.00},
                new Produit{IDProduit=202,nom="Samsung Galaxy S20",marque="Samsung",detail="Écran (pouces):6.2  pouces |Mémoire (Go):128  GB",prix=789.00}
            };
            produits.ForEach(s => context.Produits.Add(s));
            context.SaveChanges();
            var commandes = new List<Commande>
            {
                new Commande{IDCommande=1,IDClient=1,IDProduit=201,quantite=1},
                new Commande{IDCommande=2,IDClient=1,IDProduit=202,quantite=1},
                new Commande{IDCommande=3,IDClient=2,IDProduit=201,quantite=1}
            };
            commandes.ForEach(s => context.Commandes.Add(s));
            context.SaveChanges();
        }
    }
}