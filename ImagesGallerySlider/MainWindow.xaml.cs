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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path = null;
            BitmapImage bitmap = null;
            try
            {
                path = Environment.CurrentDirectory + "\\connecting.png";
                bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path);
                bitmap.EndInit();
                conIcon.Source = bitmap;
            }
            catch (Exception)
            {
                MessageBox.Show("Something wrong!");
            }
            
            try
            {                
                ConnectionProvider connection = new ConnectionProvider();
                connection.ConectedEvent += (Entities.EFContext db) =>
                {
                    _db = db;
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        lblStatus.Content = "Status: Connected!";

                        var categories = db.Categories.AsQueryable();
                        comboBox.Items.Add("All photos");
                        foreach (var item in categories)
                        {
                            comboBox.Items.Add(item.NameOfCategory);
                        }
                        
                        Photos.Db = _db;
                        comboBox.SelectedIndex = 0;
                        path = Environment.CurrentDirectory + "\\complete.png";
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(path);
                        bitmap.EndInit();
                        conIcon.Source = bitmap;
                    }));
                };
                connection.ConnectRun();
            }
            catch (Exception)
            {

                MessageBox.Show("Something wrong!");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem != null && comboBox.SelectedItem.ToString().Count() > 0)
            {
                Photos.Category = comboBox.SelectedItem.ToString();
                Photos.Update();
            }
        }
    }
}
