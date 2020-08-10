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

namespace SpartaGlobalView.Pages.Students
{
    /// <summary>
    /// Interaction logic for StudentFormView.xaml
    /// </summary>
    public partial class StudentFormView : Page
    {
        private StudentsController _studentsController = new StudentsController();
        public StudentFormView()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBoxName.Text;
            int courseId = Int32.Parse(TextBoxCourseId.Text);
            string email = TextBoxEmail.Text;
            _studentsController.PostStudent(name, courseId, email);
            MessageBox.Show("Course saved successfully");
            MainFrame.Navigate(new StudentsView());
        }


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StudentsView());
        }
    }
}
