using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesGallerySlider.Entities
{
    public class EFContext : DbContext
    {
        public EFContext() : base("connectTo_DB_Gallery") { }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
