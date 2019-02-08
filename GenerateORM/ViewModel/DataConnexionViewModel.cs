using GenerateORM.Model;
using GenerateORM.ViewModel.InterfaceOrm;
using GenerateORM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Ressource;

namespace GenerateORM.ViewModel
{
    public class DataConnexionViewModel : INotifyPropertyChanged, IDataConnexionModel
    {
        private string bddSelected;
        private string txtChaineConnexion;
        private Type_De_Bdd typebddSelected;
        private ChoixLanguage choixLanguageSelected;
        private List<ChoixLanguage> language;
        private List<Type_De_Bdd> typebdd;
        private RelayCommand clickShowTable;

        public DataConnexionViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Type_De_Bdd Type_bddSelected
        {
            get
            {
                return typebddSelected;
            }
            set
            {
                if (typebddSelected != value)
                {
                    typebddSelected = value;
                    NotifyPropertyChanged(ref typebddSelected, value);
                }
            }
        }

        public ChoixLanguage ChoixLanguageSelected
        {
            get
            {
                return choixLanguageSelected;
            }
            set
            {
                if (choixLanguageSelected != value)
                {
                    choixLanguageSelected = value;
                    NotifyPropertyChanged(ref choixLanguageSelected, value);
                }
            }
        }

        public List<Type_De_Bdd> Type_Bdd
        {
            get
            {
                return Enum.GetValues(typeof(ViewModel.Type_De_Bdd)).Cast<ViewModel.Type_De_Bdd>().ToList();
            }
            set
            {
                if (typebdd != value)
                {
                    typebdd = value;
                    NotifyPropertyChanged(ref typebdd, value);
                }
            }
        }

        public string TxtChaineConnexion
        {
            get
            {
                if (string.IsNullOrEmpty(txtChaineConnexion))
                {
                    txtChaineConnexion = DatabaseData.GetServiceIfEmpty();
                }
                return txtChaineConnexion;
            }

            set
            {
                if (txtChaineConnexion != value)
                {
                    txtChaineConnexion = value;
                    NotifyPropertyChanged(ref txtChaineConnexion, value);
                }
            }
        }

        public string BddSelected
        {
            get
            {
                return bddSelected;
            }

            set
            {
                if (bddSelected != value)
                {
                    bddSelected = value;
                    NotifyPropertyChanged(ref bddSelected, value);
                }
            }
        }

        public List<ChoixLanguage> Language
        {
            get
            {
                return Enum.GetValues(typeof(ViewModel.ChoixLanguage)).Cast<ViewModel.ChoixLanguage>().ToList();
            }

            set
            {
                if (language != value)
                {
                    language = value;
                    NotifyPropertyChanged(ref language, value);
                }
            }
        }

        public ICommand ClickShowTable
        {
            get
            {
                if (clickShowTable == null)
                {
                    clickShowTable = new RelayCommand(param => this.LoadChoixBdd());
                }
                return clickShowTable;
            }
        }

        public void NotifyPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }

        private bool NotifyPropertyChanged<T>(ref T variable, T valeur, [CallerMemberName] string nomPropriete = null)
        {
            if (object.Equals(variable, valeur))
            {
                return false;
            }
            variable = valeur;

            NotifyPropertyChanged(nomPropriete);
            return true;
        }

        private void LoadChoixBdd()
        {
            string test1 = bddSelected;
            string test = txtChaineConnexion;
            string con = string.Format(Properties.Settings.Default.ConnectionModel, txtChaineConnexion, bddSelected);

            SqlTable sqlTable = new SqlTable(con, SqlForSearchTableAndColumn.GetTable, SqlForSearchTableAndColumn.GetGetterSetter);
            sqlTable.CreateTableClass();

            List<StringBuilder> tables = new List<StringBuilder>();

            string path = TemporaryRepertory.CreateUniqueTempDirectory();
            GenerateClass generateClass = new GenerateClass();
            generateClass.CreateClass(tables, "test");
            generateClass.GenerateCSharpCode(path);
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                List<User> user = new List<User>();
                var identity = connection.Insert(user);
            }

            //Table hostWindow = new Table(con);
            //hostWindow.Show();
        }
    }

    public class User
    {
        [Key]
        private int TheId { get; set; }

        private string Name { get; set; }
        private int Age { get; set; }
    }
}