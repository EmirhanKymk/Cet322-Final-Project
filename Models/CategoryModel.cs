using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class CategoryModel
    {
        [Required, StringLength(40), Display(Name = "Kategori Adı")]
        public string Name { get; set; }

        [StringLength(160), Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
