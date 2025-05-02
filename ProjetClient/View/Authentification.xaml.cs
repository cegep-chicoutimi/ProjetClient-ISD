using System.Windows;
using System.Windows.Controls;
using BiblioAPI;
using ProjetClient.ViewModel;

namespace ProjetClient.View
{
    /// <summary>
    /// Logique d'interaction pour Authentification.xaml
    /// </summary>
    public partial class Authentification : UserControl
    {
        public Authentification()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            AuthentificationVM authVM = (AuthentificationVM)this.DataContext;

            authVM.Password = passwordBox.Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthentificationVM authentificationVM = (AuthentificationVM)this.DataContext;
            if (!authentificationVM.Connection())
                MessageBox.Show("Identifiant invalide", "Invalide", MessageBoxButton.OK, MessageBoxImage.Error);

            else
            {
                APIBibliotheque apIBibliotheque = Window.GetWindow(this) as APIBibliotheque;


                if (apIBibliotheque != null)
                    apIBibliotheque.ChangeVisibility();
            }
        }

        public void UpdateUI()
        {
            label_nom.Content = Ressources.Ressource.label_nom;
            label_password.Content = Ressources.Ressource.label_password;
            btn_connection.Content = Ressources.Ressource.btn_connection;
        }
    }
}
