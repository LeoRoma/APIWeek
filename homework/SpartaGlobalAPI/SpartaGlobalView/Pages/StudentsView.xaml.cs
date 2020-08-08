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
    /// Interaction logic for StudentsView.xaml
    /// </summary>
    public partial class StudentsView : Page
    {
        public StudentsView()
        {
            InitializeComponent();
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
