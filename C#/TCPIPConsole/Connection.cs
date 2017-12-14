using System;
using System.Net;
using System.Net.Sockets;

namespace TCPIPConsole
{
    public class Connection
    {
        public static int GetPort()
        {
            PORTTOP:
            Console.Clear();
            Console.Write("Port:");
            var input = Console.ReadLine();
            try
            {
                var port = Int32.Parse(input);
                if (port <= 65534 && port > 1204)
                    return port;
                else goto PORTTOP;
            }
            catch
            {
                goto PORTTOP;
            }
        }

        public static string GetIP()
        {
            string localIP = String.Empty;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
    }
}
