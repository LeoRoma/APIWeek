using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace lab_29_async_await
{
    class Program
    {
        static Stopwatch s = new Stopwatch();
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
                for (int i = 0; i < 10000; i++)
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


        }
        
        static string[] ReadTextFileToArray()
        {
            var array = File.ReadAllLines("data.txt");
            return array;
        }
      
   }

}
