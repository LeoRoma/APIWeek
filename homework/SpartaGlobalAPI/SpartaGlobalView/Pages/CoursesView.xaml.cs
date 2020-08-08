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

namespace SpartaGlobalView.Pages
{
    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    public partial class CoursesView : Page
    {
        public CoursesView()
        {
            InitializeComponent();
        }

        private void ButtonAddCourse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEditCourse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteCourse_Click(object sender, RoutedEventArgs e)
        {

        }

        public void ListViewCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewCourses.SelectedItem != null)
            {
                //_itemsManagerController.SetSelectedItem(ListViewItems.SelectedItem);
                //PopulateItemFields();
            }
        }
    }
}
