using System;
using System.Collections.Generic;

namespace SpartaGlobalAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            Students = new List<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseType { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}
