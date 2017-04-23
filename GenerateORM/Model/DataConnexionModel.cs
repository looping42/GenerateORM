using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.Model
{
    public enum ChoixLanguage { Csharp, Php };

    public enum Type_De_Bdd { Sql, MySql };

    public class DataConnexionModel
    {
        public List<Type_De_Bdd> Type_Bdd
        {
            get { return Enum.GetValues(typeof(Model.Type_De_Bdd)).Cast<Model.Type_De_Bdd>().ToList(); }
        }

        public List<ChoixLanguage> Language
        {
            get { return Enum.GetValues(typeof(Model.ChoixLanguage)).Cast<Model.ChoixLanguage>().ToList(); }
        }
    }
}