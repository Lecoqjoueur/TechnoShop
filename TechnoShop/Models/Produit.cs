using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoShop.Models
{
    public class Produit
    {
        [Key]
        public int IDProduit { get; set; }
        public string nom { get; set; }

        public string marque { get; set; }
        public string detail { get; set; }
        public Double prix { get; set; }

        public string Secret { get; set; }
        public virtual ICollection<Commande> Commandes { get; set; }
    }
}