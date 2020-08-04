using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

            // Firstly ==> running methods in parallel with Parallel.Invoke

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

            // Parallel for
            Parallel.For(0, 10, 
                i => {
                    Thread.Sleep(7);
                    Console.WriteLine(($"Parallel for Job {i} - running background processing"));
                }
            );

            // Parallel foreach
            var stringArray = new string[] { "hey", "there", "I", "am", "string" };
            Parallel.ForEach(stringArray,
                (item) => { 
                    Console.WriteLine($"Processing string array item {item} with a length of {item.Length}"); 
                }
            );

            // Parallel LINQ from database
            var customers = new List<string>(); // Imagine list from Northwind
            // LINQ as parallel
            var processingOutPut = customers.AsParallel();

            Console.WriteLine($"All completed at { s.ElapsedMilliseconds}");
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
