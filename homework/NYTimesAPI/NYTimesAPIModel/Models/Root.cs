using System;
using System.Collections.Generic;
using System.Text;

namespace NYTimesAPIModel.Models
{
    public class Root
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public string section { get; set; }
        public DateTime last_updated { get; set; }
        public int num_results { get; set; }
        public List<Result> results { get; set; }
    }
}
