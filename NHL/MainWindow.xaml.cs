using AjoutSupModifPersonnel;
using ClassNHL;
using System;
using System.Collections.Generic;
using System.Windows;
/// <summary>

    /* FENETRE INITIALE : CONNEXION DES USERS : admin, prepose, medecin*/

/// </summary>
namespace NHL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static NHLEntities myBDD;
        Ajout_Sup_Modif adm;
        Admission adm1;
        CongeMedecin adm2;
        public static int tentative = 3;
        List<Utilisateur> UserMdp = new List<Utilisateur> { new Utilisateur("admin", "admin"), new Utilisateur("prepose", "prepose"), new Utilisateur("medecin", "medecin") };

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult reponse = MessageBox.Show("etes vous sur de vouloir quitter ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (reponse == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        public Boolean trouve(string a, string b)
        {
            foreach (Utilisateur e1 in UserMdp)
            {
                if (e1.Username.Equals(a) && e1.Password.Equals(b))
                {
                    switch (a)
                    {
                        case "admin":
                            adm = new Ajout_Sup_Modif();
                            adm.Show();
                            break;
                        case "prepose":  adm1 = new Admission();
                            adm1.Show();
                            break;
                         case "medecin":
                             adm2 = new CongeMedecin();
                             adm2.Show();
                            break;

                        default: break;
                    }
                    return true;
                }
                
            }
            return false;
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUser.Text;
            string mdp = txtMdp.Password;
            if (!trouve(user, mdp))
            {
                tentative--;
                MessageBox.Show("Erreur d'authentification, il vous reste " + tentative + " tentative(s)", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                if (tentative == 0)
                {
                    MessageBox.Show("Vous n'avez plus de possibilites de continuer, l'application va fermer toute seule", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    Application.Current.Shutdown();
                }
            }
            else
            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myBDD = new NHLEntities();
        }
    }
}
