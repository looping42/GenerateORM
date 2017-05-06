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
        //public void ChargeClient()
        //{
        //    LoadConnexion service = new LoadConnexion();
        //    ConnexionBdd client = service.Charger();
        //}

        private Type_De_Bdd type_bddSelected;
        private ChoixLanguage choixLanguageSelected;
        private string choixBdd;
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

        public string ChoixBddVal
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
    }
}