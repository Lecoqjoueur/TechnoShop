using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnoShop.Models
{
    public class Client
    {
        [Key]
        public int IDClient { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "le pseudo ne peut pas etre plus long que 50 lettres.")]
        [Column("Pseudo")]
        [Display(Name = "Pseudo")]
        public string pseudo { get; set; }
        [StringLength(50)]
        [Display(Name = "Adresse")]
        public string adresse { get; set; }
        [StringLength(50)]
        [Display(Name = "Email")]
        public string email { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Mot de Passe")]
        public string mdp { get; set; }

        public string Secret { get; set; }

        [Display(Name = "pseudo et mot de passe")]
        public string FullName
        {
            get
            {
                return pseudo + ", " + mdp;
            }
        }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}