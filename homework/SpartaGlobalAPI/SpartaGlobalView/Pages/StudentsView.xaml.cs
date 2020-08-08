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

namespace SpartaGlobalView.Pages
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
            
        }

        private void ButtonEditStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        public void ListViewStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewStudents.SelectedItem != null)
            {
                //_itemsManagerController.SetSelectedItem(ListViewItems.SelectedItem);
                //PopulateItemFields();
            }
        }
    }
}
