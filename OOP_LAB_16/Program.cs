using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_LAB_16
{
    class Program
    {
        private static BlockingCollection<string> block;
        static CancellationTokenSource tokenSource = new CancellationTokenSource();
        public static void WritePrime()
        {
            int n = 10000;
            bool[] A = new bool[n];
            for (int i = 2; i < n; i++)
            {
                A[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(n) + 1; ++i)
            {
                if (A[i])
                {
                    for (int j = i * i; j < n; j += i)
                    {
                        A[j] = false;
                    }
                }
            }
            Console.WriteLine();
            for (int i = 2; i < n; i++)
            {
                if (tokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана токеном");
                    return;
                }
                if (A[i])
                    Console.WriteLine($"{i} ");
            }
        }
        public static int Formula1(int x, int y)
        {
            return (int)(x * (8 - Math.Pow(y, 3.5) / 3 + Math.Cos(-1)));
        }

        public static int Formula2(int x)
        {
            return (int)(9 * (x - 5) + 4 / 3 + Math.Sin(5));
        }

        public static int Formula3(int x)
        {
            return (int)(-17 / 12 * (-x + 4) / x * 33);
        }

        public static int ResultFormula(int x, int y, int z)
        {
            return (x + y + z);
        }
        static async void SayAsync()
        {
            await Task.Run(() => Console.WriteLine("Async stream"));
        }
        static void Supl()
        {
            Random r = new Random();
            int x;
            List<string> products = new List<string>() { "телефон", "машина", "лампа", "ключ", "дверь" };
            for (int i = 0; i < 5; i++)
            {
                x = r.Next(0, products.Count - 1);
                Console.WriteLine("Добавлен товар: {0}", products[x]);
                block.Add(products[x]);
                products.RemoveAt(x);
                Thread.Sleep(r.Next(4, 10));
            }
            block.CompleteAdding();
        }

        static void Cons()
        {
            string str;
            while (!block.IsAddingCompleted)
            {
                if (block.TryTake(out str))
                    Console.WriteLine("Был куплен товар: {0}", str);
                else
                    Console.WriteLine("Покупатель ушел");
                Thread.Sleep(2);
            }
        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("First task");
            stopwatch.Start();
            Task eratosthenes = new Task(() =>
            {
                WritePrime();
            });
            eratosthenes.Start();
            Console.WriteLine($"ID: {eratosthenes.Id} Status: {eratosthenes.Status}");
            eratosthenes.Wait();
            Console.WriteLine($"ID: {eratosthenes.Id} Status: {eratosthenes.Status}");
            stopwatch.Stop();
            Console.WriteLine($"Working Time: {stopwatch.Elapsed.Seconds}:{stopwatch.Elapsed.Milliseconds}");
            stopwatch.Reset();
            Console.WriteLine("Second Task");
            Task eratosToken = new Task(WritePrime, tokenSource.Token);
            eratosToken.Start();
            string s = Console.ReadLine();
            if (s == "q")
            {
                tokenSource.Cancel();
            }
            eratosToken.Wait();
            Console.WriteLine("Third task");
            Task<int> task1 = Task.Run(() => Formula1(5, 2));
            Task<int> task2 = Task.Run(() => Formula2(3));
            Task<int> task3 = Task.Run(() => Formula3(-6));
            Task<int> result = Task.Run(() => ResultFormula(task1.Result, task2.Result, task3.Result));
            Console.WriteLine("Fourth task");
            //first way
            Task continuation = Task.WhenAll(result).ContinueWith(t => Console.WriteLine("Continue"));
            //second way
            var awaiter = result.GetAwaiter();
            awaiter.OnCompleted(() => Console.WriteLine("Awaiter result: {0}", awaiter.GetResult()));

            Console.WriteLine($"Task1: {task1.Result}");
            Console.WriteLine($"Task2: {task2.Result}");
            Console.WriteLine($"Task3: {task3.Result}");
            Console.WriteLine($"Result: {result.Result}");
            Console.WriteLine("Fifth task");
            int k = 0;
            int arrSize = 10000;
            stopwatch.Restart();
            Parallel.For(k, arrSize, (index) => {
                short[] arr = new short[arrSize];
                Random rand = new Random();
                for (int j = 0; j < arrSize; j++)
                {
                    arr[j] = (short)rand.Next();
                }
            });
            stopwatch.Stop();
            Console.WriteLine($"Parallel for: {stopwatch.ElapsedMilliseconds / (double)1000} s");
            stopwatch.Restart();
            for (k = 0; k < arrSize; k++)
            {
                short[] arr = new short[arrSize];
                Random rand = new Random();
                for (int j = 0; j < arrSize; j++)
                {
                    arr[j] = (short)rand.Next();
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Sequential for: {stopwatch.ElapsedMilliseconds / (double)1000} s");
            Console.WriteLine("Sixth task");
            Parallel.Invoke(() =>
            {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("1 ");
            }
            },
            () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("2 ");
                }
            });

            Console.WriteLine("\nSeventh task");
            block = new BlockingCollection<string>(5);
            Task Sup = new Task(Supl);
            Task Con = new Task(Cons);
            Sup.Start();
            Con.Start();
            Task.WaitAll(Sup, Con);
            Sup.Dispose();
            Con.Dispose();
            Console.WriteLine();
            
            SayAsync();
            Console.WriteLine("I'm Legend!");
        }
    }
}
