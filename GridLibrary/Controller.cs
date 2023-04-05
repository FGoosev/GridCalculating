using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLibrary
{
    public class Controller : MarshalByRefObject
    {
        public Job GetJob()
        {
            var job = JobDistributing.GetJob();
            if (job != null) Console.WriteLine("В работе");
            return job;
        }
        public JobResult Exe(Job job)
        {
            var execute = JobDistributing.GetExecute();
            if (execute == null) Console.WriteLine("Ошибка передачи Dll");
            Object[] objs = new Object[1];
            objs[0] = job;
            var result = execute.Type.GetMethod("Execute").Invoke(execute.Obj,objs);

            return (JobResult)result;
        }

        public void SetResult(JobResult res)
        {
            JobComparer.AddResult(res);
            Console.WriteLine($"Клиент посчитал {res.Count}, при индексе {res.LastValidId}");
        }
    }
}
