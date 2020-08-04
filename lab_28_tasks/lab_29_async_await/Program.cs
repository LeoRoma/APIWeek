using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab_29_async_await
{
    class Program
    {
        static Stopwatch s = new Stopwatch();
        static List<string> fileOutput3 = new List<string>();
        static List<string> fileOutput4 = new List<string>();

        static void Main(string[] args)
        {
            // Sync code ...Line by line

            // Async 
            // async void DoThisAsync(){
            //      var output = await ReadFileAsync("thisfile.txt");
            //      var output = await GetHttp/JsonDataAsync(URL);
            //      return output;
            // }

            // Walkthrough : read file sync and async

            // 1. Create text file 10.000 lines?
            // 2. Method to read text file to array a) File.Read.. b) StreamReader (bonus)
            // 3. Call this method from the Main()
            // 4. Time application start to finish

            s.Start();
            File.Delete("data.txt");
            if (!File.Exists("data.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    File.AppendAllText("data.txt", $"Adding a new line to text file at {DateTime.Now}\n");
                }
                Console.WriteLine($"File create took {s.ElapsedMilliseconds}");
            }

     
            // Synchronous read
            var array01 = ReadTextFileToArray();

            Console.WriteLine($"Synchronous read took: {s.ElapsedMilliseconds}");

            // Streamreader read
            s.Restart();
            List<string> fileOutput = new List<string>();
            using(var reader = new StreamReader("data.txt"))
            {
                while(!reader.EndOfStream)
                {
                    fileOutput.Add(reader.ReadLine());
                }
                
            }
            Console.WriteLine($"StreamReader to list took {s.ElapsedMilliseconds}");

            // Streamreader read to stringbuilder
            s.Restart();
            var stringbuilder = new StringBuilder();
            using (var reader = new StreamReader("data.txt"))
            {
                while (!reader.EndOfStream)
                {
                    stringbuilder.AppendLine(reader.ReadLine());
                }
            }
            string fileOutput2 = stringbuilder.ToString();
            Console.WriteLine($"Stringbuilder to string took {s.ElapsedMilliseconds}");

            // Async read - basic FileReadAsync
            s.Restart();
            ReadTextFileToArrayAsync();
            Console.WriteLine($"Async File Read took {s.ElapsedMilliseconds} with {fileOutput3.Count} records");

            // Async read - streamreader
            //Thread.Sleep(3000);
            StreamReadTextFileAsync();
            Console.WriteLine($"Async StreamReader took {s.ElapsedMilliseconds} with {fileOutput4.Count} records");

            // Final lab - get result but can you turn this into a proper async overnight?
            // (This way only partly works - tasks overnight to improve it)
            s.Restart();
            // This returns a 'task'
            var arrayOutPut = ReturnTextFileToArrayAsync();
            Console.WriteLine($"Async array returned in {s.ElapsedMilliseconds} with {arrayOutPut.Result.Length} records");
           
        }
        
        static string[] ReadTextFileToArray()
        {
            var array = File.ReadAllLines("data.txt");
            return array;
        }

        static async void ReadTextFileToArrayAsync()
        {
            var array = await File.ReadAllLinesAsync("data.txt");
            fileOutput3 = array.ToList();
        }
      
        // This one returns data with Task<T> structure
        static async Task<string[]> ReturnTextFileToArrayAsync()
        {
            var array = await File.ReadAllLinesAsync("data.txt");
            return array;
        }

        static async void StreamReadTextFileAsync()
        {
            using (var reader = new StreamReader("data.txt"))
            {
                while (!reader.EndOfStream)
                {
                    fileOutput4.Add(await reader.ReadLineAsync());
                }

            }
        }
   }

}
