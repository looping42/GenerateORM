using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.Model
{
    public class BddTable
    {
        public string Name { get; set; }
        public List<BddLine> BddLines { get; set; }
    }
}