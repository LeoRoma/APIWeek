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
using System.Linq;
using System.Security.Cryptography;

namespace NYTimesAPIModel
{
    public class Program
    {   
        static List<Result> results = new List<Result>();
        static List<Multimedia> images = new List<Multimedia>();
        static List<string> imgs = new List<string>();
        static Uri url = new Uri("https://api.nytimes.com/svc/topstories/v2/arts.json?api-key=s3sidQNE043xhMtYMOTXG0E044n5RsFd");
        static public Root root = new Root();
         
        static void Main(string[] args)
        {
            GetNYTimes();

            //GetImages();
            Test();
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

        //static List<Result> GetResults()
        //{

        //    foreach (var item in root.results)
        //    {
        //        foreach (var i in item.multimedia[0].url)
        //        {
        //            results.Add();
        //        }
        //    }
        //    return results;
        //}

        //static List<Multimedia> GetImages()
        //{

        //    foreach (var item in root.results)
        //    {
        //        foreach (var image in item.multimedia)
        //        {
        //            images.Add(image);
        //        }
        //    }

        //    //foreach (var item in images)
        //    //{
        //    //    Console.WriteLine(item);
        //    //}
        //    return images;

    


        static void Test()
        {
            foreach (var item in root.results)
            {

                for (int i = 2; i < item.multimedia.Count; i += 5)
                {
                    
                    images.Add(item.multimedia[i]);
                }

            }
            foreach (var item in images)
            {
                Console.WriteLine(item.url);
            }
        }


    }
}
