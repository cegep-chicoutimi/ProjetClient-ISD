using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BiblioAPI;
using ProjetClient.Models;
using ProjetClient.Ressources;
using ProjetClient.ViewModel;

namespace ProjetClient.View
{
    /// <summary>
    /// Logique d'interaction pour APIBibliotheque.xaml
    /// </summary>
    public partial class APIBibliotheque : Window
    {
        public event EventHandler LanguageChanged;

        GestionnaireLivres gestionnaireLivres = new GestionnaireLivres();
        public APIBibliotheque()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            ResourceHelper.SetInitialLanguage();
            UpdateUI();

            this.DataContext = new ThemeVM();

            Authentification.DataContext = new AuthentificationVM(gestionnaireLivres);
        }

        public void ChangeVisibility()
        {
            Authentification.Visibility = Visibility.Collapsed;
            Modification.Visibility = Visibility.Visible;
            Modification.DataContext = new ModificationVM(gestionnaireLivres);

        }

        public void LanguageSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedItem = languageSelector.SelectedItem as System.Windows.Controls.ComboBoxItem;

            if (selectedItem != null)
            {
                string? cultureCode = selectedItem.Tag.ToString();
                ResourceHelper.SetCulture(cultureCode);
                UpdateUI();
            }

            OnLanguageChanged();
        }

        private void OnLanguageChanged()
        {
            LanguageChanged?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateUI()
        {
            label_theme.Content = Ressources.Ressource.label_theme;
            Modification.UpdateUI();
            Authentification.UpdateUI();
        }
    }
}
