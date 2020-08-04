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
            
            Loop1();
            Loop2();
            Console.WriteLine(LoopAsync());
        }

        static void Loop1()
        {
            s.Start();
            Console.WriteLine($"Loop1 started at {s.ElapsedTicks}");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"i is {i} at {s.ElapsedTicks}");
            }
            Console.WriteLine($"Loop1 terminated at {s.ElapsedTicks}");
        }

        static void Loop2()
        {
            s.Start();
            Console.WriteLine($"Loop2 started at {s.ElapsedTicks}");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"i is {i} at {s.ElapsedTicks}");
            }
            Console.WriteLine($"Loop2 terminated at {s.ElapsedTicks}");
        }


        static async Task<string> LoopAsync()
        {
            s.Start();
            Console.WriteLine($"LoopAsync started at {s.ElapsedTicks}");
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"i is {i} at {s.ElapsedTicks}");
                }
            });
               
            
            return $"Async loop terminated at {s.ElapsedTicks}";
        }
    }
}
