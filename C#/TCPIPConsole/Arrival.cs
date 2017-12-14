using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TCPIPConsole
{
    public class Arrival
    {
        public static void ReceiveFile(Settings programSettings)
        {
            var port = Connection.GetPort();
            Console.WriteLine("Getting IP...");
            var ip = Connection.GetIP();
            Console.WriteLine("Opening Port: " + port);
            var listener = new TcpListener(IPAddress.Any, 100);//Bypass Compilier
            try
            {
                listener = new TcpListener(IPAddress.Parse(ip), port);
            }
            catch
            {
                Console.WriteLine("ERROR Failed to open port");
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("Port Open");
            Console.WriteLine("Waiting for connection on IP " + ip + " port: " + port);

            //Wait for sender
            listener.Start();
            while (true)
            {
                if (listener.Pending())
                    break;
            }

            using (var client = listener.AcceptTcpClient())
            using (var stream = client.GetStream())
            using (var output = File.Create(programSettings.outputPath + @"\Data"))
            {
                Console.WriteLine("Connected: " + client.Client.LocalEndPoint.ToString());
                Console.WriteLine("Receiving Data");

                //Read the file in chunks of 1KB (as Default)
                var buffer = new byte[programSettings.BytesPerRead];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    output.Write(buffer, 0, bytesRead);
            }

            Console.WriteLine("File Received.");
            Console.WriteLine("Closing port...");
            listener.Stop();
            Console.WriteLine("Data at:" + programSettings.outputPath + @"\Data");
            Console.ReadLine();

        }
    }
}
