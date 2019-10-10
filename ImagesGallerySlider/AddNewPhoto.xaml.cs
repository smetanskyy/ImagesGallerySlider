using System;
using System.Collections.Generic;
using System.IO;
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
        private int _idCategory;

        private CroppingWindow _croppingWindow;

        public AddNewPhoto(Entities.EFContext db)
        {
            InitializeComponent();
            Topmost = true;
            _idCategory = 0;
            _db = db;
        }

        private void ComboBoxChoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nameOfCategory = comboBoxChoose.SelectedItem.ToString();
            try
            {
                _idCategory = _db.Categories.SingleOrDefault(c => c.NameOfCategory == nameOfCategory).IdCategory;
            }
            catch (Exception)
            {
                _idCategory = 0;
            }
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (_croppingWindow != null)
                return;
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                _croppingWindow = new CroppingWindow(this.Height);
                BitmapImage image = new BitmapImage(new Uri(op.FileName));

                _croppingWindow.Closed += (a, b) => _croppingWindow = null;
                _croppingWindow.Height = image.Height;
                _croppingWindow.Width = image.Width;
                _croppingWindow.SourceImage.Source = image;
                _croppingWindow.SourceImage.Height = image.Height;
                _croppingWindow.SourceImage.Width = image.Width;

                _croppingWindow.Show();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_croppingWindow == null)
                return;

            if (_idCategory == 0)
            {
                MessageBox.Show("You don't choose the category!");
                return;
            }

            BitmapFrame croppedBitmapFrame = _croppingWindow.CroppingAdorner.GetCroppedBitmapFrame();
            
            //create GMP image
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(croppedBitmapFrame);

            _croppingWindow.Close();

            //save image to file
            string namePhoto = Guid.NewGuid().ToString() + ".jpg";
            string path = Environment.CurrentDirectory + "\\images\\" + namePhoto;
            try
            {
                using (FileStream imageFile = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    encoder.Save(imageFile);
                    imageFile.Flush();
                    imageFile.Close();
                }
                Entities.Photo photo = new Entities.Photo()
                {
                    FileName = namePhoto,
                    IdCategory = _idCategory,
                };

                if (textboxCaption != null && textboxCaption.Text.Count() > 0)
                    photo.Сaption = textboxCaption.Text;
                else
                    photo.Сaption = "no info";
                
                _db.Photos.Add(photo);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Something wrong!");
            }
            finally
            {
                this.Close();
            }
        }

        private void BtnCansel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var categories = _db.Categories.AsQueryable();
            foreach (var item in categories)
            {
                comboBoxChoose.Items.Add(item.NameOfCategory);
            }
        }
    }
}
