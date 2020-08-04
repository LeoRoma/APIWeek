using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace lab_28b_task_array
{
    
    class Program
    {
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            // Single tasks - not much benefit
            // Array of tasks ==> each one can complete at its own leisure

            s.Start();

            var taskArray = new Task[5];

            taskArray[0] = Task.Run(
               () => { Console.WriteLine($"Task 0 completed"); }
            );

            taskArray[1] = Task.Run(
               () => { Console.WriteLine($"Task 1 completed"); }
            );

            taskArray[2] = Task.Run(
               () => { Console.WriteLine($"Task 2 completed"); }
            );

            taskArray[3] = Task.Run(
               () => {
                   Thread.Sleep(500);
                   Console.WriteLine($"Task 3 completed"); 
               }
            );

            taskArray[4] = Task.Run(
               () => {
                   Thread.Sleep(300);
                   Console.WriteLine($"Task 4 completed"); 
               }
            );

            var oneTask = Task.Run(
                () =>
                {
                    Thread.Sleep(800);
                    Console.WriteLine("Individual task completed");
                }
            );

            // Get data back with Task.Result
            var getDataBack = Task<string>.Run(
                () =>
                {
                    return "Here is some data back from my background task";
                }
            );

            // Wait for any one to complete

            Task.WaitAny(taskArray);

            Console.WriteLine($"First task completed at {s.ElapsedMilliseconds}");

            Task.WaitAll(taskArray);

            Console.WriteLine($"Array tasks completed at {s.ElapsedMilliseconds}");

            oneTask.Wait();

            Console.WriteLine($"Background data returned at time {s.ElapsedMilliseconds} - data is {getDataBack.Result}");

            Console.WriteLine($"Program terminates at {s.ElapsedMilliseconds}");

            Console.ReadLine();

            
        }
    }
}
