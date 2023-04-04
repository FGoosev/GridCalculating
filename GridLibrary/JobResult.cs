using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLibrary
{
    [Serializable]
    public class JobResult
    {
        public int Count { get; set; }
        public int LastValidId { get; set; }

    }
}
