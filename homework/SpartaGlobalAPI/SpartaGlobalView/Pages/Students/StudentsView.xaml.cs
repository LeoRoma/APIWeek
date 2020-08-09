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
        private CoursesController _coursesController = new CoursesController();

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
            string name = StudentName.Text;
            int type = Int32.Parse(Score.Text);
            int studentId = _studentsController.SelectedStudent.StudentId;
            string email = Email.Text;
            int courseId = Int32.Parse(CourseId.Text);
            _studentsController.UpdateStudent(name, type, studentId, email, courseId);
            MessageBox.Show("Course updated successfully");
            MainFrame.Navigate(new StudentsView());
            PopulateAllStudents();
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
                StudentName.Text = _studentsController.SelectedStudent.StudentName;
                Score.Text = _studentsController.SelectedStudent.Score.ToString();
                Email.Text = _studentsController.SelectedStudent.Email;
                CourseId.Text = _studentsController.SelectedStudent.CourseId.ToString();
            }
        }

        //private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        //{
        //    _coursesController.GetCourses();
        //    var combo = sender as ComboBox;
        //    combo.ItemsSource = _coursesController.courses;
        //    combo.SelectedIndex = 0;
        //}

        //private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if(_studentsController.SelectedCourse != null)
        //    {
        //        var selectedComboCourse = sender as ComboBox;
        //        _studentsController.SetSelectedCourse(selectedComboCourse.SelectedItem);
        //        PopulateStudentByCourse();
        //    }
            
        //}

        //public void PopulateStudentByCourse()
        //{
        //    ListViewStudents.ItemsSource = _studentsController.studentsByCourse;
        //}

        //private void ButtonGo_Click(object sender, RoutedEventArgs e)
        //{
            
        //}
    }
}
