using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.ViewModel.Interface
{
    public interface IDataConnexionModel
    {
        List<Type_De_Bdd> Type_Bdd { get; set; }
        List<ChoixLanguage> Language { get; set; }
    }
}