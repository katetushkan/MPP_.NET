using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4
{
        class Program
        {
            static public void CopyFile(string filePath, string receiveDir)
            {
                string fileName = new FileInfo(filePath).Name;
                File.Copy(filePath, receiveDir + "\\" + fileName);

                Console.WriteLine($"Flow {Thread.CurrentThread.ManagedThreadId} copied files {filePath} in dirrectory A {receiveDir}");
            }

            static public void ProcessDir(string sourceDir, string receiveDir)
            {

                string path = new DirectoryInfo(sourceDir).Name;
                Directory.CreateDirectory(receiveDir + "\\" + path);

                Parallel.ForEach(Directory.GetFiles(sourceDir), (strFile) => CopyFile(strFile, receiveDir + "\\" + path));

                foreach (string s in Directory.GetDirectories(sourceDir, "**", SearchOption.AllDirectories))
                {
                    ProcessDir(s, receiveDir + "\\" + path);
                }
            }

            static void Main(string[] args)
            {
                string sourceDir, receiveDir;

                while (true)
                {
                    Console.WriteLine("Enter dirrectory to copy from: ");
                    sourceDir = Console.ReadLine();
                    if (Directory.Exists(sourceDir))
                        break;
                }

                while (true)
                {
                    Console.WriteLine("Enter dirrectory to send to: ");
                    receiveDir = Console.ReadLine();
                    if (Directory.Exists(receiveDir))
                        break;
                }

                foreach (string dir in Directory.GetDirectories(sourceDir))
                {
                    ProcessDir(dir, receiveDir);
                }

                Parallel.ForEach(Directory.GetFiles(sourceDir), (strFile) => CopyFile(strFile, receiveDir));

                Console.ReadLine();
            }
        }
    

}
