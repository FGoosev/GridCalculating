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
using System.Runtime.Remoting.Channels.Http;

namespace GridClient
{
    
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            ChannelServices.RegisterChannel(new HttpChannel(), false);


            Controller controller = (Controller)Activator.GetObject(typeof(Controller), "http://localhost:3000/Grid");
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

                    
                    var hasJobs = false;
                    for(int i = 0; i < 100; i++)
                    {
                       
                        var job = controller.GetJob();
                        if (job == null) break;
                        hasJobs = true;
                        var start = DateTime.Now;
                        var res = controller.Exe(job);
                        var end = DateTime.Now;
                        Console.WriteLine((end - start).TotalMilliseconds + " ms." + " (X1 +X2)");
                        controller.SetResult(res);
                    }
                    
                    
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
