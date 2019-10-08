using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesGallerySlider.Entities
{
    [Table ("Categories")]
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        public string NameOfCategory { get; set; }
    }
}
