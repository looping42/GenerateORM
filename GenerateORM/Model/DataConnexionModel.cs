using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.Model
{
    public enum ChoixLanguage { Csharp, Php };

    public enum Type_Bdd { Sql, MySql };

    public class DataConnexionModel : INotifyPropertyChanged

    {
        private ChoixLanguage choixBdd;
        private List<ChoixLanguage> language;
        private List<Type_Bdd> type_bdd;

        public List<Type_Bdd> TypeBdd
        {
            get
            {
                return type_bdd;
            }

            set
            {
                if (type_bdd != value)
                {
                    type_bdd = value;
                    RaisePropertyChanged("Type_Bdd");
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
                    RaisePropertyChanged("ChoixBdd");
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
                    RaisePropertyChanged("Language");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}