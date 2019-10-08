using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesGallerySlider.Entities
{
    [Table ("Photos")]
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FileName { get; set; }

        [Required, StringLength(100)]
        public string Сaption { get; set; }

        public int? IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public Category Category { get; set; }
    }
}
