using GenerateORM.Model;
using GenerateORM.ViewModel.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        //private string[] _choixBdd;
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

        /// <summary>
        ///
        /// </summary>
        //public string[] ChoixBdd
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(_txtChaineConnexion))
        //            return new DatabaseData().GetDatabaseNames(_txtChaineConnexion);
        //        else
        //            return new string[0];
        //    }
        //    set
        //    {
        //        if (_choixBdd != value)
        //        {
        //            _choixBdd = value;
        //            NotifyPropertyChanged(ref _choixBdd, value);
        //        }
        //    }
        //}

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

        //private RelayCommand _loadBddTable;

        //public ICommand LoadBddTable
        //{
        //    get
        //    {
        //        if (_loadBddTable == null)
        //        {
        //            _loadBddTable = new RelayCommand(param => this.LoadChoixBdd());
        //        }
        //        return _loadBddTable;
        //    }
        //}

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
            //if (string.IsNullOrEmpty(_txtChaineConnexion))
            string test1 = _bddSelected;
            string test = _txtChaineConnexion;
            //_choixBdd =
            // Save command execution logic
        }
    }

    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion Constructors

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameters)
        {
            return _canExecute == null ? true : _canExecute(parameters);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameters)
        {
            _execute(parameters);
        }

        #endregion ICommand Members
    }
}