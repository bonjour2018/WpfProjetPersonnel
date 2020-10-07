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

/*FENETRE QUI PERMET AU MEDECIN DE DONNER CONGÉ AUX PATIENTS AYANT UNE ADMISSION*/

namespace NHL
{
    /// <summary>
    /// Logique d'interaction pour CongeMedecin.xaml
    /// </summary>
    public partial class CongeMedecin : Window
    {
        NHLEntities myBDD2;
        public CongeMedecin()
        {
            InitializeComponent();
        }
        public void refresh()  //rafraichir les 2 datagrid, le combobox des admissions n,ayant ps eu de congé
        {
            List<DemandeAdmission> admisVal = new List<DemandeAdmission>();
            List<DemandeAdmission> admisconge = new List<DemandeAdmission>();
            //DemandeAdmission d = new DemandeAdmission();
            foreach (DemandeAdmission dem in myBDD2.DemandeAdmissions)
            {
                if (string.IsNullOrEmpty(dem.dateConge.ToString()))

                    admisVal.Add(dem);
                else
                    admisconge.Add(dem);
                    
            }
            dtAdmission1.ItemsSource = admisVal;
            dtAdmisConge.ItemsSource = admisconge;
            cbAdmis.DataContext = admisVal;
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myBDD2 = new NHLEntities();
           
            refresh();
            cbAdmis.SelectedIndex = -1;
        }

        private void cbAdmis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   //affichage du nom de patient associé a l,admission ayant un idAdmission
            txtNom.Text = String.Empty;
           DemandeAdmission dem = cbAdmis.SelectedItem as DemandeAdmission;
            if (dem != null)
                foreach (Patient l in myBDD2.Patients)
            {
                if (l.id==dem.idPatient)
                {
                    txtNom.Text = l.nom.Trim();
                }
            }
           
              
        }

      
        private void btnConge_Click(object sender, RoutedEventArgs e)
        {
            if (cbAdmis.SelectedIndex !=-1 )
            {
                DemandeAdmission dem = cbAdmis.SelectedItem as DemandeAdmission;
                foreach (Patient l in myBDD2.Patients)  //liberer le patient de l,admission (il pourra avoir une autre admission maintenant
                {
                    if (l.id==dem.idPatient)
                    {
                        l.pris = false;
                    }
                }
                foreach (Lit l in myBDD2.Lits)  //liberer le lit
                {
                    if (l.idLit == dem.idLit)
                    {
                        l.dispo = true;
                    }
                }
                
                dem.dateConge = datePicker1.SelectedDate;
                myBDD2.SaveChanges();
                MessageBox.Show("Operation de congé effectuée avec succes", "Bravo", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            refresh();
            cbAdmis.SelectedIndex = -1;
        }

       
    }
}
