using Grid.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLogic
{
    public class GridJobController : MarshalByRefObject
    {
        public Job GetJob()
        {
            var job = JobDistributing.GetJob();
            if (job != null) Console.WriteLine("В работе");
            return job;
        }

        public void SetResult(int count)
        {

        }
    }
}
