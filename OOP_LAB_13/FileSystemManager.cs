using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_LAB_13
{
    class FileSystemManager
    {
        public static string FileInformation(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                return $"File Name : {fileInfo.FullName} \nCreate time : {fileInfo.CreationTime} \nChange time : {fileInfo.LastWriteTime} \nFile extension : {fileInfo.Extension}";
            }

            return default;
        }

        public static void SearchFile(string startDir, string fileName)
        {

            string[] file = new DirectoryInfo(startDir).GetFiles(fileName, SearchOption.AllDirectories)
                .Select(t => t.FullName).ToArray();
            foreach (var elements in file)
            {
                Console.WriteLine(elements);
            }
        }
        public static void SearchFileWithMask(string startDir, string fileMaskName)
        {
            SearchFile(startDir,fileMaskName);
        }

        public static void DrivesInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            foreach (var drives in driveInfo)
            {
                Console.WriteLine($"Drive name : {drives.Name} \nFree space : {drives.TotalFreeSpace.ToString()} \nFull volume : {drives.TotalSize.ToString()}");
            }
            Console.ResetColor();
        }

        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                DirectoryInfo createDirectory = Directory.CreateDirectory(path);
            }
            else
            {
                throw new Exception("We have this directory");
            }

        }

        public static void CreateFile(string fileName, string path, string content)
        {
            string currentPath = Path.Combine(path, fileName);
            if (!File.Exists(currentPath))
            {
                using (StreamWriter sw = File.CreateText(currentPath))
                {
                    File.Create(currentPath);
                    sw.Write(content);
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(currentPath))
                {
                    sw.Write(content);
                    sw.Close();
                }
            }
        }

        public static void ReadFile(string fileName, string path)
        {
            string currentPath = Path.Combine(path, fileName);
            if (File.Exists(currentPath))
            {
                using (StreamReader sw = File.OpenText(currentPath))
                {
                    string result = String.Empty;
                    while (!sw.EndOfStream)
                    {
                        result += sw.ReadLine() + "\n";
                    }
                    Console.WriteLine(result);
                }
            }
            else
            {
                throw new Exception("Error in working file");
            }
        }

    }
}
