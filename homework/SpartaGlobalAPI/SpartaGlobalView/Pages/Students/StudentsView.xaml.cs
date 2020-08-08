using System;
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

namespace SpartaGlobalView.Pages.Students
{
    /// <summary>
    /// Interaction logic for StudentsView.xaml
    /// </summary>
    public partial class StudentsView : Page
    {
        private StudentsController _studentsController = new StudentsController();
        public StudentsView()
        {
            InitializeComponent();
            PopulateAllStudents();
        }

        private void PopulateAllStudents()
        {
            _studentsController.GetStudents();
            if (_studentsController.students != null)
            {
                ListViewStudents.ItemsSource = _studentsController.students;
            }
        }
        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StudentFormView());
        }

        private void ButtonEditStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            _studentsController.DeleteStudent(_studentsController.SelectedStudent.StudentId);
            MessageBox.Show("Student deleted successfully");
            PopulateAllStudents();
        }

        public void ListViewStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewStudents.SelectedItem != null)
            {
                _studentsController.SetSelectedStudent(ListViewStudents.SelectedItem);
                PopulateStudentFields();
            }
        }

        public void PopulateStudentFields()
        {
            if (_studentsController.SelectedStudent != null)
            {
                Name.Text = _studentsController.SelectedStudent.StudentName;
            }
        }
    }
}
