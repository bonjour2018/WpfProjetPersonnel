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

/*FENETRE QUI SERT A AJOUTER DES PATIENTS S,ILS N,ONT PAS DE DOSSIER, AJOUTER DES ADMISSIONS EN SUIVANT DES REGLES D,AFFAIRES */

namespace NHL
{
    /// <summary>
    /// Logique d'interaction pour Admission.xaml
    /// </summary>
    public partial class Admission : Window
    {
        private decimal prixChambre = 0;
        Patient patient;
        DemandeAdmission dem;
        NHLEntities myBDD2;
        public Admission()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            List<Patient> pa = new List<Patient>();
            var query = from l in myBDD2.DemandeAdmissions
                        join p in myBDD2.Patients on l.idPatient equals p.id
                        select new { l.idMedecin,l.idPrepose,l.idPatient,l.idLit,p.nomAssurance,l.idCommo,l.dateAdmiss,l.dateConge,l.prix };
            dtAdmission.ItemsSource = query.ToList();//affichage des admissions courantes
            
            /*var query1 = from l in myBDD2.Patients
                        where l.pris==false
                        select new { l.id, l.nom, l.age, l.nomAssurance, l.parent, l.TypeIntervention, l.pris};*/

            foreach(Patient a in myBDD2.Patients) //pour afficher juste patient qui ne sont pas dans des admissions(pour etre dans une autre admissions il faut 
            {
                //avoir congé dans la precedente

                if (a.pris == false)
                    pa.Add(a);
            }
            dtPatient.ItemsSource =  myBDD2.Patients.ToList();

            CommoditeSup com = new CommoditeSup();
            // refresh de l,affichage des contenus de tous les combobox :Patients, Preposes,Medecins,Chgambres, Departements,Lits ...etc
            cbCommod.ItemsSource = myBDD2.CommoditeSups.ToList();
            cbMedecin.ItemsSource = myBDD2.Medecins.ToList();
            cbPrepose.ItemsSource = myBDD2.Preposes.ToList();
            cbPatient.ItemsSource = pa.ToList();
            cbDepartement.ItemsSource = myBDD2.Departement1.ToList();
           
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myBDD2 = new NHLEntities();
            refresh();
          
        }

