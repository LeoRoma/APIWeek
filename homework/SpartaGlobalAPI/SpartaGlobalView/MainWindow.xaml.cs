using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SpartaGlobalView.Pages.Courses;
using SpartaGlobalView.Pages.Students;

namespace SpartaGlobalView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CoursesView _coursesView = new CoursesView();
        private StudentsView _studentsView = new StudentsView();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCourses_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CoursesView());
        }

        private void ButtonStudents_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StudentsView());
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
