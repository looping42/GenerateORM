using GenerateORM.ViewModel.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.ViewModel
{
    public enum ChoixLanguage { Csharp, Php };

    public enum Type_De_Bdd { Sql, MySql };

    public class DataConnexionLoadModel : IDataConnexionModel

    {
        public List<Type_De_Bdd> Type_Bdd
        {
            get { return Enum.GetValues(typeof(ViewModel.Type_De_Bdd)).Cast<ViewModel.Type_De_Bdd>().ToList(); }
            set { }
        }

        public List<ChoixLanguage> Language
        {
            get { return Enum.GetValues(typeof(ViewModel.ChoixLanguage)).Cast<ViewModel.ChoixLanguage>().ToList(); }
            set { }
        }
    }
}