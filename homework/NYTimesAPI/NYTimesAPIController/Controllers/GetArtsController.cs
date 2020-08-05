using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using NYTimesAPIModel.Models;

namespace NYTimesAPIController.Controllers
{
    public class GetArtsController
    {
        static Uri url = new Uri("https://api.nytimes.com/svc/topstories/v2/arts.json?api-key=s3sidQNE043xhMtYMOTXG0E044n5RsFd");
        static public Root root = new Root();

        public static void GetNYTimesAPI()
        {
            using (var httpclient = new HttpClient())
            {
                var data = httpclient.GetStringAsync(url);

                root = JsonConvert.DeserializeObject<Root>(data.Result);
            }
        }
    }
}
