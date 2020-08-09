using NUnit.Framework;
using SpartaGlobalClient.Controllers;
using SpartaGlobalClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SpartaGlobalTest
{
    public class Tests
    {
        
        private CoursesController _coursesController = new CoursesController();

        private Uri urlCourses = new Uri("https://localhost:44355/api/Courses");

        [Test]
        public void GetCourses()
        {
            _coursesController.GetCourses();
            Assert.AreEqual(_coursesController.courses[0].CourseId, 13);
            Assert.AreEqual(_coursesController.courses[1].CourseName, "Engineering 66");
        }
    }
}
