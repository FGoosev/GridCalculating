using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GridLibrary
{
    [Serializable]
    public class ImportDll
    {
        public object Obj { get; set; }
        public Type Type { get; set; }
    }
}
