using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace async
{
    class Program
    {
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            //Async -> to avoid to wait if a method complete to run and starts another, with Async is possible to let them run in the same time

            s.Start();
            callMethod();
            Console.ReadKey();
        }

        public static async void callMethod()
        {
            Task<string> task = LoopAsync();
            Loop1();
            string count = await task;
            Method3(count);
        }

        static void Loop1()
        {
            Console.WriteLine($"Loop1 started at {s.ElapsedTicks}");

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Loop1 i is {i} at {s.ElapsedTicks}");
            }
            Console.WriteLine($"Loop1 terminated at {s.ElapsedTicks}");
        }

        static async Task<string> LoopAsync()
        {
            Console.WriteLine($"LoopAsync started at {s.ElapsedTicks}");
            string count = "";
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Async i is {i} at {s.ElapsedTicks}");
                    count = i.ToString();
                }
            });
            return $"Async loop completed at {s.ElapsedTicks} with {count}";
        }

        static void Method3(string count)
        {
            Console.WriteLine("Total count is " + count);
        }
    }
}
