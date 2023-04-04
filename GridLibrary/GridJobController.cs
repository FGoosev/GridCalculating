using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLibrary
{
    public class GridJobController : MarshalByRefObject
    {
        public Job GetJob()
        {
            var job = JobDistributing.GetJob();
            if (job != null) Console.WriteLine("В работе");
            return job;
        }

        public void SetResult(JobResult res)
        {
            JobComparer.AddResult(res);
            Console.WriteLine($"Клиент посчитал {res.Count}, при индексе {res.LastValidId}");
        }
    }
}
