using GridLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace GridServer
{
    class Program
    {
        public static void Main(string[] args)
        {
            TcpServerChannel channel = new TcpServerChannel(3000);
            ChannelServices.RegisterChannel(channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(GridJobController), "Grid", WellKnownObjectMode.Singleton);
        }
    }
}
