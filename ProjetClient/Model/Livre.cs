using BiblioAPI.Models;

namespace ProjetClient.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int NbPages { get; set; }
        public int AuteurId { get; set; }
        public int CategorieId { get; set; }
        public Auteur? Auteur { get; set; }
        public Catégorie? Catégorie { get; set; }

        public Livre() { }

        public Livre(LivreAPI livre)
        {
            Id = livre.Id;
            Titre = livre.Titre;
            ISBN = livre.ISBN ;
            NbPages = livre.NbPages;
            AuteurId = livre.AuteurId;
            CategorieId = livre.CategorieId;
            Auteur = livre.Auteur;
            Catégorie = livre.Catégorie;

        }
    }
}
