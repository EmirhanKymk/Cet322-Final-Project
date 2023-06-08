using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Common
    {
        [Required, StringLength(50)]
        public string? CreatedUser { get; set; }

        public DateTime? CreatedAt { get; set; }

        [StringLength(50)]
        public string? ModifiedUser { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
