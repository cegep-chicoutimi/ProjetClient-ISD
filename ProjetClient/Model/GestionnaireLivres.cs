using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioAPI;
using BiblioAPI.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjetClient.Models
{
    internal class GestionnaireLivres: ObservableObject
    {
        public string apiKey {  get; set; }
        public ObservableCollection<Livre> Livres {  get; set; }
        public ObservableCollection<Auteur> Auteurs { get; set; }

        public GestionnaireLivres() 
        {
            Livres = new ObservableCollection<Livre>();
            Auteurs = new ObservableCollection<Auteur>();
        }

        public async void ChargerLivre()
        {
            List<LivreAPI> livreAPIs = await BiblioProcessor.GetAllLivre();

            foreach (LivreAPI livreAPI in livreAPIs)
            {
                Livres.Add(new Livre(livreAPI));
            }
        }

        public async void ChargerAuteurs()
        {
            List<Auteur> auteurs = await BiblioProcessor.GetAllAuteur();

            foreach (Auteur auteur in auteurs)
            {
                Auteurs.Add(auteur);
            }
        }
    }
}
