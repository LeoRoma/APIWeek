using System;
using System.Collections.Generic;

namespace SpartaGlobalAPI.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public int? Score { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
