﻿using System;
using System.Collections.Generic;
using System.Text;
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
using SpartaGlobalClient.Models;

namespace SpartaGlobalView.Pages.Courses
{
    /// <summary>
    /// Interaction logic for CourseFormView.xaml
    /// </summary>
    public partial class CourseFormView : Page
    {
        private CoursesController _coursesController = new CoursesController();

        private string _name;
        private string _type;

        public CourseFormView()
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

        public void GetCourseDetails(string name, string type)
        {
            SetCourseName(name);
            SetCourseType(type);
        }

        public void SetCourseName(string name)
        {
            _name = name;
        }

        public void SetCourseType(string type)
        {
            _type = type;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBoxName.Text;
            string type = TextBoxType.Text;
            _coursesController.PostCourse(name, type);
            MessageBox.Show("Course saved successfully");
            MainFrame.Navigate(new CoursesView());
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            //string name = TextBoxName.Text;
            //string type = TextBoxType.Text;
            //_coursesController.UpdateCourse(name, type);
            //MessageBox.Show("Course updated successfully");
            //MainFrame.Navigate(new CoursesView());
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CoursesView());
        }
    }
}
