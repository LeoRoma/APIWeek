using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace lab_30a_http_deserialise_to_json
{
    class Program
    {
        static Uri url = new Uri("https://jsonplaceholder.typicode.com/todos");
        static List<TODO> todos = new List<TODO>();
        static List<TODO> todosAsync = new List<TODO>();
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            GetTodos();
            Console.WriteLine($"Synchronously we have obtained {todos.Count} ");

            s.Start();
            GetTodosAsync();
            Console.WriteLine($"Immediately async data length is {todosAsync.Count}");
            Console.WriteLine($"Program terminates at time {s.ElapsedMilliseconds}");

            Thread.Sleep(430);
            Console.WriteLine($"After Sleep async data length is {todosAsync.Count}");

        }

        // Sync
        static void GetTodos()
        {
            using (var httpclient = new HttpClient())
            {
                var data = httpclient.GetStringAsync(url);
                
                todos = JsonConvert.DeserializeObject<List<TODO>>(data.Result);

            }
            Console.WriteLine("\n\nDeserialised TODO Json into List\n\n");
            foreach (var todo in todos)
            {
                Console.WriteLine($"User: {todo.userId, -10}, ID: {todo.id, -10}, Title: {todo.title, -10}, Completed: {todo.completed, 10}");
            }
        }

        // Async
        static async void GetTodosAsync()
        {
            using (var httpclient = new HttpClient())
            {
                var data = await httpclient.GetStringAsync(url);

                todosAsync = JsonConvert.DeserializeObject<List<TODO>>(data);
                Console.WriteLine($"Todos Async Data Has Arrived at {s.ElapsedMilliseconds}");

            }
            Console.WriteLine("\n\nDeserialised TODO Json into List\n\n");
            foreach (var todo in todosAsync)
            {
                Console.WriteLine($"{todo.userId}, {todo.id}, {todo.title}, {todo.completed}");
            }
        }
    }

    public class TODO
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string completed { get; set; }
    }
}
