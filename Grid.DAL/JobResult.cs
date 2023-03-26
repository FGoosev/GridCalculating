using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.DAL
{
    public class JobResult
    {
        public int Count { get; set; }

        public JobResult(int count)
        {
            Count = count;
        }
    }
}
