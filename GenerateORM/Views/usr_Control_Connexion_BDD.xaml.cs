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
    /// Interaction logic for usr_Control_Connexion_BDD.xaml
    /// </summary>
    public partial class usr_Control_Connexion_BDD : UserControl
    {
        public usr_Control_Connexion_BDD()
        {
            InitializeComponent();
            DataContext = new DataConnexionViewModel();
        }

        private void Btn_LoadBddtable_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Chaineconnexion.Text))
            {
            }
            Cmb_ChoixBdd.ItemsSource = new DatabaseData().GetDatabaseNames(Txt_Chaineconnexion.Text);
        }

        ///// <summary>
        ///// Récupére toute les bases de données correspondant au serveur passé en paramétres
        ///// </summary>
        ///// <param name = "serverName" ></ param >
        ///// < returns ></ returns >
        //public static string[] GetDatabaseNames(string serverName)
        //{
        //    var server = new Server(serverName);
        //    return (from Database database in server.Databases
        //            where !database.IsSystemObject && !database.IsDatabaseSnapshot
        //            select database.Name
        //           ).ToArray();
        //}
    }
}