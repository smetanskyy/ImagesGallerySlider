using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImagesGallerySlider
{
    public class Photo
    {
        private string _path;
        private Uri _source;
        private BitmapFrame _image;

        public Photo(string path)
        {
            _path = path;
            _source = new Uri(path);

            _image = BitmapFrame.Create(_source);
        }

        public override string ToString()
        {
            return _source.ToString();
        }
        public BitmapFrame Image { get { return _image; } }
    }

    public class PhotoCollection : ObservableCollection<Photo>
    {
        private DirectoryInfo _directory;
        public PhotoCollection() { }

        public PhotoCollection(string path) : this(new DirectoryInfo(path)) { }

        public PhotoCollection(DirectoryInfo directory)
        {
            _directory = directory;
            Update();
        }
        public string Path
        {
            get { return _directory.FullName; }
            set
            {
                _directory = new DirectoryInfo(value);
                Update();
            }
        }

        public DirectoryInfo Directory
        {
            set
            {
                _directory = value;
                Update();
            }
            get { return _directory; }
        }

        private void Update()
        {
            this.Clear();
            try
            {
                foreach (FileInfo f in _directory.GetFiles("*.jpg"))
                {
                    Add(new Photo(f.FullName));
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("No Such Directory");
            }
        }
    }
}