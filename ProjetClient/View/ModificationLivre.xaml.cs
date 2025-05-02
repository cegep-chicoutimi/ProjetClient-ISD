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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BiblioAPI;
using ProjetClient.ViewModel;

namespace ProjetClient.View
{
    /// <summary>
    /// Logique d'interaction pour ModificationLivre.xaml
    /// </summary>
    public partial class ModificationLivre : UserControl
    {
        public ModificationLivre()
        {
            InitializeComponent();
            UpdateUI();
        }

        public void UpdateUI()
        {
            head_info.Header = Ressources.Ressource.head_info;
            head_livre.Header = Ressources.Ressource.head_livre;
            listColumn_Titre.Header = Ressources.Ressource.listColumn_Titre;
            label_auteur.Content = Ressources.Ressource.label_auteur;
            label_nbPages.Content = Ressources.Ressource.label_nbPages;
            label_titre.Content = Ressources.Ressource.label_titre;
            btn_modif.Content = Ressources.Ressource.btn_modif;
        }
    }
}
