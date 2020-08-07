using System;
using System.Collections.Generic;

namespace SpartaGlobalAPI.Models
{
    public partial class Students
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int? Score { get; set; }
        public int? CourseId { get; set; }

        public virtual Courses Course { get; set; }
    }
}
