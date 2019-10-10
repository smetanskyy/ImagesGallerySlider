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
using System.Windows.Shapes;
using CroppingImageLibrary;
using Microsoft.Win32;

namespace ImagesGallerySlider
{
    /// <summary>
    /// Interaction logic for AddNewPhoto.xaml
    /// </summary>
    public partial class AddNewPhoto : Window
    {
        private Entities.EFContext _db;
        private int idCategory;
        public CroppingAdorner CroppingAdorner;

        public AddNewPhoto(Entities.EFContext db)
        {
            InitializeComponent();
            idCategory = 0;
            _db = db;
            _db.Photos.Count();
        }

        private void ComboBoxChoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nameOfCategory = comboBoxChoose.SelectedItem.ToString();
            try
            {
                idCategory = _db.Categories.SingleOrDefault(c => c.NameOfCategory == nameOfCategory).IdCategory;
            }
            catch (Exception)
            {
                idCategory = 0;
            }
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                //_croppingWindow.Closed += (a, b) => _croppingWindow = null;
                //_croppingWindow.Height = new BitmapImage(new Uri(op.FileName)).Height;
                //_croppingWindow.Width = new BitmapImage(new Uri(op.FileName)).Width;

                SourceImage.Source = new BitmapImage(new Uri(op.FileName));
                SourceImage.Height = new BitmapImage(new Uri(op.FileName)).Height;
                SourceImage.Width = new BitmapImage(new Uri(op.FileName)).Width;
            }
            // last code
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(CanvasPanel);
            CroppingAdorner = new CroppingAdorner(CanvasPanel);
            adornerLayer.Add(CroppingAdorner);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnCansel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CanvasPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CroppingAdorner.CaptureMouse();
            CroppingAdorner.MouseLeftButtonDownEventHandler(sender, e);
        }
    }
}
