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

namespace ImagesGallerySlider
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Entities.EFContext _db;
        public PhotoCollection Photos;
        public MainWindow()
        {
            InitializeComponent();
            _db = new Entities.EFContext();
            _db.Photos.Count();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var categories = _db.Categories.AsQueryable();
            foreach (var item in categories)
            {
                comboBox.Items.Add(item.NameOfCategory);
            }
            //ImagesDir.Text = Environment.CurrentDirectory + "\\images";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Photos.Path = ImagesDir.Text;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
