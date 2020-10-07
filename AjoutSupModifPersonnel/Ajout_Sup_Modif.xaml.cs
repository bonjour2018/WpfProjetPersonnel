using AjoutSupModifPersonnel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AjoutSupModifPersonnel
{
    /// <summary>
    /// Logique d'interaction pour Ajout_Sup_Modif.xaml
    /// </summary>
    public partial class Ajout_Sup_Modif : Window
    {
        private  static NHLEntities  myBDD1; 
        List<Prepose> prep = new List<Prepose>();
        List<Medecin> med = new List<Medecin>();

        public Ajout_Sup_Modif(NHLEntities myBDD)
        {
            InitializeComponent();
            myBDD1 = myBDD;
        }

        public void refresh()
        {
            var query = from l in myBDD1.Preposes
                        select new { l.idPrepose, l.nom };
            dataGrid.ItemsSource = query.ToList();
            var query1 = from l in myBDD1.Medecins
                         select new { l.idMedecin, l.nom };
            dtMedecin.ItemsSource = query1.ToList();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // dtPrepose.ItemsSource = myBDD1.Preposes.ToList();
            refresh();            
        }

    }
}
