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
    /// Logique d'interaction pour fenPrepose.xaml
    /// </summary>
    public partial class fenPrepose : Window
    {
        public fenPrepose()
        {
            InitializeComponent();
        }

        private void btnAdm_Click(object sender, RoutedEventArgs e)
        {
            Admission adm=new Admission();
            adm.Show();
        }
    }
}
