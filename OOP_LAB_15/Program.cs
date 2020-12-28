using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace OOP_LAB_15
{
    class Program
    {
        public static int num;
        public static Thread thread;
        public static void LoadDomain(object sender, EventArgs args)
        {
            Console.WriteLine("Domain is loaded");
        }

        public static void LoadAssembly(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("Assembly is loaded");
        }

        public static void Go()
        {
            StreamWriter sw = new StreamWriter("MyNumbers.txt");
            for (int i = 0; i <= num; ++i)
            {
                sw.Write(i + ", ");
                Console.Write(i + ", ");
                Thread.Sleep(1000);
            }
            sw.Close();
            Console.WriteLine("\nИнформация потока: ");
            Console.WriteLine($"ID: {thread.ManagedThreadId}");
            Console.WriteLine($"Имя: {thread.Name}");
            Console.WriteLine($"Статус: {thread.ThreadState}");
            Console.WriteLine($"Приоритет: {thread.Priority}");
        }

        public static void Odd(object counter)
        {
            int number;
            for (int i = 0; i <= (int)counter; i++)
            {
                if (i % 2 !=0)
                {
                    number = i;
                    Console.Write($"{number} ");
                }
            }

            Console.WriteLine("\n");
        }
        public static void Even(object counter)
        {
            int number;
            for (int i = 0; i <= (int)counter; i++)
            {
                if (i % 2 == 0)
                {
                    number = i;
                    Console.Write($"{number} ");
                }
            }

            Console.WriteLine("\n");
        }
        static void Even1(object counter)
        {
            using (var mutex = new Mutex(false, "UNIQUE_NAME"))
            {

                for (int i = 0; i <= (int)counter; i += 2)
                {
                    mutex.WaitOne();
                    using (var aFile = new FileStream("MyNumbers.txt", FileMode.Append, FileAccess.Write,FileShare.Write))
                    using (StreamWriter writer = new StreamWriter(aFile))
                    {
                        mutex.WaitOne();
                        writer.Write(i + ", ");
                        Console.Write(i + ", ");
                        Thread.Sleep(1500);
                        mutex.ReleaseMutex();

                    }

                    mutex.ReleaseMutex();
                }
            }
        }

        static void Odd1(object counter)
        {
            using (var mutex = new Mutex(false, "UNIQUE_NAME"))
            {

                for (int i = 1; i <= (int)counter; i += 2)
                {
                    mutex.WaitOne();
                    using (var aFile = new FileStream("MyNumbers.txt", FileMode.Append, FileAccess.Write, FileShare.Write))
                    using (StreamWriter writer = new StreamWriter(aFile))
                    {
                        mutex.WaitOne();
                        writer.Write(i + ", ");
                        Console.Write(i + ", ");
                        Thread.Sleep(1500);
                        mutex.ReleaseMutex();

                    }

                    mutex.ReleaseMutex();
                }
            }
        }

        public static void ForTimer(object t)
        {
            int x = (int)t;
            for (int i = 1; i <= 3; i++)
                Console.WriteLine($"{i}+{i} = {i + i}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var allProcesses = Process.GetProcesses();
            Process.Start("notepad.exe");
            foreach (var processes in allProcesses)
            {
                string str =
                    $"Process ID : {processes.Id} \nName : {processes.ProcessName} \nPriority : {processes.BasePriority}\n";
                Console.WriteLine(str);
                File.AppendAllText(@"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_15",str);
                
            }
            AppDomain appDomain = AppDomain.CurrentDomain;
            Console.Write($"Name : {appDomain.FriendlyName} \nDetail of configuration : {appDomain.SetupInformation} \nAssemblies : ");
            foreach (var elements in appDomain.GetAssemblies())
            {
                Console.WriteLine($"{elements}");
            }
            AppDomain newAppDomain = AppDomain.CreateDomain("NewDomain");
            newAppDomain.DomainUnload += LoadDomain;
            newAppDomain.AssemblyLoad += LoadAssembly;
            Console.WriteLine($"\nNew domain : {newAppDomain.FriendlyName}");
            newAppDomain.Load("OOP_LAB_15");
            AppDomain.Unload(newAppDomain);
            Console.WriteLine("Enter a number");
            num = Convert.ToInt32(Console.ReadLine());
            thread = new Thread(new ThreadStart(Go));
            thread.Start();
            thread.Join();
            Console.WriteLine("Enter a number");
            int counter = Convert.ToInt32(Console.ReadLine());
            ParameterizedThreadStart firstStart = new ParameterizedThreadStart(Odd);
            Thread first = new Thread(firstStart);
            ParameterizedThreadStart secondStart = new ParameterizedThreadStart(Even);
            Thread second = new Thread(secondStart);
            second.Start(counter);
            first.Start(counter);
            second.Join();
            first.Join();
            Thread otherOdd = new Thread(new ParameterizedThreadStart(Odd1));
            Thread otherEven = new Thread(new ParameterizedThreadStart(Even1));
            otherEven.Start(counter);
            otherOdd.Start(counter);
            otherEven.Join();
            otherOdd.Join();
            Console.WriteLine();
            int y = 0;
            TimerCallback time = new TimerCallback(ForTimer);
            Timer tm = new Timer(time, y, 5000, 00);
            Console.ReadKey();





        }

    }

}
