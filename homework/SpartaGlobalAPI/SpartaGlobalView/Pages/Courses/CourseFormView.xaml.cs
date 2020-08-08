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

        public CourseFormView()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            
            string name = TextBoxName.Text;
            string type = TextBoxType.Text;
            _coursesController.PostCourse(name, type);
            MessageBox.Show("Course saved successfully");
            MainFrame.Navigate(new CoursesView());
        }
    }
}
