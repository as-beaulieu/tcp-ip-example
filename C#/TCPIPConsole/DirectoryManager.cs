using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TCPIPConsole
{
    public class DirectoryManager
    {
        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public static void ProcessDirectory(string targetDirectory)
        {
            var fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            var subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        internal static void PrintFiles(string targetPath)
        {
            if (File.Exists(targetPath))
            {
                //This path is a file
                ProcessFile(targetPath);
            }
            else if (Directory.Exists(targetPath))
            {
                //This path is a directory
                ProcessDirectory(targetPath);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", targetPath);
            }
        }

        internal static void InitializeDirectories(string inputPath, string outputPath)
        {
            if (!Directory.Exists(inputPath))
                Directory.CreateDirectory(inputPath);

            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);
        }

        public static void ProcessFile(string path)
        {
            Console.WriteLine("Processed File '{0}'.", path);
        }
    }
}
