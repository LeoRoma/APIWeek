using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;

using SpartaGlobalClient.Models;

namespace SpartaGlobalClient.Controllers
{
    public class StudentsController
    {
        Uri urlStudents = new Uri("https://localhost:44355/api/Students");

        public Student student = new Student();

        public List<Student> students = new List<Student>();

        public async void GetStudentsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync(urlStudents);
                students = JsonConvert.DeserializeObject<List<Student>>(data);
            }
        }

        public void GetStudents()
        {
            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync(urlStudents);
                students = JsonConvert.DeserializeObject<List<Student>>(data.Result);
            }
        }

        public bool StudentExists(int studentId)
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

        public async void GetOneStudentAsync(int studentId)
        {
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync($"{urlStudents}/{studentId}");
                student = JsonConvert.DeserializeObject<Student>(data);
            }
        }

        public async void PostStudentAsync(Student newStudent)
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

        public void PostStudent(string name, int courseId)
        {
            Student newStudent = new Student()
            {
                StudentName = name,
                CourseId = courseId
            };
            if (!StudentExists(newStudent.StudentId))
            {
                string newStudentAsJson = JsonConvert.SerializeObject(newStudent, Formatting.Indented);

                var httpContent = new StringContent(newStudentAsJson);

                httpContent.Headers.ContentType.MediaType = "application/json";
                httpContent.Headers.ContentType.CharSet = "UTF-8";

                using (var httpClient = new HttpClient())
                {
                    var httpResponse = httpClient.PostAsync(urlStudents, httpContent);
                    if (httpResponse.Result.IsSuccessStatusCode)
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

        public async void DeleteStudentAsync(int studentId)
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

        public async void UpdateStudentAsync(Student updateStudent)
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
