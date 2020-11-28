using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoShop.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Commande
    {
        [Key]
        public int IDCommande { get; set; }
        public int IDClient { get; set; }
        public int IDProduit { get; set; }

        public int quantite { get; set; }
        public Grade? Grade { get; set; }

        public virtual Client Clients { get; set; }
        public virtual Produit Produits { get; set; }
    }
}