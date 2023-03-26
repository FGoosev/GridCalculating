using Grid.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            Job job = new Job();
            JobExecute jobExecute = new JobExecute();

            job.SizeBoard = 4;
            job.StartIndex = 1;
            job.EndIndex = 65535;

            var res = jobExecute.Execute(job);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
