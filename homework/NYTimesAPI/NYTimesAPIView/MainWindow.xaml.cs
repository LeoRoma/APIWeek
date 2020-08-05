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
using NYTimesAPIController;
using NYTimesAPIController.Controllers;
using NYTimesAPIModel.Models;

namespace NYTimesAPIView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GetArtsController _getArtController = new GetArtsController();
        private ItemWrapper wrapper = new ItemWrapper();
        public MainWindow()
        {
            InitializeComponent();
            _getArtController.GetNYTimesAPI();
            PopulateAllNews();
        }

        public void PopulateAllNews()
        {
            if (_getArtController.GetNews() != null)
            {
                ListViewNews.ItemsSource = _getArtController.GetNews();
                ListViewImages.ItemsSource = _getArtController.GetImages();
            }

        }
    }
}
