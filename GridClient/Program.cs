using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Reflection;
using GridLibrary;

namespace GridClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpChannel(), false);
           

            GridJobController controller = (GridJobController)Activator.GetObject(typeof(GridJobController), "tcp://localhost:3000/Grid");
            if(controller == null)
            {
                Console.WriteLine("Локальный сервер не найден");
                return;
            }

            bool q = false;

            while (!q)
            {
                try
                {
                    IJobExecute exe;
                    var start = DateTime.Now;
                    var hasJobs = false;
                    for(int i = 0; i < 100; i++)
                    {
                        var job = controller.GetJob();
                        if (job == null) break;
                        hasJobs = true;
                        var res = exe.Execute(job);

                        controller.SetResult(res);
                    }
                    var end = DateTime.Now;
                    if(hasJobs) Console.WriteLine((end - start).TotalMilliseconds + " ms.");
                    System.Threading.Thread.Sleep(500);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }

                if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Q) break;
            }

        }
    }
}
