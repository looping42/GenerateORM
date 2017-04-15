using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.Model
{
    public enum ChoixLanguage { Csharp, Php };

    public class DataConnexionModel : INotifyPropertyChanged

    {
        private ChoixLanguage choixBdd;
        private List<ChoixLanguage> language;

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