using AjoutSupModifPersonnel;
using NHL;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

/*FENETRE D,AJOUT, DE MODIFICATION ET DE SUPPRESSION MEDECIN*/

namespace AjoutSupModifPersonnel
{
    /// <summary>
    /// Logique d'interaction pour Ajout_Sup_Modif.xaml
    /// </summary>
    public partial class Ajout_Sup_Modif : Window
    {
        private static NHLEntities myBDD1;
        List<Prepose> prep = new List<Prepose>();
        List<Medecin> med = new List<Medecin>();

        public Ajout_Sup_Modif()
        {
            InitializeComponent();
            
        }

        public void refresh()//rafraichissement du combobox de IdMedecin
        {
            dtMedecin.ItemsSource = myBDD1.Medecins.ToList();
            dtMedecin.SelectedIndex = -1;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // dtPrepose.ItemsSource = myBDD1.Preposes.ToList();
            myBDD1 = new NHLEntities();
            refresh();

        }

        
        private void btnAjouterMed_Click(object sender, RoutedEventArgs e)
        {
            bool trouve = false;
            if ( !string.IsNullOrEmpty(txtMedecin.Text.Trim()))
            {
                foreach (Medecin p1 in myBDD1.Medecins.ToList())
                {
                    if (p1.nom.Trim().Equals(txtMedecin.Text.Trim())) //verifier si medecin existe deja avant de l,ajouter
                    {
                        trouve = true;
                        MessageBox.Show("Dossier Médecin existe deja", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                }
                if (!trouve)  //si medecin qu.on veut ajouter n,existe pas
                {
                    Medecin p = new Medecin();
                    p.nom = txtMedecin.Text.Trim();

                    myBDD1.Medecins.Add(p);
                    myBDD1.SaveChanges();
                    refresh();
                    MessageBox.Show("Dossier Médecin Ajouté", "Fait", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

       
        private void dtMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin p = dtMedecin.SelectedItem as Medecin; //afficher idmedecin et nom en cliquant dans le datagrid medecin
            if (p != null)
            {
                txtMedecin.Text = p.nom;
                txtIdMedecin.Text = p.idMedecin.ToString();
            }
        }

        private void btnModifMed_Click(object sender, RoutedEventArgs e)  //modifier infos d,un medecin existant
        {
            if (!string.IsNullOrEmpty(txtMedecin.Text.Trim()))
            {
                
                    Medecin p = new Medecin();
                    foreach (Medecin p1 in myBDD1.Medecins.ToList())
                    {
                        if (p1.idMedecin==int.Parse(txtIdMedecin.Text.Trim()))
                        {
                        p1.nom = txtMedecin.Text.Trim();
                        }
                    }
                    myBDD1.SaveChanges();
                    refresh();
                MessageBox.Show("Dossier Médecin modifié", "Fait", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

      
        /*Suppression d,un dossier medecin avec un clique droit dans le datagrid*/
        private void dtMedecin_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           MessageBoxResult reponse=MessageBox.Show("Voulez-vous vraiment supprimer l'enregistrement sélectionné ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (reponse==MessageBoxResult.Yes)
            {
                Medecin med = dtMedecin.SelectedItem as Medecin;
                myBDD1.Medecins.Remove(med);
                myBDD1.SaveChanges();
                dtMedecin.SelectedIndex = -1;
                refresh();
                MessageBox.Show("Dossier Médecin supprimé", "Fait", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
