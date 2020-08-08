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

        static Course newCourse = new Course()
        {
            CourseId = 1,
            CourseName = "Data 55",
            CourseType = "Data Analysts"
        };

        static Student newStudent = new Student()
        {
            StudentId = 10,
            StudentName = "Goat",
            Score = 0,
            CourseId = 1
        };

        static Course updateCourse = new Course()
        {
            CourseId = 4,
            CourseName = "Engineering 100",
            CourseType = "Test"
        };

        static Student updateStudent = new Student()
        {
            StudentId = 11,
            StudentName = "Donkey",
            Score = 3,
            CourseId = 2
        };

        static void Main(string[] args)
        {
            //Thread.Sleep(5000);

            //// Post course async
            //PostCourseAsync(newCourse);
            //Thread.Sleep(2000);

            //// Post student async
            //PostStudentAsync(newStudent);
            //Thread.Sleep(2000);

            //// Get courses Async
            //Console.WriteLine("All courses");
            //GetCoursesAsync();
            //Thread.Sleep(2000);
            //foreach (var item in courses)
            //{
            //    Console.WriteLine($"Course: {item.CourseName} Type: {item.CourseType} Students: {item.Students}");
            //};
            //// Get Students Async
            //Console.WriteLine("\n\nAll students");
            //GetStudentsAsync();
            //Thread.Sleep(2000);
            //foreach (var item in students)
            //{
            //    Console.WriteLine($"Name: {item.StudentName} Score: {item.Score}");
            //};

            //// Get course Async
            //Console.WriteLine("\n\nOne Course");
            //GetOneCourseAsync(1);
            //Thread.Sleep(2000);
            //Console.WriteLine($"{course.CourseName}, {course.CourseType}");
            
            //// Get student Async
            //Console.WriteLine("\n\nOne Student");
            //GetOneStudentAsync(1);
            //Thread.Sleep(2000);
            //Console.WriteLine($"{student.StudentName}, {student.Score}");

            //// Get Student and course
            //Console.WriteLine("\n\nGet student and course");
            //if (course.CourseId == student.CourseId)
            //{
            //    Console.WriteLine($"{course.CourseName} {student.StudentName} {student.Score}");
            //}

            //// Delete Course
            //DeleteCourseAsync(5);
            //Thread.Sleep(2000);

            //// Delete Student
            //DeleteStudentAsync(14);
            //Thread.Sleep(2000);

            //// Update Course
            //UpdateCourseAsync(updateCourse);
            //Thread.Sleep(2000);

            //UpdateStudentAsync(updateStudent);
            //Thread.Sleep(2000);

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

        static bool CourseExists(int courseId)
        {
            GetCourses();
            course = null;
            course = courses.Where(c => c.CourseId == courseId).FirstOrDefault();
            if (course != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static async void GetOneCourseAsync(int courseId)
        {
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync($"{urlCourses}/{courseId}");
                course = JsonConvert.DeserializeObject<Course>(data);
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

        static bool StudentExists(int studentId)
        {
            GetStudents();
            student = null;
            student = students.Where(s => s.StudentId == studentId).FirstOrDefault();
            if (student != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static async void GetOneStudentAsync(int studentId)
        {
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync($"{urlStudents}/{studentId}");
                student = JsonConvert.DeserializeObject<Student>(data);
            }
        }

        // Post a Course
        static async void PostCourseAsync(Course newCourse)
        {
            if (!CourseExists(newCourse.CourseId))
            {
                string newCourseAsJson = JsonConvert.SerializeObject(newCourse, Formatting.Indented);

                var httpContent = new StringContent(newCourseAsJson);

                httpContent.Headers.ContentType.MediaType = "application/json";
                httpContent.Headers.ContentType.CharSet = "UTF-8";

                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.PostAsync(urlCourses, httpContent);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Record {newCourse.CourseName} successfully added");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Course with Name: {newCourse.CourseName} already exists, can't create a new customer");
            }
        }

        // Post a Student
        static async void PostStudentAsync(Student newStudent)
        {
            if (!StudentExists(newStudent.StudentId))
            {
                string newStudentAsJson = JsonConvert.SerializeObject(newStudent, Formatting.Indented);

                var httpContent = new StringContent(newStudentAsJson);

                httpContent.Headers.ContentType.MediaType = "application/json";
                httpContent.Headers.ContentType.CharSet = "UTF-8";

                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.PostAsync(urlStudents, httpContent);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Record {newStudent.StudentName} successfully added");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Student with Name: {newStudent.StudentName} already exists, can't create a new Student");
            }
        }

        // Delete a course
        static async void DeleteCourseAsync(int courseId)
        {
            if (CourseExists(courseId) == true)
            {
                // Send Data
                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.DeleteAsync($"{urlCourses}/{courseId}");
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Course {courseId} successfully deleted");
                    }
                }
            }
            else
            {
                Console.WriteLine($"A course with ID: {courseId} doesn't exists, can't delete");
            }
        }

        // Delete a student
        static async void DeleteStudentAsync(int studentId)
        {
            if (StudentExists(studentId) == true)
            {
                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.DeleteAsync($"{urlStudents}/{studentId}");
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Student {studentId} successfully deleted");
                    }
                }
            }
            else
            {
                Console.WriteLine($"A Student with ID: {studentId} doesn't exists, can't delete");
            }
        }

        // Update a course
        static async void UpdateCourseAsync(Course updateCourse)
        {
            if (CourseExists(updateCourse.CourseId) == true)
            {
                string updateCourseAsJson = JsonConvert.SerializeObject(updateCourse, Formatting.Indented);

                // Convert this to HTTP
                var httpContent = new StringContent(updateCourseAsJson);

                // Add headers before send
                httpContent.Headers.ContentType.MediaType = "application/json";
                httpContent.Headers.ContentType.CharSet = "UTF-8";

                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.PutAsync($"{urlCourses}/{updateCourse.CourseId}", httpContent);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Course {updateCourse.CourseId} successfully updated");
                    }
                }
            }
            else
            {
                Console.WriteLine($"A course with ID: {updateCourse.CourseId} doesn't exists, can't update");
            }
        }

        // Update a student
        static async void UpdateStudentAsync(Student updateStudent)
        {
            if (StudentExists(updateStudent.StudentId) == true)
            {
                string updateStudentAsJson = JsonConvert.SerializeObject(updateStudent, Formatting.Indented);

                // Convert this to HTTP
                var httpContent = new StringContent(updateStudentAsJson);

                // Add headers before send
                httpContent.Headers.ContentType.MediaType = "application/json";
                httpContent.Headers.ContentType.CharSet = "UTF-8";

                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.PutAsync($"{urlStudents}/{updateStudent.StudentId}", httpContent);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Student {updateStudent.StudentId} successfully updated");
                    }
                }
            }
            else
            {
                Console.WriteLine($"A student with ID: {updateStudent.StudentId} doesn't exists, can't update");
            }
        }
    }

    
}
