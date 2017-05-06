using GenerateORM.ViewModel;
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
            //dataconnexion.ChargeClient();
        }

        private void Btn_LoadBddtable_Click(object sender, RoutedEventArgs e)
        {
            var t = this.DataContext;
            //var test1 = test.ChoixBddVal;
            //var t = this.DataContext;
        }
    }
}