        public bool verif()//verifier si aucune cases n,a ete oublié et verifier si regles d,affaires sont respectées
        { Patient p = cbPatient.SelectedItem as Patient;
            int count = 0;
            
            if ((cbLit.Text.Equals(""))|| (string.IsNullOrEmpty(dateAdmission.SelectedDate.ToString())))
            {
                MessageBox.Show("vous avez oublié la date d'admission ou de lit, sinon veuillez selectionner un lit dans une autre chambre", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if((rdStandard.IsChecked==false)&&(p.nomAssurance.Trim().Equals(""))) //si chambre standard n,a pas ete selectionnée et que Patient n,a aucune assurance
            { Departement1 dp = cbDepartement.SelectedItem as Departement1;
                foreach(Chambre g in myBDD2.Chambres) //verifier si les chambres dans le combobox (surtout celles qui sont standards) n,a aucun lit
                {  if ((g.idType == 4)&&(dp.prefixe.Equals(g.prefixe)))
                        count++;
                       
                 }
                if (count == 0)
                { prixChambre = 0; return true; }
                else
                {
                    MessageBoxResult reponse = MessageBox.Show("Etes vous sur que le patient prendra en charge les frais supp ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (reponse == MessageBoxResult.Yes)
                    { prixChambre = 1; return true;  }
                    else return false;
                }

            }
            return true;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            
            bool valider = verif();
            if(valider)
            { 
            DemandeAdmission dem1 = new DemandeAdmission();
            Patient pat = cbPatient.SelectedItem as Patient;
            CommoditeSup com = cbCommod.SelectedItem as CommoditeSup;
                Medecin m = cbMedecin.SelectedItem as Medecin;
                Prepose k = cbPrepose.SelectedItem as Prepose;
                Lit lit = cbLit.SelectedItem as Lit;
                if (prixChambre!=0) //appliquer les prix selon le type de la chambre(ici le patient accepte les frais )
                { 
                    if ((rdPrive.IsChecked==true)|| (rdSemi.IsChecked == true))
                    {

                        foreach(TypeChambre type1 in myBDD2.TypeChambres)
                        {
                            if ((type1.idType==1)||(type1.idType == 2))
                            {
                                prixChambre =  Convert.ToDecimal(type1.prix);
                                break;
                            }
                        }
                    }
                }
                pat.pris = true;
                prixChambre += Convert.ToDecimal( com.prix);
            dem1.idMedecin = m.idMedecin;
            dem1.idPatient = pat.id;
            dem1.idPrepose = k.idPrepose;
                lit.dispo = false;

                dem1.idLit = lit.idLit;
            dem1.idCommo = com.idCommo;
            dem1.dateAdmiss = dateAdmission.SelectedDate;
            dem1.nomAssurance = pat.nomAssurance;
                dem1.prix = prixChambre;
            myBDD2.DemandeAdmissions.Add(dem1); //ajout de l,admission
            myBDD2.SaveChanges();
            MessageBox.Show("Insertion réussie", "Bravo", MessageBoxButton.OK, MessageBoxImage.Information);
                refresh();
            }
            else
                MessageBox.Show("Verifiez les champs sélectionnés, ils ne correspondent pas au reglement, type de chambre et assurance privée ...etc", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
            prixChambre = 0;

        }

        private void cbDepartement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   //affichage des lits et des chambres correspondants au departement sélectionné

            Departement1 dep = cbDepartement.SelectedItem as Departement1;
            if(dep!=null)
            { 
            List<Chambre> chambre = new List<Chambre>();
            foreach (Chambre ch in myBDD2.Chambres.ToList())
            {
                string c = ch.prefixe.First().ToString();
                if (dep.prefixe.Equals(c))
                {
                    chambre.Add(ch);
                    
                }
            }
            cbChambre.ItemsSource = chambre;
            foreach (Chambre ch1 in cbChambre.ItemsSource)
                if (ch1.idType == 4)
                    cbChambre.SelectedValue = ch1;
            }
        }

        private void cbChambre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   //affichage des lits et du type de la chambre sélectionnée
            List<Lit> lit = new List<Lit>();
            int n = cbChambre.SelectedIndex;
            Chambre ch = cbChambre.SelectedItem as Chambre;
            var query = from a in myBDD2.Chambres
                        join b in myBDD2.TypeChambres on a.idType equals b.idType where a.idChambre == ch.idChambre
                        select new { b.Deisgnation };
            if(ch != null)
            { 
                foreach (Lit l in myBDD2.Lits)
                {
                    if ((l.idChambre.Trim().Equals(ch.idChambre.Trim()))&&(l.dispo==true))
                        lit.Add(l);
                }
                cbLit.ItemsSource = lit;

                string type = "";
                foreach (var item in query)
                    type += item.Deisgnation; 
                switch (type.Trim())
                {
                    case "standard": rdStandard.IsChecked = true;
                                
                        break;
                    case "privee":
                        rdPrive.IsChecked = true;
                        break;
                    case "semi privee":
                        rdSemi.IsChecked = true;
                        break;
                    default:break;
                }
            }
        }

        private void btnAjouterPatient_Click(object sender, RoutedEventArgs e)  //ajout de Patient (verifié au prealable qu,il n,existe pas)
        {
            if ((txtNomPatient.Text.Equals(""))|| (txtAgePatient.Text.Equals("")) || (txtNomParent.Text.Equals("")))
            {
                MessageBox.Show("Attention vous avez oublié un des champs", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {           bool existe = false;
                        foreach (Patient er in myBDD2.Patients)
                        {
                            if(er.nom.Trim().Equals(txtNomPatient.Text.Trim()))
                            {
                                existe = true;
                                MessageBox.Show("Patient existe deja ", "Bravo", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;

                            }
                        }
                        if(!existe)
                        { 
                            Patient p = new NHL.Patient();
                            p.nom = txtNomPatient.Text;
                            p.nomAssurance = txtAssure.Text;
                            p.age = int.Parse( txtAgePatient.Text);
                            p.parent = txtNomParent.Text;
                            p.pris = false;
                            // p.TypeIntervention = cbDepart.Text;
                            myBDD2.Patients.Add(p);
                            myBDD2.SaveChanges();
                            MessageBox.Show("Patient ajoutée avec succes ", "Bravo", MessageBoxButton.OK, MessageBoxImage.None);
                            refresh();
                         }
            }
            }
        

        private void txtAgePatient_PreviewKeyDown(object sender, KeyEventArgs e)//verifier que l,age soit juste des nombres
        {
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                //Détermine si la séquence de touches est un nombre du clavier.
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    if ((e.Key != Key.Back) && (e.Key != Key.Tab))
                    {
                        e.Handled = true;
                        MessageBox.Show("J'accepte uniquement les chiffres, désolé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }
            }
        }

        private void dtPatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   //affichage des infos du patient sélectionné dans le datagrid section "Patient"

            patient = dtPatient.SelectedItem as Patient;
            txtAgePatient.Text = patient.age.ToString();
            
            txtNomParent.Text = patient.parent.Trim();
            txtAssure.Text = patient.nomAssurance.Trim();
            txtNomPatient.Text = patient.nom.Trim();
        }

        private void cbPatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  //MessageBox d,infos indiquant au preposé de sélectionner Pediatrie si possible, puisque patient est mineur

            bool litLibre = false;
            Lit temp;
           Patient p = cbPatient.SelectedItem as Patient;
            if(p!=null)
            { 
               if (p.age<=16)
                {
                    foreach(Lit l in myBDD2.Lits.ToList())
                    {
                        if((l.idLit.StartsWith("P") )&&(l.dispo==true))
                        {
                            MessageBox.Show("Patient est mineur et il ya des lits disponibles dans Pediatrie s'il n'a pas de chirurgie", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            litLibre = true;
                            break;
                        }
                    }
                    if (!litLibre)
                    {
                        MessageBox.Show("Vous n,avez pas de place disponible pour le patient mineur dans Pediatrie, veuille choisir un autre deoartement", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    }
                }
            }


        }

        
        private void txtNomPatient_TextChanged(object sender, TextChangedEventArgs e)
        {  //verifie si Patient existe ou non dans la section Patient
            bool trouve = false;
            foreach (Patient p1 in myBDD2.Patients.ToList())
            {
                if (p1.nom.Trim().Equals(txtNomPatient.Text.Trim()))
                {
                    trouve = true;
                    txtNomPatient.Text = p1.nom;
                    txtNomParent.Text = p1.parent;
                    txtAssure.Text = p1.nomAssurance;
                    txtAgePatient.Text = p1.age.ToString();
                    break;
                }
            }
            
        }
    }
}
