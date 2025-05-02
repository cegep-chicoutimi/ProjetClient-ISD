using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using BiblioAPI;
using BiblioAPI.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjetClient.Models;
using ProjetClient.View;

namespace ProjetClient.ViewModel
{
    partial class ModificationVM : ObservableObject
    {
        private GestionnaireLivres gestionnaireLivres;
        private LivreAPI livreAPI;

        [ObservableProperty]
        private ObservableCollection<Livre> livreCollection;

        [ObservableProperty]
        private Livre livre;

        [ObservableProperty]
        private Livre livreSelectionner;

        [ObservableProperty]
        private ObservableCollection<Auteur> auteurCollection;

        [ObservableProperty]
        private Auteur auteurSelectionner;

        public ModificationVM(GestionnaireLivres gestionnaireLivres)
        {
            livreAPI = new LivreAPI();
            this.gestionnaireLivres = gestionnaireLivres;

            this.gestionnaireLivres.ChargerLivre();
            LivreCollection = gestionnaireLivres.Livres;

            this.gestionnaireLivres.ChargerAuteurs();
            AuteurCollection = gestionnaireLivres.Auteurs;
        }

        [RelayCommand]
        public void Enregistrer()
        {
            LivreSelectionner.Auteur = AuteurSelectionner;

            livreAPI.Id = LivreSelectionner.Id;
            livreAPI.Titre = LivreSelectionner.Titre;
            livreAPI.ISBN = LivreSelectionner.ISBN;
            livreAPI.NbPages = LivreSelectionner.NbPages;
            livreAPI.Auteur = LivreSelectionner.Auteur;
            livreAPI.Catégorie = LivreSelectionner.Catégorie;

            livreAPI.AuteurId = AuteurSelectionner.Id;
            livreAPI.CategorieId = LivreSelectionner.CategorieId;

            Envoi();
        }

        public async void Envoi()
        {
            HttpResponseMessage responseMessage = await BiblioProcessor.PutLivre(livreAPI);

            if (responseMessage.IsSuccessStatusCode)
            {

            }
        }

    }
}
