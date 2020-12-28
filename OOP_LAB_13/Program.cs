using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Search File-----");
            FileSystemManager.SearchFile(@"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_13","Program.cs");
            Console.WriteLine("---------------------");
            Console.WriteLine("-----Search File with mask-----");
            FileSystemManager.SearchFileWithMask(@"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_13","*.txt");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("-----Drives Info-----");
            FileSystemManager.DrivesInfo();
            Console.WriteLine("---------------------");
            FileSystemManager.CreateDirectory(@"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_13\CreateDirectory Method");
            FileSystemManager.CreateFile("newfile.txt", @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_13","Hello, Alexander");
            FileSystemManager.CreateFile("newfile.txt", @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_13","I'm Student Ilya");
            FileSystemManager.ReadFile("ReadFile.txt", @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_13");
            Console.WriteLine(FileSystemManager.FileInformation(@"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_13\newfile.txt"));
            
            
         }
    }
}
