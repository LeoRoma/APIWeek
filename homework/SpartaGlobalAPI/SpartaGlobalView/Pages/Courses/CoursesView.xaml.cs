﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SpartaGlobalClient.Controllers;

namespace SpartaGlobalView.Pages.Courses
{
    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    public partial class CoursesView : Page
    {
        private CoursesController _coursesController = new CoursesController();


        public CoursesView()
        {
            //Thread.Sleep(6000);
            InitializeComponent();
            PopulateAllCourses();
            //PopulateCourseFields();
        }

        public void PopulateAllCourses()
        {
            _coursesController.GetCourses();
            if (_coursesController.courses != null)
            {
                ListViewCourses.ItemsSource = _coursesController.courses;
            }
        }

        private void ButtonAddCourse_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CourseFormView());
        }

        private void ButtonEditCourse_Click(object sender, RoutedEventArgs e)
        {
            string name = CourseName.Text;
            string type = CourseType.Text;
            int id = _coursesController.SelectedCourse.CourseId; 
            _coursesController.UpdateCourse(name, type, id);
            MessageBox.Show("Course updated successfully");
            MainFrame.Navigate(new CoursesView());
            PopulateAllCourses();
        }

        private void ButtonDeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            _coursesController.DeleteCourse(_coursesController.SelectedCourse.CourseId);
            MessageBox.Show("Course deleted successfully");
            PopulateAllCourses();
        }

        public void ListViewCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewCourses.SelectedItem != null)
            {
                _coursesController.SetSelectedCourse(ListViewCourses.SelectedItem);
                PopulateCourseFields();
            }
        }

        public void PopulateCourseFields()
        {
            if (_coursesController.SelectedCourse != null)
            {
                CourseName.Text = _coursesController.SelectedCourse.CourseName;
                CourseType.Text = _coursesController.SelectedCourse.CourseType;
            }
        }
    }
}
