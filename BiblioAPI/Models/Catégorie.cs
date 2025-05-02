using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioAPI.Models
{
    public class Catégorie
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;

        public Catégorie(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }
    }
}
