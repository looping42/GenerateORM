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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = new GenerateORM.ViewModel.DataConnexionViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataConnexionViewModel DataConnexionObject = new DataConnexionViewModel();
            DataConnexionObject.LoadCmdLanguage();

            foreach (var item in DataConnexionObject.LanguagesLoad)
            {
                usr_Control_Connexion_BDD.Cmb_Language.ItemsSource = item.Language;
                usr_Control_Connexion_BDD.Cmb_Language.SelectedIndex = 0;
                usr_Control_Connexion_BDD.Cmb_TypeBdd.ItemsSource = item.TypeBdd;
            }
            usr_Control_Connexion_BDD.Cmb_Language.SelectedIndex = 0;
            usr_Control_Connexion_BDD.Cmb_TypeBdd.SelectedIndex = 0;
        }
    }
}