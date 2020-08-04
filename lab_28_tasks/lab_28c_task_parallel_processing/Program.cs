using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace lab_28c_task_parallel_processing
{
    class Program
    {
        
        delegate void MyDelegate();
        static void Main(string[] args)
        {
            // C# has a library to help with task 'parallel' processing

            // Firstly ==> running methods in parallel

            Action instance01 = OvernightTask01;
            Action instance02 = OvernightTask02;
            Action instance03 = OvernightTask03;
            Action instance04 = OvernightTask04;
            Action instance05 = OvernightTask05;

            Parallel.Invoke(
                () => { OvernightTask01(); },
                () => { OvernightTask02(); },
                () => { OvernightTask03(); },
                () => { OvernightTask04(); },
                () => { OvernightTask05(); }
            );

            var s = new Stopwatch();
            s.Start();

            // Parallel for
            var taskArray = new Task[32];
            for (int i = 0; i < taskArray.Length; i++)
            {
                var j = i;
                taskArray[j] = Task.Run(() => {
                    Thread.Sleep(5);
                    Console.WriteLine($"Task {j} has completed at {s.ElapsedMilliseconds}"); 
                });
            }

            Console.WriteLine($"All completed at{ s.ElapsedMilliseconds}");
        }

        static void OvernightTask01()
        {
            Console.WriteLine("Processing overnight task 01");
        }

        static void OvernightTask02()
        {
            Console.WriteLine("Processing overnight task 02");
        }

        static void OvernightTask03()
        {
            Thread.Sleep(500);
            Console.WriteLine("Processing overnight task 03");
        }

        static void OvernightTask04()
        {
            Console.WriteLine("Processing overnight task 04");
        }

        static void OvernightTask05()
        {
            Console.WriteLine("Processing overnight task 05");
        }
    }
}
