using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLibrary
{
    public interface IJobExecute
    {
        JobResult Execute(Job job);
    }
}
