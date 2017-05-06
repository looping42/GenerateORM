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

namespace GenerateORM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataConnexionViewModel dataConnexionViewModel = new DataConnexionViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = dataConnexionViewModel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            usr_Control_Connexion_BDD.Cmb_Type_Bdd.SelectedIndex = 0;
            usr_Control_Connexion_BDD.Cmb_Language.SelectedIndex = 0;
        }
    }
}