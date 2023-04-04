using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLogic
{
    class JobComparer
    {
        static JobResult finalResult = new JobResult();

        public static void AddResult(JobResult result)
        {
            if (!JobDistributing.hasJob && result.LastValidId == JobDistributing.LastValidId)
            {
                
                finalResult.Count += result.Count;
                var str = $"Количество всех вариантов вариантов: {finalResult.Count}";
                Console.WriteLine(str);
                Console.ReadLine();
            }
        }
    }
}
