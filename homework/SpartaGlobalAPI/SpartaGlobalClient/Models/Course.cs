using System;
using System.Collections.Generic;
using System.Text;

namespace SpartaGlobalClient.Models
{
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseType { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
