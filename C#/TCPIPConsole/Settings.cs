using System;

namespace TCPIPConsole
{
    public class Settings
    {
        //bool mode;// true=send, false=receive
        public string inputPath { get; set; }//= @"Upload\";//Files send
        public string outputPath { get; set; }//= @"Download\";//Files received
        public int BytesPerRead { get; set; }//= 1024;//Buffer to read before writing

        public Settings(string inputPath, string outputPath, int bytesPerRead)
        {
            this.inputPath = inputPath;
            this.outputPath = outputPath;
            this.BytesPerRead = bytesPerRead;
        }

        public static bool SetSettingMode()
        {
            SETTINGSTOP:
            Console.Clear();
            Console.Write("elect to Send or Receive files: ");
            var input = Console.ReadLine();
            if (input.StartsWith("r"))
            {
                return false;
            }
            else if (input.StartsWith("s"))
            {
                return true;
            }
            else goto SETTINGSTOP;
        }
    }
}
