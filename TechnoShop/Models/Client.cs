using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoShop.Models
{
    public class Client
    {
        [Key]
        public int IDClient { get; set; }
        public string pseudo { get; set; }
        public string adresse { get; set; }
        public string email { get; set; }
        public string mdp { get; set; }

        public string Secret { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}