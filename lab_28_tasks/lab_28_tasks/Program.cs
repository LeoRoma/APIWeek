using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace lab_28_tasks
{
    class Program
    {
        static Stopwatch s = new Stopwatch();
        delegate void Delegate01();
        static void Main(string[] args)
        {
            // Async - Main() thread


            // Sync - sequence in order

            // Process = .exe running application which is able to send commands to CPU for processing

            // Thread ==> set of instructions bundled up and sent to CPU for processing

            // Main()
            //{
            //Sub() ==> execute as different process on computer   
            //}

            // C# Threading ==> manually create thread
            // Tasks ==> hard work removed ==> easy for programmer to work with sub-threads/sub-tasks

            // Key Words

            //Process - running exe
            //Application - run by user and runs in foreground 
            //Service - run by the computer at startup and runs in background (DNS, DHCP, WebSite)
            //Thread - set of instructions sent to CPU for processing
            //Single-Threaded runs on main thread only
            //Multi-Threaded can take advantage of multi-core CPUs which can run multiple threads simultaneously

            // Faster? NO
            // Scale out - More CPUs YES

            // When are tasks/threads useful?
            //  a) Multi-task processing eg background processing of graphics
            //  b) Background processing jobs eg overnight tasks for credit card financial reporting 
            //  c) Website => click => data can take 5 seconds but rather than freeze screen, can still work

            

            var thread = new Thread(
                () => {
                    Thread.Sleep(3000);
                    Console.WriteLine($"This is a thread {s.ElapsedMilliseconds}");
                }
            );

            var task01 = new Task(
                () => {
                    Thread.Sleep(1000);
                    Console.WriteLine($"This is a task {s.ElapsedMilliseconds}");
                }
            );

            // Create and start
            var task02 = new Task(
                () => {
                    Thread.Sleep(2000);
                    Console.WriteLine($"Creating and running task at same time{s.ElapsedMilliseconds}");
                }
            );

            // Delegates
    
            Delegate01 delegateInstance = Method01;

            var task03 = new Task(
                new Action(delegateInstance)
            );

            static void Method01()
            {
                Console.WriteLine($"Running Method 01");
            }

            // Last one - TaskFactory
            var task04 = Task.Factory.StartNew(
                () => { Console.WriteLine("Hey I am running a task factory"); }
                );
            s.Start();

            thread.Start();
            task01.Start();
            task02.Start();
            task03.Start();

            Console.WriteLine($"Program has ended {s.ElapsedMilliseconds}");

            Console.ReadLine();

            

            
        }
    }
}
