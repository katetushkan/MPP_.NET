using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class MyTask : IAction
    {
        private string oldFilePath;
        private string newFilePath;


        public MyTask(string oldFilePath, string recvDir)
        {
            string fileName = new FileInfo(oldFilePath).Name;
            this.oldFilePath = oldFilePath;
            newFilePath = recvDir + "\\" + fileName;
        }

        public void Action()
        {
            if (!File.Exists(newFilePath))
            {
                File.Copy(oldFilePath, newFilePath);
                Console.WriteLine($"On the background of {oldFilePath} was created {newFilePath}");
            }
            else
            {
                Console.WriteLine($"this file are already copied {oldFilePath}");
            }
        }
    }
}
