using GenerateORM.Model;
using GenerateORM.ViewModel.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.ViewModel
{
    public class DataConnexionViewModel : INotifyPropertyChanged, IDataConnexionModel
    {
        //public DataConnexionViewModel()
        //{
        //    LoadCmdLanguage();
        //}

        //public ObservableCollection<DataConnexionModel> LanguagesLoad
        //{
        //    get;
        //    set;
        //}

        //public void LoadCmdLanguage()
        //{
        //    ObservableCollection<DataConnexionModel> languagePack = new ObservableCollection<DataConnexionModel>();
        //    languagePack.Add(new DataConnexionModel { Language = Enum.GetValues(typeof(Model.ChoixLanguage)).Cast<Model.ChoixLanguage>().ToList(), Type_Bdd = Enum.GetValues(typeof(Model.Type_De_Bdd)).Cast<Model.Type_De_Bdd>().ToList() });
        //    LanguagesLoad = languagePack;
        //}

        private ChoixLanguage choixBdd;
        private List<ChoixLanguage> language;
        private List<Type_De_Bdd> type_bdd;

        public List<Type_De_Bdd> Type_Bdd
        {
            get { return type_bdd; }

            set
            {
                if (type_bdd != value)
                {
                    type_bdd = value;
                    NotifyPropertyChanged(ref type_bdd, value);
                }
            }
        }

        public ChoixLanguage ChoixBddVal
        {
            get
            {
                return choixBdd;
            }

            set
            {
                if (choixBdd != value)
                {
                    choixBdd = value;
                    NotifyPropertyChanged(ref choixBdd, value);
                }
            }
        }

        public List<ChoixLanguage> Language
        {
            get { return language; }

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
    }
}