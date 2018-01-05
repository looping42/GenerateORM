using GenerateORM.Model;
using GenerateORM.ViewModel.Interface;
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

namespace GenerateORM.ViewModel

{
    public class DataConnexionViewModel : INotifyPropertyChanged, IDataConnexionModel
    {
        public DataConnexionViewModel()
        {
        }

        private string _bddSelected;
        private string _txtChaineConnexion;
        private Type_De_Bdd type_bddSelected;
        private ChoixLanguage choixLanguageSelected;
        private List<ChoixLanguage> language;

        private List<Type_De_Bdd> type_bdd;

        public Type_De_Bdd Type_bddSelected
        {
            get
            {
                return type_bddSelected;
            }
            set
            {
                if (type_bddSelected != value)
                {
                    type_bddSelected = value;
                    NotifyPropertyChanged(ref type_bddSelected, value);
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
            get { return Enum.GetValues(typeof(ViewModel.Type_De_Bdd)).Cast<ViewModel.Type_De_Bdd>().ToList(); }
            set
            {
                if (type_bdd != value)
                {
                    type_bdd = value;
                    NotifyPropertyChanged(ref type_bdd, value);
                }
            }
        }

        public string TxtChaineConnexion
        {
            get
            {
                if (string.IsNullOrEmpty(_txtChaineConnexion))
                {
                    _txtChaineConnexion = new DatabaseData().GetServiceIfEmpty();
                }
                return _txtChaineConnexion;
            }

            set
            {
                if (_txtChaineConnexion != value)
                {
                    _txtChaineConnexion = value;
                    NotifyPropertyChanged(ref _txtChaineConnexion, value);
                }
            }
        }

        public string BddSelected
        {
            get
            {
                return _bddSelected;
            }

            set
            {
                if (_bddSelected != value)
                {
                    _bddSelected = value;
                    NotifyPropertyChanged(ref _bddSelected, value);
                }
            }
        }

        public List<ChoixLanguage> Language
        {
            get { return Enum.GetValues(typeof(ViewModel.ChoixLanguage)).Cast<ViewModel.ChoixLanguage>().ToList(); }

            set
            {
                if (language != value)
                {
                    language = value;
                    NotifyPropertyChanged(ref language, value);
                }
            }
        }

        private bool NotifyPropertyChanged<T>(ref T variable, T valeur, [CallerMemberName] string nomPropriete = null)
        {
            if (object.Equals(variable, valeur)) return false;

            variable = valeur;

            NotifyPropertyChanged(nomPropriete);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }

        private RelayCommand _clickShowTable;

        public ICommand ClickShowTable
        {
            get
            {
                if (_clickShowTable == null)
                {
                    _clickShowTable = new RelayCommand(param => this.LoadChoixBdd());
                }
                return _clickShowTable;
            }
        }

        private void LoadChoixBdd()
        {
            string test1 = _bddSelected;
            string test = _txtChaineConnexion;
            string con = string.Format(Properties.Settings.Default.ConnectionModel, _txtChaineConnexion, _bddSelected);

            SqlTable sqlTable = new SqlTable(con);
            sqlTable.CreateTableClass();

            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                List<User> user = new List<User>();
                var identity = connection.Insert(user);
                // Do work here; connection closed on following line.
            }
            Table hostWindow = new Table(con);
            hostWindow.Show();
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