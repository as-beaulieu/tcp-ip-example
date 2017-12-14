using System;
using System.IO;

namespace TCPIPConsole
{
    public class Application
    {
        public static void Start()
        {
            var programSettings = new Settings(@"Upload\", @"Download\", 1024);

            Console.Clear();
            Console.Title = "Research File Transfer TCP/IP";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;

            DirectoryManager.InitializeDirectories(programSettings.inputPath, programSettings.outputPath);

            Console.WriteLine("press any key to continue...");
            Console.ReadLine();

            var fileMode = Settings.SetSettingMode();
            if (fileMode)
                Departure.SendFile(programSettings);
            else
                Arrival.ReceiveFile(programSettings);
        }
    }
}
