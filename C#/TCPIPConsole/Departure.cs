using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TCPIPConsole
{
    public class Departure
    {
        public static void SendFile(Settings programSettings)
        {
            SENDTOP:
            Console.Clear();
            DirectoryManager.PrintFiles(programSettings.inputPath);
            Console.Write("File to Upload: ");
            var file = Console.ReadLine();
            if (File.Exists(file))
            {
                FILETOP:
                Console.Clear();
                Console.Write("IP to send to: ");
                var ip = Console.ReadLine();
                try
                {
                    IPAddress.Parse(ip);
                }
                catch
                {
                    goto FILETOP;
                }
                var port = Connection.GetPort();

                //Sending File:
                Console.Clear();
                Console.WriteLine("Connecting...");
                var soc = new TcpClient(ip, port);
                Console.WriteLine("Connected!");
                Console.WriteLine("Sending File...");
                Console.WriteLine(file);
                Console.WriteLine("To IP:" + ip + "  port:" + port);
                soc.Client.SendFile(file);
                Console.WriteLine("Done!");
                Console.WriteLine("Closing Port");
                soc.Close();
                Console.WriteLine("Done!");
            }
            else goto SENDTOP;
        }
    }
}
