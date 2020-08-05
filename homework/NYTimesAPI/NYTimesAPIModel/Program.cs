using System;

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using NYTimesAPIModel.Models;

namespace NYTimesAPIModel
{
    public class Program
    {
        static Uri url = new Uri("https://api.nytimes.com/svc/topstories/v2/arts.json?api-key=s3sidQNE043xhMtYMOTXG0E044n5RsFd");
        static public Root root = new Root();
         
        static void Main(string[] args)
        {
            GetNYTimes();
            GetNews();
        }

        static void GetNYTimes()
        {
            
            using (var httpclient = new HttpClient())
            {
                var data = httpclient.GetStringAsync(url);

                root = JsonConvert.DeserializeObject<Root>(data.Result);
                Console.WriteLine(data);
            }
            Console.WriteLine("\n\nDeserialised TODO Json into List\n\n");
            

        }

        static void GetNews()
        {
            foreach (var item in root.results)
            {
                Console.WriteLine(item);
            }
        }
    }
}
