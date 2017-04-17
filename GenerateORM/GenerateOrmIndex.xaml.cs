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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataConnexionViewModel DataConnexionObject = new DataConnexionViewModel();
            DataConnexionObject.LoadCmdLanguage();
            string s = "";
            foreach (var item in DataConnexionObject.LanguagesLoad)
            {
                usr_Control_Connexion_BDD.Cmb_Language.ItemsSource = item.Language;
            }
            //usr_Control_Connexion_BDD.Cmb_Language.ItemsSource = DataConnexionObject.LanguagesLoad.Select(s => s.Language);
            //usr_Control_Connexion_BDD.Cmb_Language.ItemsSource = Enum.GetValues(typeof(Model.ChoixLanguage)).Cast<Model.ChoixLanguage>();
        }
    }
}