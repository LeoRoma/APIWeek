using System;
using System.Collections.Generic;
using System.Text;


namespace NYTimesAPIModel.Models
{
    public partial class Result
    {
        public override string ToString()
        {
            return $"{title}";
        }
    }
}
