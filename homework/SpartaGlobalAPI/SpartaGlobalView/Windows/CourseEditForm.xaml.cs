using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using SpartaGlobalClient.Controllers;
using SpartaGlobalClient.Models;
using SpartaGlobalView.Pages;
using SpartaGlobalView.Pages.Courses;

namespace SpartaGlobalView.Windows
{
    /// <summary>
    /// Interaction logic for CourseEditForm.xaml
    /// </summary>
    public partial class CourseEditForm : Window
    {
        private CoursesController _coursesController = new CoursesController();

        private string _name;
        private string _type;
        private int _id;

        public CourseEditForm()
        {
            InitializeComponent();
            PopulateCourseField();
        }

        public void PopulateCourseField()
        {
            if (_name != null && _type != null)
            {
                TextBoxName.Text = _name;
                TextBoxType.Text = _type;
            }
        }

        public void GetCourseDetails(string name, string type, int id)
        {
            SetCourseName(name);
            SetCourseType(type);
            SetCourseId(id);
        }

        public void SetCourseName(string name)
        {
            _name = name;
        }

        public void SetCourseType(string type)
        {
            _type = type;
        }

        public void SetCourseId(int id)
        {
            _id = id;
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBoxName.Text;
            string type = TextBoxType.Text;
            int id = _id;
            _coursesController.UpdateCourse(name, type, id);
            MessageBox.Show("Course updated successfully");
            MainFrame.Navigate(new CoursesView());
            this.Close();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CoursesView());
        }
    }
}
