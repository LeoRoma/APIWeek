using System;
using System.Collections.Generic;
using System.Net.Http;
using SpartaGlobalClient.Models;
using System.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SpartaGlobalClient
{
    class Program
    {
        static Stopwatch s = new Stopwatch();

        static List<Course> courses = new List<Course>();
        static List<Student> students = new List<Student>();

        static Course course = new Course();
        static Student student = new Student();

        static Uri urlCourses = new Uri("https://localhost:44355/api/Courses");
        static Uri urlStudents = new Uri("https://localhost:44355/api/Students");

        static void Main(string[] args)
        {
            Thread.Sleep(5000);

            Console.WriteLine("All courses");
            GetCoursesAsync();
            Thread.Sleep(2000);
            foreach (var item in courses)
            {
                Console.WriteLine($"Course: {item.CourseName} Type: {item.CourseType}");
            };

            Console.WriteLine("\n\nAll students");
            GetStudentsAsync();
            Thread.Sleep(2000);
            foreach (var item in students)
            {
                Console.WriteLine($"Name: {item.StudentName} Score: {item.Score}");
            };


        }

        // GetCourses
        static async void GetCoursesAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync(urlCourses);
                courses = JsonConvert.DeserializeObject<List<Course>>(data);
            }
        }

        static void GetCourses()
        {
            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync(urlCourses);
                courses = JsonConvert.DeserializeObject<List<Course>>(data.Result);
            }
        }

        // GetStudents

        static async void GetStudentsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync(urlStudents);
                students = JsonConvert.DeserializeObject<List<Student>>(data);
            }
        }

        static void GetStudents()
        {
            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync(urlStudents);
                students = JsonConvert.DeserializeObject<List<Student>>(data.Result);
            }
        }
    }
}
