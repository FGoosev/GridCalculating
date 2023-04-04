using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLogic
{
    [Serializable]
    public class Job
    {
        public int SizeBoard { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
    }
}
