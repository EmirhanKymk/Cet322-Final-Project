using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class NoteModel
    {
        [Required, 
         StringLength(80), 
         Display(Name = "Başlık")]
        public string Title { get; set; }

        [Required, 
         StringLength(250), 
         Display(Name = "Özet")]
        public string Summary { get; set; }

        [Display(Name = "Detay")]
        public string Detail { get; set; }

        [Display(Name = "Taslak")]
        public bool IsDraft { get; set; }

        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
    }
}
