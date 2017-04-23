using GenerateORM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.ViewModel
{
    public class DataConnexionViewModel
    {
        public ObservableCollection<DataConnexionModel> LanguagesLoad
        {
            get;
            set;
        }

        public void LoadCmdLanguage()
        {
            ObservableCollection<DataConnexionModel> languagePack = new ObservableCollection<DataConnexionModel>();
            languagePack.Add(new DataConnexionModel { Language = Enum.GetValues(typeof(Model.ChoixLanguage)).Cast<Model.ChoixLanguage>().ToList(), Type_Bdd = Enum.GetValues(typeof(Model.Type_De_Bdd)).Cast<Model.Type_De_Bdd>().ToList() });
            LanguagesLoad = languagePack;
        }
    }
}