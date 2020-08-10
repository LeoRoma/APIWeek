using System;
using System.Collections.Generic;
using System.Text;
using SpartaGlobalClient.Models;

namespace SpartaGlobalClient.Models
{ 
    public partial class Course
    {
        public override string ToString()
        {
            return $"{CourseName}";
        }
    }
}
