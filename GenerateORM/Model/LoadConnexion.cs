using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.Model
{
    public class LoadConnexion
    {
        public ConnexionBdd Charger()
        {
            return new ConnexionBdd { Language = Enum.GetValues(typeof(ViewModel.ChoixLanguage)).Cast<ViewModel.ChoixLanguage>().ToList(), Type_Bdd = Enum.GetValues(typeof(ViewModel.Type_De_Bdd)).Cast<ViewModel.Type_De_Bdd>().ToList() };
        }
    }
}