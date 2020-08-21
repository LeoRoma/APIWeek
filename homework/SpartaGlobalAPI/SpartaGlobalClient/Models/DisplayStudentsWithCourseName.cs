using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaGlobalAPI.Models
{
    public class DisplayStudentsWithCourseName
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string CourseName { get; set; }
        public int? Score { get; set; }
    }
}
