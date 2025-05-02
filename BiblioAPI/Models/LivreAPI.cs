using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioAPI.Models
{
    public class LivreAPI
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int NbPages { get; set; }
        public int AuteurId { get; set; }
        public int CategorieId { get; set; }
        public Auteur? Auteur { get; set; }
        public Catégorie? Catégorie { get; set; }
    }
}
