using System;
using System.Collections.Generic;
using System.Text;

namespace NYTimesAPIModel.Models
{
    public partial class Multimedia
    {
        public string url { get; set; }
        public string format { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public string caption { get; set; }
        public string copyright { get; set; }
    }
}
