using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using SpartaGlobalClient.Models;

namespace SpartaGlobalClient.Controllers
{
    public class CoursesController
    {
        public Course SelectedCourse { get; set; }

        Uri urlCourses = new Uri("https://localhost:44355/api/Courses");

        //public Course course = new Course();

        public List<Course> courses = new List<Course>();

        //public async void GetCoursesAsync()
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        var data = await httpClient.GetStringAsync(urlCourses);
        //        courses = JsonConvert.DeserializeObject<List<Course>>(data);
        //    }
        //}

        public void GetCourses()
        {
            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync(urlCourses);
                courses = JsonConvert.DeserializeObject<List<Course>>(data.Result);
            }
        }

        //public bool CourseExists(int courseId)
        //{
        //    GetCourses();
        //    course = null;
        //    course = courses.Where(c => c.CourseId == courseId).FirstOrDefault();
        //    if (course != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public async void GetOneCourseAsync(int courseId)
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        var data = await httpClient.GetStringAsync($"{urlCourses}/{courseId}");
        //        course = JsonConvert.DeserializeObject<Course>(data);
        //    }
        //}

        //public async void PostCourseAsync(Course newCourse)
        //{
        //    if (!CourseExists(newCourse.CourseId))
        //    {
        //        string newCourseAsJson = JsonConvert.SerializeObject(newCourse, Formatting.Indented);

        //        var httpContent = new StringContent(newCourseAsJson);

        //        httpContent.Headers.ContentType.MediaType = "application/json";
        //        httpContent.Headers.ContentType.CharSet = "UTF-8";

        //        using (var httpClient = new HttpClient())
        //        {
        //            var httpResponse = await httpClient.PostAsync(urlCourses, httpContent);
        //            if (httpResponse.IsSuccessStatusCode)
        //            {
        //                Console.WriteLine($"Record {newCourse.CourseName} successfully added");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Course with Name: {newCourse.CourseName} already exists, can't create a new customer");
        //    }
        //}

        public void PostCourse(string name, string type)
        {
            Course newCourse = new Course()
            {
                CourseName = name,
                CourseType = type
            };
            //if (!CourseExists(newCourse.CourseId))
            //{
            string newCourseAsJson = JsonConvert.SerializeObject(newCourse, Formatting.Indented);

            var httpContent = new StringContent(newCourseAsJson);

            httpContent.Headers.ContentType.MediaType = "application/json";
            httpContent.Headers.ContentType.CharSet = "UTF-8";

            using (var httpClient = new HttpClient())
            {
                var httpResponse = httpClient.PostAsync(urlCourses, httpContent);
                if (httpResponse.Result.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Record {newCourse.CourseName} successfully added");
                }
            }
        }
        //else
        //{
        //    Console.WriteLine($"Course with Name: {newCourse.CourseName} already exists, can't create a new customer");
        //}


        //    public async void DeleteCourseAsync(int courseId)
        //    {
        //    if (CourseExists(courseId) == true)
        //    {
        //        // Send Data
        //        using (var httpClient = new HttpClient())
        //            {
        //                var httpResponse = await httpClient.DeleteAsync($"{urlCourses}/{courseId}");
        //                if (httpResponse.IsSuccessStatusCode)
        //                {
        //                    Console.WriteLine($"Course {courseId} successfully deleted");
        //                }
        //            }
        //}
        //        else
        //        {
        //            Console.WriteLine($"A course with ID: {courseId} doesn't exists, can't delete");
        //        }
        //    }

        public void DeleteCourse(int courseId)
        {
            //if (CourseExists(courseId) == true)
            //{
            // Send Data
            using (var httpClient = new HttpClient())
            {
                var httpResponse = httpClient.DeleteAsync($"{urlCourses}/{courseId}");
                if (httpResponse.Result.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Course {courseId} successfully deleted");
                }
            }
        }
        //else
        //{
        //    Console.WriteLine($"A course with ID: {courseId} doesn't exists, can't delete");
        //}


        //public async void UpdateCourseAsync(Course updateCourse)
        //{
        //    if (CourseExists(updateCourse.CourseId) == true)
        //    {
        //        string updateCourseAsJson = JsonConvert.SerializeObject(updateCourse, Formatting.Indented);

        //        // Convert this to HTTP
        //        var httpContent = new StringContent(updateCourseAsJson);

        //        // Add headers before send
        //        httpContent.Headers.ContentType.MediaType = "application/json";
        //        httpContent.Headers.ContentType.CharSet = "UTF-8";

        //        using (var httpClient = new HttpClient())
        //        {
        //            var httpResponse = await httpClient.PutAsync($"{urlCourses}/{updateCourse.CourseId}", httpContent);
        //            if (httpResponse.IsSuccessStatusCode)
        //            {
        //                Console.WriteLine($"Course {updateCourse.CourseId} successfully updated");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine($"A course with ID: {updateCourse.CourseId} doesn't exists, can't update");
        //    }
        //}
        public void UpdateCourse(string name, string type, int courseId)
        {
            Course updateCourse = new Course()
            {
                CourseId = courseId,
                CourseName = name,
                CourseType = type
            };
            //if (CourseExists(updateCourse.CourseId) == true)
            //{
            string updateCourseAsJson = JsonConvert.SerializeObject(updateCourse, Formatting.Indented);

            // Convert this to HTTP
            var httpContent = new StringContent(updateCourseAsJson);

            // Add headers before send
            httpContent.Headers.ContentType.MediaType = "application/json";
            httpContent.Headers.ContentType.CharSet = "UTF-8";

            using (var httpClient = new HttpClient())
            {
                var httpResponse = httpClient.PutAsync($"{urlCourses}/{updateCourse.CourseId}", httpContent);
                if (httpResponse.Result.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Course {courseId} successfully updated");
                }
            }
        }
        //else
        //{
        //    Console.WriteLine($"A course with ID: {courseId} doesn't exists, can't update");
        //}


        public void SetSelectedCourse(object selectedCourse)
        {
            SelectedCourse = (Course)selectedCourse;
        }
    }
}

