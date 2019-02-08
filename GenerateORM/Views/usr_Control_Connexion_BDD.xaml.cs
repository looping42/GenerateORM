using GenerateORM.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using Microsoft.SqlServer.Management.Smo;
using GenerateORM.Model;

namespace GenerateORM.Views
{
    /// <summary>
    /// Interaction logic for usr_Control_Connexion_BDD.xaml.
    /// </summary>
    public partial class Usr_Control_Connexion_BDD : UserControl
    {
        public Usr_Control_Connexion_BDD()
        {
            InitializeComponent();
            DataContext = new DataConnexionViewModel();
        }

        private void Btn_LoadBddtable_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Chaineconnexion.Text))
            {
            }
            Cmb_ChoixBdd.ItemsSource = DatabaseData.GetDatabaseNames(Txt_Chaineconnexion.Text);
            Cmb_ChoixBdd.SelectedIndex = 0;
        }
    }
}