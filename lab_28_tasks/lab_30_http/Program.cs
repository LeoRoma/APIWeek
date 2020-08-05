using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lab_30_http
{
    class Program
    {
        static Uri url = new Uri("https://jsonplaceholder.typicode.com/todos/1");
        static Uri originalUrl = new Uri("https://jsonplaceholder.typicode.com/todos");
        static Uri url2 = new Uri("https://www.bbc.co.uk");
       

        static void Main(string[] args)
        {
            // Synchronous programming
            //GetDataUsingWebCLient();
            //GetDataUsingWebCLient1();
            //GetPageUsingWebRequest();

            GetDataUsingHTTPClient();
        }

        static void GetDataUsingWebCLient()
        {
            var webClient = new WebClient { Proxy = null };
            var data = webClient.DownloadString(url); //DownloadDataAsync
            Console.WriteLine(data);
        }
        static void GetDataUsingWebCLient1()
        {
            var webClient = new WebClient { Proxy = null };
            webClient.DownloadFile(url2, "bbcWebPage.html");
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "bbcWebPage.html");
        }

        static void GetPageUsingWebRequest()
        {
            var bbcPageRequest = WebRequest.Create(url2);
            bbcPageRequest.Proxy = null;

            var bbcPageResponse = bbcPageRequest.GetResponse();

            // Interrogate response

            Console.WriteLine("\n\nBBC Page has arrived");
            Console.WriteLine(bbcPageResponse.ContentType);
            Console.WriteLine(bbcPageResponse.ContentLength);

            // Interrogate request - page headers
            Console.WriteLine("\n\nGetting page header information");
            // String array of keys
            var pageResponseHeaders = bbcPageResponse.Headers.AllKeys;

            // Values
            foreach (var key in pageResponseHeaders)
            {
                Console.WriteLine(key);
                foreach (var value in bbcPageResponse.Headers.GetValues(key))
                {
                    Console.WriteLine($"\t\t: {value}");
                }
            }
        }

        static void GetDataUsingHTTPClient()
        {
            var httpClient = new HttpClient();
            // Sync at present
            var httpResponse = httpClient.GetStringAsync(url);
            var data = httpResponse.Result;

            Console.WriteLine($"\n\nGetting Data Using HttpClient\n\n{data}");

            // Turn from string into JSON object
            // add Newtonsoft.json library

            var json = JObject.Parse(data);
            Console.WriteLine($"\n\nThis is JSON: {json}");

            Console.WriteLine(json["userId"]);
            Console.WriteLine(json["id"]);
            Console.WriteLine(json["title"]);
            Console.WriteLine(json["completed"]);

            string jsonToString = @$"{json}";
            User user = JsonConvert.DeserializeObject<User>(jsonToString);

            Console.WriteLine("\n\nOOP data deserialised is:");
            Console.WriteLine($"this user title: {user.title}"); // {data, -20} tabbing out
            Console.WriteLine($"this user id: {user.id}");
            Console.WriteLine($"this user userid: {user.userId}");
            Console.WriteLine($"this user completed: {user.completed}");
            Console.WriteLine($"this user title: {user.title,-20}, {user.id,-20}, {user.userId,-20}, {user.completed,-20}"); // {data, -20} tabbing out

            // take this to next level - deserialise a List Of Users!

            var httpClient2 = new HttpClient();
            // Sync at present
            var httpResponse2 = httpClient.GetStringAsync(originalUrl);
            var data2 = httpResponse2.Result;
            //var json2 = JObject.Parse(data2);
            //string jsonToString2 = @$"{json2}";
            var users = new List<string>();

            //var array = JArray.Parse(jsonToString2);
            List<User> obj = JsonConvert.DeserializeObject<List<User>>(data2);

            Console.WriteLine("\n\nDeserialised Json into List");
            foreach (var u in obj)
            {
                Console.WriteLine($"{u.userId}, {u.id}, {u.title}, {u.completed}");
            }
        }
    }

    public class User
    {
        // Create Class
        // in main method use newtonsoft to deserialize to instance
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string completed { get; set; }
    }
}
