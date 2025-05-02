using BiblioAPI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjetClient.Models;

namespace ProjetClient.ViewModel
{
    partial class AuthentificationVM : ObservableObject
    {
        private GestionnaireLivres gestionnaireLivres;
        private string apiKey;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;


        public AuthentificationVM(GestionnaireLivres gestionnaireLivres)
        {
            this.gestionnaireLivres = gestionnaireLivres;
        }

        public async void Verification()
        {
            apiKey = await BiblioProcessor.Authentification(Username, Password);
            apiKey = apiKey.Trim('"');

            ApiHelper.InsertApikey(apiKey);
        }

        public bool Connection()
        {
           Verification();

            return apiKey != null;
        }
    }
}
