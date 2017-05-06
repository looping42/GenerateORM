using GenerateORM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.Model
{
    public class ConnexionBdd
    {
        public List<ChoixLanguage> Language { get; set; }
        public List<Type_De_Bdd> Type_Bdd { get; set; }
    }
}