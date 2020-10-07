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

namespace NHL
{
    /// <summary>
    /// Logique d'interaction pour Medecin.xaml
    /// </summary>
    public partial class MedecinConge : Window
    {
        NHLEntities myBDD2;
        public MedecinConge()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            var query = from l in myBDD2.DemandeAdmissions
                        //join p in myBDD2.Patients on l.idPatient equals p.id
                        select new { l.idMedecin, l.idPrepose, l.idPatient, l.idLit, l.idCommo, l.dateAdmiss, l.dateConge, l.nomAssurance };
            dtAdmission1.ItemsSource = query.ToList();
            /*var query1 = from l in myBDD2.Patients
                        select new { l.id, l.nom, l.age, l.nomAssurance,l.parent };
            dtPatient.ItemsSource = myBDD2.Patients.ToList();// query1.ToList();*/

            CommoditeSup com = new CommoditeSup();
            //lit.Add(new Lit());
            // cbCommod.a
           /* cbCommod.ItemsSource = myBDD2.CommoditeSups.ToList();
            // cbLit.ItemsSource = myBDD2.Lits.ToList();
            cbMedecin.ItemsSource = myBDD2.Medecins.ToList();
            cbPrepose.ItemsSource = myBDD2.Preposes.ToList();
            cbPatient.ItemsSource = myBDD2.Patients.ToList();
            cbDepartement.ItemsSource = myBDD2.Departement1.ToList();
            cbDepart.ItemsSource = myBDD2.Departement1.ToList();*/
            /*var query1 = from l in myBDD1.Medecins
                         select new { l.idMedecin, l.nom };
            dtMedecin.ItemsSource = query1.ToList();*/
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
