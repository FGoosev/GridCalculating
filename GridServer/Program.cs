using GridLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace GridServer
{
    class Program
    {
        public static void Main(string[] args)
        {

            HttpServerChannel channel = new HttpServerChannel(3000);
            ChannelServices.RegisterChannel(channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Controller), "Grid", WellKnownObjectMode.Singleton);
            Console.WriteLine("Введите раз доски: ");
            var num = Console.ReadLine();
            int n = 0;
            n = Convert.ToInt32(num);
            Console.WriteLine("Путь к ДЛЛ");
            var dll = Console.ReadLine();

            Assembly a = Assembly.LoadFile(dll);

            Type type = a.GetType("GrigJob.JobExecute");

            object obj = type.GetConstructor(new Type[0]).Invoke(new object[0]);



            JobDistributing.SetJob(n, obj, type);
            Console.ReadLine();
        }
    }
}
